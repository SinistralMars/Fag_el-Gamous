using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Fag_el_Gamous.Migrations.Burial
{
    public partial class AddPrimaryKeyToNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "excelimporter$template_nr_mxseq");

            migrationBuilder.CreateSequence(
                name: "system$filedocument_fileid_mxseq");

            migrationBuilder.CreateSequence(
                name: "system$queuedtask_sequence_mxseq");

            migrationBuilder.CreateTable(
                name: "new_table",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false),
                    burialid = table.Column<long>(nullable: true),
                    dateofexcavation = table.Column<DateTime>(nullable: true),
                    sex = table.Column<string>(maxLength: 200, nullable: true),
                    northsouth = table.Column<string>(maxLength: 200, nullable: true),
                    depth = table.Column<string>(maxLength: 200, nullable: true),
                    eastwest = table.Column<string>(maxLength: 200, nullable: true),
                    adultsubadult = table.Column<string>(maxLength: 200, nullable: true),
                    facebundles = table.Column<string>(maxLength: 200, nullable: true),
                    southtohead = table.Column<string>(maxLength: 200, nullable: true),
                    preservation = table.Column<string>(maxLength: 200, nullable: true),
                    fieldbookpage = table.Column<string>(maxLength: 200, nullable: true),
                    squareeastwest = table.Column<string>(maxLength: 200, nullable: true),
                    goods = table.Column<string>(maxLength: 200, nullable: true),
                    text = table.Column<string>(maxLength: 2000, nullable: true),
                    wrapping = table.Column<string>(maxLength: 200, nullable: true),
                    haircolor = table.Column<string>(maxLength: 200, nullable: true),
                    westtohead = table.Column<string>(maxLength: 200, nullable: true),
                    samplescollected = table.Column<string>(maxLength: 200, nullable: true),
                    area = table.Column<string>(maxLength: 200, nullable: true),
                    length = table.Column<string>(maxLength: 200, nullable: true),
                    burialnumber = table.Column<string>(maxLength: 200, nullable: true),
                    dataexpertinitials = table.Column<string>(maxLength: 200, nullable: true),
                    westtofeet = table.Column<string>(maxLength: 200, nullable: true),
                    ageatdeath = table.Column<string>(maxLength: 200, nullable: true),
                    southtofeet = table.Column<string>(maxLength: 200, nullable: true),
                    excavationrecorder = table.Column<string>(maxLength: 100, nullable: true),
                    photos = table.Column<string>(maxLength: 5, nullable: true),
                    hair = table.Column<string>(maxLength: 5, nullable: true),
                    burialmaterials = table.Column<string>(maxLength: 5, nullable: true),
                    fieldbookexcavationyear = table.Column<string>(maxLength: 200, nullable: true),
                    clusternumber = table.Column<string>(maxLength: 200, nullable: true),
                    shaftnumber = table.Column<string>(maxLength: 200, nullable: true),
                    squarenorthsouth = table.Column<string>(maxLength: 200, nullable: true),
                    headdirection = table.Column<string>(maxLength: 200, nullable: true),
                    estimatestature = table.Column<int>(nullable: true),
                    StructureValue = table.Column<string>(maxLength: 500, nullable: true),
                    ColorValue = table.Column<string>(maxLength: 500, nullable: true),
                    TextileFunctionValue = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "new_table");

            migrationBuilder.DropSequence(
                name: "excelimporter$template_nr_mxseq");

            migrationBuilder.DropSequence(
                name: "system$filedocument_fileid_mxseq");

            migrationBuilder.DropSequence(
                name: "system$queuedtask_sequence_mxseq");
        }
    }
}
