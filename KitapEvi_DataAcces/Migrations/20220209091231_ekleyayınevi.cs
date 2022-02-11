using Microsoft.EntityFrameworkCore.Migrations;

namespace KitapEvi_DataAcces.Migrations
{
    public partial class ekleyayınevi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Kitap_tb_Kategori_KategoriID",
                table: "tb_Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "tb_Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YayıneviID",
                table: "tb_Kitap",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tb_Yayınevi",
                columns: table => new
                {
                    YayıneviID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YayıneviAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_Yayınevi", x => x.YayıneviID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_Kitap_YayıneviID",
                table: "tb_Kitap",
                column: "YayıneviID");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Kitap_tb_Kategori_KategoriID",
                table: "tb_Kitap",
                column: "KategoriID",
                principalTable: "tb_Kategori",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Kitap_tb_Yayınevi_YayıneviID",
                table: "tb_Kitap",
                column: "YayıneviID",
                principalTable: "tb_Yayınevi",
                principalColumn: "YayıneviID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_Kitap_tb_Kategori_KategoriID",
                table: "tb_Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_Kitap_tb_Yayınevi_YayıneviID",
                table: "tb_Kitap");

            migrationBuilder.DropTable(
                name: "tb_Yayınevi");

            migrationBuilder.DropIndex(
                name: "IX_tb_Kitap_YayıneviID",
                table: "tb_Kitap");

            migrationBuilder.DropColumn(
                name: "YayıneviID",
                table: "tb_Kitap");

            migrationBuilder.AlterColumn<int>(
                name: "KategoriID",
                table: "tb_Kitap",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_Kitap_tb_Kategori_KategoriID",
                table: "tb_Kitap",
                column: "KategoriID",
                principalTable: "tb_Kategori",
                principalColumn: "KategoriID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
