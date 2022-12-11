using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eTickets.Migrations
{
    public partial class Roles : Migration
    {

        private string _managerRoleId = Guid.NewGuid().ToString();  
        private string _adminRoleId = Guid.NewGuid().ToString();
        private string _userRoleID = Guid.NewGuid().ToString(); 

        private const string _adminId = "54afbe8d-29cf-4498-9d9e-3bc19410747b";    
        private const string _managerId = "21c564a7-6feb-4283-9db4-6909b7caf776";


        private void SeedRolesTable(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"Insert into [dbo].[AspNetRoles] ([Id] ,[Name] ,[NormalizedName] ,[ConcurrencyStamp]) Values('{_managerRoleId}', 'Manager', 'MANAGER', null)");
            migrationBuilder.Sql(@$"Insert into [dbo].[AspNetRoles] ([Id] ,[Name] ,[NormalizedName] ,[ConcurrencyStamp]) Values('{_adminRoleId}', 'Administrator', 'ADMINISTRATOR', null)");
            migrationBuilder.Sql(@$"Insert into [dbo].[AspNetRoles] ([Id] ,[Name] ,[NormalizedName] ,[ConcurrencyStamp]) Values('{_userRoleID}', 'User', 'USER', null)");
        }

        private void SeedUserRolesTable(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"Insert into [dbo].[AspNetUserRoles] ( [UserId] , [RoleId] ) Values ('{_adminId}', '{_adminRoleId}') ");
            migrationBuilder.Sql(@$"Insert into [dbo].[AspNetUserRoles] ( [UserId] , [RoleId] ) Values ('{_managerId}', '{_managerRoleId}') ");
        }


        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesTable(migrationBuilder);
            SeedUserRolesTable(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
