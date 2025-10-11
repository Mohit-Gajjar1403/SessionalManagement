using Microsoft.EntityFrameworkCore.Migrations;

namespace SessionalManagement.Migrations
{
    public partial class BCryptedPass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -3,
                column: "Password",
                value: "$2a$11$ja5LU/B.9HcRE2PNBF/AB.1EPqbjsSc/0mvIHGk/tM7T7u0Vmqpva");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                column: "Password",
                value: "$2a$11$yn0ZmxludgxDDqaktwgToOTKZ9xniVW/Lbqd/gemZGPwe/3miI/xq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "Password",
                value: "$2a$11$msM8vgUX5/QaMQ0L09t0T.gpUPHkBFJ/rfYCty1iwAb9MJmOudVhu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -5,
                column: "Password",
                value: "$2a$11$BfwbBLU1bg9E9qDk1TjjhO3eETjuq3kK.Bp52peXg56vrMxsX7/HO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -4,
                column: "Password",
                value: "$2a$11$qGWbhdZ3mGuODeKGYL7hQOmk4/rT8kZjbFEljFcu.Ta6u97dVBE7G");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -3,
                column: "Password",
                value: "$2a$11$sgKN4ye39rPRDJ9TVW7QBOY5oD.JFwdenetAwW6bDx6Aic3y3TozO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                column: "Password",
                value: "$2a$11$VyDAIITwVcjhnXBR.dh17e5wCxO.IUR1v43XL2th.QOcCDtg3HlYu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -1,
                column: "Password",
                value: "$2a$11$39BX7NFeiHK3vzp7r8zeveuQsu7OelWr1xCTNJC4GBmu/750fdmmC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -5,
                column: "Password",
                value: "$2a$11$i9J3rHyBhSOYrLquvpLaie5/2fiMS40pCf18DNdjwK23kEj8OqGlG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -4,
                column: "Password",
                value: "$2a$11$C9c5sFlwU8pKhtzZAdHHGO5kVt/xka9gvOSfIcuOcB7r4FYs8M.4i");
        }
    }
}
