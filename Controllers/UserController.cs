﻿using LSF.Data;
using LSF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using TokenResponse = LSF.Models.TokenResponse;
using System.Net.Mail;
using System.Net;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Security.Cryptography;
using PurchaseObjects;


namespace LSF.Controllers
{
    [Route("user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly APIDbContext _dbContext;
        private readonly IConfiguration _config;
        private Random _random = new Random();
        private static readonly RandomNumberGenerator _rng = RandomNumberGenerator.Create();

        public UserController(APIDbContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);


            var user = await (
                from u in _dbContext.Users
                join ur in _dbContext.UserRoles on u.Id equals ur.UserId
                join r in _dbContext.Roles on ur.RoleId equals r.Id
                where u.Email == email
                select new { User = u, Role = r }
            ).FirstOrDefaultAsync();

            if (user == null) return Unauthorized("Usuário não encontrado");

            if (!VerifyPassword(password, user.User.Password)) return Unauthorized("Senha incorreta");


            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("userId", user.User.Id.ToString()),
                new Claim("role", user.Role.Id.ToString()),
                new Claim("userName", user.User.UserName),
                new Claim("fa", user.User.FirstAccess.ToString()),
                new Claim("active", user.User.isActive.ToString())
            };

            var accessToken = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var accessTokenString = new JwtSecurityTokenHandler().WriteToken(accessToken);

            var refreshToken = GenerateRefreshToken();

            var tokenResponse = new TokenResponse(accessTokenString, refreshToken);

            return Ok(tokenResponse);
        }

        static bool VerifyPassword(string password, string storedHash)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string hashedPassword = HashPassword(password);
                return hashedPassword == storedHash;
            }
        }

        static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = System.Security.Cryptography.RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserModel model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);

                if (!IsPasswordValidate(model.Password!)) return BadRequest(ModelState);

                var hashedPassword = HashPassword(model.Password);

                var newUser = new User
                {
                    Name = model.Name,
                    UserName = model.UserName,
                    Phone = model.Phone,
                    Email = model.Email,
                    Password = hashedPassword,
                };

                var result = await _dbContext.Users.AddAsync(newUser);
                await _dbContext.SaveChangesAsync();

                var userRole = new UserRole
                {
                    UserId = newUser.Id,
                    RoleId = 2
                };

                await _dbContext.UserRoles.AddAsync(userRole);
                await _dbContext.SaveChangesAsync();

                return Ok("Usuário registrado com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro durante o processamento da solicitação. {ex}");
            }
        }

        private static int RandomNumber(int maxValue)
        {
            byte[] randomNumber = new byte[1];
            _rng.GetBytes(randomNumber);
            double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
            double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            int range = maxValue - 1;
            double randomValueInRange = Math.Floor(multiplier * range + 0.5d);
            return Convert.ToInt32(randomValueInRange);
        }

        private static void Shuffle<T>(T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = RandomNumber(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
        [HttpPost("Customer")]
        [Authorize]
        public async Task<IActionResult> Customer()
        {
            try
            {
                var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
                if (userIdClaim == null)
                {
                    return BadRequest("Claim 'userId' não encontrada.");
                }

                if (!int.TryParse(userIdClaim.Value, out int userId))
                {
                    return BadRequest("O ID do usuário é inválido.");
                }

                // Consulta para obter o usuário
                var user = await _dbContext.Users
                    .Where(u => u.Id == userId)
                    .Select(u => new
                    {
                        u.Id,
                        u.Name,
                        u.Email,
                        u.CreatedAt
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    return NotFound("User not found.");
                }
                var projects = await (from p in _dbContext.Project
                                      where p.userId == userId
                                      select new
                                      {
                                          p.Id,
                                          p.Name,
                                          Geolocation = (from pg in _dbContext.Project_Geolocation
                                                         join g in _dbContext.Geolocation on pg.GeolocationId equals g.Id
                                                         where pg.ProjectId == p.Id
                                                         select g).FirstOrDefault(),
                                          Point = (from pp in _dbContext.Project_Point
                                                   join pt in _dbContext.Point on pp.PointId equals pt.Id
                                                   where pp.ProjectId == p.Id
                                                   select pt).FirstOrDefault(),
                                          Suppliers = (from ps in _dbContext.Project_Supplier
                                                       join s in _dbContext.Supplier on ps.SupplierId equals s.Id
                                                       where ps.ProjectId == p.Id
                                                       select s).ToList(),
                                          Technician = (from ptc in _dbContext.Project_Technician
                                                        join t in _dbContext.Technician on ptc.TechnicianId equals t.Id
                                                        where ptc.ProjectId == p.Id
                                                        select t).FirstOrDefault(),
                                          Electric = (from e in _dbContext.Project_Electric
                                                      where e.ProjectId == p.Id
                                                      select e).FirstOrDefault(),
                                          ProjectFiles = new
                                          {
                                              ConfirmedReceipt = (from pf in _dbContext.Project_File
                                                                  where pf.ProjectId == p.Id
                                                                  select pf.ConfirmedReceipt).FirstOrDefault(),
                                              ReceiptDeclinedReason = (from pf in _dbContext.Project_File
                                                                       where pf.ProjectId == p.Id
                                                                       select pf.ReceiptDeclinedReason).FirstOrDefault(),
                                              Recipe = (from pf in _dbContext.Project_File
                                                        join f in _dbContext.FileModel on pf.FileId equals f.Id
                                                        where pf.ProjectId == p.Id && f.FileType == "Recipe"
                                                        select f).FirstOrDefault(),
                                              HydraulicModel = (from pf in _dbContext.Project_File
                                                                join fh in _dbContext.FileModel on pf.FileId equals fh.Id
                                                                where pf.ProjectId == p.Id && fh.FileType == "HydraulicModel"
                                                                select fh).FirstOrDefault(),
                                              ElectricModel = (from pf in _dbContext.Project_File
                                                               join fe in _dbContext.FileModel on pf.FileId equals fe.Id
                                                               where pf.ProjectId == p.Id && fe.FileType == "ElectricModel"
                                                               select fe).FirstOrDefault(),
                                              SketchModel = (from pf in _dbContext.Project_File
                                                             join fs in _dbContext.FileModel on pf.FileId equals fs.Id
                                                             where pf.ProjectId == p.Id && fs.FileType == "SketchModel"
                                                             select fs).FirstOrDefault() 
                                          }
                                      }).ToListAsync();



                var result = new
                {
                    User = new
                    {
                        user.Id,
                        user.Name,
                        user.Email,
                        user.CreatedAt,
                        Projects = projects
                    }
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro durante o processamento da solicitação. {ex.Message}");
            }
        }

        public static bool IsPasswordValidate(string senha)
        {
            if (senha.Length < 8) return false;
            if (!senha.Any(char.IsUpper)) return false;
            if (!senha.Any(char.IsDigit)) return false;
            if (!Regex.IsMatch(senha, @"[!@#$%^&*()_+=\[{\]};:<>|./?,-]")) return false;

            return true;
        }

        [HttpPost("ResetPassword")]
        public async Task<ActionResult> ResetPassword(string Email)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == Email);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            var verificationCode = GerarCodigoVerificacao();

            user.RecoveryCode = verificationCode;
            await _dbContext.SaveChangesAsync();

            var timer = new Timer(async (state) =>
            {
                await RemoverCodigoDoBancoAsync(user);
            }, null, TimeSpan.FromHours(1), TimeSpan.Zero);

            var emailContent = $"Seu código de verificação é: {verificationCode}";
            var emailSubject = "Confirmação de Email";

            var result = await SendEmailAsync(user.Email, emailSubject, emailContent);

            if (!result)
            {
                return BadRequest("Falha ao enviar email de confirmação.");
            }

            return Ok("Reset password enviado com sucesso.");
        }

        private int GerarCodigoVerificacao()
        {
            var random = new Random();
            return random.Next(100000, 999999);
        }

        private async Task RemoverCodigoDoBancoAsync(User user)
        {
            if (user != null)
            {
                user.RecoveryCode = null;
                await _dbContext.SaveChangesAsync();
            }
        }

        private async Task<bool> SendEmailAsync(string emailDestinatário, string emailSubject, string emailContent)
        {
            string remetenteEmail = "suporte@faculdadedalavanderia.com.br";
            string remetenteSenha = "Lavanderiaprojeto#1";
            string destinatarioEmail = emailDestinatário;
            string smtpServidor = "smtp.hostinger.com";
            int porta = 587;

            try
            {
                using (SmtpClient smtp = new SmtpClient(smtpServidor, porta))
                {
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(remetenteEmail, remetenteSenha);
                    using (MailMessage mensagem = new MailMessage(new MailAddress(remetenteEmail, "Contato"), new MailAddress(destinatarioEmail)))
                    {
                        mensagem.Subject = emailSubject;
                        mensagem.Body = emailContent;

                        await smtp.SendMailAsync(mensagem);
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost("ConfirmCode")]
        public async Task<bool> ConfirmCode(string Email, int code)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == Email);

            if (user == null) return false;

            if (user.RecoveryCode != code)
            {
                return false;
            }

            return true;
        }

        [HttpPost("UserProduct")]
        public async Task<bool> UserProduct(ProjectProduct product)
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);

            var result = new ProjectProduct
            {
                Quantity = product.Quantity,
                ProjectId = product.ProjectId,
                ProductId = product.ProductId,
                SupplierType = product.SupplierType
            };

            _dbContext.Project_Product.Add(result);

            await _dbContext.SaveChangesAsync();

            return true;
        }

        [HttpGet("UserProduct")]
        [Authorize]
        public async Task<ProjectProduct> GetUserProduct(int projectId)
        {

            var product = await _dbContext.Project_Product
           .FirstOrDefaultAsync(u => u.ProjectId == projectId && u.SupplierType == 1);

            return product;
        }

        [HttpPut("NewPassword")]
        [Authorize]
        public async Task<ActionResult> NewPassword(string password)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            var userNameClaim = User.Claims.FirstOrDefault(c => c.Type == "userName");

            if (userIdClaim == null || userNameClaim == null)
            {
                return BadRequest("Claims 'userId' ou 'userName' não encontradas.");
            }

            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                return BadRequest("O ID do usuário é inválido.");
            }

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == userId && u.UserName == userNameClaim.Value);

            if (user == null)
            {
                return BadRequest("Usuário não encontrado.");
            }

            if (!IsPasswordValidate(password))
            {
                return BadRequest("Senha inválida.");
            }
            user.FirstAccess = false;
            user.Password = HashPassword(password);
            await _dbContext.SaveChangesAsync();

            return Ok("Senha atualizada com sucesso.");
        }


        [HttpPut("FirstAccess")]
        [Authorize]
        public async Task<ActionResult> FirstAccess(UserModelRegister model)
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "userId");
            if (userIdClaim == null)
            {
                return BadRequest("Claim 'userId' não encontrada.");
            }

            if (!int.TryParse(userIdClaim.Value, out int userId))
            {
                return BadRequest("O ID do usuário é inválido.");
            }

            var user = await _dbContext.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            if (!IsPasswordValidate(model.Password))
            {
                return BadRequest("Senha inválida.");
            }

            // Atualizar a senha do usuário
            user.Password = HashPassword(model.Password);
            await _dbContext.SaveChangesAsync();

            return Ok("Senha atualizada com sucesso.");
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _dbContext.Users
                    .Select(u => new
                    {
                        u.Id,
                        u.Name,
                        u.Email,
                        u.CreatedAt,
                        Projects = (from p in _dbContext.Project
                                    where p.userId == u.Id
                                    select new
                                    {
                                        p.Id,
                                        p.Name,
                                        Geolocation = (from pg in _dbContext.Project_Geolocation
                                                       join g in _dbContext.Geolocation on pg.GeolocationId equals g.Id
                                                       where pg.ProjectId == p.Id
                                                       select g).FirstOrDefault(),
                                        Point = (from pp in _dbContext.Project_Point
                                                 join pt in _dbContext.Point on pp.PointId equals pt.Id
                                                 where pp.ProjectId == p.Id
                                                 select pt).FirstOrDefault(),
                                        Suppliers = (from ps in _dbContext.Project_Supplier
                                                     join s in _dbContext.Supplier on ps.SupplierId equals s.Id
                                                     where ps.ProjectId == p.Id
                                                     select s).ToList(),
                                        Technician = (from ptc in _dbContext.Project_Technician
                                                      join t in _dbContext.Technician on ptc.TechnicianId equals t.Id
                                                      where ptc.ProjectId == p.Id
                                                      select t).FirstOrDefault(),
                                        Electric = (from e in _dbContext.Project_Electric
                                                    where e.ProjectId == p.Id
                                                    select e).FirstOrDefault(),
                                        ProjectFiles = new
                                        {
                                            ConfirmedReceipt = (from pf in _dbContext.Project_File
                                                                where pf.ProjectId == p.Id
                                                                select pf.ConfirmedReceipt).FirstOrDefault(),
                                            ReceiptDeclinedReason = (from pf in _dbContext.Project_File
                                                                     where pf.ProjectId == p.Id
                                                                     select pf.ReceiptDeclinedReason).FirstOrDefault(),
                                            Recipe = (from pf in _dbContext.Project_File
                                                      join f in _dbContext.FileModel on pf.FileId equals f.Id
                                                      where pf.ProjectId == p.Id && f.FileType == "Recipe"
                                                      select f).FirstOrDefault(),
                                            HydraulicModel = (from pf in _dbContext.Project_File
                                                              join fh in _dbContext.FileModel on pf.FileId equals fh.Id
                                                              where pf.ProjectId == p.Id && fh.FileType == "HydraulicModel"
                                                              select fh).FirstOrDefault(),
                                            ElectricModel = (from pf in _dbContext.Project_File
                                                             join fe in _dbContext.FileModel on pf.FileId equals fe.Id
                                                             where pf.ProjectId == p.Id && fe.FileType == "ElectricModel"
                                                             select fe).FirstOrDefault(),
                                            SketchModel = (from pf in _dbContext.Project_File
                                                           join fs in _dbContext.FileModel on pf.FileId equals fs.Id
                                                           where pf.ProjectId == p.Id && fs.FileType == "SketchModel"
                                                           select fs).FirstOrDefault()
                                        }
                                    }).ToList()
                    })
                    .ToListAsync();

                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro durante o processamento da solicitação. {ex.Message}");
            }
        }

        [HttpPut("Put/{id}")]
        public async Task<IActionResult> Put(int id, UserModel updatedUser)
        {
            var existingUser = await _dbContext.Users.FindAsync(id);

            if (existingUser == null)
                return NotFound("Usuário não encontrado");

            // Atualize apenas os campos que não são nulos ou vazios
            if (!string.IsNullOrEmpty(updatedUser.Email))
            {
                existingUser.Email = updatedUser.Email;
            }

            if (!string.IsNullOrEmpty(updatedUser.Name))
            {
                existingUser.Name = updatedUser.Name;
            }

            if (!string.IsNullOrEmpty(updatedUser.UserName))
            {
                existingUser.UserName = updatedUser.UserName;
            }

            if (!string.IsNullOrEmpty(updatedUser.Phone))
            {
                existingUser.Phone = updatedUser.Phone;
            }

            if (!string.IsNullOrEmpty(updatedUser.Password))
            {
                if (!IsPasswordValidate(updatedUser.Password))
                {
                    return BadRequest("Senha inválida.");
                }
                existingUser.Password = HashPassword(updatedUser.Password); // Criptografa a senha antes de salvar
            }

            await _dbContext.SaveChangesAsync();

            var updatedUserData = new
            {
                existingUser.Id,
                existingUser.Name,
                existingUser.UserName,
                existingUser.Phone,
                existingUser.Email,
                existingUser.Password,
                existingUser.UserImage,
            };

            return Ok(updatedUserData);
        }

        [HttpPut("UpdateUserAndAddRole")]
        [Authorize]
        public async Task<IActionResult> UpdateUserAndAddRole(int roleId)
        {
            var userId = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value);
            var user = await _dbContext.Users.FirstOrDefaultAsync(uid => uid.Id == userId);
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            var role = await _dbContext.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
            if (role == null)
            {
                return NotFound("Role não encontrada");
            }

            var rolesToDelete = await _dbContext.UserRoles
            .Where(ur => ur.UserId == userId && ur.RoleId != roleId)
            .ToListAsync();

            _dbContext.UserRoles.RemoveRange(rolesToDelete);
            await _dbContext.SaveChangesAsync();


            var existingUserRole = await _dbContext.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);
            if (existingUserRole != null)
            {
                return BadRequest("O usuário já possui esta role");
            }

            var userRole = new UserRole
            {
                UserId = userId,
                RoleId = role.Id
            };

            user.UserRoles.Add(userRole);

            await _dbContext.SaveChangesAsync();

            return Ok("Usuário atualizado e role adicionada com sucesso");
        }
        [HttpDelete("Delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("Usuário não encontrado");
            }

            try
            {
                var userRoles = _dbContext.UserRoles.Where(ur => ur.UserId == id);
                _dbContext.UserRoles.RemoveRange(userRoles);
                await _dbContext.SaveChangesAsync();

                var projects = await _dbContext.Project.Where(p => p.userId == id).ToListAsync();

                foreach (var project in projects)
                {
                    _dbContext.Project_Geolocation.RemoveRange(_dbContext.Project_Geolocation.Where(pg => pg.ProjectId == project.Id));
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Project_Point.RemoveRange(_dbContext.Project_Point.Where(pp => pp.ProjectId == project.Id));
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Project_Product.RemoveRange(_dbContext.Project_Product.Where(pp => pp.ProjectId == project.Id));
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Project_Supplier.RemoveRange(_dbContext.Project_Supplier.Where(ps => ps.ProjectId == project.Id));
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Project_Technician.RemoveRange(_dbContext.Project_Technician.Where(pt => pt.ProjectId == project.Id));
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Project_Electric.RemoveRange(_dbContext.Project_Electric.Where(pe => pe.ProjectId == project.Id));
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Project_File.RemoveRange(_dbContext.Project_File.Where(pf => pf.ProjectId == project.Id));
                    await _dbContext.SaveChangesAsync();

                    _dbContext.Project.Remove(project);
                    await _dbContext.SaveChangesAsync();
                }

                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
        [HttpGet("Profile/wGetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _dbContext.Users
                                        .Where(u => u.Id == id)
                                        .Select(u => new
                                        {
                                            u.Id,
                                            u.Name,
                                            u.UserName,
                                            u.Phone,
                                            u.Email,
                                            u.UserImage
                                        })
                                        .FirstOrDefaultAsync();

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user);
        }

    }
}