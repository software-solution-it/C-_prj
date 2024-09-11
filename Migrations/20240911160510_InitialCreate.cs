using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LSF.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Geolocation");

            migrationBuilder.DropTable(
                name: "User_Point");

            migrationBuilder.DropTable(
                name: "User_Supplier");

            migrationBuilder.DropTable(
                name: "User_Technician");

            migrationBuilder.DropColumn(
                name: "Comprovante",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SupplierResponsible",
                table: "Supplier");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "FirstAccess",
                table: "Users",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ThreadId",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "SupplierName",
                keyValue: null,
                column: "SupplierName",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "SupplierName",
                table: "Supplier",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Supplier",
                keyColumn: "Phone",
                keyValue: null,
                column: "Phone",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Supplier",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Supplier",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SupplierType",
                table: "Supplier",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Point",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Geolocation",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "BotError",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Visor = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cause = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotError", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FileName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Folder = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FileType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_File", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Mandala",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ChooseLocation = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CloseContract = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PlumbingElectrical = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Drywall = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MDFOptional = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    GlassWall = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Machines = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AutomatedComputers = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CardMachine = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PlatesDispensers = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Chemicals = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BrandRegistrationOptional = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Stickers = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EnvironmentDecoration = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SofaTableBasket = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Facade = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AirConditioning = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Internet = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PaperHolder = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AlcoholSprayer = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ClothesFoldersOptional = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Camera = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AirSensor = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MachineAlarm = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    WifiSocketAdapter = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DoorLock = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    userId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mandala", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Url = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    userId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project_Electric",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    Voltage = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Network = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Electric", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project_File",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    FileId = table.Column<int>(type: "int", nullable: true),
                    ConfirmedReceipt = table.Column<int>(type: "int", nullable: true),
                    ReceiptDeclinedReason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_File", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project_Geolocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    GeolocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Geolocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Geolocation_Geolocation_GeolocationId",
                        column: x => x.GeolocationId,
                        principalTable: "Geolocation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project_Point",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    PointId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Point", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Point_Point_PointId",
                        column: x => x.PointId,
                        principalTable: "Point",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project_Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Supplier_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project_Technician",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Technician", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Technician_Technician_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technician",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SalesReport",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Laundry = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SellDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Interprise = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InterpriseDocument = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Equipment = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Situation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PaymentType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<double>(type: "double", nullable: true),
                    ValueWithNoDiscount = table.Column<double>(type: "double", nullable: true),
                    Provider = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Acquirer = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CardFlag = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CardType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CardNumber = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Authorizer = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Voucher = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VoucherCategory = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cupom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CPFClient = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NameClient = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Requisition = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CupomRequisition = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodeAuthSender = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Error = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ErrorDetail = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesReport", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Supplier_Domain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplierTypeName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier_Domain", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User_Token",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_Id = table.Column<int>(type: "int", nullable: true),
                    ResetToken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Token", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product_Domain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductBrand = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WasherType = table.Column<int>(type: "int", nullable: true),
                    SupplierType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product_Domain", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Domain_Supplier_Domain_SupplierType",
                        column: x => x.SupplierType,
                        principalTable: "Supplier_Domain",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Project_Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    ProjectId = table.Column<int>(type: "int", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: true),
                    SupplierType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_Product_Product_Domain_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product_Domain",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Project_Product_Supplier_Domain_SupplierType",
                        column: x => x.SupplierType,
                        principalTable: "Supplier_Domain",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_SupplierType",
                table: "Supplier",
                column: "SupplierType");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Domain_SupplierType",
                table: "Product_Domain",
                column: "SupplierType");

            migrationBuilder.CreateIndex(
                name: "IX_Project_userId",
                table: "Project",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Geolocation_GeolocationId",
                table: "Project_Geolocation",
                column: "GeolocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Point_PointId",
                table: "Project_Point",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Product_ProductId",
                table: "Project_Product",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Product_SupplierType",
                table: "Project_Product",
                column: "SupplierType");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Supplier_SupplierId",
                table: "Project_Supplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Technician_TechnicianId",
                table: "Project_Technician",
                column: "TechnicianId");

            migrationBuilder.AddForeignKey(
                name: "FK_Supplier_Supplier_Domain_SupplierType",
                table: "Supplier",
                column: "SupplierType",
                principalTable: "Supplier_Domain",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Supplier_Supplier_Domain_SupplierType",
                table: "Supplier");

            migrationBuilder.DropTable(
                name: "BotError");

            migrationBuilder.DropTable(
                name: "File");

            migrationBuilder.DropTable(
                name: "Mandala");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Project_Electric");

            migrationBuilder.DropTable(
                name: "Project_File");

            migrationBuilder.DropTable(
                name: "Project_Geolocation");

            migrationBuilder.DropTable(
                name: "Project_Point");

            migrationBuilder.DropTable(
                name: "Project_Product");

            migrationBuilder.DropTable(
                name: "Project_Supplier");

            migrationBuilder.DropTable(
                name: "Project_Technician");

            migrationBuilder.DropTable(
                name: "SalesReport");

            migrationBuilder.DropTable(
                name: "User_Token");

            migrationBuilder.DropTable(
                name: "Product_Domain");

            migrationBuilder.DropTable(
                name: "Supplier_Domain");

            migrationBuilder.DropIndex(
                name: "IX_Supplier_SupplierType",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FirstAccess",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ThreadId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "SupplierType",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Point");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Geolocation");

            migrationBuilder.AddColumn<byte[]>(
                name: "Comprovante",
                table: "Users",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmailConfirmed",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SupplierName",
                table: "Supplier",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Supplier",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "SupplierResponsible",
                table: "Supplier",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User_Geolocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    GeolocationId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Geolocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Geolocation_Geolocation_GeolocationId",
                        column: x => x.GeolocationId,
                        principalTable: "Geolocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Geolocation_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User_Point",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PointId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Point", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Point_Point_PointId",
                        column: x => x.PointId,
                        principalTable: "Point",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Point_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User_Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Supplier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Supplier_Supplier_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Supplier_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "User_Technician",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Technician", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Technician_Technician_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technician",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Technician_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_User_Geolocation_GeolocationId",
                table: "User_Geolocation",
                column: "GeolocationId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Geolocation_UserId",
                table: "User_Geolocation",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Point_PointId",
                table: "User_Point",
                column: "PointId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Point_UserId",
                table: "User_Point",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Supplier_SupplierId",
                table: "User_Supplier",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Supplier_UserId",
                table: "User_Supplier",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Technician_TechnicianId",
                table: "User_Technician",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Technician_UserId",
                table: "User_Technician",
                column: "UserId");
        }
    }
}
