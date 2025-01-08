using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Estudantes.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EducationalInstitution",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalInstitution", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GraduationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EducationalnstitutionId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Course_EducationalInstitution_EducationalnstitutionId",
                        column: x => x.EducationalnstitutionId,
                        principalTable: "EducationalInstitution",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Address_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "AC", "Acre" },
                    { "AL", "Alagoas" },
                    { "AM", "Amazonas" },
                    { "BA", "Bahia" },
                    { "CE", "Ceará" },
                    { "DF", "Distrito Federal" },
                    { "ES", "Espírito Santo" },
                    { "GO", "Goiás" },
                    { "MA", "Maranhão" },
                    { "MG", "Minas Gerais" },
                    { "MS", "Mato Grosso do Sul" },
                    { "MT", "Mato Grosso" },
                    { "PA", "Pará" },
                    { "PB", "Paraíba" },
                    { "PE", "Pernambuco" },
                    { "PI", "Piauí" },
                    { "PR", "Paraná" },
                    { "RJ", "Rio de Janeiro" },
                    { "RN", "Rio Grande do Norte" },
                    { "RO", "Rondônia" },
                    { "RR", "Roraima" },
                    { "RS", "Rio Grande do Sul" },
                    { "SC", "Santa Catarina" },
                    { "SE", "Sergipe" },
                    { "SP", "São Paulo" },
                    { "TO", "Tocantins" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "StateId" },
                values: new object[,]
                {
                    { "1", "Rio Branco", "AC" },
                    { "10", "Porto Walter", "AC" },
                    { "100", "Barra do Garças", "MT" },
                    { "101", "Campo Grande", "MS" },
                    { "102", "Dourados", "MS" },
                    { "103", "Três Lagoas", "MS" },
                    { "104", "Ponta Porã", "MS" },
                    { "105", "Corumbá", "MS" },
                    { "106", "Naviraí", "MS" },
                    { "107", "Sidrolândia", "MS" },
                    { "108", "Aquidauana", "MS" },
                    { "109", "Coxim", "MS" },
                    { "11", "Maceió", "AL" },
                    { "110", "São Gabriel do Oeste", "MS" },
                    { "111", "Belo Horizonte", "MG" },
                    { "112", "Uberlândia", "MG" },
                    { "113", "Contagem", "MG" },
                    { "114", "Juiz de Fora", "MG" },
                    { "115", "Montes Claros", "MG" },
                    { "116", "Betim", "MG" },
                    { "117", "Muriaé", "MG" },
                    { "118", "Poços de Caldas", "MG" },
                    { "119", "Ipatinga", "MG" },
                    { "12", "Arapiraca", "AL" },
                    { "120", "Governador Valadares", "MG" },
                    { "121", "Belém", "PA" },
                    { "122", "Ananindeua", "PA" },
                    { "123", "Santarém", "PA" },
                    { "124", "Marabá", "PA" },
                    { "125", "Castanhal", "PA" },
                    { "126", "Parauapebas", "PA" },
                    { "127", "Tailândia", "PA" },
                    { "128", "Altamira", "PA" },
                    { "129", "Barcarena", "PA" },
                    { "13", "Palmeira dos Índios", "AL" },
                    { "130", "Breves", "PA" },
                    { "131", "João Pessoa", "PB" },
                    { "132", "Campina Grande", "PB" },
                    { "133", "Patos", "PB" },
                    { "134", "Cabedelo", "PB" },
                    { "135", "Santa Rita", "PB" },
                    { "136", "Bayeux", "PB" },
                    { "137", "Sousa", "PB" },
                    { "138", "Cajazeiras", "PB" },
                    { "139", "São Bento", "PB" },
                    { "14", "Rio Largo", "AL" },
                    { "140", "Monteiro", "PB" },
                    { "141", "Curitiba", "PR" },
                    { "142", "Londrina", "PR" },
                    { "143", "Maringá", "PR" },
                    { "144", "Ponta Grossa", "PR" },
                    { "145", "Cascavel", "PR" },
                    { "146", "Foz do Iguaçu", "PR" },
                    { "147", "Guarapuava", "PR" },
                    { "148", "São José dos Pinhais", "PR" },
                    { "149", "Paranaguá", "PR" },
                    { "15", "Penedo", "AL" },
                    { "150", "Araucária", "PR" },
                    { "151", "Recife", "PE" },
                    { "152", "Olinda", "PE" },
                    { "153", "Jaboatão dos Guararapes", "PE" },
                    { "154", "Caruaru", "PE" },
                    { "155", "Petrolina", "PE" },
                    { "156", "Cabo de Santo Agostinho", "PE" },
                    { "157", "Garanhuns", "PE" },
                    { "158", "Igarassu", "PE" },
                    { "159", "Afogados da Ingazeira", "PE" },
                    { "16", "Delmiro Gouveia", "AL" },
                    { "160", "Arcoverde", "PE" },
                    { "161", "Teresina", "PI" },
                    { "162", "Parnaíba", "PI" },
                    { "163", "Picos", "PI" },
                    { "164", "Campo Maior", "PI" },
                    { "165", "Floriano", "PI" },
                    { "166", "Barras", "PI" },
                    { "167", "São Raimundo Nonato", "PI" },
                    { "168", "Uruçuí", "PI" },
                    { "169", "Oeiras", "PI" },
                    { "17", "União dos Palmares", "AL" },
                    { "170", "Barras", "PI" },
                    { "171", "Rio de Janeiro", "RJ" },
                    { "172", "Niterói", "RJ" },
                    { "173", "Nova Iguaçu", "RJ" },
                    { "174", "São Gonçalo", "RJ" },
                    { "175", "Duque de Caxias", "RJ" },
                    { "176", "Volta Redonda", "RJ" },
                    { "177", "Cabo Frio", "RJ" },
                    { "178", "Macaé", "RJ" },
                    { "179", "Belford Roxo", "RJ" },
                    { "18", "Murici", "AL" },
                    { "180", "Angra dos Reis", "RJ" },
                    { "181", "Natal", "RN" },
                    { "182", "Mossoró", "RN" },
                    { "183", "Parnamirim", "RN" },
                    { "184", "Caicó", "RN" },
                    { "185", "São Gonçalo do Amarante", "RN" },
                    { "186", "Açu", "RN" },
                    { "187", "Currais Novos", "RN" },
                    { "188", "Santa Cruz", "RN" },
                    { "189", "Pau dos Ferros", "RN" },
                    { "19", "Coruripe", "AL" },
                    { "190", "João Câmara", "RN" },
                    { "191", "Porto Alegre", "RS" },
                    { "192", "Caxias do Sul", "RS" },
                    { "193", "Pelotas", "RS" },
                    { "194", "Santa Maria", "RS" },
                    { "195", "Viamão", "RS" },
                    { "196", "Gravataí", "RS" },
                    { "197", "Passo Fundo", "RS" },
                    { "198", "São Leopoldo", "RS" },
                    { "199", "Novo Hamburgo", "RS" },
                    { "2", "Cruzeiro do Sul", "AC" },
                    { "20", "Satuba", "AL" },
                    { "200", "Rio Grande", "RS" },
                    { "201", "Porto Velho", "RO" },
                    { "202", "Ji-Paraná", "RO" },
                    { "203", "Ariquemes", "RO" },
                    { "204", "Cacoal", "RO" },
                    { "205", "Vilhena", "RO" },
                    { "206", "Rolim de Moura", "RO" },
                    { "207", "Ouro Preto do Oeste", "RO" },
                    { "208", "Guajará-Mirim", "RO" },
                    { "209", "São Francisco do Guaporé", "RO" },
                    { "21", "Manaus", "AM" },
                    { "210", "Nova Mamoré", "RO" },
                    { "211", "Boa Vista", "RR" },
                    { "212", "Rorainópolis", "RR" },
                    { "213", "Caracaraí", "RR" },
                    { "214", "Cantá", "RR" },
                    { "215", "Mucajaí", "RR" },
                    { "216", "Normandia", "RR" },
                    { "217", "São João da Baliza", "RR" },
                    { "218", "São Luiz", "RR" },
                    { "219", "Uiramutã", "RR" },
                    { "22", "Parintins", "AM" },
                    { "220", "Iracema", "RR" },
                    { "221", "Florianópolis", "SC" },
                    { "222", "Joinville", "SC" },
                    { "223", "Blumenau", "SC" },
                    { "224", "Chapecó", "SC" },
                    { "225", "São José", "SC" },
                    { "226", "Criciúma", "SC" },
                    { "227", "Lages", "SC" },
                    { "228", "Itajaí", "SC" },
                    { "229", "Ponta Grossa", "SC" },
                    { "23", "Itacoatiara", "AM" },
                    { "230", "Tubarão", "SC" },
                    { "231", "São Paulo", "SP" },
                    { "232", "Campinas", "SP" },
                    { "233", "Guarulhos", "SP" },
                    { "234", "Santos", "SP" },
                    { "235", "São Bernardo do Campo", "SP" },
                    { "236", "Ribeirão Preto", "SP" },
                    { "237", "Sorocaba", "SP" },
                    { "238", "São José dos Campos", "SP" },
                    { "239", "Bauru", "SP" },
                    { "24", "Manacapuru", "AM" },
                    { "240", "Mogi das Cruzes", "SP" },
                    { "241", "Aracaju", "SE" },
                    { "242", "Nossa Senhora do Socorro", "SE" },
                    { "243", "Lagarto", "SE" },
                    { "244", "Itabaiana", "SE" },
                    { "245", "Propriá", "SE" },
                    { "246", "Estância", "SE" },
                    { "247", "Itabaianinha", "SE" },
                    { "248", "São Cristóvão", "SE" },
                    { "249", "Simão Dias", "SE" },
                    { "25", "Coari", "AM" },
                    { "250", "Barra dos Coqueiros", "SE" },
                    { "251", "Palmas", "TO" },
                    { "252", "Araguaína", "TO" },
                    { "253", "Gurupi", "TO" },
                    { "254", "Porto Nacional", "TO" },
                    { "255", "Miracema do Tocantins", "TO" },
                    { "256", "Paraíso do Tocantins", "TO" },
                    { "257", "Tocantinópolis", "TO" },
                    { "258", "Dianópolis", "TO" },
                    { "259", "Augustinópolis", "TO" },
                    { "26", "Tabatinga", "AM" },
                    { "260", "Colinas do Tocantins", "TO" },
                    { "27", "Tefé", "AM" },
                    { "28", "Humaitá", "AM" },
                    { "29", "Boa Vista do Ramos", "AM" },
                    { "3", "Sena Madureira", "AC" },
                    { "30", "Lábrea", "AM" },
                    { "31", "Salvador", "BA" },
                    { "32", "Feira de Santana", "BA" },
                    { "33", "Vitória da Conquista", "BA" },
                    { "34", "Camaçari", "BA" },
                    { "35", "Juazeiro", "BA" },
                    { "36", "Ilhéus", "BA" },
                    { "37", "Itabuna", "BA" },
                    { "38", "Lauro de Freitas", "BA" },
                    { "39", "Porto Seguro", "BA" },
                    { "4", "Tarauacá", "AC" },
                    { "40", "Teixeira de Freitas", "BA" },
                    { "41", "Fortaleza", "CE" },
                    { "42", "Juazeiro do Norte", "CE" },
                    { "43", "Caucaia", "CE" },
                    { "44", "Sobral", "CE" },
                    { "45", "Maracanaú", "CE" },
                    { "46", "Crato", "CE" },
                    { "47", "Aquiraz", "CE" },
                    { "48", "Iguatu", "CE" },
                    { "49", "São Gonçalo do Amarante", "CE" },
                    { "5", "Feijó", "AC" },
                    { "50", "Tianguá", "CE" },
                    { "51", "Vitória", "ES" },
                    { "52", "Vila Velha", "ES" },
                    { "53", "Serra", "ES" },
                    { "54", "Cariacica", "ES" },
                    { "55", "Guarapari", "ES" },
                    { "56", "Linhares", "ES" },
                    { "57", "Colatina", "ES" },
                    { "58", "Cachoeiro de Itapemirim", "ES" },
                    { "59", "São Mateus", "ES" },
                    { "6", "Brasiléia", "AC" },
                    { "60", "Nova Venécia", "ES" },
                    { "61", "Goiânia", "GO" },
                    { "62", "Aparecida de Goiânia", "GO" },
                    { "63", "Anápolis", "GO" },
                    { "64", "Rio Verde", "GO" },
                    { "65", "Luziânia", "GO" },
                    { "66", "Catalão", "GO" },
                    { "67", "Jataí", "GO" },
                    { "68", "Itumbiara", "GO" },
                    { "69", "Águas Lindas de Goiás", "GO" },
                    { "7", "Xapuri", "AC" },
                    { "70", "Planaltina", "GO" },
                    { "71", "Brasília", "DF" },
                    { "72", "Gama", "DF" },
                    { "73", "Taguatinga", "DF" },
                    { "74", "Ceilândia", "DF" },
                    { "75", "Planaltina", "DF" },
                    { "76", "Águas Claras", "DF" },
                    { "77", "Samambaia", "DF" },
                    { "78", "Recanto das Emas", "DF" },
                    { "79", "Lago Sul", "DF" },
                    { "8", "Epitaciolândia", "AC" },
                    { "80", "Lago Norte", "DF" },
                    { "81", "São Luís", "MA" },
                    { "82", "Imperatriz", "MA" },
                    { "83", "Caxias", "MA" },
                    { "84", "Timon", "MA" },
                    { "85", "São José de Ribamar", "MA" },
                    { "86", "Codó", "MA" },
                    { "87", "Bacabal", "MA" },
                    { "88", "Açailândia", "MA" },
                    { "89", "Chapadinha", "MA" },
                    { "9", "Plácido de Castro", "AC" },
                    { "90", "Paço do Lumiar", "MA" },
                    { "91", "Cuiabá", "MT" },
                    { "92", "Várzea Grande", "MT" },
                    { "93", "Rondonópolis", "MT" },
                    { "94", "Sinop", "MT" },
                    { "95", "Lucas do Rio Verde", "MT" },
                    { "96", "Tangará da Serra", "MT" },
                    { "97", "Alta Floresta", "MT" },
                    { "98", "Sorriso", "MT" },
                    { "99", "Cáceres", "MT" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_CityId",
                table: "Address",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_EducationalnstitutionId",
                table: "Course",
                column: "EducationalnstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_AddressId",
                table: "Students",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "EducationalInstitution");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}
