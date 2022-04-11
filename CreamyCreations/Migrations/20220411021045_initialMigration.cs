using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CreamyCreations.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    addressID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    city = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    postalCode = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    street = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    province = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.addressID);
                });

            migrationBuilder.CreateTable(
                name: "AdminOrdersVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    orderID = table.Column<int>(type: "INTEGER", nullable: false),
                    weddingCakeID = table.Column<int>(type: "INTEGER", nullable: false),
                    userID = table.Column<int>(type: "INTEGER", nullable: false),
                    deliveryDate = table.Column<string>(type: "TEXT", nullable: true),
                    email = table.Column<string>(type: "TEXT", nullable: true),
                    price = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminOrdersVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerWeddingCakeVM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    orderID = table.Column<int>(type: "INTEGER", nullable: false),
                    userID = table.Column<int>(type: "INTEGER", nullable: false),
                    firstName = table.Column<string>(type: "TEXT", nullable: true),
                    lastName = table.Column<string>(type: "TEXT", nullable: true),
                    weddingCakeID = table.Column<int>(type: "INTEGER", nullable: false),
                    cover = table.Column<string>(type: "TEXT", nullable: true),
                    level = table.Column<int>(type: "INTEGER", nullable: false),
                    label = table.Column<string>(type: "TEXT", nullable: true),
                    filling = table.Column<string>(type: "TEXT", nullable: true),
                    deliveryDate = table.Column<string>(type: "TEXT", nullable: true),
                    price = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerWeddingCakeVM", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdersVm",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: true),
                    price = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersVm", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    userID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    firstName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    lastName = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileVM",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileVM", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WeddingCakeVM",
                columns: table => new
                {
                    WeddingCakeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoverId = table.Column<int>(type: "INTEGER", nullable: false),
                    FillingId = table.Column<int>(type: "INTEGER", nullable: false),
                    LabelId = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingCakeVM", x => x.WeddingCakeId);
                });

            migrationBuilder.CreateTable(
                name: "WeddingCakeVM_1",
                columns: table => new
                {
                    WeddingCakeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CoverId = table.Column<int>(type: "INTEGER", nullable: false),
                    FillingId = table.Column<int>(type: "INTEGER", nullable: false),
                    LabelId = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingCakeVM_1", x => x.WeddingCakeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Decoration",
                columns: table => new
                {
                    decorationID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    decoration = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CustomerWeddingCakeVMId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decoration", x => x.decorationID);
                    table.ForeignKey(
                        name: "FK_Decoration_CustomerWeddingCakeVM_CustomerWeddingCakeVMId",
                        column: x => x.CustomerWeddingCakeVMId,
                        principalTable: "CustomerWeddingCakeVM",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cover",
                columns: table => new
                {
                    coverID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    flavor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreateWeddingCakeVMWeddingCakeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cover", x => x.coverID);
                    table.ForeignKey(
                        name: "FK_Cover_WeddingCakeVM_CreateWeddingCakeVMWeddingCakeId",
                        column: x => x.CreateWeddingCakeVMWeddingCakeId,
                        principalTable: "WeddingCakeVM",
                        principalColumn: "WeddingCakeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Filling",
                columns: table => new
                {
                    fillingID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    flavor = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreateWeddingCakeVMWeddingCakeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filling", x => x.fillingID);
                    table.ForeignKey(
                        name: "FK_Filling_WeddingCakeVM_CreateWeddingCakeVMWeddingCakeId",
                        column: x => x.CreateWeddingCakeVMWeddingCakeId,
                        principalTable: "WeddingCakeVM",
                        principalColumn: "WeddingCakeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    labelID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    labelName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    CreateWeddingCakeVMWeddingCakeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.labelID);
                    table.ForeignKey(
                        name: "FK_Label_WeddingCakeVM_CreateWeddingCakeVMWeddingCakeId",
                        column: x => x.CreateWeddingCakeVMWeddingCakeId,
                        principalTable: "WeddingCakeVM",
                        principalColumn: "WeddingCakeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    levelNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    price = table.Column<decimal>(type: "money", nullable: false),
                    CreateWeddingCakeVMWeddingCakeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Level__8AB0A30A55D0C97C", x => x.levelNumber);
                    table.ForeignKey(
                        name: "FK_Level_WeddingCakeVM_CreateWeddingCakeVMWeddingCakeId",
                        column: x => x.CreateWeddingCakeVMWeddingCakeId,
                        principalTable: "WeddingCakeVM",
                        principalColumn: "WeddingCakeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DecorationCheckBoxVM",
                columns: table => new
                {
                    DecorationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    DecorationTitle = table.Column<string>(type: "TEXT", nullable: true),
                    IsChecked = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreateWeddingCakeVMWeddingCakeId = table.Column<int>(type: "INTEGER", nullable: true),
                    WeddingCakeVMWeddingCakeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecorationCheckBoxVM", x => x.DecorationId);
                    table.ForeignKey(
                        name: "FK_DecorationCheckBoxVM_WeddingCakeVM_1_WeddingCakeVMWeddingCakeId",
                        column: x => x.WeddingCakeVMWeddingCakeId,
                        principalTable: "WeddingCakeVM_1",
                        principalColumn: "WeddingCakeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DecorationCheckBoxVM_WeddingCakeVM_CreateWeddingCakeVMWeddingCakeId",
                        column: x => x.CreateWeddingCakeVMWeddingCakeId,
                        principalTable: "WeddingCakeVM",
                        principalColumn: "WeddingCakeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeddingCake",
                columns: table => new
                {
                    weddingCakeID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    coverID = table.Column<int>(type: "INTEGER", nullable: false),
                    fillingID = table.Column<int>(type: "INTEGER", nullable: false),
                    labelID = table.Column<int>(type: "INTEGER", nullable: false),
                    levelNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    totalPrice = table.Column<decimal>(type: "money", nullable: false),
                    LevelNumberNavigationLevelNumber = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeddingCake", x => x.weddingCakeID);
                    table.ForeignKey(
                        name: "FK_WeddingCake_Cover_coverID",
                        column: x => x.coverID,
                        principalTable: "Cover",
                        principalColumn: "coverID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeddingCake_Filling_fillingID",
                        column: x => x.fillingID,
                        principalTable: "Filling",
                        principalColumn: "fillingID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeddingCake_Label_labelID",
                        column: x => x.labelID,
                        principalTable: "Label",
                        principalColumn: "labelID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WeddingCake_Level_LevelNumberNavigationLevelNumber",
                        column: x => x.LevelNumberNavigationLevelNumber,
                        principalTable: "Level",
                        principalColumn: "levelNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    orderID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    addressID = table.Column<int>(type: "INTEGER", nullable: false),
                    weddingCakeID = table.Column<int>(type: "INTEGER", nullable: false),
                    userID = table.Column<int>(type: "INTEGER", nullable: false),
                    deliveryDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.orderID);
                    table.ForeignKey(
                        name: "FK__Order__addressID__3B75D760",
                        column: x => x.addressID,
                        principalTable: "Address",
                        principalColumn: "addressID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Order__userID__3D5E1FD2",
                        column: x => x.userID,
                        principalTable: "User",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Order__weddingCa__3C69FB99",
                        column: x => x.weddingCakeID,
                        principalTable: "WeddingCake",
                        principalColumn: "weddingCakeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WeddingCakeDecoration",
                columns: table => new
                {
                    weddingCakeID = table.Column<int>(type: "INTEGER", nullable: false),
                    decorationID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__WeddingC__E226A6EB5A68EDCE", x => new { x.weddingCakeID, x.decorationID });
                    table.ForeignKey(
                        name: "FK__WeddingCa__decor__412EB0B6",
                        column: x => x.decorationID,
                        principalTable: "Decoration",
                        principalColumn: "decorationID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__WeddingCa__weddi__403A8C7D",
                        column: x => x.weddingCakeID,
                        principalTable: "WeddingCake",
                        principalColumn: "weddingCakeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "addressID", "city", "postalCode", "province", "street" },
                values: new object[] { 1, "Vancouver", "V4B 9X2", "BC", "2 South Mega Street" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "addressID", "city", "postalCode", "province", "street" },
                values: new object[] { 2, "Burnaby", "V8Y 3W2", "BC", "12 Main Street" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "addressID", "city", "postalCode", "province", "street" },
                values: new object[] { 3, "Surrey", "S1L 9H7", "BC", "1 Shopping Street" });

            migrationBuilder.InsertData(
                table: "Cover",
                columns: new[] { "coverID", "CreateWeddingCakeVMWeddingCakeId", "flavor", "price" },
                values: new object[] { 1, null, "Butter with vanilla", 44.35m });

            migrationBuilder.InsertData(
                table: "Cover",
                columns: new[] { "coverID", "CreateWeddingCakeVMWeddingCakeId", "flavor", "price" },
                values: new object[] { 2, null, "Plain butter", 10.35m });

            migrationBuilder.InsertData(
                table: "Cover",
                columns: new[] { "coverID", "CreateWeddingCakeVMWeddingCakeId", "flavor", "price" },
                values: new object[] { 3, null, "Butter with dark chocolate", 34.35m });

            migrationBuilder.InsertData(
                table: "Decoration",
                columns: new[] { "decorationID", "CustomerWeddingCakeVMId", "decoration", "price" },
                values: new object[] { 1, null, "Chocolate hearts", 34.35m });

            migrationBuilder.InsertData(
                table: "Decoration",
                columns: new[] { "decorationID", "CustomerWeddingCakeVMId", "decoration", "price" },
                values: new object[] { 2, null, "Butter roses", 22.15m });

            migrationBuilder.InsertData(
                table: "Decoration",
                columns: new[] { "decorationID", "CustomerWeddingCakeVMId", "decoration", "price" },
                values: new object[] { 3, null, "Angles", 12.15m });

            migrationBuilder.InsertData(
                table: "Filling",
                columns: new[] { "fillingID", "CreateWeddingCakeVMWeddingCakeId", "flavor", "price" },
                values: new object[] { 3, null, "Butter with strawberries", 24.35m });

            migrationBuilder.InsertData(
                table: "Filling",
                columns: new[] { "fillingID", "CreateWeddingCakeVMWeddingCakeId", "flavor", "price" },
                values: new object[] { 1, null, "Butter with almond", 60.35m });

            migrationBuilder.InsertData(
                table: "Filling",
                columns: new[] { "fillingID", "CreateWeddingCakeVMWeddingCakeId", "flavor", "price" },
                values: new object[] { 2, null, "Butter with dark chocolate", 30.35m });

            migrationBuilder.InsertData(
                table: "Label",
                columns: new[] { "labelID", "CreateWeddingCakeVMWeddingCakeId", "labelName", "price" },
                values: new object[] { 1, null, "Dark chocolate  label of last name", 10.25m });

            migrationBuilder.InsertData(
                table: "Label",
                columns: new[] { "labelID", "CreateWeddingCakeVMWeddingCakeId", "labelName", "price" },
                values: new object[] { 2, null, "White almond label of last name at the top", 20.25m });

            migrationBuilder.InsertData(
                table: "Label",
                columns: new[] { "labelID", "CreateWeddingCakeVMWeddingCakeId", "labelName", "price" },
                values: new object[] { 3, null, "Red strawberry label of last name in the middle", 30.25m });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "levelNumber", "CreateWeddingCakeVMWeddingCakeId", "price" },
                values: new object[] { 3, null, 14.25m });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "levelNumber", "CreateWeddingCakeVMWeddingCakeId", "price" },
                values: new object[] { 1, null, 10.5m });

            migrationBuilder.InsertData(
                table: "Level",
                columns: new[] { "levelNumber", "CreateWeddingCakeVMWeddingCakeId", "price" },
                values: new object[] { 2, null, 12.5m });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "userID", "email", "firstName", "lastName" },
                values: new object[] { 1, "john.doe@doe.com", "John", "Doe" });

            migrationBuilder.InsertData(
                table: "WeddingCake",
                columns: new[] { "weddingCakeID", "coverID", "fillingID", "labelID", "levelNumber", "LevelNumberNavigationLevelNumber", "totalPrice" },
                values: new object[] { 1, 1, 1, 1, 1, null, 320.23m });

            migrationBuilder.InsertData(
                table: "WeddingCake",
                columns: new[] { "weddingCakeID", "coverID", "fillingID", "labelID", "levelNumber", "LevelNumberNavigationLevelNumber", "totalPrice" },
                values: new object[] { 2, 2, 2, 2, 2, null, 211.83m });

            migrationBuilder.InsertData(
                table: "WeddingCake",
                columns: new[] { "weddingCakeID", "coverID", "fillingID", "labelID", "levelNumber", "LevelNumberNavigationLevelNumber", "totalPrice" },
                values: new object[] { 3, 3, 3, 3, 3, null, 101.99m });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "orderID", "addressID", "deliveryDate", "userID", "weddingCakeID" },
                values: new object[] { 1, 1, new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "orderID", "addressID", "deliveryDate", "userID", "weddingCakeID" },
                values: new object[] { 2, 2, new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 });

            migrationBuilder.InsertData(
                table: "Order",
                columns: new[] { "orderID", "addressID", "deliveryDate", "userID", "weddingCakeID" },
                values: new object[] { 3, 3, new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3 });

            migrationBuilder.InsertData(
                table: "WeddingCakeDecoration",
                columns: new[] { "decorationID", "weddingCakeID" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "WeddingCakeDecoration",
                columns: new[] { "decorationID", "weddingCakeID" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "WeddingCakeDecoration",
                columns: new[] { "decorationID", "weddingCakeID" },
                values: new object[] { 3, 1 });

            migrationBuilder.InsertData(
                table: "WeddingCakeDecoration",
                columns: new[] { "decorationID", "weddingCakeID" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "WeddingCakeDecoration",
                columns: new[] { "decorationID", "weddingCakeID" },
                values: new object[] { 1, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cover_CreateWeddingCakeVMWeddingCakeId",
                table: "Cover",
                column: "CreateWeddingCakeVMWeddingCakeId");

            migrationBuilder.CreateIndex(
                name: "UQ__Cover__1DA1A8C1AAB7B0D6",
                table: "Cover",
                column: "flavor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Decoration_CustomerWeddingCakeVMId",
                table: "Decoration",
                column: "CustomerWeddingCakeVMId");

            migrationBuilder.CreateIndex(
                name: "UQ__Decorati__129665722C1950E6",
                table: "Decoration",
                column: "decoration",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DecorationCheckBoxVM_CreateWeddingCakeVMWeddingCakeId",
                table: "DecorationCheckBoxVM",
                column: "CreateWeddingCakeVMWeddingCakeId");

            migrationBuilder.CreateIndex(
                name: "IX_DecorationCheckBoxVM_WeddingCakeVMWeddingCakeId",
                table: "DecorationCheckBoxVM",
                column: "WeddingCakeVMWeddingCakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Filling_CreateWeddingCakeVMWeddingCakeId",
                table: "Filling",
                column: "CreateWeddingCakeVMWeddingCakeId");

            migrationBuilder.CreateIndex(
                name: "UQ__Filling__1DA1A8C1F474B9D9",
                table: "Filling",
                column: "flavor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Label_CreateWeddingCakeVMWeddingCakeId",
                table: "Label",
                column: "CreateWeddingCakeVMWeddingCakeId");

            migrationBuilder.CreateIndex(
                name: "UQ__Label__FB497B2DA698282A",
                table: "Label",
                column: "labelName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Level_CreateWeddingCakeVMWeddingCakeId",
                table: "Level",
                column: "CreateWeddingCakeVMWeddingCakeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_addressID",
                table: "Order",
                column: "addressID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_userID",
                table: "Order",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_weddingCakeID",
                table: "Order",
                column: "weddingCakeID");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingCake_coverID",
                table: "WeddingCake",
                column: "coverID");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingCake_fillingID",
                table: "WeddingCake",
                column: "fillingID");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingCake_labelID",
                table: "WeddingCake",
                column: "labelID");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingCake_LevelNumberNavigationLevelNumber",
                table: "WeddingCake",
                column: "LevelNumberNavigationLevelNumber");

            migrationBuilder.CreateIndex(
                name: "IX_WeddingCakeDecoration_decorationID",
                table: "WeddingCakeDecoration",
                column: "decorationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminOrdersVM");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "DecorationCheckBoxVM");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrdersVm");

            migrationBuilder.DropTable(
                name: "UserProfileVM");

            migrationBuilder.DropTable(
                name: "WeddingCakeDecoration");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WeddingCakeVM_1");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Decoration");

            migrationBuilder.DropTable(
                name: "WeddingCake");

            migrationBuilder.DropTable(
                name: "CustomerWeddingCakeVM");

            migrationBuilder.DropTable(
                name: "Cover");

            migrationBuilder.DropTable(
                name: "Filling");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "WeddingCakeVM");
        }
    }
}
