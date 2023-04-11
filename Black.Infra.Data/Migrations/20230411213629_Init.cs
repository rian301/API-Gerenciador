using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Black.Infra.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    DatePurchase = table.Column<DateTime>(type: "date", nullable: true),
                    Requester = table.Column<string>(nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", maxLength: 8, nullable: false),
                    Signature = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Responsible = table.Column<string>(nullable: false),
                    DateCanceled = table.Column<DateTime>(type: "date", nullable: true),
                    MotiveCancel = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssetsCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssetsCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    LinkClass = table.Column<string>(maxLength: 255, nullable: true),
                    LinkInfo = table.Column<string>(maxLength: 255, nullable: true),
                    LinkCopy = table.Column<string>(maxLength: 255, nullable: true),
                    LinkCreative = table.Column<string>(maxLength: 255, nullable: true),
                    LinkTraffic = table.Column<string>(maxLength: 255, nullable: true),
                    LinkRegister = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: false),
                    RG = table.Column<string>(maxLength: 20, nullable: true),
                    Document = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 100, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: true),
                    Street = table.Column<string>(maxLength: 200, nullable: true),
                    Number = table.Column<string>(maxLength: 20, nullable: true),
                    Complement = table.Column<string>(maxLength: 200, nullable: true),
                    District = table.Column<string>(maxLength: 70, nullable: true),
                    City = table.Column<string>(maxLength: 70, nullable: true),
                    Country = table.Column<string>(maxLength: 70, nullable: true),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    ImportCode = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    RG = table.Column<string>(maxLength: 20, nullable: true),
                    CNPJ = table.Column<string>(maxLength: 14, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "date", nullable: true),
                    DemissionDate = table.Column<DateTime>(maxLength: 100, nullable: true),
                    Function = table.Column<string>(maxLength: 100, nullable: true),
                    MonthlyHour = table.Column<string>(maxLength: 20, nullable: true),
                    WorkSchedule = table.Column<string>(nullable: true),
                    Gender = table.Column<int>(maxLength: 100, nullable: true),
                    PIS = table.Column<string>(maxLength: 100, nullable: true),
                    Mom = table.Column<string>(maxLength: 100, nullable: true),
                    Father = table.Column<string>(maxLength: 100, nullable: true),
                    Schooling = table.Column<string>(maxLength: 100, nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Agency = table.Column<string>(maxLength: 20, nullable: true),
                    Acount = table.Column<string>(maxLength: 20, nullable: true),
                    Pix = table.Column<string>(maxLength: 40, nullable: true),
                    VoterTitle = table.Column<string>(maxLength: 20, nullable: true),
                    ReservistCertificate = table.Column<string>(maxLength: 20, nullable: true),
                    Wage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Benefit = table.Column<string>(maxLength: 20, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 20, nullable: true),
                    Street = table.Column<string>(maxLength: 200, nullable: true),
                    Number = table.Column<string>(maxLength: 20, nullable: true),
                    Complement = table.Column<string>(maxLength: 100, nullable: true),
                    District = table.Column<string>(maxLength: 100, nullable: true),
                    City = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    State = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<int>(maxLength: 100, nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gift",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    DateIncluse = table.Column<DateTime>(type: "date", nullable: true),
                    Responsible = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Entrance = table.Column<int>(nullable: true),
                    Exit = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gift", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Launch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    QuantityStudents = table.Column<int>(maxLength: 4, nullable: false),
                    Invoice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 8, nullable: false),
                    Investment = table.Column<decimal>(type: "decimal(18,2)", maxLength: 8, nullable: false),
                    TopCriative = table.Column<string>(maxLength: 100, nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Launch", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogAudit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CascadeMode = table.Column<int>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true),
                    LogType = table.Column<int>(nullable: false),
                    TableName = table.Column<string>(nullable: true),
                    KeyValues = table.Column<string>(nullable: true),
                    OldValues = table.Column<string>(nullable: true),
                    NewValues = table.Column<string>(nullable: true),
                    ChangedColumns = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogAudit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogErro",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CascadeMode = table.Column<int>(nullable: false),
                    LogDate = table.Column<DateTime>(nullable: false),
                    System = table.Column<int>(nullable: false),
                    Class = table.Column<string>(nullable: true),
                    Context = table.Column<string>(nullable: true),
                    Request = table.Column<string>(nullable: true),
                    Error = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogErro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoginRefreshToken",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CascadeMode = table.Column<int>(nullable: false),
                    IdUser = table.Column<int>(nullable: false),
                    Token = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginRefreshToken", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mentored",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Email = table.Column<string>(maxLength: 255, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    RG = table.Column<string>(maxLength: 20, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 14, nullable: true),
                    Street = table.Column<string>(maxLength: 200, nullable: true),
                    District = table.Column<string>(maxLength: 70, nullable: true),
                    City = table.Column<string>(maxLength: 70, nullable: true),
                    Country = table.Column<string>(maxLength: 70, nullable: true),
                    State = table.Column<string>(maxLength: 2, nullable: true),
                    ZipCode = table.Column<string>(maxLength: 80, nullable: true),
                    Complement = table.Column<string>(maxLength: 200, nullable: true),
                    Number = table.Column<int>(maxLength: 20, nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    IsPartner = table.Column<bool>(nullable: false),
                    Off = table.Column<string>(maxLength: 1000, nullable: true),
                    Deleted = table.Column<int>(maxLength: 1, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentored", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pendency",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    IncludDate = table.Column<DateTime>(type: "date", nullable: true),
                    Requester = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Responsible = table.Column<string>(nullable: true),
                    ResolveDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pendency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConstPermission = table.Column<string>(maxLength: 100, nullable: false),
                    Name = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    TimeAccess = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provider",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Document = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Agency = table.Column<string>(nullable: true),
                    Acount = table.Column<string>(nullable: true),
                    Pix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    UserProfileId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerLaunch",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Nicho = table.Column<string>(maxLength: 255, nullable: false),
                    Invoice = table.Column<decimal>(type: "decimal(18,2)", maxLength: 8, nullable: false),
                    Instagram = table.Column<string>(maxLength: 255, nullable: false),
                    Testimonial = table.Column<string>(maxLength: 255, nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerLaunch", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerLaunch_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    PaymentMethodId = table.Column<int>(nullable: false),
                    SignatureDate = table.Column<DateTime>(type: "date", nullable: true),
                    CancelDate = table.Column<DateTime>(type: "date", nullable: true),
                    Installments = table.Column<int>(nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerPayment_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Container = table.Column<string>(maxLength: 50, nullable: true),
                    TypeDoc = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDoc_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    GiftId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Container = table.Column<string>(maxLength: 50, nullable: true),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TypeDoc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GiftDoc_Gift_GiftId",
                        column: x => x.GiftId,
                        principalTable: "Gift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Award",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    MentoredId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Award", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Award_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Award_Mentored_MentoredId",
                        column: x => x.MentoredId,
                        principalTable: "Mentored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MentoredCompany",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    CompanyName = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Instagram = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    SubscriptionDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    MentoredId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentoredCompany", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentoredCompany_Mentored_MentoredId",
                        column: x => x.MentoredId,
                        principalTable: "Mentored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Partner",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CascadeMode = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    MentoredId = table.Column<int>(nullable: false),
                    MentoredPartnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partner_Mentored_MentoredId",
                        column: x => x.MentoredId,
                        principalTable: "Mentored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PendencyDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    PendencyId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Container = table.Column<string>(maxLength: 50, nullable: true),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TypeDoc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PendencyDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PendencyDoc_Pendency_PendencyId",
                        column: x => x.PendencyId,
                        principalTable: "Pendency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DatePurchase = table.Column<DateTime>(type: "date", nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    DatePayment = table.Column<DateTime>(nullable: true),
                    DateSchedulingPayment = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Document = table.Column<string>(nullable: true),
                    Bank = table.Column<string>(nullable: true),
                    Agency = table.Column<string>(nullable: true),
                    Acount = table.Column<string>(nullable: true),
                    Pix = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Deleted = table.Column<int>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyPayment_ExpenseCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ExpenseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DailyPayment_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseControl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: false),
                    ProviderId = table.Column<int>(nullable: false),
                    ExpenseCategoryId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Value = table.Column<decimal>(type: "decimal(18,2)", maxLength: 8, nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    Deleted = table.Column<int>(maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseControl_ExpenseCategory_ExpenseCategoryId",
                        column: x => x.ExpenseCategoryId,
                        principalTable: "ExpenseCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpenseControl_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Patrimony",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Tag = table.Column<string>(nullable: true),
                    Brand = table.Column<string>(nullable: true),
                    Nf = table.Column<string>(nullable: true),
                    NumberSerie = table.Column<string>(nullable: true),
                    PurchaseDate = table.Column<DateTime>(type: "date", nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Note = table.Column<string>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true),
                    AssetsCategoryId = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimony", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimony_AssetsCategory_AssetsCategoryId",
                        column: x => x.AssetsCategoryId,
                        principalTable: "AssetsCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Patrimony_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseControl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    RequestName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Tracking = table.Column<string>(nullable: true),
                    Responsible = table.Column<int>(nullable: true),
                    DateLimit = table.Column<DateTime>(type: "date", nullable: true),
                    DateSolicitation = table.Column<DateTime>(type: "date", nullable: true),
                    DatePurchase = table.Column<DateTime>(type: "date", nullable: true),
                    DateDelivery = table.Column<DateTime>(type: "date", nullable: true),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PaymentMethodId = table.Column<int>(nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    ProviderId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseControl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseControl_Provider_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Provider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfilePermission",
                columns: table => new
                {
                    UserProfileId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfilePermission", x => new { x.UserProfileId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserProfilePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProfilePermission_UserProfile_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    DateSend = table.Column<DateTime>(type: "date", nullable: false),
                    DateReceiving = table.Column<DateTime>(type: "date", nullable: true),
                    DateDevolution = table.Column<DateTime>(nullable: true),
                    DateResend = table.Column<DateTime>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    AwardId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAward_Award_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Award",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAward_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MentoredAward",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    DateSend = table.Column<DateTime>(type: "date", nullable: false),
                    DateReceiving = table.Column<DateTime>(type: "date", nullable: true),
                    Note = table.Column<string>(maxLength: 1000, nullable: true),
                    AwardId = table.Column<int>(nullable: false),
                    MentoredId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentoredAward", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentoredAward_Award_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Award",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MentoredAward_Mentored_MentoredId",
                        column: x => x.MentoredId,
                        principalTable: "Mentored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CascadeMode = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    AwardId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: true),
                    MentoredId = table.Column<int>(nullable: true),
                    DateRequest = table.Column<DateTime>(type: "date", nullable: true),
                    DateSend = table.Column<DateTime>(type: "date", nullable: true),
                    DateReceiving = table.Column<DateTime>(type: "date", nullable: true),
                    Requester = table.Column<string>(nullable: true),
                    Campaign = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    ZipCode = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    Complement = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sent_Award_AwardId",
                        column: x => x.AwardId,
                        principalTable: "Award",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sent_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Sent_Mentored_MentoredId",
                        column: x => x.MentoredId,
                        principalTable: "Mentored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MentoredDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    MentoredId = table.Column<int>(nullable: false),
                    MentoredCompanyId = table.Column<int>(nullable: true),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Container = table.Column<string>(maxLength: 50, nullable: true),
                    TypeDoc = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentoredDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentoredDoc_MentoredCompany_MentoredCompanyId",
                        column: x => x.MentoredCompanyId,
                        principalTable: "MentoredCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MentoredDoc_Mentored_MentoredId",
                        column: x => x.MentoredId,
                        principalTable: "Mentored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MentoredPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    MentoredId = table.Column<int>(nullable: false),
                    MentoredCompanyId = table.Column<int>(nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "date", nullable: true),
                    SubscriptionEndDate = table.Column<DateTime>(type: "date", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    DueDate = table.Column<DateTime>(type: "date", nullable: true),
                    InitialAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethodId = table.Column<int>(nullable: false),
                    Installments = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentoredPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MentoredPayment_MentoredCompany_MentoredCompanyId",
                        column: x => x.MentoredCompanyId,
                        principalTable: "MentoredCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MentoredPayment_Mentored_MentoredId",
                        column: x => x.MentoredId,
                        principalTable: "Mentored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    MentoredCompanyId = table.Column<int>(nullable: true),
                    MentoredId = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    CanceledDate = table.Column<DateTime>(nullable: true),
                    SubscriptionDate = table.Column<DateTime>(type: "date", nullable: true),
                    EndSubscriptionDate = table.Column<DateTime>(type: "date", nullable: true),
                    CurrentPeriodId = table.Column<int>(nullable: true),
                    MotiveCanceled = table.Column<string>(maxLength: 1000, nullable: true),
                    OverdueSince = table.Column<DateTime>(type: "date", nullable: true),
                    RequestCancelDate = table.Column<DateTime>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    RequestCancelMotive = table.Column<string>(maxLength: 1000, nullable: true),
                    InitialAmount = table.Column<decimal>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    DiscountAmount = table.Column<decimal>(nullable: false),
                    Installments = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_MentoredCompany_MentoredCompanyId",
                        column: x => x.MentoredCompanyId,
                        principalTable: "MentoredCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscription_Mentored_MentoredId",
                        column: x => x.MentoredId,
                        principalTable: "Mentored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subscription_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DailyPaymentDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    DailyPaymentId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Container = table.Column<string>(maxLength: 50, nullable: true),
                    TypeDoc = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyPaymentDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyPaymentDoc_DailyPayment_DailyPaymentId",
                        column: x => x.DailyPaymentId,
                        principalTable: "DailyPayment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseControlDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    ExpenseControlId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Container = table.Column<string>(maxLength: 50, nullable: true),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    Active = table.Column<bool>(nullable: false),
                    TypeDoc = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseControlDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpenseControlDoc_ExpenseControl_ExpenseControlId",
                        column: x => x.ExpenseControlId,
                        principalTable: "ExpenseControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PatrimonyDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    PatrimonyId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Container = table.Column<string>(maxLength: 50, nullable: true),
                    TypeDoc = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatrimonyDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatrimonyDoc_Patrimony_PatrimonyId",
                        column: x => x.PatrimonyId,
                        principalTable: "Patrimony",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseControlDoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    PurchaseControlId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 250, nullable: true),
                    Container = table.Column<string>(maxLength: 50, nullable: true),
                    TypeDoc = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(maxLength: 5, nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseControlDoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseControlDoc_PurchaseControl_PurchaseControlId",
                        column: x => x.PurchaseControlId,
                        principalTable: "PurchaseControl",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ChangedAt = table.Column<DateTime>(nullable: true),
                    UserIdChange = table.Column<int>(nullable: true),
                    SubscriptionId = table.Column<int>(nullable: false),
                    MentoredId = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "date", nullable: true),
                    PaidDate = table.Column<DateTime>(type: "date", nullable: true),
                    CanceledDate = table.Column<DateTime>(type: "date", nullable: true),
                    NextAttempt = table.Column<DateTime>(type: "date", nullable: true),
                    OverdueSince = table.Column<DateTime>(type: "date", nullable: true),
                    AttemptCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoice_Mentored_MentoredId",
                        column: x => x.MentoredId,
                        principalTable: "Mentored",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoice_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Award_CustomerId",
                table: "Award",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Award_MentoredId",
                table: "Award",
                column: "MentoredId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAward_AwardId",
                table: "CustomerAward",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAward_CustomerId",
                table: "CustomerAward",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerLaunch_CustomerId",
                table: "CustomerLaunch",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerPayment_CustomerId",
                table: "CustomerPayment",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_CustomerId",
                table: "CustomerProduct",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerProduct_ProductId",
                table: "CustomerProduct",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPayment_CategoryId",
                table: "DailyPayment",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPayment_ProviderId",
                table: "DailyPayment",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyPaymentDoc_DailyPaymentId",
                table: "DailyPaymentDoc",
                column: "DailyPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDoc_EmployeeId",
                table: "EmployeeDoc",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseControl_ExpenseCategoryId",
                table: "ExpenseControl",
                column: "ExpenseCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseControl_ProviderId",
                table: "ExpenseControl",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseControlDoc_ExpenseControlId",
                table: "ExpenseControlDoc",
                column: "ExpenseControlId");

            migrationBuilder.CreateIndex(
                name: "IX_GiftDoc_GiftId",
                table: "GiftDoc",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_MentoredId",
                table: "Invoice",
                column: "MentoredId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_SubscriptionId",
                table: "Invoice",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_MentoredAward_AwardId",
                table: "MentoredAward",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_MentoredAward_MentoredId",
                table: "MentoredAward",
                column: "MentoredId");

            migrationBuilder.CreateIndex(
                name: "IX_MentoredCompany_MentoredId",
                table: "MentoredCompany",
                column: "MentoredId");

            migrationBuilder.CreateIndex(
                name: "IX_MentoredDoc_MentoredCompanyId",
                table: "MentoredDoc",
                column: "MentoredCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MentoredDoc_MentoredId",
                table: "MentoredDoc",
                column: "MentoredId");

            migrationBuilder.CreateIndex(
                name: "IX_MentoredPayment_MentoredCompanyId",
                table: "MentoredPayment",
                column: "MentoredCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_MentoredPayment_MentoredId",
                table: "MentoredPayment",
                column: "MentoredId");

            migrationBuilder.CreateIndex(
                name: "IX_Partner_MentoredId",
                table: "Partner",
                column: "MentoredId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimony_AssetsCategoryId",
                table: "Patrimony",
                column: "AssetsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimony_ProviderId",
                table: "Patrimony",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PatrimonyDoc_PatrimonyId",
                table: "PatrimonyDoc",
                column: "PatrimonyId");

            migrationBuilder.CreateIndex(
                name: "IX_PendencyDoc_PendencyId",
                table: "PendencyDoc",
                column: "PendencyId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseControl_ProviderId",
                table: "PurchaseControl",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseControlDoc_PurchaseControlId",
                table: "PurchaseControlDoc",
                column: "PurchaseControlId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Roles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sent_AwardId",
                table: "Sent",
                column: "AwardId");

            migrationBuilder.CreateIndex(
                name: "IX_Sent_CustomerId",
                table: "Sent",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Sent_MentoredId",
                table: "Sent",
                column: "MentoredId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_MentoredCompanyId",
                table: "Subscription",
                column: "MentoredCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_MentoredId",
                table: "Subscription",
                column: "MentoredId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_ProductId",
                table: "Subscription",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfilePermission_PermissionId",
                table: "UserProfilePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "CustomerAward");

            migrationBuilder.DropTable(
                name: "CustomerLaunch");

            migrationBuilder.DropTable(
                name: "CustomerPayment");

            migrationBuilder.DropTable(
                name: "CustomerProduct");

            migrationBuilder.DropTable(
                name: "DailyPaymentDoc");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "EmployeeDoc");

            migrationBuilder.DropTable(
                name: "ExpenseControlDoc");

            migrationBuilder.DropTable(
                name: "GiftDoc");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Launch");

            migrationBuilder.DropTable(
                name: "LogAudit");

            migrationBuilder.DropTable(
                name: "LogErro");

            migrationBuilder.DropTable(
                name: "LoginRefreshToken");

            migrationBuilder.DropTable(
                name: "MentoredAward");

            migrationBuilder.DropTable(
                name: "MentoredDoc");

            migrationBuilder.DropTable(
                name: "MentoredPayment");

            migrationBuilder.DropTable(
                name: "Partner");

            migrationBuilder.DropTable(
                name: "PatrimonyDoc");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "PendencyDoc");

            migrationBuilder.DropTable(
                name: "PurchaseControlDoc");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "Sent");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserProfilePermission");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "DailyPayment");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "ExpenseControl");

            migrationBuilder.DropTable(
                name: "Gift");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "Patrimony");

            migrationBuilder.DropTable(
                name: "Pendency");

            migrationBuilder.DropTable(
                name: "PurchaseControl");

            migrationBuilder.DropTable(
                name: "Award");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "ExpenseCategory");

            migrationBuilder.DropTable(
                name: "MentoredCompany");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "AssetsCategory");

            migrationBuilder.DropTable(
                name: "Provider");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Mentored");
        }
    }
}
