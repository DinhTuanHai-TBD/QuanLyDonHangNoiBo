using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyDonHangNoiBo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddPickPackPodExportDemo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExportJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExportCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ExportType = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: false),
                    DownloadUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CompletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExportJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExportJobs_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExportJobs_Users_RequestedByUserId",
                        column: x => x.RequestedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    WeightKg = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LengthCm = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    WidthCm = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    HeightCm = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    LabelUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Packages_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PickLists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WarehouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PickListCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CompletedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickLists_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PickLists_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PickLists_Users_AssignedToUserId",
                        column: x => x.AssignedToUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PickLists_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProofOfDeliveries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ShipmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    ReceiverName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: true),
                    Longitude = table.Column<double>(type: "float", nullable: true),
                    CapturedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProofOfDeliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProofOfDeliveries_Shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "Shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProofOfDeliveries_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProofOfDeliveries_Users_UploadedByUserId",
                        column: x => x.UploadedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Returns",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReturnCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    RefundAmount = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ApprovedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Returns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Returns_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Returns_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Returns_Users_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "PickListItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PickListId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkuCode = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    RequiredQuantity = table.Column<int>(type: "int", nullable: false),
                    PickedQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PickListItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PickListItems_PickLists_PickListId",
                        column: x => x.PickListId,
                        principalTable: "PickLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PickListItems_ProductSkus_SkuId",
                        column: x => x.SkuId,
                        principalTable: "ProductSkus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExportJobs_RequestedByUserId",
                table: "ExportJobs",
                column: "RequestedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ExportJobs_TenantId_ExportCode",
                table: "ExportJobs",
                columns: new[] { "TenantId", "ExportCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExportJobs_TenantId_ExportType_CreatedAt",
                table: "ExportJobs",
                columns: new[] { "TenantId", "ExportType", "CreatedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_OrderId",
                table: "Packages",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_TenantId_OrderId",
                table: "Packages",
                columns: new[] { "TenantId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_Packages_TenantId_PackageCode",
                table: "Packages",
                columns: new[] { "TenantId", "PackageCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PickListItems_Barcode",
                table: "PickListItems",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_PickListItems_PickListId_SkuId",
                table: "PickListItems",
                columns: new[] { "PickListId", "SkuId" });

            migrationBuilder.CreateIndex(
                name: "IX_PickListItems_SkuId",
                table: "PickListItems",
                column: "SkuId");

            migrationBuilder.CreateIndex(
                name: "IX_PickLists_AssignedToUserId",
                table: "PickLists",
                column: "AssignedToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PickLists_OrderId",
                table: "PickLists",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PickLists_TenantId_OrderId",
                table: "PickLists",
                columns: new[] { "TenantId", "OrderId" });

            migrationBuilder.CreateIndex(
                name: "IX_PickLists_TenantId_PickListCode",
                table: "PickLists",
                columns: new[] { "TenantId", "PickListCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PickLists_TenantId_WarehouseId_Status",
                table: "PickLists",
                columns: new[] { "TenantId", "WarehouseId", "Status" });

            migrationBuilder.CreateIndex(
                name: "IX_PickLists_WarehouseId",
                table: "PickLists",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_ProofOfDeliveries_ShipmentId",
                table: "ProofOfDeliveries",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProofOfDeliveries_TenantId_ShipmentId_CapturedAt",
                table: "ProofOfDeliveries",
                columns: new[] { "TenantId", "ShipmentId", "CapturedAt" });

            migrationBuilder.CreateIndex(
                name: "IX_ProofOfDeliveries_UploadedByUserId",
                table: "ProofOfDeliveries",
                column: "UploadedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_ApprovedByUserId",
                table: "Returns",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_OrderId",
                table: "Returns",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Returns_TenantId_ReturnCode",
                table: "Returns",
                columns: new[] { "TenantId", "ReturnCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Returns_TenantId_Status_CreatedAt",
                table: "Returns",
                columns: new[] { "TenantId", "Status", "CreatedAt" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExportJobs");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "PickListItems");

            migrationBuilder.DropTable(
                name: "ProofOfDeliveries");

            migrationBuilder.DropTable(
                name: "Returns");

            migrationBuilder.DropTable(
                name: "PickLists");
        }
    }
}





