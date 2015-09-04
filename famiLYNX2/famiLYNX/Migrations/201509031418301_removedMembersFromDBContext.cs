namespace famiLYNX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedMembersFromDBContext : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FamilyMembers", newName: "FamilyApplicationUsers");
            RenameColumn(table: "dbo.FamilyApplicationUsers", name: "Member_Id", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.OrgRoles", name: "Member_Id", newName: "ApplicationUser_Id");
            RenameIndex(table: "dbo.OrgRoles", name: "IX_Member_Id", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.FamilyApplicationUsers", name: "IX_Member_Id", newName: "IX_ApplicationUser_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            RenameIndex(table: "dbo.FamilyApplicationUsers", name: "IX_ApplicationUser_Id", newName: "IX_Member_Id");
            RenameIndex(table: "dbo.OrgRoles", name: "IX_ApplicationUser_Id", newName: "IX_Member_Id");
            RenameColumn(table: "dbo.OrgRoles", name: "ApplicationUser_Id", newName: "Member_Id");
            RenameColumn(table: "dbo.FamilyApplicationUsers", name: "ApplicationUser_Id", newName: "Member_Id");
            RenameTable(name: "dbo.FamilyApplicationUsers", newName: "FamilyMembers");
        }
    }
}
