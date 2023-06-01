using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Server.Migrations
{
    /// <inheritdoc />
    public partial class Initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Order = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Login = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WordBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Word = table.Column<string>(type: "TEXT", maxLength: 12, nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Root = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    Ending = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true),
                    ConjugationType = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WordBase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerbsMutationBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PronounForm = table.Column<int>(type: "INTEGER", nullable: false),
                    VerbConjugationType = table.Column<int>(type: "INTEGER", nullable: false),
                    TenseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    Prefix = table.Column<string>(type: "TEXT", nullable: true),
                    Ending = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VerbsMutationBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VerbsMutationBase_Tenses_TenseId",
                        column: x => x.TenseId,
                        principalTable: "Tenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LearningSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Completed = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LearningSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LearningSessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskBase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MutationId = table.Column<int>(type: "INTEGER", nullable: false),
                    WordId = table.Column<int>(type: "INTEGER", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false),
                    LearningSessionId = table.Column<int>(type: "INTEGER", nullable: true),
                    Subject = table.Column<string>(type: "TEXT", maxLength: 12, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskBase_LearningSessions_LearningSessionId",
                        column: x => x.LearningSessionId,
                        principalTable: "LearningSessions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TaskBase_VerbsMutationBase_MutationId",
                        column: x => x.MutationId,
                        principalTable: "VerbsMutationBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskBase_WordBase_WordId",
                        column: x => x.WordId,
                        principalTable: "WordBase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Login", "Name", "Password", "Role" },
                values: new object[] { 1, "Admin", "Vasily", "E6C83B282AEB2E022844595721CC00BBDA47CB24537C1779F9BB84F04039E1676E6BA8573E588DA1052510E3AA0A32A9E55879AE22B0C2D62136FC0A3E85F8BB", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_LearningSessions_UserId",
                table: "LearningSessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBase_LearningSessionId",
                table: "TaskBase",
                column: "LearningSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBase_MutationId",
                table: "TaskBase",
                column: "MutationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskBase_WordId",
                table: "TaskBase",
                column: "WordId");

            migrationBuilder.CreateIndex(
                name: "IX_VerbsMutationBase_TenseId",
                table: "VerbsMutationBase",
                column: "TenseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskBase");

            migrationBuilder.DropTable(
                name: "LearningSessions");

            migrationBuilder.DropTable(
                name: "VerbsMutationBase");

            migrationBuilder.DropTable(
                name: "WordBase");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Tenses");
        }
    }
}
