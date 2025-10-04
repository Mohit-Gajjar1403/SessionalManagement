using Microsoft.EntityFrameworkCore.Migrations;

namespace SessionalManagement.Migrations
{
    public partial class Encrypt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Email", "Password" },
                values: new object[] { "student003@ddu.ac.in", "$2a$11$sgKN4ye39rPRDJ9TVW7QBOY5oD.JFwdenetAwW6bDx6Aic3y3TozO" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "student002@ddu.ac.in", "$2a$11$VyDAIITwVcjhnXBR.dh17e5wCxO.IUR1v43XL2th.QOcCDtg3HlYu" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "student001@ddu.ac.in", "$2a$11$39BX7NFeiHK3vzp7r8zeveuQsu7OelWr1xCTNJC4GBmu/750fdmmC" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "Email", "Password" },
                values: new object[] { "faculty002@ddu.ac.in", "$2a$11$i9J3rHyBhSOYrLquvpLaie5/2fiMS40pCf18DNdjwK23kEj8OqGlG" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Email", "Password" },
                values: new object[] { "faculty001@ddu.ac.in", "$2a$11$C9c5sFlwU8pKhtzZAdHHGO5kVt/xka9gvOSfIcuOcB7r4FYs8M.4i" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Email", "Password" },
                values: new object[] { "student003@student.com", "student003" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "student002@ddu.in", "student002" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                columns: new[] { "Email", "Password" },
                values: new object[] { "student001@ddu.in", "student001" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -5,
                columns: new[] { "Email", "Password" },
                values: new object[] { "faculty002@ddu.in", "faculty002" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -4,
                columns: new[] { "Email", "Password" },
                values: new object[] { "faculty001@ddu.in", "faculty001" });
        }
    }
}
