using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HQSOFT.Configuration.Migrations
{
    /// <inheritdoc />
    public partial class AddTblTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationHQTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Project = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    ExpectedStartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpectedEndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ExpectedTime = table.Column<double>(type: "double precision", nullable: false),
                    Process = table.Column<double>(type: "double precision", nullable: false),
                    ExtraProperties = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uuid", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uuid", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationHQTasks", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationCSAttributes_AttributeID",
                table: "ConfigurationCSAttributes",
                column: "AttributeID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationCSAttributeDetails_ValueID",
                table: "ConfigurationCSAttributeDetails",
                column: "ValueID",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationHQTasks");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationCSAttributes_AttributeID",
                table: "ConfigurationCSAttributes");

            migrationBuilder.DropIndex(
                name: "IX_ConfigurationCSAttributeDetails_ValueID",
                table: "ConfigurationCSAttributeDetails");
        }
    }
}
