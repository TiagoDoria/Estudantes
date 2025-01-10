using Estudantes.Models;
using Microsoft.EntityFrameworkCore;

namespace Estudantes.Data
{
    public class StudentContext : DbContext
    {
        public StudentContext()
        {
        }

        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<EducationalInstitution> Institutions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EducationalInstitution>().HasData(
                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Universidade Federal do Acre (UFAC)", CityId = "1" },
                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Faculdade da Amazônia Ocidental (FAAO)", CityId = "2" },

                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Universidade Federal do Amazonas (UFAM)", CityId = "21" },
                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Universidade do Estado do Amazonas (UEA)", CityId = "21" },

                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Universidade Federal de Alagoas (UFAL)", CityId = "11" },
                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Faculdade Integrada de Arapiraca (FIA)", CityId = "12" },

                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Universidade Federal da Bahia (UFBA)", CityId = "31" },
                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Universidade Estadual de Feira de Santana (UEFS)", CityId = "32" },

                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Universidade de São Paulo (USP)", CityId = "231" },
                 new EducationalInstitution { Id = Guid.NewGuid().ToString(), Name = "Universidade Estadual de Campinas (UNICAMP)", CityId = "232" }


            );

            // Seed States and Cities
            modelBuilder.Entity<State>().HasData(
                new State { Id = "AC", Name = "Acre" },
                new State { Id = "AL", Name = "Alagoas" },
                new State { Id = "AM", Name = "Amazonas" },
                new State { Id = "BA", Name = "Bahia" },
                new State { Id = "CE", Name = "Ceará" },
                new State { Id = "ES", Name = "Espírito Santo" },
                new State { Id = "GO", Name = "Goiás" },
                new State { Id = "MA", Name = "Maranhão" },
                new State { Id = "MT", Name = "Mato Grosso" },
                new State { Id = "MS", Name = "Mato Grosso do Sul" },
                new State { Id = "MG", Name = "Minas Gerais" },
                new State { Id = "PA", Name = "Pará" },
                new State { Id = "PB", Name = "Paraíba" },
                new State { Id = "PR", Name = "Paraná" },
                new State { Id = "PE", Name = "Pernambuco" },
                new State { Id = "PI", Name = "Piauí" },
                new State { Id = "RJ", Name = "Rio de Janeiro" },
                new State { Id = "RN", Name = "Rio Grande do Norte" },
                new State { Id = "RS", Name = "Rio Grande do Sul" },
                new State { Id = "RO", Name = "Rondônia" },
                new State { Id = "RR", Name = "Roraima" },
                new State { Id = "SC", Name = "Santa Catarina" },
                new State { Id = "SP", Name = "São Paulo" },
                new State { Id = "SE", Name = "Sergipe" },
                new State { Id = "TO", Name = "Tocantins" },
                new State { Id = "DF", Name = "Distrito Federal" }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = "1", Name = "Rio Branco", StateId = "AC" },
                new City { Id = "2", Name = "Cruzeiro do Sul", StateId = "AC" },
                new City { Id = "3", Name = "Sena Madureira", StateId = "AC" },
                new City { Id = "4", Name = "Tarauacá", StateId = "AC" },
                new City { Id = "5", Name = "Feijó", StateId = "AC" },
                new City { Id = "6", Name = "Brasiléia", StateId = "AC" },
                new City { Id = "7", Name = "Xapuri", StateId = "AC" },
                new City { Id = "8", Name = "Epitaciolândia", StateId = "AC" },
                new City { Id = "9", Name = "Plácido de Castro", StateId = "AC" },
                new City { Id = "10", Name = "Porto Walter", StateId = "AC" },

                new City { Id = "11", Name = "Maceió", StateId = "AL" },
                new City { Id = "12", Name = "Arapiraca", StateId = "AL" },
                new City { Id = "13", Name = "Palmeira dos Índios", StateId = "AL" },
                new City { Id = "14", Name = "Rio Largo", StateId = "AL" },
                new City { Id = "15", Name = "Penedo", StateId = "AL" },
                new City { Id = "16", Name = "Delmiro Gouveia", StateId = "AL" },
                new City { Id = "17", Name = "União dos Palmares", StateId = "AL" },
                new City { Id = "18", Name = "Murici", StateId = "AL" },
                new City { Id = "19", Name = "Coruripe", StateId = "AL" },
                new City { Id = "20", Name = "Satuba", StateId = "AL" },

                new City { Id = "21", Name = "Manaus", StateId = "AM" },
                new City { Id = "22", Name = "Parintins", StateId = "AM" },
                new City { Id = "23", Name = "Itacoatiara", StateId = "AM" },
                new City { Id = "24", Name = "Manacapuru", StateId = "AM" },
                new City { Id = "25", Name = "Coari", StateId = "AM" },
                new City { Id = "26", Name = "Tabatinga", StateId = "AM" },
                new City { Id = "27", Name = "Tefé", StateId = "AM" },
                new City { Id = "28", Name = "Humaitá", StateId = "AM" },
                new City { Id = "29", Name = "Boa Vista do Ramos", StateId = "AM" },
                new City { Id = "30", Name = "Lábrea", StateId = "AM" },

                new City { Id = "31", Name = "Salvador", StateId = "BA" },
                new City { Id = "32", Name = "Feira de Santana", StateId = "BA" },
                new City { Id = "33", Name = "Vitória da Conquista", StateId = "BA" },
                new City { Id = "34", Name = "Camaçari", StateId = "BA" },
                new City { Id = "35", Name = "Juazeiro", StateId = "BA" },
                new City { Id = "36", Name = "Ilhéus", StateId = "BA" },
                new City { Id = "37", Name = "Itabuna", StateId = "BA" },
                new City { Id = "38", Name = "Lauro de Freitas", StateId = "BA" },
                new City { Id = "39", Name = "Porto Seguro", StateId = "BA" },
                new City { Id = "40", Name = "Teixeira de Freitas", StateId = "BA" },

                new City { Id = "41", Name = "Fortaleza", StateId = "CE" },
                new City { Id = "42", Name = "Juazeiro do Norte", StateId = "CE" },
                new City { Id = "43", Name = "Caucaia", StateId = "CE" },
                new City { Id = "44", Name = "Sobral", StateId = "CE" },
                new City { Id = "45", Name = "Maracanaú", StateId = "CE" },
                new City { Id = "46", Name = "Crato", StateId = "CE" },
                new City { Id = "47", Name = "Aquiraz", StateId = "CE" },
                new City { Id = "48", Name = "Iguatu", StateId = "CE" },
                new City { Id = "49", Name = "São Gonçalo do Amarante", StateId = "CE" },
                new City { Id = "50", Name = "Tianguá", StateId = "CE" },

                new City { Id = "51", Name = "Vitória", StateId = "ES" },
                new City { Id = "52", Name = "Vila Velha", StateId = "ES" },
                new City { Id = "53", Name = "Serra", StateId = "ES" },
                new City { Id = "54", Name = "Cariacica", StateId = "ES" },
                new City { Id = "55", Name = "Guarapari", StateId = "ES" },
                new City { Id = "56", Name = "Linhares", StateId = "ES" },
                new City { Id = "57", Name = "Colatina", StateId = "ES" },
                new City { Id = "58", Name = "Cachoeiro de Itapemirim", StateId = "ES" },
                new City { Id = "59", Name = "São Mateus", StateId = "ES" },
                new City { Id = "60", Name = "Nova Venécia", StateId = "ES" },

                new City { Id = "61", Name = "Goiânia", StateId = "GO" },
                new City { Id = "62", Name = "Aparecida de Goiânia", StateId = "GO" },
                new City { Id = "63", Name = "Anápolis", StateId = "GO" },
                new City { Id = "64", Name = "Rio Verde", StateId = "GO" },
                new City { Id = "65", Name = "Luziânia", StateId = "GO" },
                new City { Id = "66", Name = "Catalão", StateId = "GO" },
                new City { Id = "67", Name = "Jataí", StateId = "GO" },
                new City { Id = "68", Name = "Itumbiara", StateId = "GO" },
                new City { Id = "69", Name = "Águas Lindas de Goiás", StateId = "GO" },
                new City { Id = "70", Name = "Planaltina", StateId = "GO" },

                new City { Id = "71", Name = "Brasília", StateId = "DF" },
                new City { Id = "72", Name = "Gama", StateId = "DF" },
                new City { Id = "73", Name = "Taguatinga", StateId = "DF" },
                new City { Id = "74", Name = "Ceilândia", StateId = "DF" },
                new City { Id = "75", Name = "Planaltina", StateId = "DF" },
                new City { Id = "76", Name = "Águas Claras", StateId = "DF" },
                new City { Id = "77", Name = "Samambaia", StateId = "DF" },
                new City { Id = "78", Name = "Recanto das Emas", StateId = "DF" },
                new City { Id = "79", Name = "Lago Sul", StateId = "DF" },
                new City { Id = "80", Name = "Lago Norte", StateId = "DF" },

                new City { Id = "81", Name = "São Luís", StateId = "MA" },
                new City { Id = "82", Name = "Imperatriz", StateId = "MA" },
                new City { Id = "83", Name = "Caxias", StateId = "MA" },
                new City { Id = "84", Name = "Timon", StateId = "MA" },
                new City { Id = "85", Name = "São José de Ribamar", StateId = "MA" },
                new City { Id = "86", Name = "Codó", StateId = "MA" },
                new City { Id = "87", Name = "Bacabal", StateId = "MA" },
                new City { Id = "88", Name = "Açailândia", StateId = "MA" },
                new City { Id = "89", Name = "Chapadinha", StateId = "MA" },
                new City { Id = "90", Name = "Paço do Lumiar", StateId = "MA" },

                new City { Id = "91", Name = "Cuiabá", StateId = "MT" },
                new City { Id = "92", Name = "Várzea Grande", StateId = "MT" },
                new City { Id = "93", Name = "Rondonópolis", StateId = "MT" },
                new City { Id = "94", Name = "Sinop", StateId = "MT" },
                new City { Id = "95", Name = "Lucas do Rio Verde", StateId = "MT" },
                new City { Id = "96", Name = "Tangará da Serra", StateId = "MT" },
                new City { Id = "97", Name = "Alta Floresta", StateId = "MT" },
                new City { Id = "98", Name = "Sorriso", StateId = "MT" },
                new City { Id = "99", Name = "Cáceres", StateId = "MT" },
                new City { Id = "100", Name = "Barra do Garças", StateId = "MT" },

                new City { Id = "101", Name = "Campo Grande", StateId = "MS" },
                new City { Id = "102", Name = "Dourados", StateId = "MS" },
                new City { Id = "103", Name = "Três Lagoas", StateId = "MS" },
                new City { Id = "104", Name = "Ponta Porã", StateId = "MS" },
                new City { Id = "105", Name = "Corumbá", StateId = "MS" },
                new City { Id = "106", Name = "Naviraí", StateId = "MS" },
                new City { Id = "107", Name = "Sidrolândia", StateId = "MS" },
                new City { Id = "108", Name = "Aquidauana", StateId = "MS" },
                new City { Id = "109", Name = "Coxim", StateId = "MS" },
                new City { Id = "110", Name = "São Gabriel do Oeste", StateId = "MS" },

                new City { Id = "111", Name = "Belo Horizonte", StateId = "MG" },
                new City { Id = "112", Name = "Uberlândia", StateId = "MG" },
                new City { Id = "113", Name = "Contagem", StateId = "MG" },
                new City { Id = "114", Name = "Juiz de Fora", StateId = "MG" },
                new City { Id = "115", Name = "Montes Claros", StateId = "MG" },
                new City { Id = "116", Name = "Betim", StateId = "MG" },
                new City { Id = "117", Name = "Muriaé", StateId = "MG" },
                new City { Id = "118", Name = "Poços de Caldas", StateId = "MG" },
                new City { Id = "119", Name = "Ipatinga", StateId = "MG" },
                new City { Id = "120", Name = "Governador Valadares", StateId = "MG" },

                new City { Id = "121", Name = "Belém", StateId = "PA" },
                new City { Id = "122", Name = "Ananindeua", StateId = "PA" },
                new City { Id = "123", Name = "Santarém", StateId = "PA" },
                new City { Id = "124", Name = "Marabá", StateId = "PA" },
                new City { Id = "125", Name = "Castanhal", StateId = "PA" },
                new City { Id = "126", Name = "Parauapebas", StateId = "PA" },
                new City { Id = "127", Name = "Tailândia", StateId = "PA" },
                new City { Id = "128", Name = "Altamira", StateId = "PA" },
                new City { Id = "129", Name = "Barcarena", StateId = "PA" },
                new City { Id = "130", Name = "Breves", StateId = "PA" },

                new City { Id = "131", Name = "João Pessoa", StateId = "PB" },
                new City { Id = "132", Name = "Campina Grande", StateId = "PB" },
                new City { Id = "133", Name = "Patos", StateId = "PB" },
                new City { Id = "134", Name = "Cabedelo", StateId = "PB" },
                new City { Id = "135", Name = "Santa Rita", StateId = "PB" },
                new City { Id = "136", Name = "Bayeux", StateId = "PB" },
                new City { Id = "137", Name = "Sousa", StateId = "PB" },
                new City { Id = "138", Name = "Cajazeiras", StateId = "PB" },
                new City { Id = "139", Name = "São Bento", StateId = "PB" },
                new City { Id = "140", Name = "Monteiro", StateId = "PB" },

                new City { Id = "141", Name = "Curitiba", StateId = "PR" },
                new City { Id = "142", Name = "Londrina", StateId = "PR" },
                new City { Id = "143", Name = "Maringá", StateId = "PR" },
                new City { Id = "144", Name = "Ponta Grossa", StateId = "PR" },
                new City { Id = "145", Name = "Cascavel", StateId = "PR" },
                new City { Id = "146", Name = "Foz do Iguaçu", StateId = "PR" },
                new City { Id = "147", Name = "Guarapuava", StateId = "PR" },
                new City { Id = "148", Name = "São José dos Pinhais", StateId = "PR" },
                new City { Id = "149", Name = "Paranaguá", StateId = "PR" },
                new City { Id = "150", Name = "Araucária", StateId = "PR" },

                new City { Id = "151", Name = "Recife", StateId = "PE" },
                new City { Id = "152", Name = "Olinda", StateId = "PE" },
                new City { Id = "153", Name = "Jaboatão dos Guararapes", StateId = "PE" },
                new City { Id = "154", Name = "Caruaru", StateId = "PE" },
                new City { Id = "155", Name = "Petrolina", StateId = "PE" },
                new City { Id = "156", Name = "Cabo de Santo Agostinho", StateId = "PE" },
                new City { Id = "157", Name = "Garanhuns", StateId = "PE" },
                new City { Id = "158", Name = "Igarassu", StateId = "PE" },
                new City { Id = "159", Name = "Afogados da Ingazeira", StateId = "PE" },
                new City { Id = "160", Name = "Arcoverde", StateId = "PE" },

                new City { Id = "161", Name = "Teresina", StateId = "PI" },
                new City { Id = "162", Name = "Parnaíba", StateId = "PI" },
                new City { Id = "163", Name = "Picos", StateId = "PI" },
                new City { Id = "164", Name = "Campo Maior", StateId = "PI" },
                new City { Id = "165", Name = "Floriano", StateId = "PI" },
                new City { Id = "166", Name = "Barras", StateId = "PI" },
                new City { Id = "167", Name = "São Raimundo Nonato", StateId = "PI" },
                new City { Id = "168", Name = "Uruçuí", StateId = "PI" },
                new City { Id = "169", Name = "Oeiras", StateId = "PI" },
                new City { Id = "170", Name = "Barras", StateId = "PI" },


                new City { Id = "171", Name = "Rio de Janeiro", StateId = "RJ" },
                new City { Id = "172", Name = "Niterói", StateId = "RJ" },
                new City { Id = "173", Name = "Nova Iguaçu", StateId = "RJ" },
                new City { Id = "174", Name = "São Gonçalo", StateId = "RJ" },
                new City { Id = "175", Name = "Duque de Caxias", StateId = "RJ" },
                new City { Id = "176", Name = "Volta Redonda", StateId = "RJ" },
                new City { Id = "177", Name = "Cabo Frio", StateId = "RJ" },
                new City { Id = "178", Name = "Macaé", StateId = "RJ" },
                new City { Id = "179", Name = "Belford Roxo", StateId = "RJ" },
                new City { Id = "180", Name = "Angra dos Reis", StateId = "RJ" },


                new City { Id = "181", Name = "Natal", StateId = "RN" },
                new City { Id = "182", Name = "Mossoró", StateId = "RN" },
                new City { Id = "183", Name = "Parnamirim", StateId = "RN" },
                new City { Id = "184", Name = "Caicó", StateId = "RN" },
                new City { Id = "185", Name = "São Gonçalo do Amarante", StateId = "RN" },
                new City { Id = "186", Name = "Açu", StateId = "RN" },
                new City { Id = "187", Name = "Currais Novos", StateId = "RN" },
                new City { Id = "188", Name = "Santa Cruz", StateId = "RN" },
                new City { Id = "189", Name = "Pau dos Ferros", StateId = "RN" },
                new City { Id = "190", Name = "João Câmara", StateId = "RN" },

                new City { Id = "191", Name = "Porto Alegre", StateId = "RS" },
                new City { Id = "192", Name = "Caxias do Sul", StateId = "RS" },
                new City { Id = "193", Name = "Pelotas", StateId = "RS" },
                new City { Id = "194", Name = "Santa Maria", StateId = "RS" },
                new City { Id = "195", Name = "Viamão", StateId = "RS" },
                new City { Id = "196", Name = "Gravataí", StateId = "RS" },
                new City { Id = "197", Name = "Passo Fundo", StateId = "RS" },
                new City { Id = "198", Name = "São Leopoldo", StateId = "RS" },
                new City { Id = "199", Name = "Novo Hamburgo", StateId = "RS" },
                new City { Id = "200", Name = "Rio Grande", StateId = "RS" },

                new City { Id = "201", Name = "Porto Velho", StateId = "RO" },
                new City { Id = "202", Name = "Ji-Paraná", StateId = "RO" },
                new City { Id = "203", Name = "Ariquemes", StateId = "RO" },
                new City { Id = "204", Name = "Cacoal", StateId = "RO" },
                new City { Id = "205", Name = "Vilhena", StateId = "RO" },
                new City { Id = "206", Name = "Rolim de Moura", StateId = "RO" },
                new City { Id = "207", Name = "Ouro Preto do Oeste", StateId = "RO" },
                new City { Id = "208", Name = "Guajará-Mirim", StateId = "RO" },
                new City { Id = "209", Name = "São Francisco do Guaporé", StateId = "RO" },
                new City { Id = "210", Name = "Nova Mamoré", StateId = "RO" },

                new City { Id = "211", Name = "Boa Vista", StateId = "RR" },
                new City { Id = "212", Name = "Rorainópolis", StateId = "RR" },
                new City { Id = "213", Name = "Caracaraí", StateId = "RR" },
                new City { Id = "214", Name = "Cantá", StateId = "RR" },
                new City { Id = "215", Name = "Mucajaí", StateId = "RR" },
                new City { Id = "216", Name = "Normandia", StateId = "RR" },
                new City { Id = "217", Name = "São João da Baliza", StateId = "RR" },
                new City { Id = "218", Name = "São Luiz", StateId = "RR" },
                new City { Id = "219", Name = "Uiramutã", StateId = "RR" },
                new City { Id = "220", Name = "Iracema", StateId = "RR" },

                new City { Id = "221", Name = "Florianópolis", StateId = "SC" },
                new City { Id = "222", Name = "Joinville", StateId = "SC" },
                new City { Id = "223", Name = "Blumenau", StateId = "SC" },
                new City { Id = "224", Name = "Chapecó", StateId = "SC" },
                new City { Id = "225", Name = "São José", StateId = "SC" },
                new City { Id = "226", Name = "Criciúma", StateId = "SC" },
                new City { Id = "227", Name = "Lages", StateId = "SC" },
                new City { Id = "228", Name = "Itajaí", StateId = "SC" },
                new City { Id = "229", Name = "Ponta Grossa", StateId = "SC" },
                new City { Id = "230", Name = "Tubarão", StateId = "SC" },

                new City { Id = "231", Name = "São Paulo", StateId = "SP" },
                new City { Id = "232", Name = "Campinas", StateId = "SP" },
                new City { Id = "233", Name = "Guarulhos", StateId = "SP" },
                new City { Id = "234", Name = "Santos", StateId = "SP" },
                new City { Id = "235", Name = "São Bernardo do Campo", StateId = "SP" },
                new City { Id = "236", Name = "Ribeirão Preto", StateId = "SP" },
                new City { Id = "237", Name = "Sorocaba", StateId = "SP" },
                new City { Id = "238", Name = "São José dos Campos", StateId = "SP" },
                new City { Id = "239", Name = "Bauru", StateId = "SP" },
                new City { Id = "240", Name = "Mogi das Cruzes", StateId = "SP" },


                new City { Id = "241", Name = "Aracaju", StateId = "SE" },
                new City { Id = "242", Name = "Nossa Senhora do Socorro", StateId = "SE" },
                new City { Id = "243", Name = "Lagarto", StateId = "SE" },
                new City { Id = "244", Name = "Itabaiana", StateId = "SE" },
                new City { Id = "245", Name = "Propriá", StateId = "SE" },
                new City { Id = "246", Name = "Estância", StateId = "SE" },
                new City { Id = "247", Name = "Itabaianinha", StateId = "SE" },
                new City { Id = "248", Name = "São Cristóvão", StateId = "SE" },
                new City { Id = "249", Name = "Simão Dias", StateId = "SE" },
                new City { Id = "250", Name = "Barra dos Coqueiros", StateId = "SE" },


                new City { Id = "251", Name = "Palmas", StateId = "TO" },
                new City { Id = "252", Name = "Araguaína", StateId = "TO" },
                new City { Id = "253", Name = "Gurupi", StateId = "TO" },
                new City { Id = "254", Name = "Porto Nacional", StateId = "TO" },
                new City { Id = "255", Name = "Miracema do Tocantins", StateId = "TO" },
                new City { Id = "256", Name = "Paraíso do Tocantins", StateId = "TO" },
                new City { Id = "257", Name = "Tocantinópolis", StateId = "TO" },
                new City { Id = "258", Name = "Dianópolis", StateId = "TO" },
                new City { Id = "259", Name = "Augustinópolis", StateId = "TO" },
                new City { Id = "260", Name = "Colinas do Tocantins", StateId = "TO" }

            );
        }
    }
}
