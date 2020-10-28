using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace serverdespacho.Migrations
{
    public partial class sql : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "_LogAuthenticacionAPI",
                columns: table => new
                {
                    IdLog = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Type = table.Column<string>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Application = table.Column<string>(nullable: false),
                    Method = table.Column<string>(nullable: false),
                    Entity = table.Column<string>(nullable: false),
                    IsException = table.Column<bool>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    Parameters = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__LogAuthenticacionAPI", x => x.IdLog);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Area = table.Column<string>(nullable: true),
                    Organization = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    CodigoDane = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false),
                    Region = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.CodigoDane);
                });

            migrationBuilder.CreateTable(
                name: "EstadosDespachos",
                columns: table => new
                {
                    IdEstado = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosDespachos", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "EstadosOfertas",
                columns: table => new
                {
                    IdEstado = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadosOfertas", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "TiposNotificaciones",
                columns: table => new
                {
                    IdTipoNotificacion = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposNotificaciones", x => x.IdTipoNotificacion);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Catalogos",
                columns: table => new
                {
                    IdCatalogo = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    FechaCreacion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogos", x => x.IdCatalogo);
                    table.ForeignKey(
                        name: "FK_Catalogos_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    CodigoDane = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: true),
                    CodigoDepartamento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.CodigoDane);
                    table.ForeignKey(
                        name: "FK_Municipios_Departamentos_CodigoDepartamento",
                        column: x => x.CodigoDepartamento,
                        principalTable: "Departamentos",
                        principalColumn: "CodigoDane",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notificaciones",
                columns: table => new
                {
                    IdOferta = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdTipoNotificacion = table.Column<int>(nullable: false),
                    Mensaje = table.Column<string>(nullable: false),
                    MensajeCorto = table.Column<string>(maxLength: 160, nullable: false),
                    FechaEnvio = table.Column<DateTime>(nullable: false),
                    Entregada = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notificaciones", x => x.IdOferta);
                    table.ForeignKey(
                        name: "FK_Notificaciones_TiposNotificaciones_IdTipoNotificacion",
                        column: x => x.IdTipoNotificacion,
                        principalTable: "TiposNotificaciones",
                        principalColumn: "IdTipoNotificacion",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notificaciones_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Despachos",
                columns: table => new
                {
                    IdDespacho = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFinOfertas = table.Column<DateTime>(nullable: false),
                    FechaCierreDespacho = table.Column<DateTime>(nullable: false),
                    IdEstado = table.Column<int>(nullable: false),
                    IdMunicipioOrigen = table.Column<int>(nullable: false),
                    IdMunicipioDestino = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despachos", x => x.IdDespacho);
                    table.ForeignKey(
                        name: "FK_Despachos_EstadosDespachos_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "EstadosDespachos",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despachos_Municipios_IdMunicipioDestino",
                        column: x => x.IdMunicipioDestino,
                        principalTable: "Municipios",
                        principalColumn: "CodigoDane",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despachos_Municipios_IdMunicipioOrigen",
                        column: x => x.IdMunicipioOrigen,
                        principalTable: "Municipios",
                        principalColumn: "CodigoDane",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Despachos_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Servicios",
                columns: table => new
                {
                    IdServicio = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCatalogo = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    IdMunicipioOrigen = table.Column<int>(nullable: false),
                    IdMunicipioDestino = table.Column<int>(nullable: false),
                    Precio = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicios", x => x.IdServicio);
                    table.ForeignKey(
                        name: "FK_Servicios_Catalogos_IdCatalogo",
                        column: x => x.IdCatalogo,
                        principalTable: "Catalogos",
                        principalColumn: "IdCatalogo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_Municipios_IdMunicipioDestino",
                        column: x => x.IdMunicipioDestino,
                        principalTable: "Municipios",
                        principalColumn: "CodigoDane",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Servicios_Municipios_IdMunicipioOrigen",
                        column: x => x.IdMunicipioOrigen,
                        principalTable: "Municipios",
                        principalColumn: "CodigoDane",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ofertas",
                columns: table => new
                {
                    IdOferta = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaPostulacion = table.Column<DateTime>(nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(nullable: true),
                    Precio = table.Column<long>(nullable: false),
                    IdEstado = table.Column<int>(nullable: false),
                    IdDespacho = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ofertas", x => x.IdOferta);
                    table.ForeignKey(
                        name: "FK_Ofertas_Despachos_IdDespacho",
                        column: x => x.IdDespacho,
                        principalTable: "Despachos",
                        principalColumn: "IdDespacho",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ofertas_EstadosOfertas_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "EstadosOfertas",
                        principalColumn: "IdEstado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ofertas_AspNetUsers_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2, "82190427-3e6b-4436-9f2a-906ce91ec435", "Proveedor", "PROVEEDOR" },
                    { 1, "73a0a8fc-4b9f-4f0c-b705-bc6b70cc53b4", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "CodigoDane", "Nombre", "Region" },
                values: new object[,]
                {
                    { 91, "Amazonas", "Región Centro Sur" },
                    { 47, "Magdalena", "Región Caribe" },
                    { 50, "Meta", "Región Llano" },
                    { 52, "Nariño", "Región Pacífico" },
                    { 54, "Norte de Santander", "Región Centro Oriente" },
                    { 63, "Quindío", "Región Eje Cafetero - Antioquia" },
                    { 66, "Risaralda", "Región Eje Cafetero - Antioquia" },
                    { 68, "Santander", "Región Centro Oriente" },
                    { 70, "Sucre", "Región Caribe" },
                    { 73, "Tolima", "Región Centro Sur" },
                    { 76, "Valle del Cauca", "Región Pacífico" },
                    { 97, "Vaupés", "Región Llano" },
                    { 99, "Vichada", "Región Llano" },
                    { 44, "La Guajira", "Región Caribe" },
                    { 41, "Huila", "Región Centro Sur" },
                    { 86, "Putumayo", "Región Centro Sur" },
                    { 94, "Guainía", "Región Llano" },
                    { 81, "Arauca", "Región Llano" },
                    { 95, "Guaviare", "Región Llano" },
                    { 88, "Archipiélago de San Andrés, Providencia y Santa Catalina", "Región Caribe" },
                    { 8, "Atlántico", "Región Caribe" },
                    { 13, "Bolívar", "Región Caribe" },
                    { 15, "Boyacá", "Región Centro Oriente" },
                    { 17, "Caldas", "Región Eje Cafetero - Antioquia" },
                    { 18, "Caquetá", "Región Centro Sur" },
                    { 85, "Casanare", "Región Llano" },
                    { 19, "Cauca", "Región Pacífico" },
                    { 5, "Antioquia", "Región Eje Cafetero - Antioquia" },
                    { 20, "Cesar", "Región Caribe" },
                    { 27, "Chocó", "Región Pacífico" },
                    { 23, "Córdoba", "Región Caribe" },
                    { 25, "Cundinamarca", "Región Centro Oriente" }
                });

            migrationBuilder.InsertData(
                table: "EstadosDespachos",
                columns: new[] { "IdEstado", "Nombre" },
                values: new object[,]
                {
                    { 6, "Entregado" },
                    { 5, "En Camino" },
                    { 1, "Ofertando" },
                    { 3, "Ofertas Cerrada" },
                    { 2, "Selección de Proveedor" },
                    { 4, "Preparando Envío" }
                });

            migrationBuilder.InsertData(
                table: "EstadosOfertas",
                columns: new[] { "IdEstado", "Nombre" },
                values: new object[,]
                {
                    { 1, "Enviada" },
                    { 2, "Aceptada" },
                    { 3, "Rechazada" },
                    { 4, "Completada" },
                    { 5, "Cancelada" }
                });

            migrationBuilder.InsertData(
                table: "TiposNotificaciones",
                columns: new[] { "IdTipoNotificacion", "Nombre" },
                values: new object[,]
                {
                    { 1, "Email" },
                    { 2, "SMS" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "CodigoDane", "CodigoDepartamento", "Nombre" },
                values: new object[,]
                {
                    { 91460, 91, "Miriti Paraná" },
                    { 41801, 41, "Teruel" },
                    { 41807, 41, "Timaná" },
                    { 41872, 41, "Villavieja" },
                    { 41885, 41, "Yaguará" },
                    { 44001, 44, "Riohacha" },
                    { 44035, 44, "Albania" },
                    { 44078, 44, "Barrancas" },
                    { 44090, 44, "Dibula" },
                    { 44098, 44, "Distracción" },
                    { 44110, 44, "El Molino" },
                    { 44279, 44, "Fonseca" },
                    { 44378, 44, "Hatonuevo" },
                    { 44430, 44, "Maicao" },
                    { 44560, 44, "Manaure" },
                    { 44847, 44, "Uribia" },
                    { 44855, 44, "Urumita" },
                    { 44874, 44, "Villanueva" },
                    { 44420, 44, "La Jagua del Pilar" },
                    { 47720, 47, "Santa Bárbara de Pinto" },
                    { 47570, 47, "Pueblo Viejo" },
                    { 47001, 47, "Santa Marta" },
                    { 47030, 47, "Algarrobo" },
                    { 47053, 47, "Aracataca" },
                    { 47058, 47, "Ariguaní" },
                    { 47161, 47, "Cerro San Antonio" },
                    { 47170, 47, "Chivolo" },
                    { 47205, 47, "Concordia" },
                    { 41799, 41, "Tello" },
                    { 47245, 47, "El Banco" },
                    { 41797, 41, "Tesalia" },
                    { 41770, 41, "Suaza" },
                    { 41006, 41, "Acevedo" },
                    { 41013, 41, "Agrado" },
                    { 41016, 41, "Aipe" },
                    { 41020, 41, "Algeciras" },
                    { 41026, 41, "Altamira" },
                    { 41078, 41, "Baraya" },
                    { 41132, 41, "Campoalegre" },
                    { 41206, 41, "Colombia" },
                    { 41244, 41, "Elías" },
                    { 41298, 41, "Garzón" },
                    { 41306, 41, "Gigante" },
                    { 41319, 41, "Guadalupe" },
                    { 41349, 41, "Hobo" },
                    { 41357, 41, "Iquira" },
                    { 41359, 41, "Isnos" },
                    { 41378, 41, "La Argentina" },
                    { 41396, 41, "La Plata" },
                    { 41483, 41, "Nátaga" },
                    { 41503, 41, "Oporapa" },
                    { 41518, 41, "Paicol" },
                    { 41524, 41, "Palermo" },
                    { 41530, 41, "Palestina" },
                    { 41548, 41, "Pital" },
                    { 41551, 41, "Pitalito" },
                    { 41615, 41, "Rivera" },
                    { 41660, 41, "Saladoblanco" },
                    { 41676, 41, "Santa María" },
                    { 41791, 41, "Tarqui" },
                    { 47258, 47, "El Piñon" },
                    { 47268, 47, "El Retén" },
                    { 47288, 47, "Fundación" },
                    { 50450, 50, "Puerto Concordia" },
                    { 50568, 50, "Puerto Gaitán" },
                    { 50573, 50, "Puerto López" },
                    { 50577, 50, "Puerto Lleras" },
                    { 50590, 50, "Puerto Rico" },
                    { 50606, 50, "Restrepo" },
                    { 50686, 50, "San Juanito" },
                    { 50689, 50, "San Martín" },
                    { 50711, 50, "Vista Hermosa" },
                    { 50110, 50, "Barranca de Upía" },
                    { 50287, 50, "Fuente de Oro" },
                    { 50680, 50, "San Carlos de Guaroa" },
                    { 52110, 52, "Buesaco" },
                    { 52835, 52, "San Andrés de Tumaco" },
                    { 52083, 52, "Belén" },
                    { 52240, 52, "Chachagüí" },
                    { 52051, 52, "Arboleda" },
                    { 52001, 52, "Pasto" },
                    { 52019, 52, "Albán" },
                    { 52022, 52, "Aldana" },
                    { 52036, 52, "Ancuyá" },
                    { 52079, 52, "Barbacoas" },
                    { 52203, 52, "Colón" },
                    { 52207, 52, "Consaca" },
                    { 52210, 52, "Contadero" },
                    { 52215, 52, "Córdoba" },
                    { 52224, 52, "Cuaspud" },
                    { 50400, 50, "Lejanías" },
                    { 50370, 50, "Uribe" },
                    { 50350, 50, "La Macarena" },
                    { 50330, 50, "Mesetas" },
                    { 47318, 47, "Guamal" },
                    { 47460, 47, "Nueva Granada" },
                    { 47541, 47, "Pedraza" },
                    { 47551, 47, "Pivijay" },
                    { 47555, 47, "Plato" },
                    { 47605, 47, "Remolino" },
                    { 47675, 47, "Salamina" },
                    { 47703, 47, "San Zenón" },
                    { 47707, 47, "Santa Ana" },
                    { 47745, 47, "Sitionuevo" },
                    { 47798, 47, "Tenerife" },
                    { 47960, 47, "Zapayán" },
                    { 47980, 47, "Zona Bananera" },
                    { 41001, 41, "Neiva" },
                    { 47189, 47, "Ciénaga" },
                    { 47660, 47, "Sabanas de San Angel" },
                    { 50150, 50, "Castilla la Nueva" },
                    { 50001, 50, "Villavicencio" },
                    { 50006, 50, "Acacias" },
                    { 50124, 50, "Cabuyaro" },
                    { 50223, 50, "Cubarral" },
                    { 50226, 50, "Cumaral" },
                    { 50245, 50, "El Calvario" },
                    { 50251, 50, "El Castillo" },
                    { 50270, 50, "El Dorado" },
                    { 50313, 50, "Granada" },
                    { 50318, 50, "Guamal" },
                    { 50325, 50, "Mapiripán" },
                    { 47692, 47, "San Sebastián de Buenavista" },
                    { 52227, 52, "Cumbal" },
                    { 95200, 95, "Miraflores" },
                    { 95015, 95, "Calamar" },
                    { 25293, 25, "Gachala" },
                    { 25295, 25, "Gachancipá" },
                    { 25297, 25, "Gachetá" },
                    { 25307, 25, "Girardot" },
                    { 25312, 25, "Granada" },
                    { 25317, 25, "Guachetá" },
                    { 25320, 25, "Guaduas" },
                    { 25322, 25, "Guasca" },
                    { 25324, 25, "Guataquí" },
                    { 25326, 25, "Guatavita" },
                    { 25290, 25, "Fusagasugá" },
                    { 25335, 25, "Guayabetal" },
                    { 25339, 25, "Gutiérrez" },
                    { 25368, 25, "Jerusalén" },
                    { 25372, 25, "Junín" },
                    { 25377, 25, "La Calera" },
                    { 25386, 25, "La Mesa" },
                    { 25394, 25, "La Palma" },
                    { 25398, 25, "La Peña" },
                    { 25402, 25, "La Vega" },
                    { 25407, 25, "Lenguazaque" },
                    { 25426, 25, "Macheta" },
                    { 25430, 25, "Madrid" },
                    { 25436, 25, "Manta" },
                    { 25438, 25, "Medina" },
                    { 25473, 25, "Mosquera" },
                    { 25483, 25, "Nariño" },
                    { 25288, 25, "Fúquene" },
                    { 25486, 25, "Nemocón" },
                    { 25286, 25, "Funza" },
                    { 25279, 25, "Fomeque" },
                    { 25019, 25, "Albán" },
                    { 25040, 25, "Anolaima" },
                    { 25175, 25, "Chía" },
                    { 25258, 25, "El Peñón" },
                    { 25758, 25, "Sopó" },
                    { 25299, 25, "Gama" },
                    { 25718, 25, "Sasaima" },
                    { 25885, 25, "Yacopí" },
                    { 25035, 25, "Anapoima" },
                    { 25053, 25, "Arbeláez" },
                    { 25086, 25, "Beltrán" },
                    { 25095, 25, "Bituima" },
                    { 25099, 25, "Bojacá" },
                    { 25120, 25, "Cabrera" },
                    { 25123, 25, "Cachipay" },
                    { 25126, 25, "Cajicá" },
                    { 25148, 25, "Caparrapí" },
                    { 25151, 25, "Caqueza" },
                    { 25168, 25, "Chaguaní" },
                    { 25178, 25, "Chipaque" },
                    { 25181, 25, "Choachí" },
                    { 25183, 25, "Chocontá" },
                    { 25200, 25, "Cogua" },
                    { 25214, 25, "Cota" },
                    { 25224, 25, "Cucunubá" },
                    { 25245, 25, "El Colegio" },
                    { 25260, 25, "El Rosal" },
                    { 25281, 25, "Fosca" },
                    { 25488, 25, "Nilo" },
                    { 25489, 25, "Nimaima" },
                    { 25491, 25, "Nocaima" },
                    { 25807, 25, "Tibirita" },
                    { 25815, 25, "Tocaima" },
                    { 25817, 25, "Tocancipá" },
                    { 25823, 25, "Topaipí" },
                    { 25839, 25, "Ubalá" },
                    { 25841, 25, "Ubaque" },
                    { 25845, 25, "Une" },
                    { 25851, 25, "Útica" },
                    { 25867, 25, "Vianí" },
                    { 25871, 25, "Villagómez" },
                    { 25873, 25, "Villapinzón" },
                    { 25875, 25, "Villeta" },
                    { 25878, 25, "Viotá" },
                    { 25898, 25, "Zipacón" },
                    { 25269, 25, "Facatativá" },
                    { 25662, 25, "San Juan de Río Seco" },
                    { 25843, 25, "Villa de San Diego de Ubate" },
                    { 25328, 25, "Guayabal de Siquima" },
                    { 94001, 94, "Inírida" },
                    { 94343, 94, "Barranco Minas" },
                    { 94663, 94, "Mapiripana" },
                    { 94883, 94, "San Felipe" },
                    { 94884, 94, "Puerto Colombia" },
                    { 94885, 94, "La Guadalupe" },
                    { 94886, 94, "Cacahual" },
                    { 94887, 94, "Pana Pana" },
                    { 94888, 94, "Morichal" },
                    { 25805, 25, "Tibacuy" },
                    { 25799, 25, "Tenjo" },
                    { 25797, 25, "Tena" },
                    { 25793, 25, "Tausa" },
                    { 25506, 25, "Venecia" },
                    { 25513, 25, "Pacho" },
                    { 25518, 25, "Paime" },
                    { 25524, 25, "Pandi" },
                    { 25530, 25, "Paratebueno" },
                    { 25535, 25, "Pasca" },
                    { 25572, 25, "Puerto Salgar" },
                    { 25580, 25, "Pulí" },
                    { 25592, 25, "Quebradanegra" },
                    { 25594, 25, "Quetame" },
                    { 25596, 25, "Quipile" },
                    { 25599, 25, "Apulo" },
                    { 25612, 25, "Ricaurte" },
                    { 95001, 95, "San José del Guaviare" },
                    { 25649, 25, "San Bernardo" },
                    { 25658, 25, "San Francisco" },
                    { 25899, 25, "Zipaquirá" },
                    { 25736, 25, "Sesquilé" },
                    { 25740, 25, "Sibaté" },
                    { 25743, 25, "Silvania" },
                    { 25745, 25, "Simijaca" },
                    { 25754, 25, "Soacha" },
                    { 25769, 25, "Subachoque" },
                    { 25772, 25, "Suesca" },
                    { 25777, 25, "Supatá" },
                    { 25779, 25, "Susa" },
                    { 25781, 25, "Sutatausa" },
                    { 25785, 25, "Tabio" },
                    { 25653, 25, "San Cayetano" },
                    { 23675, 23, "San Bernardo del Viento" },
                    { 52233, 52, "Cumbitara" },
                    { 52254, 52, "El Peñol" },
                    { 68780, 68, "Suratá" },
                    { 68820, 68, "Tona" },
                    { 68861, 68, "Vélez" },
                    { 68867, 68, "Vetas" },
                    { 68872, 68, "Villanueva" },
                    { 68895, 68, "Zapatoca" },
                    { 68524, 68, "Palmas del Socorro" },
                    { 68689, 68, "San Vicente de Chucurí" },
                    { 68684, 68, "San José de Miranda" },
                    { 68720, 68, "Santa Helena del Opón" },
                    { 70670, 70, "Sampués" },
                    { 70215, 70, "Corozal" },
                    { 70001, 70, "Sincelejo" },
                    { 70110, 70, "Buenavista" },
                    { 70124, 70, "Caimito" },
                    { 70204, 70, "Coloso" },
                    { 70221, 70, "Coveñas" },
                    { 70230, 70, "Chalán" },
                    { 70233, 70, "El Roble" },
                    { 70235, 70, "Galeras" },
                    { 70265, 70, "Guaranda" },
                    { 70400, 70, "La Unión" },
                    { 70418, 70, "Los Palmitos" },
                    { 70429, 70, "Majagual" },
                    { 70473, 70, "Morroa" },
                    { 70508, 70, "Ovejas" },
                    { 70523, 70, "Palmito" },
                    { 68773, 68, "Sucre" },
                    { 70678, 70, "San Benito Abad" },
                    { 68770, 68, "Suaita" },
                    { 68745, 68, "Simacota" },
                    { 68327, 68, "Güepsa" },
                    { 68368, 68, "Jesús María" },
                    { 68370, 68, "Jordán" },
                    { 68377, 68, "La Belleza" },
                    { 68385, 68, "Landázuri" },
                    { 68397, 68, "La Paz" },
                    { 68406, 68, "Lebríja" },
                    { 68418, 68, "Los Santos" },
                    { 68425, 68, "Macaravita" },
                    { 68432, 68, "Málaga" },
                    { 68444, 68, "Matanza" },
                    { 68464, 68, "Mogotes" },
                    { 68468, 68, "Molagavita" },
                    { 68498, 68, "Ocamonte" },
                    { 68500, 68, "Oiba" },
                    { 68502, 68, "Onzaga" },
                    { 68522, 68, "Palmar" },
                    { 68533, 68, "Páramo" },
                    { 68547, 68, "Piedecuesta" },
                    { 68549, 68, "Pinchote" },
                    { 68572, 68, "Puente Nacional" },
                    { 68615, 68, "Rionegro" },
                    { 68669, 68, "San Andrés" },
                    { 68679, 68, "San Gil" },
                    { 68682, 68, "San Joaquín" },
                    { 68686, 68, "San Miguel" },
                    { 68705, 68, "Santa Bárbara" },
                    { 68755, 68, "Socorro" },
                    { 70708, 70, "San Marcos" },
                    { 70713, 70, "San Onofre" },
                    { 70717, 70, "San Pedro" },
                    { 73504, 73, "Ortega" },
                    { 73520, 73, "Palocabildo" },
                    { 73547, 73, "Piedras" },
                    { 73555, 73, "Planadas" },
                    { 73563, 73, "Prado" },
                    { 73585, 73, "Purificación" },
                    { 73616, 73, "Rio Blanco" },
                    { 73622, 73, "Roncesvalles" },
                    { 73624, 73, "Rovira" },
                    { 73671, 73, "Saldaña" },
                    { 73686, 73, "Santa Isabel" },
                    { 73861, 73, "Venadillo" },
                    { 73870, 73, "Villahermosa" },
                    { 73873, 73, "Villarrica" },
                    { 73854, 73, "Valle de San Juan" },
                    { 76834, 76, "Tuluá" },
                    { 76275, 76, "Florida" },
                    { 76364, 76, "Jamundí" },
                    { 76109, 76, "Buenaventura" },
                    { 97889, 97, "Yavaraté" },
                    { 97001, 97, "Mitú" },
                    { 97161, 97, "Caruru" },
                    { 97511, 97, "Pacoa" },
                    { 97666, 97, "Taraira" },
                    { 97777, 97, "Papunaua" },
                    { 99001, 99, "Puerto Carreño" },
                    { 99524, 99, "La Primavera" },
                    { 73483, 73, "Natagaima" },
                    { 73461, 73, "Murillo" },
                    { 73449, 73, "Melgar" },
                    { 73443, 73, "Mariquita" },
                    { 70771, 70, "Sucre" },
                    { 70823, 70, "Tolú Viejo" },
                    { 70742, 70, "San Luis de Sincé" },
                    { 73152, 73, "Casabianca" },
                    { 73043, 73, "Anzoátegui" },
                    { 73001, 73, "Ibagué" },
                    { 73411, 73, "Líbano" },
                    { 73408, 73, "Lérida" },
                    { 73770, 73, "Suárez" },
                    { 73024, 73, "Alpujarra" },
                    { 73026, 73, "Alvarado" },
                    { 73030, 73, "Ambalema" },
                    { 73055, 73, "Armero" },
                    { 68324, 68, "Guavatá" },
                    { 73067, 73, "Ataco" },
                    { 73168, 73, "Chaparral" },
                    { 73200, 73, "Coello" },
                    { 73217, 73, "Coyaima" },
                    { 73226, 73, "Cunday" },
                    { 73236, 73, "Dolores" },
                    { 73268, 73, "Espinal" },
                    { 73270, 73, "Falan" },
                    { 73275, 73, "Flandes" },
                    { 73283, 73, "Fresno" },
                    { 73319, 73, "Guamo" },
                    { 73347, 73, "Herveo" },
                    { 73349, 73, "Honda" },
                    { 73352, 73, "Icononzo" },
                    { 73124, 73, "Cajamarca" },
                    { 52250, 52, "El Charco" },
                    { 68322, 68, "Guapotá" },
                    { 68318, 68, "Guaca" },
                    { 52678, 52, "Samaniego" },
                    { 52683, 52, "Sandoná" },
                    { 52685, 52, "San Bernardo" },
                    { 52687, 52, "San Lorenzo" },
                    { 52693, 52, "San Pablo" },
                    { 52696, 52, "Santa Bárbara" },
                    { 52720, 52, "Sapuyes" },
                    { 52786, 52, "Taminango" },
                    { 52788, 52, "Tangua" },
                    { 52699, 52, "Santacruz" },
                    { 52838, 52, "Túquerres" },
                    { 52885, 52, "Yacuanquer" },
                    { 54518, 54, "Pamplona" },
                    { 54520, 54, "Pamplonita" },
                    { 54001, 54, "Cúcuta" },
                    { 54245, 54, "El Carmen" },
                    { 86568, 86, "Puerto Asís" },
                    { 86885, 86, "Villagarzón" },
                    { 86001, 86, "Mocoa" },
                    { 86219, 86, "Colón" },
                    { 86320, 86, "Orito" },
                    { 86569, 86, "Puerto Caicedo" },
                    { 86571, 86, "Puerto Guzmán" },
                    { 86573, 86, "Leguízamo" },
                    { 86749, 86, "Sibundoy" },
                    { 86755, 86, "San Francisco" },
                    { 86757, 86, "San Miguel" },
                    { 52621, 52, "Roberto Payán" },
                    { 86760, 86, "Santiago" },
                    { 52612, 52, "Ricaurte" },
                    { 52573, 52, "Puerres" },
                    { 52256, 52, "El Rosario" },
                    { 52260, 52, "El Tambo" },
                    { 52287, 52, "Funes" },
                    { 52317, 52, "Guachucal" },
                    { 52320, 52, "Guaitarilla" },
                    { 52323, 52, "Gualmatán" },
                    { 52352, 52, "Iles" },
                    { 52354, 52, "Imués" },
                    { 52356, 52, "Ipiales" },
                    { 52378, 52, "La Cruz" },
                    { 52381, 52, "La Florida" },
                    { 52385, 52, "La Llanada" },
                    { 52390, 52, "La Tola" },
                    { 52399, 52, "La Unión" },
                    { 52405, 52, "Leiva" },
                    { 52411, 52, "Linares" },
                    { 52418, 52, "Los Andes" },
                    { 52427, 52, "Magüí" },
                    { 52435, 52, "Mallama" },
                    { 52473, 52, "Mosquera" },
                    { 52480, 52, "Nariño" },
                    { 52490, 52, "Olaya Herrera" },
                    { 52506, 52, "Ospina" },
                    { 52520, 52, "Francisco Pizarro" },
                    { 52540, 52, "Policarpa" },
                    { 52560, 52, "Potosí" },
                    { 52565, 52, "Providencia" },
                    { 52585, 52, "Pupiales" },
                    { 63130, 63, "Calarcá" },
                    { 63302, 63, "Génova" },
                    { 63001, 63, "Armenia" },
                    { 68079, 68, "Barichara" },
                    { 68081, 68, "Barrancabermeja" },
                    { 68092, 68, "Betulia" },
                    { 68101, 68, "Bolívar" },
                    { 68121, 68, "Cabrera" },
                    { 68132, 68, "California" },
                    { 68152, 68, "Carcasí" },
                    { 68160, 68, "Cepitá" },
                    { 68162, 68, "Cerrito" },
                    { 68167, 68, "Charalá" },
                    { 68169, 68, "Charta" },
                    { 68179, 68, "Chipatá" },
                    { 68190, 68, "Cimitarra" },
                    { 68207, 68, "Concepción" },
                    { 68209, 68, "Confines" },
                    { 68211, 68, "Contratación" },
                    { 68217, 68, "Coromoro" },
                    { 68229, 68, "Curití" },
                    { 68245, 68, "El Guacamayo" },
                    { 68255, 68, "El Playón" },
                    { 68264, 68, "Encino" },
                    { 68266, 68, "Enciso" },
                    { 68271, 68, "Florián" },
                    { 68276, 68, "Floridablanca" },
                    { 68296, 68, "Galán" },
                    { 68298, 68, "Gambita" },
                    { 68307, 68, "Girón" },
                    { 68077, 68, "Barbosa" },
                    { 68051, 68, "Aratoca" },
                    { 68020, 68, "Albania" },
                    { 68013, 68, "Aguada" },
                    { 63111, 63, "Buenavista" },
                    { 63190, 63, "Circasia" },
                    { 63212, 63, "Córdoba" },
                    { 63272, 63, "Filandia" },
                    { 63401, 63, "La Tebaida" },
                    { 63470, 63, "Montenegro" },
                    { 63548, 63, "Pijao" },
                    { 63594, 63, "Quimbaya" },
                    { 63690, 63, "Salento" },
                    { 66001, 66, "Pereira" },
                    { 66045, 66, "Apía" },
                    { 66075, 66, "Balboa" },
                    { 66170, 66, "Dosquebradas" },
                    { 68320, 68, "Guadalupe" },
                    { 66318, 66, "Guática" },
                    { 66400, 66, "La Virginia" },
                    { 66440, 66, "Marsella" },
                    { 66456, 66, "Mistrató" },
                    { 66572, 66, "Pueblo Rico" },
                    { 66594, 66, "Quinchía" },
                    { 66687, 66, "Santuario" },
                    { 66682, 66, "Santa Rosa de Cabal" },
                    { 68176, 68, "Chimá" },
                    { 68147, 68, "Capitanejo" },
                    { 68250, 68, "El Peñón" },
                    { 68575, 68, "Puerto Wilches" },
                    { 68573, 68, "Puerto Parra" },
                    { 68001, 68, "Bucaramanga" },
                    { 66383, 66, "La Celia" },
                    { 23580, 23, "Puerto Libertador" },
                    { 23350, 23, "La Apartada" },
                    { 23855, 23, "Valencia" },
                    { 8560, 8, "Ponedera" },
                    { 8372, 8, "Juan de Acosta" },
                    { 8520, 8, "Palmar de Varela" },
                    { 13268, 13, "El Peñón" },
                    { 13006, 13, "Achí" },
                    { 13042, 13, "Arenal" },
                    { 13052, 13, "Arjona" },
                    { 13062, 13, "Arroyohondo" },
                    { 13140, 13, "Calamar" },
                    { 13160, 13, "Cantagallo" },
                    { 13188, 13, "Cicuco" },
                    { 13212, 13, "Córdoba" },
                    { 13222, 13, "Clemencia" },
                    { 13248, 13, "El Guamo" },
                    { 13430, 13, "Magangué" },
                    { 13433, 13, "Mahates" },
                    { 13440, 13, "Margarita" },
                    { 13458, 13, "Montecristo" },
                    { 13468, 13, "Mompós" },
                    { 13473, 13, "Morales" },
                    { 13490, 13, "Norosí" },
                    { 13549, 13, "Pinillos" },
                    { 13580, 13, "Regidor" },
                    { 13600, 13, "Río Viejo" },
                    { 13647, 13, "San Estanislao" },
                    { 13650, 13, "San Fernando" },
                    { 13657, 13, "San Juan Nepomuceno" },
                    { 8573, 8, "Puerto Colombia" },
                    { 13673, 13, "Santa Catalina" },
                    { 8606, 8, "Repelón" },
                    { 8832, 8, "Tubará" },
                    { 5665, 5, "San Pedro de Uraba" },
                    { 5042, 5, "Santafé de Antioquia" },
                    { 5686, 5, "Santa Rosa de Osos" },
                    { 5647, 5, "San Andrés de Cuerquía" },
                    { 81065, 81, "Arauquita" },
                    { 81220, 81, "Cravo Norte" },
                    { 81300, 81, "Fortul" },
                    { 81591, 81, "Puerto Rondón" },
                    { 81736, 81, "Saravena" },
                    { 81794, 81, "Tame" },
                    { 81001, 81, "Arauca" },
                    { 88564, 88, "Providencia" },
                    { 8001, 8, "Barranquilla" },
                    { 8078, 8, "Baranoa" },
                    { 8141, 8, "Candelaria" },
                    { 8296, 8, "Galapa" },
                    { 8421, 8, "Luruaco" },
                    { 8433, 8, "Malambo" },
                    { 8436, 8, "Manatí" },
                    { 8549, 8, "Piojó" },
                    { 8558, 8, "Polonuevo" },
                    { 8634, 8, "Sabanagrande" },
                    { 8638, 8, "Sabanalarga" },
                    { 8675, 8, "Santa Lucía" },
                    { 8685, 8, "Santo Tomás" },
                    { 8758, 8, "Soledad" },
                    { 8770, 8, "Suan" },
                    { 8849, 8, "Usiacurí" },
                    { 13683, 13, "Santa Rosa" },
                    { 13744, 13, "Simití" },
                    { 13760, 13, "Soplaviento" },
                    { 15187, 15, "Chivatá" },
                    { 15204, 15, "Cómbita" },
                    { 15212, 15, "Coper" },
                    { 15215, 15, "Corrales" },
                    { 15218, 15, "Covarachía" },
                    { 15223, 15, "Cubará" },
                    { 15224, 15, "Cucaita" },
                    { 15226, 15, "Cuítiva" },
                    { 15232, 15, "Chíquiza" },
                    { 15236, 15, "Chivor" },
                    { 15238, 15, "Duitama" },
                    { 15244, 15, "El Cocuy" },
                    { 15248, 15, "El Espino" },
                    { 15272, 15, "Firavitoba" },
                    { 15276, 15, "Floresta" },
                    { 15293, 15, "Gachantivá" },
                    { 15296, 15, "Gameza" },
                    { 15299, 15, "Garagoa" },
                    { 15317, 15, "Guacamayas" },
                    { 15322, 15, "Guateque" },
                    { 15325, 15, "Guayatá" },
                    { 15332, 15, "Güicán" },
                    { 15362, 15, "Iza" },
                    { 15367, 15, "Jenesano" },
                    { 15368, 15, "Jericó" },
                    { 15377, 15, "Labranzagrande" },
                    { 15380, 15, "La Capilla" },
                    { 15185, 15, "Chitaraque" },
                    { 15183, 15, "Chita" },
                    { 15180, 15, "Chiscas" },
                    { 15176, 15, "Chiquinquirá" },
                    { 13780, 13, "Talaigua Nuevo" },
                    { 13810, 13, "Tiquisio" },
                    { 13836, 13, "Turbaco" },
                    { 13838, 13, "Turbaná" },
                    { 13873, 13, "Villanueva" },
                    { 13001, 13, "Cartagena" },
                    { 13442, 13, "María la Baja" },
                    { 13620, 13, "San Cristóbal" },
                    { 13894, 13, "Zambrano" },
                    { 13074, 13, "Barranco de Loba" },
                    { 13688, 13, "Santa Rosa del Sur" },
                    { 13300, 13, "Hatillo de Loba" },
                    { 15806, 15, "Tibasosa" },
                    { 5086, 5, "Belmira" },
                    { 15001, 15, "Tunja" },
                    { 15047, 15, "Aquitania" },
                    { 15051, 15, "Arcabuco" },
                    { 15090, 15, "Berbeo" },
                    { 15092, 15, "Betéitiva" },
                    { 15097, 15, "Boavita" },
                    { 15104, 15, "Boyacá" },
                    { 15106, 15, "Briceño" },
                    { 15109, 15, "Buena Vista" },
                    { 15114, 15, "Busbanzá" },
                    { 15131, 15, "Caldas" },
                    { 15135, 15, "Campohermoso" },
                    { 15162, 15, "Cerinza" },
                    { 15172, 15, "Chinavita" },
                    { 15022, 15, "Almeida" },
                    { 15401, 15, "La Victoria" },
                    { 5756, 5, "Sonsón" },
                    { 5313, 5, "Granada" },
                    { 5120, 5, "Cáceres" },
                    { 5125, 5, "Caicedo" },
                    { 5129, 5, "Caldas" },
                    { 5134, 5, "Campamento" },
                    { 5138, 5, "Cañasgordas" },
                    { 5142, 5, "Caracolí" },
                    { 5145, 5, "Caramanta" },
                    { 5147, 5, "Carepa" },
                    { 5150, 5, "Carolina" },
                    { 5154, 5, "Caucasia" },
                    { 5172, 5, "Chigorodó" },
                    { 5190, 5, "Cisneros" },
                    { 5197, 5, "Cocorná" },
                    { 5206, 5, "Concepción" },
                    { 5209, 5, "Concordia" },
                    { 5212, 5, "Copacabana" },
                    { 5234, 5, "Dabeiba" },
                    { 5237, 5, "Don Matías" },
                    { 5240, 5, "Ebéjico" },
                    { 5250, 5, "El Bagre" },
                    { 5264, 5, "Entrerrios" },
                    { 5266, 5, "Envigado" },
                    { 5282, 5, "Fredonia" },
                    { 5306, 5, "Giraldo" },
                    { 5308, 5, "Girardota" },
                    { 5310, 5, "Gómez Plata" },
                    { 5315, 5, "Guadalupe" },
                    { 5113, 5, "Buriticá" },
                    { 5318, 5, "Guarne" },
                    { 5107, 5, "Briceño" },
                    { 5093, 5, "Betulia" },
                    { 91001, 91, "Leticia" },
                    { 91263, 91, "El Encanto" },
                    { 91405, 91, "La Chorrera" },
                    { 91407, 91, "La Pedrera" },
                    { 91430, 91, "La Victoria" },
                    { 91536, 91, "Puerto Arica" },
                    { 91540, 91, "Puerto Nariño" },
                    { 91669, 91, "Puerto Santander" },
                    { 91798, 91, "Tarapacá" },
                    { 5001, 5, "Medellín" },
                    { 5002, 5, "Abejorral" },
                    { 5004, 5, "Abriaquí" },
                    { 5021, 5, "Alejandría" },
                    { 5030, 5, "Amagá" },
                    { 5031, 5, "Amalfi" },
                    { 5034, 5, "Andes" },
                    { 5036, 5, "Angelópolis" },
                    { 5038, 5, "Angostura" },
                    { 5040, 5, "Anorí" },
                    { 5044, 5, "Anza" },
                    { 5045, 5, "Apartadó" },
                    { 5051, 5, "Arboletes" },
                    { 5055, 5, "Argelia" },
                    { 5059, 5, "Armenia" },
                    { 5079, 5, "Barbosa" },
                    { 5088, 5, "Bello" },
                    { 5091, 5, "Betania" },
                    { 5101, 5, "Ciudad Bolívar" },
                    { 5321, 5, "Guatapé" },
                    { 5347, 5, "Heliconia" },
                    { 5353, 5, "Hispania" },
                    { 5664, 5, "San Pedro" },
                    { 5667, 5, "San Rafael" },
                    { 5670, 5, "San Roque" },
                    { 5674, 5, "San Vicente" },
                    { 5679, 5, "Santa Bárbara" },
                    { 5690, 5, "Santo Domingo" },
                    { 5697, 5, "El Santuario" },
                    { 5736, 5, "Segovia" },
                    { 5761, 5, "Sopetrán" },
                    { 5789, 5, "Támesis" },
                    { 5790, 5, "Tarazá" },
                    { 5792, 5, "Tarso" },
                    { 5809, 5, "Titiribí" },
                    { 5819, 5, "Toledo" },
                    { 5837, 5, "Turbo" },
                    { 5842, 5, "Uramita" },
                    { 5847, 5, "Urrao" },
                    { 5854, 5, "Valdivia" },
                    { 5856, 5, "Valparaíso" },
                    { 5858, 5, "Vegachí" },
                    { 5861, 5, "Venecia" },
                    { 5885, 5, "Yalí" },
                    { 5887, 5, "Yarumal" },
                    { 5890, 5, "Yolombó" },
                    { 5893, 5, "Yondó" },
                    { 5895, 5, "Zaragoza" },
                    { 5284, 5, "Frontino" },
                    { 5660, 5, "San Luis" },
                    { 5656, 5, "San Jerónimo" },
                    { 5652, 5, "San Francisco" },
                    { 5642, 5, "Salgar" },
                    { 5360, 5, "Itagui" },
                    { 5361, 5, "Ituango" },
                    { 5368, 5, "Jericó" },
                    { 5376, 5, "La Ceja" },
                    { 5380, 5, "La Estrella" },
                    { 5390, 5, "La Pintada" },
                    { 5400, 5, "La Unión" },
                    { 5411, 5, "Liborina" },
                    { 5425, 5, "Maceo" },
                    { 5440, 5, "Marinilla" },
                    { 5467, 5, "Montebello" },
                    { 5475, 5, "Murindó" },
                    { 5480, 5, "Mutatá" },
                    { 5364, 5, "Jardín" },
                    { 5483, 5, "Nariño" },
                    { 5495, 5, "Nechí" },
                    { 5501, 5, "Olaya" },
                    { 5541, 5, "Peñol" },
                    { 5543, 5, "Peque" },
                    { 5576, 5, "Pueblorrico" },
                    { 5579, 5, "Puerto Berrío" },
                    { 5585, 5, "Puerto Nare" },
                    { 5591, 5, "Puerto Triunfo" },
                    { 5604, 5, "Remedios" },
                    { 5607, 5, "Retiro" },
                    { 5615, 5, "Rionegro" },
                    { 5628, 5, "Sabanalarga" },
                    { 5631, 5, "Sabaneta" },
                    { 5490, 5, "Necoclí" },
                    { 15425, 15, "Macanal" },
                    { 15442, 15, "Maripí" },
                    { 15455, 15, "Miraflores" },
                    { 19573, 19, "Puerto Tejada" },
                    { 19585, 19, "Puracé" },
                    { 19622, 19, "Rosas" },
                    { 19701, 19, "Santa Rosa" },
                    { 19743, 19, "Silvia" },
                    { 19760, 19, "Sotara" },
                    { 19780, 19, "Suárez" },
                    { 19785, 19, "Sucre" },
                    { 19807, 19, "Timbío" },
                    { 19809, 19, "Timbiquí" },
                    { 19821, 19, "Toribio" },
                    { 19824, 19, "Totoró" },
                    { 19845, 19, "Villa Rica" },
                    { 19698, 19, "Santander de Quilichao" },
                    { 20001, 20, "Valledupar" },
                    { 20011, 20, "Aguachica" },
                    { 20013, 20, "Agustín Codazzi" },
                    { 20032, 20, "Astrea" },
                    { 20045, 20, "Becerril" },
                    { 20060, 20, "Bosconia" },
                    { 20175, 20, "Chimichagua" },
                    { 20178, 20, "Chiriguaná" },
                    { 20228, 20, "Curumaní" },
                    { 20238, 20, "El Copey" },
                    { 20250, 20, "El Paso" },
                    { 20295, 20, "Gamarra" },
                    { 20310, 20, "González" },
                    { 19548, 19, "Piendamó" },
                    { 20383, 20, "La Gloria" },
                    { 19533, 19, "Piamonte" },
                    { 19513, 19, "Padilla" },
                    { 85430, 85, "Trinidad" },
                    { 85440, 85, "Villanueva" },
                    { 85325, 85, "San Luis de Gaceno" },
                    { 85250, 85, "Paz de Ariporo" },
                    { 19517, 19, "Páez" },
                    { 19001, 19, "Popayán" },
                    { 19022, 19, "Almaguer" },
                    { 19050, 19, "Argelia" },
                    { 19075, 19, "Balboa" },
                    { 19100, 19, "Bolívar" },
                    { 19110, 19, "Buenos Aires" },
                    { 19130, 19, "Cajibío" },
                    { 19137, 19, "Caldono" },
                    { 19142, 19, "Caloto" },
                    { 19212, 19, "Corinto" },
                    { 19256, 19, "El Tambo" },
                    { 19290, 19, "Florencia" },
                    { 19300, 19, "Guachené" },
                    { 19318, 19, "Guapi" },
                    { 19355, 19, "Inzá" },
                    { 19364, 19, "Jambaló" },
                    { 19392, 19, "La Sierra" },
                    { 19397, 19, "La Vega" },
                    { 19418, 19, "López" },
                    { 19450, 19, "Mercaderes" },
                    { 19455, 19, "Miranda" },
                    { 19473, 19, "Morales" },
                    { 19532, 19, "Patía" },
                    { 20443, 20, "Manaure" },
                    { 20517, 20, "Pailitas" },
                    { 20550, 20, "Pelaya" },
                    { 27800, 27, "Unguía" },
                    { 27361, 27, "Istmina" },
                    { 27250, 27, "El Litoral del San Juan" },
                    { 27135, 27, "El Cantón del San Pablo" },
                    { 23466, 23, "Montelíbano" },
                    { 23001, 23, "Montería" },
                    { 23068, 23, "Ayapel" },
                    { 23079, 23, "Buenavista" },
                    { 23090, 23, "Canalete" },
                    { 23162, 23, "Cereté" },
                    { 23168, 23, "Chimá" },
                    { 23182, 23, "Chinú" },
                    { 23300, 23, "Cotorra" },
                    { 23417, 23, "Lorica" },
                    { 23419, 23, "Los Córdobas" },
                    { 23464, 23, "Momil" },
                    { 23500, 23, "Moñitos" },
                    { 23555, 23, "Planeta Rica" },
                    { 23570, 23, "Pueblo Nuevo" },
                    { 23574, 23, "Puerto Escondido" },
                    { 23586, 23, "Purísima" },
                    { 23660, 23, "Sahagún" },
                    { 23670, 23, "San Andrés Sotavento" },
                    { 23672, 23, "San Antero" },
                    { 23686, 23, "San Pelayo" },
                    { 23807, 23, "Tierralta" },
                    { 23815, 23, "Tuchín" },
                    { 27745, 27, "Sipí" },
                    { 27615, 27, "Riosucio" },
                    { 27600, 27, "Río Quito" },
                    { 27580, 27, "Río Iro" },
                    { 20570, 20, "Pueblo Bello" },
                    { 20621, 20, "La Paz" },
                    { 20710, 20, "San Alberto" },
                    { 20750, 20, "San Diego" },
                    { 20770, 20, "San Martín" },
                    { 20787, 20, "Tamalameque" },
                    { 20614, 20, "Río de Oro" },
                    { 20400, 20, "La Jagua de Ibirico" },
                    { 27150, 27, "Carmen del Darien" },
                    { 27787, 27, "Tadó" },
                    { 27001, 27, "Quibdó" },
                    { 27006, 27, "Acandí" },
                    { 27025, 27, "Alto Baudo" },
                    { 85410, 85, "Tauramena" },
                    { 27050, 27, "Atrato" },
                    { 27075, 27, "Bahía Solano" },
                    { 27077, 27, "Bajo Baudó" },
                    { 27099, 27, "Bojaya" },
                    { 27810, 27, "Unión Panamericana" },
                    { 27160, 27, "Cértegui" },
                    { 27205, 27, "Condoto" },
                    { 27372, 27, "Juradó" },
                    { 27413, 27, "Lloró" },
                    { 27425, 27, "Medio Atrato" },
                    { 27430, 27, "Medio Baudó" },
                    { 27450, 27, "Medio San Juan" },
                    { 27491, 27, "Nóvita" },
                    { 27495, 27, "Nuquí" },
                    { 27073, 27, "Bagadó" },
                    { 85315, 85, "Sácama" },
                    { 85300, 85, "Sabanalarga" },
                    { 85279, 85, "Recetor" },
                    { 15740, 15, "Siachoque" },
                    { 15753, 15, "Soatá" },
                    { 15755, 15, "Socotá" },
                    { 15757, 15, "Socha" },
                    { 15759, 15, "Sogamoso" },
                    { 15761, 15, "Somondoco" },
                    { 15762, 15, "Sora" },
                    { 15763, 15, "Sotaquirá" },
                    { 15764, 15, "Soracá" },
                    { 15774, 15, "Susacón" },
                    { 15776, 15, "Sutamarchán" },
                    { 15778, 15, "Sutatenza" },
                    { 15790, 15, "Tasco" },
                    { 15798, 15, "Tenza" },
                    { 15804, 15, "Tibaná" },
                    { 15808, 15, "Tinjacá" },
                    { 15810, 15, "Tipacoque" },
                    { 15814, 15, "Toca" },
                    { 15820, 15, "Tópaga" },
                    { 15822, 15, "Tota" },
                    { 15835, 15, "Turmequé" },
                    { 15839, 15, "Tutazá" },
                    { 15842, 15, "Umbita" },
                    { 15861, 15, "Ventaquemada" },
                    { 15879, 15, "Viracachá" },
                    { 15897, 15, "Zetaquira" },
                    { 15403, 15, "La Uvita" },
                    { 15723, 15, "Sativasur" },
                    { 15720, 15, "Sativanorte" },
                    { 15696, 15, "Santa Sofía" },
                    { 15690, 15, "Santa María" },
                    { 15464, 15, "Mongua" },
                    { 15466, 15, "Monguí" },
                    { 15469, 15, "Moniquirá" },
                    { 15480, 15, "Muzo" },
                    { 15491, 15, "Nobsa" },
                    { 15494, 15, "Nuevo Colón" },
                    { 15500, 15, "Oicatá" },
                    { 15507, 15, "Otanche" },
                    { 15511, 15, "Pachavita" },
                    { 15514, 15, "Páez" },
                    { 15516, 15, "Paipa" },
                    { 15518, 15, "Pajarito" },
                    { 15522, 15, "Panqueba" },
                    { 15087, 15, "Belén" },
                    { 15531, 15, "Pauna" },
                    { 15542, 15, "Pesca" },
                    { 15550, 15, "Pisba" },
                    { 15572, 15, "Puerto Boyacá" },
                    { 15580, 15, "Quípama" },
                    { 15599, 15, "Ramiriquí" },
                    { 15600, 15, "Ráquira" },
                    { 15621, 15, "Rondón" },
                    { 15632, 15, "Saboyá" },
                    { 15638, 15, "Sáchica" },
                    { 15646, 15, "Samacá" },
                    { 15660, 15, "San Eduardo" },
                    { 15673, 15, "San Mateo" },
                    { 15686, 15, "Santana" },
                    { 15533, 15, "Paya" },
                    { 99624, 99, "Santa Rosalía" },
                    { 15832, 15, "Tununguá" },
                    { 15189, 15, "Ciénega" },
                    { 17444, 17, "Marquetalia" },
                    { 18460, 18, "Milán" },
                    { 18001, 18, "Florencia" },
                    { 18029, 18, "Albania" },
                    { 18205, 18, "Curillo" },
                    { 18247, 18, "El Doncello" },
                    { 18256, 18, "El Paujil" },
                    { 18479, 18, "Morelia" },
                    { 18592, 18, "Puerto Rico" },
                    { 18410, 18, "La Montañita" },
                    { 18753, 18, "San Vicente del Caguán" },
                    { 18756, 18, "Solano" },
                    { 18785, 18, "Solita" },
                    { 18860, 18, "Valparaíso" },
                    { 18610, 18, "San José del Fragua" },
                    { 18094, 18, "Belén de Los Andaquies" },
                    { 85225, 85, "Nunchía" },
                    { 85139, 85, "Maní" },
                    { 85400, 85, "Támara" },
                    { 85230, 85, "Orocué" },
                    { 85001, 85, "Yopal" },
                    { 85010, 85, "Aguazul" },
                    { 85015, 85, "Chámeza" },
                    { 85125, 85, "Hato Corozal" },
                    { 85136, 85, "La Salina" },
                    { 85162, 85, "Monterrey" },
                    { 85263, 85, "Pore" },
                    { 17877, 17, "Viterbo" },
                    { 17873, 17, "Villamaría" },
                    { 17867, 17, "Victoria" },
                    { 17777, 17, "Supía" },
                    { 15816, 15, "Togüí" },
                    { 15407, 15, "Villa de Leyva" },
                    { 15537, 15, "Paz de Río" },
                    { 15693, 15, "Santa Rosa de Viterbo" },
                    { 15681, 15, "San Pablo de Borbur" },
                    { 15667, 15, "San Luis de Gaceno" },
                    { 17001, 17, "Manizales" },
                    { 17013, 17, "Aguadas" },
                    { 17042, 17, "Anserma" },
                    { 17050, 17, "Aranzazu" },
                    { 17088, 17, "Belalcázar" },
                    { 17174, 17, "Chinchiná" },
                    { 17272, 17, "Filadelfia" },
                    { 15476, 15, "Motavita" },
                    { 17380, 17, "La Dorada" },
                    { 17433, 17, "Manzanares" },
                    { 17442, 17, "Marmato" },
                    { 17446, 17, "Marulanda" },
                    { 17486, 17, "Neira" },
                    { 17495, 17, "Norcasia" },
                    { 17513, 17, "Pácora" },
                    { 17524, 17, "Palestina" },
                    { 17541, 17, "Pensilvania" },
                    { 17614, 17, "Riosucio" },
                    { 17616, 17, "Risaralda" },
                    { 17653, 17, "Salamina" },
                    { 17662, 17, "Samaná" },
                    { 17665, 17, "San José" },
                    { 17388, 17, "La Merced" },
                    { 99773, 99, "Cumaribo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Catalogos_IdUsuario",
                table: "Catalogos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_IdEstado",
                table: "Despachos",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_IdMunicipioDestino",
                table: "Despachos",
                column: "IdMunicipioDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_IdMunicipioOrigen",
                table: "Despachos",
                column: "IdMunicipioOrigen");

            migrationBuilder.CreateIndex(
                name: "IX_Despachos_IdUsuario",
                table: "Despachos",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_CodigoDepartamento",
                table: "Municipios",
                column: "CodigoDepartamento");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_IdTipoNotificacion",
                table: "Notificaciones",
                column: "IdTipoNotificacion");

            migrationBuilder.CreateIndex(
                name: "IX_Notificaciones_IdUsuario",
                table: "Notificaciones",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdDespacho",
                table: "Ofertas",
                column: "IdDespacho");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdEstado",
                table: "Ofertas",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_Ofertas_IdUsuario",
                table: "Ofertas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdCatalogo",
                table: "Servicios",
                column: "IdCatalogo");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdMunicipioDestino",
                table: "Servicios",
                column: "IdMunicipioDestino");

            migrationBuilder.CreateIndex(
                name: "IX_Servicios_IdMunicipioOrigen",
                table: "Servicios",
                column: "IdMunicipioOrigen");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_LogAuthenticacionAPI");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Notificaciones");

            migrationBuilder.DropTable(
                name: "Ofertas");

            migrationBuilder.DropTable(
                name: "Servicios");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "TiposNotificaciones");

            migrationBuilder.DropTable(
                name: "Despachos");

            migrationBuilder.DropTable(
                name: "EstadosOfertas");

            migrationBuilder.DropTable(
                name: "Catalogos");

            migrationBuilder.DropTable(
                name: "EstadosDespachos");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
