using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace Emart_final.Migrations
{
    /// <inheritdoc />
    public partial class Createintial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    catmaster_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    category_name = table.Column<string>(type: "longtext", nullable: true),
                    childflag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    parent_catid = table.Column<int>(type: "int", nullable: false),
                    cat_img_path = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.catmaster_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Config",
                columns: table => new
                {
                    config_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    config_name = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config", x => x.config_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    cust_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    cust_name = table.Column<string>(type: "longtext", nullable: true),
                    cust_address = table.Column<string>(type: "longtext", nullable: true),
                    cust_phone = table.Column<string>(type: "longtext", nullable: true),
                    cust_email = table.Column<string>(type: "longtext", nullable: true),
                    cust_password = table.Column<string>(type: "longtext", nullable: true),
                    card_holder = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.cust_id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    prod_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    prod_name = table.Column<string>(type: "longtext", nullable: true),
                    prod_short_desc = table.Column<string>(type: "longtext", nullable: true),
                    prod_long_desc = table.Column<string>(type: "longtext", nullable: true),
                    mrp_price = table.Column<double>(type: "double", nullable: false),
                    offer_price = table.Column<double>(type: "double", nullable: false),
                    card_holder_price = table.Column<double>(type: "double", nullable: false),
                    points_redeem = table.Column<int>(type: "int", nullable: false),
                    imgpath = table.Column<string>(type: "longtext", nullable: true),
                    inventory_quantity = table.Column<int>(type: "int", nullable: false),
                    catmasterid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.prod_id);
                    table.ForeignKey(
                        name: "FK_Product_Category_catmasterid",
                        column: x => x.catmasterid,
                        principalTable: "Category",
                        principalColumn: "catmaster_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    invoice_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    invoice_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    total_amt = table.Column<double>(type: "double", nullable: false),
                    tax = table.Column<double>(type: "double", nullable: false),
                    delivery_charges = table.Column<double>(type: "double", nullable: false),
                    total_bill = table.Column<double>(type: "double", nullable: false),
                    custid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.invoice_id);
                    table.ForeignKey(
                        name: "FK_Invoice_Customer_custid",
                        column: x => x.custid,
                        principalTable: "Customer",
                        principalColumn: "cust_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    custid = table.Column<int>(type: "int", nullable: false),
                    qty = table.Column<int>(type: "int", nullable: false),
                    prodid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cart", x => x.cart_id);
                    table.ForeignKey(
                        name: "FK_Cart_Customer_custid",
                        column: x => x.custid,
                        principalTable: "Customer",
                        principalColumn: "cust_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cart_Product_prodid",
                        column: x => x.prodid,
                        principalTable: "Product",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Config_Details",
                columns: table => new
                {
                    config_detailsid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    configid = table.Column<int>(type: "int", nullable: false),
                    config_details = table.Column<string>(type: "longtext", nullable: false),
                    prodid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Config_Details", x => x.config_detailsid);
                    table.ForeignKey(
                        name: "FK_Config_Details_Config_configid",
                        column: x => x.configid,
                        principalTable: "Config",
                        principalColumn: "config_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Config_Details_Product_prodid",
                        column: x => x.prodid,
                        principalTable: "Product",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Invoice_Details",
                columns: table => new
                {
                    invoice_dt_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    mrp = table.Column<double>(type: "double", nullable: false),
                    card_holder_price = table.Column<double>(type: "double", nullable: false),
                    points_redeem = table.Column<int>(type: "int", nullable: false),
                    invoiceid = table.Column<int>(type: "int", nullable: false),
                    prodid = table.Column<int>(type: "int", nullable: false),
                    prod_name = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_Details", x => x.invoice_dt_id);
                    table.ForeignKey(
                        name: "FK_Invoice_Details_Invoice_invoiceid",
                        column: x => x.invoiceid,
                        principalTable: "Invoice",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invoice_Details_Product_prodid",
                        column: x => x.prodid,
                        principalTable: "Product",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    shipping_add = table.Column<string>(type: "longtext", nullable: false),
                    order_date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    deliverydate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    cust_id = table.Column<int>(type: "int", nullable: false),
                    invoiceid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_Orders_Customer_cust_id",
                        column: x => x.cust_id,
                        principalTable: "Customer",
                        principalColumn: "cust_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Invoice_invoiceid",
                        column: x => x.invoiceid,
                        principalTable: "Invoice",
                        principalColumn: "invoice_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_custid",
                table: "Cart",
                column: "custid");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_prodid",
                table: "Cart",
                column: "prodid");

            migrationBuilder.CreateIndex(
                name: "IX_Config_Details_configid",
                table: "Config_Details",
                column: "configid");

            migrationBuilder.CreateIndex(
                name: "IX_Config_Details_prodid",
                table: "Config_Details",
                column: "prodid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_custid",
                table: "Invoice",
                column: "custid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Details_invoiceid",
                table: "Invoice_Details",
                column: "invoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Details_prodid",
                table: "Invoice_Details",
                column: "prodid");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_cust_id",
                table: "Orders",
                column: "cust_id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_invoiceid",
                table: "Orders",
                column: "invoiceid");

            migrationBuilder.CreateIndex(
                name: "IX_Product_catmasterid",
                table: "Product",
                column: "catmasterid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Config_Details");

            migrationBuilder.DropTable(
                name: "Invoice_Details");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Config");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
