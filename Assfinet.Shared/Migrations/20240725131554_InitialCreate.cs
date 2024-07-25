using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assfinet.Shared.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kunden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AmsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Bearbeitet = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Dirty = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    License = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastSynchronisation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Amsidnr = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunden", x => x.Id);
                    table.UniqueConstraint("AK_Kunden_Amsidnr", x => x.Amsidnr);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KundenFinanzen",
                columns: table => new
                {
                    KundeId = table.Column<int>(type: "int", nullable: false),
                    Einkommen = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheAltersrenteMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheBURenteMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheHinterbliebenenRenteMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheHinterbliebenenRenteTeil = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ErwerbsminderungsrenteTeil = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ErwerbsminderungsrenteVoll = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheAltersrenteTeil = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    NichtSelbstaendigeArbeitBruttoMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    NichtSelbstaendigeArbeitNettoMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SelbstaendigeArbeitNettoMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SonstigeAlterseinkuenfteMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SonstigeEinkuenfteNettoMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SonstigeLaufendeKostenMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    UnterhaltszahlungenMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheKrankenversichert = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlichRentenversichert = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheAltersrenteMonatlichAbzug = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Inflationsrate = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Kapitalmarktzins = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GAgZuschuss = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GAgZuschussProz = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheAltersrenteNettobetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheAltersrenteNetto = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheAltersrenteJahresbetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheAltersrenteProz = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheHinterbliebenenRenteNettobetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheHinterbliebenenRenteNetto = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheHinterbliebenenRenteJahresbetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheHinterbliebenenRenteProz = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheHinterbliebenenRenteNettoAbzug = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheHinterbliebenenRenteNettoZuschuss = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GesetzlicheHinterbliebenenRenteNettoZuschussProz = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KundenFinanzen", x => x.KundeId);
                    table.ForeignKey(
                        name: "FK_KundenFinanzen_Kunden_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KundenKontakte",
                columns: table => new
                {
                    KundeId = table.Column<int>(type: "int", nullable: false),
                    Bank1 = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bank2 = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bic1 = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bic2 = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Blz1 = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Blz2 = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailGeschaeftlich = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailPrivat = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Fax = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iban1 = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iban2 = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Mobiltelefon = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Konto1 = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Konto2 = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kontobezeichnung1 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kontobezeichnung2 = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kontoinhaber1 = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kontoinhaber2 = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Internet = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonGeschaeftlich = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonPrivat = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KundenKontakte", x => x.KundeId);
                    table.ForeignKey(
                        name: "FK_KundenKontakte_Kunden_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KundenPersonenDetails",
                columns: table => new
                {
                    KundeId = table.Column<int>(type: "int", nullable: false),
                    Anrede = table.Column<string>(type: "varchar(70)", maxLength: 70, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Arbeitgeber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AusbildungskostenMonatlich = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    AustrittsdatumArbeitgeber = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Beruf = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Berufsstatus = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Besitzverhaeltnis = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bilanzstichtag = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Branche = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bruttojahresmietwert = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Bruttojahresumsatz = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Bundesland = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Familienstand = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Geburtsname = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Geburtsort = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Geburtstag = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Geschlecht = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GVersicherer1 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GVersicherer2 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GVersicherer3 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GVersicherer4 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GVersicherer5 = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Handelsregisternummer = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Hinterbliebenenrente = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    HistorieZuKunde = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Honorarkunde = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IdentTyp = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Info_01 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Informationsweg = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InhaberGF = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    InterneNr = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsHistorie = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsoLand = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsZukunft = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    KeyIdentDate = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kinder = table.Column<int>(type: "int", nullable: true),
                    Kindergeldnummer = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kirchensteuer = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Klasse = table.Column<string>(type: "varchar(5)", maxLength: 5, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sozialversicherungsnummer = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Staatsangehoerigkeit = table.Column<string>(type: "varchar(3)", maxLength: 3, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SteuerIdentifikationsnummer = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Steuerklasse = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Steuernummer = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Verstorben = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Vorname = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Wasserschutzgebiet = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Zuordnung = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KundenPersonenDetails", x => x.KundeId);
                    table.ForeignKey(
                        name: "FK_KundenPersonenDetails_Kunden_KundeId",
                        column: x => x.KundeId,
                        principalTable: "Kunden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vertraege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AmsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Amsidnr = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bearbeitet = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Sparte = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Details = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vu = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VuNummer = table.Column<int>(type: "int", nullable: false),
                    ComputedStatus = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dirty = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    License = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastSynchronisation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Abbuchung = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    AblaufDt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vertraege", x => x.Id);
                    table.UniqueConstraint("AK_Vertraege_Amsidnr", x => x.Amsidnr);
                    table.ForeignKey(
                        name: "FK_Vertraege_Kunden_Key",
                        column: x => x.Key,
                        principalTable: "Kunden",
                        principalColumn: "Amsidnr",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "KrvSparten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AmsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Bearbeitet = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    Amsidnr = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Key = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Typ = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Dirty = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    License = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastSynchronisation = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    KRV101 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV102 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV103 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV104 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV105 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV106 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV108 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV109 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV110 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV111 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV112 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV113 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV114 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV115 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV116 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV117 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV118 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV119 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV120 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV121 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV122 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV123 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV124 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV125 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV126 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV127 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV128 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV129 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV130 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV132 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV134 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV135 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV136 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV138 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV141 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV143 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV145 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV147 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV149 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV151 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV153 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV155 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV156 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV158 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV159 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV161 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV162 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV164 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV165 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV167 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV168 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV169 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV171 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV172 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV173 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV174 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV204 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV205 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV206 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV207 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV209 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV214 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV215 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV216 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV217 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV219 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV229 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV239 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV249 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV259 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV260 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV261 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV262 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV263 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV264 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV177 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV178 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV180 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV181 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV300 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV301 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV306 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV307 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV308 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV309 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV314 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV315 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV316 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV317 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV324 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV325 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV326 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV327 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV333 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV334 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV335 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV336 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV337 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV343 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV344 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV345 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV346 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KRV347 = table.Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KrvSparten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KrvSparten_Vertraege_Key",
                        column: x => x.Key,
                        principalTable: "Vertraege",
                        principalColumn: "Amsidnr",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VertragBanken",
                columns: table => new
                {
                    VertragId = table.Column<int>(type: "int", nullable: false),
                    Bic = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Blz = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Iban = table.Column<string>(type: "varchar(34)", maxLength: 34, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Konto = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kontobezeichnung = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VertragBanken", x => x.VertragId);
                    table.ForeignKey(
                        name: "FK_VertragBanken_Vertraege_VertragId",
                        column: x => x.VertragId,
                        principalTable: "Vertraege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VertragDetails",
                columns: table => new
                {
                    VertragId = table.Column<int>(type: "int", nullable: false),
                    AbrInfo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Abschlussvermittler = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AendGrund = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Anfrage = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Angebot = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AnpassungAm = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Antrag = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AnzahlZahlungenProJahr = table.Column<int>(type: "int", nullable: true),
                    Anzcourtzahlung = table.Column<int>(type: "int", nullable: true),
                    ApInfo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Art = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Berater = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BeratungErforderlich = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Beratungsgebiet = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Beschreibung = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bestaetigung = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Beteiligungsverhaeltnis = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    BetreuungsvertragsNr = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro1 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro10 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro2 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro3 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro4 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro5 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro6 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro7 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro8 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugAppro9 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro1 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro10 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro2 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro3 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro4 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro5 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro6 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro7 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro8 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugApzvpro9 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro1 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro10 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro2 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro3 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro4 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro5 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro6 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro7 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro8 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugDypro9 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro1 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro10 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro2 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro3 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro4 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro5 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro6 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro7 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro8 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BezugVmpro9 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Bimonthvalue = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    BisherigeJahresNettoPraemie = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Bonusbetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Bonuseingang = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    BruttopraemieGemaessZahlweise = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    BruttoVertrag = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    BuchenAutomatisch = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Cbc = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Ccxid = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ccximport = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourtageAb = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Courtagesplit = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CourtagesplitBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CourtageBezugsgroesseFormel = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourtageBis = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CourtageFormelBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CourtageProzent = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    CourtageZahlweise = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Courtformelbetragzv = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Courtformelzv = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourtManuell = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Courtprozzv = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Courtprozzvb = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DeckungBis = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DeckungVon = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Defzeit = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Dyvm1 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dyvm10 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dyvm2 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dyvm3 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dyvm4 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dyvm5 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dyvm6 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dyvm7 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dyvm8 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Dyvm9 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    EinzelpraemienErfassen = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    EloGid = table.Column<string>(type: "varchar(38)", maxLength: 38, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Erloeskonto = table.Column<int>(type: "int", nullable: true),
                    Extid = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Faellig = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FeeArt = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FeeBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FeeJahresZahlBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FeePraemie = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FeeProz = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FeeProzB = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FeeProzV = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FestwertPraemieVom = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FNettoJPraemie = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    FPoliceGeprueft = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    FPoliceVorhanden = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Fronter = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FrontingPolice = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GdvDatenVom = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    GdvIgnore = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    GebuehrNetto = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GebuehrZw = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    GekuendigtVon = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GekuendWv = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Gesellschaft = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gevo = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gevoid = table.Column<int>(type: "int", nullable: true),
                    HaftungMakler = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm1 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm10 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm2 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm3 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm4 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm5 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm6 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm7 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm8 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HaftungVm9 = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HatFestwertBeteiligung = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    InvitatioDatum = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsHistorie = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsJPraemie = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsKorrespondenzMakler = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Jahrescourtage = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Kickback = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    KickbackBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Konto = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kommakler = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Komvers = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Kontobezeichnung = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KorrespondenzMaklerBis = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Kostenstelle = table.Column<int>(type: "int", nullable: true),
                    Kuendigung = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LetzeAnfrage = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LetzteFaelligkeit = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LetzteNettopraemie = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    LetzteProvision = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    LetzterNachtrag = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LokalCourtage = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    LokalCourtageBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    LokalFee = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    LokalFeeBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    LokalMahnDatum = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LokalPolice = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LokalSteuer = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    LokalSteuerBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    LtFaelligBis = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LtPraemiebrutto = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Kommentar = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MahnstopBis = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    MaklerFuehrtVersSteuerAb = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Matchcode = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MindestJahresNettopraermie = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ModellVmprovis = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MPraemieFronting = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    NachtragNr = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NedVstCheck = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nettoisiert = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    NonAdmittedFinc = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    NVnr = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Overrider = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    OverriderBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Parentid = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pricing = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Produkt = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Produktgruppe = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProduktgruppeId = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviMaxAp = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviMaxDy = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviMaxFp = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Provisionsreferenzdatum = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProvisMonat = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProvisTag = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prtausschluss = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Rabatt = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    RechnungAnNl = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RechnungFwDatum = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RechnungsMail = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Renta = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    RGDruckstop = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    RisikoAllgemein = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RisikoOrt = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RisikoPlz = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RisikoStrasse = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Risikotraeger = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rvart = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RVKumulnr = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rvnummer = table.Column<int>(type: "int", nullable: true),
                    RVRelKumulsumme = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    RVRelSumme = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    S2_01 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_02 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_03 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_04 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_05 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_06 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_07 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_08 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_09 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_10 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_11 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_12 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    S2_13 = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sachbearbeiter = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sammelvertrag = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Sammelvertragsnr = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SammelVtId = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchadenBetJaNein = table.Column<string>(type: "varchar(4)", maxLength: 4, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Schlagwoerter = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchwebeZuVertrag = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SEPAEinzugsmandat = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    SEPAMandatsreferenz = table.Column<string>(type: "varchar(35)", maxLength: 35, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SepaSddType = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Sicherungsschein = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Sourceid = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpartenberechnAufschub = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    SpartenberechnungAus = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    SpartenCounter = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SperrdatumVUAbrechnung = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    StandNr = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatCharges = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StatChargesBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Statpolice = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatpoliceDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Statpraemie = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatpraemieDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Status = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Statusgrund = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StopAbrechnungBis = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    StopZahlungBis = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Storno = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Stornoges = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Stornohaft = table.Column<int>(type: "int", nullable: true),
                    StornoVm1 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StornoVm10 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StornoVm2 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StornoVm3 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StornoVm4 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StornoVm5 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StornoVm6 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StornoVm7 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StornoVm8 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    StornoVm9 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Sumbuildings = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Sumcontents = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Sumpd = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Sumstocks = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ZPraemie = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ZQuote = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Zugangsdatum = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ZugangsdatumJjjj = table.Column<int>(type: "int", nullable: true),
                    ZugangsdatumJjjjmm = table.Column<int>(type: "int", nullable: true),
                    Zuordnung = table.Column<string>(type: "varchar(6)", maxLength: 6, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VertragDetails", x => x.VertragId);
                    table.ForeignKey(
                        name: "FK_VertragDetails_Vertraege_VertragId",
                        column: x => x.VertragId,
                        principalTable: "Vertraege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VertragFinanzen",
                columns: table => new
                {
                    VertragId = table.Column<int>(type: "int", nullable: false),
                    ApBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ApBuchungsdatum = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    BwSumme = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Bwsummezv = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DifferenzCourtage = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    DifferenzCourtageBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    EffektivcourtageProzent = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    PraemieNetto = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ProgrammCourtage = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ProgrammCourtageBetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Jahrespraemie = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Jahressteuerbetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Steuer = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    SteuerZw = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Zuschlagbetrag = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    ZuschlagbetragZw = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VertragFinanzen", x => x.VertragId);
                    table.ForeignKey(
                        name: "FK_VertragFinanzen_Vertraege_VertragId",
                        column: x => x.VertragId,
                        principalTable: "Vertraege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VertragHistorien",
                columns: table => new
                {
                    VertragId = table.Column<int>(type: "int", nullable: false),
                    Historiendatum = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Historiengrund = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HistorieZuVertrag = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HonorarVm1 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HonorarVm10 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HonorarVm2 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HonorarVm3 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HonorarVm4 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HonorarVm5 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HonorarVm6 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HonorarVm7 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HonorarVm8 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    HonorarVm9 = table.Column<decimal>(type: "decimal(65,30)", nullable: true),
                    Hpvahb = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HpvGruppe = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VertragHistorien", x => x.VertragId);
                    table.ForeignKey(
                        name: "FK_VertragHistorien_Vertraege_VertragId",
                        column: x => x.VertragId,
                        principalTable: "Vertraege",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_KrvSparten_AmsId",
                table: "KrvSparten",
                column: "AmsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KrvSparten_Key",
                table: "KrvSparten",
                column: "Key");

            migrationBuilder.CreateIndex(
                name: "IX_Kunden_AmsId",
                table: "Kunden",
                column: "AmsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vertraege_AmsId",
                table: "Vertraege",
                column: "AmsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vertraege_Key",
                table: "Vertraege",
                column: "Key");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KrvSparten");

            migrationBuilder.DropTable(
                name: "KundenFinanzen");

            migrationBuilder.DropTable(
                name: "KundenKontakte");

            migrationBuilder.DropTable(
                name: "KundenPersonenDetails");

            migrationBuilder.DropTable(
                name: "VertragBanken");

            migrationBuilder.DropTable(
                name: "VertragDetails");

            migrationBuilder.DropTable(
                name: "VertragFinanzen");

            migrationBuilder.DropTable(
                name: "VertragHistorien");

            migrationBuilder.DropTable(
                name: "Vertraege");

            migrationBuilder.DropTable(
                name: "Kunden");
        }
    }
}
