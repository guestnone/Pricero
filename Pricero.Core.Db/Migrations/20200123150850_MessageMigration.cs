using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pricero.Core.Db.Migrations
{
    public partial class MessageMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chains",
                columns: table => new
                {
                    ChainId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChainName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chains", x => x.ChainId);
                });

            migrationBuilder.CreateTable(
                name: "Discounts",
                columns: table => new
                {
                    DiscountID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DiscountPrice = table.Column<double>(nullable: false),
                    DiscountFrom = table.Column<DateTime>(nullable: false),
                    DiscountTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discounts", x => x.DiscountID);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    ProducerID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProducerName = table.Column<string>(nullable: true),
                    ProducerCountry = table.Column<string>(nullable: true),
                    ProducerNIP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.ProducerID);
                });

            migrationBuilder.CreateTable(
                name: "ProductGroups",
                columns: table => new
                {
                    ProductGroupID = table.Column<string>(nullable: false),
                    BaseVATCharge = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGroups", x => x.ProductGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SectionDate = table.Column<DateTime>(nullable: false),
                    SectionTitle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nickname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    UserType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductWeight = table.Column<double>(nullable: false),
                    UpcCode = table.Column<string>(nullable: true),
                    ProducerID = table.Column<int>(nullable: true),
                    ProductGroupID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductID);
                    table.ForeignKey(
                        name: "FK_Products_Producers_ProducerID",
                        column: x => x.ProducerID,
                        principalTable: "Producers",
                        principalColumn: "ProducerID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_ProductGroups_ProductGroupID",
                        column: x => x.ProductGroupID,
                        principalTable: "ProductGroups",
                        principalColumn: "ProductGroupID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ForumThreads",
                columns: table => new
                {
                    ThreadID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ThreadDate = table.Column<DateTime>(nullable: false),
                    ThreadTitle = table.Column<string>(nullable: true),
                    SectionID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumThreads", x => x.ThreadID);
                    table.ForeignKey(
                        name: "FK_ForumThreads_Sections_SectionID",
                        column: x => x.SectionID,
                        principalTable: "Sections",
                        principalColumn: "SectionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MessageSenderId = table.Column<int>(nullable: false),
                    MessageReceiverId = table.Column<int>(nullable: false),
                    MessageContent = table.Column<string>(nullable: true),
                    MessageDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        name: "FK_Messages_Users_MessageReceiverId",
                        column: x => x.MessageReceiverId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_MessageSenderId",
                        column: x => x.MessageSenderId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    ShopId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    ChainId = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.ShopId);
                    table.ForeignKey(
                        name: "FK_Shops_Chains_ChainId",
                        column: x => x.ChainId,
                        principalTable: "Chains",
                        principalColumn: "ChainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Shops_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChainProducts",
                columns: table => new
                {
                    ChainProductID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<double>(nullable: false),
                    ChainId = table.Column<int>(nullable: true),
                    DiscountId = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChainProducts", x => x.ChainProductID);
                    table.ForeignKey(
                        name: "FK_ChainProducts_Chains_ChainId",
                        column: x => x.ChainId,
                        principalTable: "Chains",
                        principalColumn: "ChainId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChainProducts_Discounts_DiscountId",
                        column: x => x.DiscountId,
                        principalTable: "Discounts",
                        principalColumn: "DiscountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChainProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteProducts",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    ProductID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteProducts", x => new { x.ProductID, x.UserID });
                    table.ForeignKey(
                        name: "FK_FavouriteProducts_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteProducts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPosts",
                columns: table => new
                {
                    PostID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PostDate = table.Column<DateTime>(nullable: false),
                    PostContent = table.Column<string>(nullable: true),
                    ThreadID = table.Column<int>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_UserPosts_ForumThreads_ThreadID",
                        column: x => x.ThreadID,
                        principalTable: "ForumThreads",
                        principalColumn: "ThreadID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPosts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteShops",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false),
                    ShopID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteShops", x => new { x.ShopID, x.UserID });
                    table.ForeignKey(
                        name: "FK_FavouriteShops_Shops_ShopID",
                        column: x => x.ShopID,
                        principalTable: "Shops",
                        principalColumn: "ShopId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteShops_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceReports",
                columns: table => new
                {
                    ReportID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ReportContent = table.Column<string>(nullable: true),
                    ChainProductID = table.Column<int>(nullable: true),
                    ProductID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceReports", x => x.ReportID);
                    table.ForeignKey(
                        name: "FK_PriceReports_ChainProducts_ChainProductID",
                        column: x => x.ChainProductID,
                        principalTable: "ChainProducts",
                        principalColumn: "ChainProductID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PriceReports_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChainProducts_ChainId",
                table: "ChainProducts",
                column: "ChainId");

            migrationBuilder.CreateIndex(
                name: "IX_ChainProducts_DiscountId",
                table: "ChainProducts",
                column: "DiscountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChainProducts_ProductID",
                table: "ChainProducts",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteProducts_UserID",
                table: "FavouriteProducts",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteShops_UserID",
                table: "FavouriteShops",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ForumThreads_SectionID",
                table: "ForumThreads",
                column: "SectionID");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageReceiverId",
                table: "Messages",
                column: "MessageReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MessageSenderId",
                table: "Messages",
                column: "MessageSenderId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceReports_ChainProductID",
                table: "PriceReports",
                column: "ChainProductID");

            migrationBuilder.CreateIndex(
                name: "IX_PriceReports_ProductID",
                table: "PriceReports",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProducerID",
                table: "Products",
                column: "ProducerID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductGroupID",
                table: "Products",
                column: "ProductGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_ChainId",
                table: "Shops",
                column: "ChainId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_UserId",
                table: "Shops",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_ThreadID",
                table: "UserPosts",
                column: "ThreadID");

            migrationBuilder.CreateIndex(
                name: "IX_UserPosts_UserId",
                table: "UserPosts",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavouriteProducts");

            migrationBuilder.DropTable(
                name: "FavouriteShops");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PriceReports");

            migrationBuilder.DropTable(
                name: "UserPosts");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "ChainProducts");

            migrationBuilder.DropTable(
                name: "ForumThreads");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Chains");

            migrationBuilder.DropTable(
                name: "Discounts");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "ProductGroups");
        }
    }
}
