﻿// <auto-generated />
using System;
using LSF.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LSF.Migrations
{
    [DbContext(typeof(APIDbContext))]
    [Migration("20240911160510_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("LSF.Models.BotError", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Cause")
                        .HasColumnType("longtext");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Visor")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("BotError");
                });

            modelBuilder.Entity("LSF.Models.FileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileName")
                        .HasColumnType("longtext");

                    b.Property<string>("FileType")
                        .HasColumnType("longtext");

                    b.Property<string>("Folder")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("File");
                });

            modelBuilder.Entity("LSF.Models.Geolocation", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("double");

                    b.Property<double?>("Longitude")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Geolocation");
                });

            modelBuilder.Entity("LSF.Models.Mandala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AirConditioning")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("AirSensor")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("AlcoholSprayer")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("AutomatedComputers")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("BrandRegistrationOptional")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Camera")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CardMachine")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Chemicals")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ChooseLocation")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CloseContract")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ClothesFoldersOptional")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("DoorLock")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Drywall")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EnvironmentDecoration")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Facade")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("GlassWall")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Internet")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("MDFOptional")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("MachineAlarm")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Machines")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("PaperHolder")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("PlatesDispensers")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("PlumbingElectrical")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("SofaTableBasket")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Stickers")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("WifiSocketAdapter")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Mandala");
                });

            modelBuilder.Entity("LSF.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Message")
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("LSF.Models.Point", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Length")
                        .HasColumnType("longtext");

                    b.Property<string>("Width")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("LSF.Models.ProductDomain", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ProductBrand")
                        .HasColumnType("longtext");

                    b.Property<string>("ProductName")
                        .HasColumnType("longtext");

                    b.Property<int?>("SupplierType")
                        .HasColumnType("int");

                    b.Property<int?>("WasherType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierType");

                    b.ToTable("Product_Domain");
                });

            modelBuilder.Entity("LSF.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<bool?>("Status")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("LSF.Models.ProjectElectric", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Network")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Voltage")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Project_Electric");
                });

            modelBuilder.Entity("LSF.Models.ProjectFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ConfirmedReceipt")
                        .HasColumnType("int");

                    b.Property<int?>("FileId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("ReceiptDeclinedReason")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Project_File");
                });

            modelBuilder.Entity("LSF.Models.ProjectGeolocation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GeolocationId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GeolocationId");

                    b.ToTable("Project_Geolocation");
                });

            modelBuilder.Entity("LSF.Models.ProjectPoint", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("PointId")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.ToTable("Project_Point");
                });

            modelBuilder.Entity("LSF.Models.ProjectProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("SupplierType");

                    b.ToTable("Project_Product");
                });

            modelBuilder.Entity("LSF.Models.ProjectSupplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierId");

                    b.ToTable("Project_Supplier");
                });

            modelBuilder.Entity("LSF.Models.ProjectTechnician", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("TechnicianId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Project_Technician");
                });

            modelBuilder.Entity("LSF.Models.Role", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Manager"
                        });
                });

            modelBuilder.Entity("LSF.Models.SalesReport", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Acquirer")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Authorizer")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CPFClient")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CardFlag")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CardNumber")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CardType")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CodeAuthSender")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Cupom")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CupomRequisition")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Equipment")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Error")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ErrorDetail")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Interprise")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("InterpriseDocument")
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Laundry")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("NameClient")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PaymentType")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Provider")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Requisition")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("SellDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool?>("Situation")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<double?>("Value")
                        .HasColumnType("double");

                    b.Property<double?>("ValueWithNoDiscount")
                        .HasColumnType("double");

                    b.Property<string>("Voucher")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("VoucherCategory")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SalesReport");
                });

            modelBuilder.Entity("LSF.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SupplierName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("SupplierType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupplierType");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("LSF.Models.SupplierDomain", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("SupplierTypeName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Supplier_Domain");
                });

            modelBuilder.Entity("LSF.Models.Technician", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int?>("Id"));

                    b.Property<bool?>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("City")
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Technician");
                });

            modelBuilder.Entity("LSF.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool?>("FirstAccess")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.Property<int?>("RecoveryCode")
                        .HasColumnType("int");

                    b.Property<string>("ThreadId")
                        .HasColumnType("longtext");

                    b.Property<byte[]>("UserImage")
                        .HasColumnType("longblob");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("LSF.Models.UserRole", b =>
                {
                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("LSF.Models.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ResetToken")
                        .HasColumnType("longtext");

                    b.Property<int?>("User_Id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User_Token");
                });

            modelBuilder.Entity("LSF.Models.ProductDomain", b =>
                {
                    b.HasOne("LSF.Models.SupplierDomain", "SupplierDomain")
                        .WithMany()
                        .HasForeignKey("SupplierType");

                    b.Navigation("SupplierDomain");
                });

            modelBuilder.Entity("LSF.Models.Project", b =>
                {
                    b.HasOne("LSF.Models.User", null)
                        .WithMany("Projects")
                        .HasForeignKey("userId");
                });

            modelBuilder.Entity("LSF.Models.ProjectGeolocation", b =>
                {
                    b.HasOne("LSF.Models.Geolocation", "Geolocation")
                        .WithMany()
                        .HasForeignKey("GeolocationId");

                    b.Navigation("Geolocation");
                });

            modelBuilder.Entity("LSF.Models.ProjectPoint", b =>
                {
                    b.HasOne("LSF.Models.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId");

                    b.Navigation("Point");
                });

            modelBuilder.Entity("LSF.Models.ProjectProduct", b =>
                {
                    b.HasOne("LSF.Models.ProductDomain", "ProductDomain")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("LSF.Models.SupplierDomain", "SupplierDomain")
                        .WithMany()
                        .HasForeignKey("SupplierType");

                    b.Navigation("ProductDomain");

                    b.Navigation("SupplierDomain");
                });

            modelBuilder.Entity("LSF.Models.ProjectSupplier", b =>
                {
                    b.HasOne("LSF.Models.Supplier", "Supplier")
                        .WithMany()
                        .HasForeignKey("SupplierId");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("LSF.Models.ProjectTechnician", b =>
                {
                    b.HasOne("LSF.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId");

                    b.Navigation("Technician");
                });

            modelBuilder.Entity("LSF.Models.Supplier", b =>
                {
                    b.HasOne("LSF.Models.SupplierDomain", "SupplierDomain")
                        .WithMany()
                        .HasForeignKey("SupplierType");

                    b.Navigation("SupplierDomain");
                });

            modelBuilder.Entity("LSF.Models.UserRole", b =>
                {
                    b.HasOne("LSF.Models.Role", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LSF.Models.User", null)
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LSF.Models.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("LSF.Models.User", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
