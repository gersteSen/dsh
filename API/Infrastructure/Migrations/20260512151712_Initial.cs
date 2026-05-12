using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "instrument");

            migrationBuilder.EnsureSchema(
                name: "lesson");

            migrationBuilder.EnsureSchema(
                name: "ref");

            migrationBuilder.EnsureSchema(
                name: "material");

            migrationBuilder.EnsureSchema(
                name: "room");

            migrationBuilder.EnsureSchema(
                name: "student");

            migrationBuilder.EnsureSchema(
                name: "teacher");

            migrationBuilder.CreateTable(
                name: "Instruments",
                schema: "instrument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instruments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "room",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                schema: "student",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    ActiveSince = table.Column<DateOnly>(type: "date", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                schema: "teacher",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Avatar = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<int>(type: "integer", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Birthday = table.Column<DateOnly>(type: "date", nullable: true),
                    ActiveSince = table.Column<DateOnly>(type: "date", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentInstruments",
                schema: "ref",
                columns: table => new
                {
                    InstrumentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInstruments", x => new { x.InstrumentsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentInstruments_Instruments_InstrumentsId",
                        column: x => x.InstrumentsId,
                        principalSchema: "instrument",
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentInstruments_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentRooms",
                schema: "ref",
                columns: table => new
                {
                    RoomsId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRooms", x => new { x.RoomsId, x.StudentsId });
                    table.ForeignKey(
                        name: "FK_StudentRooms_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalSchema: "room",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentRooms_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                schema: "lesson",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    State = table.Column<int>(type: "integer", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: false),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: false),
                    RoomId = table.Column<Guid>(type: "uuid", nullable: false),
                    InstrumentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lessons_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalSchema: "instrument",
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "room",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Lessons_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lessons_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "teacher",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                schema: "material",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Filetype = table.Column<string>(type: "text", nullable: true),
                    Filesize = table.Column<double>(type: "double precision", nullable: true),
                    Filesource = table.Column<string>(type: "text", nullable: false),
                    TeacherId = table.Column<Guid>(type: "uuid", nullable: true),
                    StudentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materials_Students_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Materials_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalSchema: "teacher",
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudentTeachers",
                schema: "ref",
                columns: table => new
                {
                    StudentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeachersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeachers", x => new { x.StudentsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_StudentTeachers_Students_StudentsId",
                        column: x => x.StudentsId,
                        principalSchema: "student",
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeachers_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalSchema: "teacher",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherInstruments",
                schema: "ref",
                columns: table => new
                {
                    InstrumentsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeachersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherInstruments", x => new { x.InstrumentsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_TeacherInstruments_Instruments_InstrumentsId",
                        column: x => x.InstrumentsId,
                        principalSchema: "instrument",
                        principalTable: "Instruments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherInstruments_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalSchema: "teacher",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherRooms",
                schema: "ref",
                columns: table => new
                {
                    RoomsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TeachersId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherRooms", x => new { x.RoomsId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_TeacherRooms_Rooms_RoomsId",
                        column: x => x.RoomsId,
                        principalSchema: "room",
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherRooms_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalSchema: "teacher",
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialLessons",
                schema: "ref",
                columns: table => new
                {
                    LessonsId = table.Column<Guid>(type: "uuid", nullable: false),
                    MaterialsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialLessons", x => new { x.LessonsId, x.MaterialsId });
                    table.ForeignKey(
                        name: "FK_MaterialLessons_Lessons_LessonsId",
                        column: x => x.LessonsId,
                        principalSchema: "lesson",
                        principalTable: "Lessons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialLessons_Materials_MaterialsId",
                        column: x => x.MaterialsId,
                        principalSchema: "material",
                        principalTable: "Materials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_InstrumentId",
                schema: "lesson",
                table: "Lessons",
                column: "InstrumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_RoomId",
                schema: "lesson",
                table: "Lessons",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_StudentId",
                schema: "lesson",
                table: "Lessons",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherId",
                schema: "lesson",
                table: "Lessons",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialLessons_MaterialsId",
                schema: "ref",
                table: "MaterialLessons",
                column: "MaterialsId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_StudentId",
                schema: "material",
                table: "Materials",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Materials_TeacherId",
                schema: "material",
                table: "Materials",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInstruments_StudentsId",
                schema: "ref",
                table: "StudentInstruments",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRooms_StudentsId",
                schema: "ref",
                table: "StudentRooms",
                column: "StudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeachers_TeachersId",
                schema: "ref",
                table: "StudentTeachers",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherInstruments_TeachersId",
                schema: "ref",
                table: "TeacherInstruments",
                column: "TeachersId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherRooms_TeachersId",
                schema: "ref",
                table: "TeacherRooms",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MaterialLessons",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "StudentInstruments",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "StudentRooms",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "StudentTeachers",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "TeacherInstruments",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "TeacherRooms",
                schema: "ref");

            migrationBuilder.DropTable(
                name: "Lessons",
                schema: "lesson");

            migrationBuilder.DropTable(
                name: "Materials",
                schema: "material");

            migrationBuilder.DropTable(
                name: "Instruments",
                schema: "instrument");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "room");

            migrationBuilder.DropTable(
                name: "Students",
                schema: "student");

            migrationBuilder.DropTable(
                name: "Teachers",
                schema: "teacher");
        }
    }
}
