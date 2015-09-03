namespace famiLYNX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inheritedApplicationUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrgName = c.String(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTypes", t => t.Type_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.Conversations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Topic = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        ExpirationDate = c.DateTime(),
                        IsEvent = c.Boolean(nullable: false),
                        Recurs = c.Boolean(nullable: false),
                        CreatedBy_Id = c.String(maxLength: 128),
                        WhichFam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.Families", t => t.WhichFam_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.WhichFam_Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        TimeSubmitted = c.DateTime(nullable: false),
                        Contributor_Id = c.String(maxLength: 128),
                        Conversation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Contributor_Id)
                .ForeignKey("dbo.Conversations", t => t.Conversation_Id)
                .Index(t => t.Contributor_Id)
                .Index(t => t.Conversation_Id);
            
            CreateTable(
                "dbo.FamilyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrgType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrgRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        OrgType_Id = c.Int(),
                        Member_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTypes", t => t.OrgType_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Member_Id)
                .Index(t => t.OrgType_Id)
                .Index(t => t.Member_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        Zip = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FamilyMembers",
                c => new
                    {
                        Family_Id = c.Int(nullable: false),
                        Member_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Family_Id, t.Member_Id })
                .ForeignKey("dbo.Families", t => t.Family_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Member_Id, cascadeDelete: true)
                .Index(t => t.Family_Id)
                .Index(t => t.Member_Id);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Conversation_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Conversation_Id1", c => c.Int());
            AddColumn("dbo.AspNetUsers", "UserAddress_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Conversation_Id");
            CreateIndex("dbo.AspNetUsers", "Conversation_Id1");
            CreateIndex("dbo.AspNetUsers", "UserAddress_Id");
            AddForeignKey("dbo.AspNetUsers", "Conversation_Id", "dbo.Conversations", "Id");
            AddForeignKey("dbo.AspNetUsers", "Conversation_Id1", "dbo.Conversations", "Id");
            AddForeignKey("dbo.AspNetUsers", "UserAddress_Id", "dbo.Addresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.OrgRoles", "Member_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrgRoles", "OrgType_Id", "dbo.FamilyTypes");
            DropForeignKey("dbo.Families", "Type_Id", "dbo.FamilyTypes");
            DropForeignKey("dbo.FamilyMembers", "Member_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FamilyMembers", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Conversations", "WhichFam_Id", "dbo.Families");
            DropForeignKey("dbo.AspNetUsers", "Conversation_Id1", "dbo.Conversations");
            DropForeignKey("dbo.Messages", "Conversation_Id", "dbo.Conversations");
            DropForeignKey("dbo.Messages", "Contributor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Conversations", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Conversation_Id", "dbo.Conversations");
            DropIndex("dbo.FamilyMembers", new[] { "Member_Id" });
            DropIndex("dbo.FamilyMembers", new[] { "Family_Id" });
            DropIndex("dbo.OrgRoles", new[] { "Member_Id" });
            DropIndex("dbo.OrgRoles", new[] { "OrgType_Id" });
            DropIndex("dbo.Messages", new[] { "Conversation_Id" });
            DropIndex("dbo.Messages", new[] { "Contributor_Id" });
            DropIndex("dbo.Conversations", new[] { "WhichFam_Id" });
            DropIndex("dbo.Conversations", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Families", new[] { "Type_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "UserAddress_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Conversation_Id1" });
            DropIndex("dbo.AspNetUsers", new[] { "Conversation_Id" });
            DropColumn("dbo.AspNetUsers", "UserAddress_Id");
            DropColumn("dbo.AspNetUsers", "Conversation_Id1");
            DropColumn("dbo.AspNetUsers", "Conversation_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.FamilyMembers");
            DropTable("dbo.Addresses");
            DropTable("dbo.OrgRoles");
            DropTable("dbo.FamilyTypes");
            DropTable("dbo.Messages");
            DropTable("dbo.Conversations");
            DropTable("dbo.Families");
        }
    }
}
