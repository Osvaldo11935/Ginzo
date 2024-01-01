using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademicLevel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademicLevel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DocumentNumber = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Discipline",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discipline", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentStatus",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SchoolYear",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    StartYear = table.Column<int>(type: "integer", nullable: false),
                    EndYear = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Country = table.Column<string>(type: "text", nullable: true),
                    County = table.Column<string>(type: "text", nullable: true),
                    Province = table.Column<string>(type: "text", nullable: true),
                    Number = table.Column<string>(type: "text", nullable: true),
                    Street = table.Column<string>(type: "text", nullable: true),
                    Complement = table.Column<string>(type: "text", nullable: true),
                    District = table.Column<string>(type: "text", nullable: true),
                    Neighborhood = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "PersonalData",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Mother = table.Column<string>(type: "text", nullable: true),
                    Father = table.Column<string>(type: "text", nullable: true),
                    Natural = table.Column<string>(type: "text", nullable: true),
                    DocumentIssuanceDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    DocumentExpirationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PlaceIssuanceDocument = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalData_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DisciplineCourse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsKey = table.Column<bool>(type: "boolean", nullable: true),
                    CourseId = table.Column<string>(type: "text", nullable: true),
                    DisciplineId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisciplineCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DisciplineCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DisciplineCourse_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentParameter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FinalAverage = table.Column<double>(type: "double precision", nullable: false),
                    MinPriorityAge = table.Column<int>(type: "integer", nullable: false),
                    MaxPriorityAge = table.Column<int>(type: "integer", nullable: false),
                    SchoolYearId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentParameter_SchoolYear_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYear",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Schedule",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    DayWeek = table.Column<string>(type: "text", nullable: true),
                    ExitDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    EntryDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    SchoolYearId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedule", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Schedule_SchoolYear_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYear",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    StudentId = table.Column<string>(type: "text", nullable: true),
                    FinalAverage = table.Column<double>(type: "double precision", nullable: false),
                    EnrollmentStatusId = table.Column<string>(type: "text", nullable: true),
                    EnrollmentParameterId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enrollment_AspNetUsers_StudentId",
                        column: x => x.StudentId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollment_EnrollmentParameter_EnrollmentParameterId",
                        column: x => x.EnrollmentParameterId,
                        principalTable: "EnrollmentParameter",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enrollment_EnrollmentStatus_EnrollmentStatusId",
                        column: x => x.EnrollmentStatusId,
                        principalTable: "EnrollmentStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VacancyCourse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    CourseId = table.Column<string>(type: "text", nullable: true),
                    TotalVacancy = table.Column<int>(type: "integer", nullable: false),
                    EnrollmentParameterId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacancyCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacancyCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VacancyCourse_EnrollmentParameter_EnrollmentParameterId",
                        column: x => x.EnrollmentParameterId,
                        principalTable: "EnrollmentParameter",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    CourseId = table.Column<string>(type: "text", nullable: true),
                    SchoolYearId = table.Column<string>(type: "text", nullable: true),
                    AcademicLevelId = table.Column<string>(type: "text", nullable: true),
                    ScheduleId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_AcademicLevel_AcademicLevelId",
                        column: x => x.AcademicLevelId,
                        principalTable: "AcademicLevel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Class_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Class_Schedule_ScheduleId",
                        column: x => x.ScheduleId,
                        principalTable: "Schedule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Class_SchoolYear_SchoolYearId",
                        column: x => x.SchoolYearId,
                        principalTable: "SchoolYear",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentCourse",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    IsFirstOption = table.Column<bool>(type: "boolean", nullable: false),
                    CourseId = table.Column<string>(type: "text", nullable: true),
                    EnrollmentId = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentCourse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnrollmentCourse_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EnrollmentCourse_Enrollment_EnrollmentId",
                        column: x => x.EnrollmentId,
                        principalTable: "Enrollment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClassSchedule",
                columns: table => new
                {
                    ClassesId = table.Column<string>(type: "text", nullable: false),
                    SchedulesId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassSchedule", x => new { x.ClassesId, x.SchedulesId });
                    table.ForeignKey(
                        name: "FK_ClassSchedule_Class_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassSchedule_Schedule_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Schedule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    ClassId = table.Column<string>(type: "text", nullable: true),
                    ProcessNumber = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Student_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EnrollmentCourseDiscipline",
                columns: table => new
                {
                    DisciplineId = table.Column<string>(type: "text", nullable: false),
                    EnrollmentCourseId = table.Column<string>(type: "text", nullable: false),
                    FinalAverage = table.Column<double>(type: "double precision", nullable: false),
                    Id = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrollmentCourseDiscipline", x => new { x.DisciplineId, x.EnrollmentCourseId });
                    table.ForeignKey(
                        name: "FK_EnrollmentCourseDiscipline_Discipline_DisciplineId",
                        column: x => x.DisciplineId,
                        principalTable: "Discipline",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrollmentCourseDiscipline_EnrollmentCourse_EnrollmentCours~",
                        column: x => x.EnrollmentCourseId,
                        principalTable: "EnrollmentCourse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "30963a2f-adbd-41e4-ae25-c3e9c5774c3d", null, "Admin", "ADMIN" },
                    { "47ecebc6-5682-45c1-8ec4-b5b8cc1da0e1", null, "Aluno", "ALUNO" },
                    { "7395136a-692d-4d60-a2b3-80c1967ba6f7", null, "Professor(a)", "PROFESSOR(A)" }
                });

            migrationBuilder.InsertData(
                table: "EnrollmentStatus",
                columns: new[] { "Id", "CreatedAt", "Description", "IsActive", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { "30963a2f-adbd-41e4-ae25-c3e9c5774c3d", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6910), "Aprovado", true, "Aprovado", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6934) },
                    { "47ecebc6-5682-45c1-8ec4-b5b8cc1da0e1", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6942), "Reprovado", true, "Reprovado", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6943) },
                    { "7395136a-692d-4d60-a2b3-80c1967ba6f7", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6948), "Anulado", true, "Anulado", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6949) },
                    { "81a9dcce-3aaf-4a56-b429-73854eb25cf2", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6959), "Pre-Aprovado", true, "Pre-Aprovado", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6960) },
                    { "fbe16f4c-bd17-4889-b027-a70a2dcdae42", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6954), "Em analise", true, "Em analise", new DateTime(2024, 1, 1, 10, 43, 30, 772, DateTimeKind.Local).AddTicks(6955) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

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
                name: "IX_Class_AcademicLevelId",
                table: "Class",
                column: "AcademicLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_CourseId",
                table: "Class",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_ScheduleId",
                table: "Class",
                column: "ScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_SchoolYearId",
                table: "Class",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_ClassSchedule_SchedulesId",
                table: "ClassSchedule",
                column: "SchedulesId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineCourse_CourseId",
                table: "DisciplineCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_DisciplineCourse_DisciplineId",
                table: "DisciplineCourse",
                column: "DisciplineId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_EnrollmentParameterId",
                table: "Enrollment",
                column: "EnrollmentParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_EnrollmentStatusId",
                table: "Enrollment",
                column: "EnrollmentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollment_StudentId",
                table: "Enrollment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentCourse_CourseId",
                table: "EnrollmentCourse",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentCourse_EnrollmentId",
                table: "EnrollmentCourse",
                column: "EnrollmentId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentCourseDiscipline_EnrollmentCourseId",
                table: "EnrollmentCourseDiscipline",
                column: "EnrollmentCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_EnrollmentParameter_SchoolYearId",
                table: "EnrollmentParameter",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalData_UserId",
                table: "PersonalData",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_SchoolYearId",
                table: "Schedule",
                column: "SchoolYearId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_ClassId",
                table: "Student",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_UserId",
                table: "Student",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VacancyCourse_CourseId",
                table: "VacancyCourse",
                column: "CourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VacancyCourse_EnrollmentParameterId",
                table: "VacancyCourse",
                column: "EnrollmentParameterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

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
                name: "ClassSchedule");

            migrationBuilder.DropTable(
                name: "DisciplineCourse");

            migrationBuilder.DropTable(
                name: "EnrollmentCourseDiscipline");

            migrationBuilder.DropTable(
                name: "PersonalData");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "VacancyCourse");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Discipline");

            migrationBuilder.DropTable(
                name: "EnrollmentCourse");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "AcademicLevel");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Schedule");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EnrollmentParameter");

            migrationBuilder.DropTable(
                name: "EnrollmentStatus");

            migrationBuilder.DropTable(
                name: "SchoolYear");
        }
    }
}
