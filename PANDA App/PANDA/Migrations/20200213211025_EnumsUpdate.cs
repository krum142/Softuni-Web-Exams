﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PANDA.Migrations
{
    public partial class EnumsUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Username = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Package",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 20, nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    ShippingAddress = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    EstimatedDeliveryDate = table.Column<DateTime>(nullable: false),
                    RecipientId = table.Column<string>(nullable: true),
                    ReceiptId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Package", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Package_Users_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Receipt",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Fee = table.Column<decimal>(nullable: false),
                    IssuedOn = table.Column<DateTime>(nullable: false),
                    RecipientId = table.Column<string>(nullable: false),
                    PackageId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipt_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipt_Users_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Package_ReceiptId",
                table: "Package",
                column: "ReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_PackageId",
                table: "Receipt",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipt_RecipientId",
                table: "Receipt",
                column: "RecipientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Receipt");

            migrationBuilder.DropTable(
                name: "Package");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
