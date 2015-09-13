namespace famiLYNX.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        City = c.String(),
                        State = c.Int(nullable: false),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                        WhichFam_Id = c.Int(),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.WhichFam_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.WhichFam_Id)
                .Index(t => t.CreatedBy_Id);
            
            CreateTable(
                "dbo.ConversationsAttendedByMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(maxLength: 128),
                        ConversationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conversations", t => t.ConversationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberId)
                .Index(t => t.MemberId)
                .Index(t => t.ConversationId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        UserAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.UserAddress_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.UserAddress_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.FamilyUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FamilyId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.FamilyId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.FamilyId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Families",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FamilyUserName = c.String(),
                        OrgName = c.String(),
                        CreatedBy_Id = c.String(maxLength: 128),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .ForeignKey("dbo.FamilyTypes", t => t.Type_Id)
                .Index(t => t.CreatedBy_Id)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.InviteOrPleas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(),
                        UserResponse = c.Int(nullable: false),
                        Approved = c.Int(nullable: false),
                        Family_Id = c.Int(),
                        Inviter_Id = c.String(maxLength: 128),
                        Pleader_Id = c.String(maxLength: 128),
                        Approver_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Families", t => t.Family_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Inviter_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Pleader_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Approver_Id)
                .Index(t => t.Family_Id)
                .Index(t => t.Inviter_Id)
                .Index(t => t.Pleader_Id)
                .Index(t => t.Approver_Id);
            
            CreateTable(
                "dbo.FamilyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OrgType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OrgRoles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                        OrgType_Id = c.Int(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FamilyTypes", t => t.OrgType_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.OrgType_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ConversationsVisibleToMembers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.String(maxLength: 128),
                        ConversationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Conversations", t => t.ConversationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.MemberId)
                .Index(t => t.MemberId)
                .Index(t => t.ConversationId);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        TimeSubmitted = c.DateTime(nullable: false),
                        ContributorId = c.String(maxLength: 128),
                        ConversationID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ContributorId)
                .ForeignKey("dbo.Conversations", t => t.ConversationID, cascadeDelete: true)
                .Index(t => t.ContributorId)
                .Index(t => t.ConversationID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Messages", "ConversationID", "dbo.Conversations");
            DropForeignKey("dbo.Messages", "ContributorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Conversations", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConversationsAttendedByMembers", "MemberId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConversationsVisibleToMembers", "MemberId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConversationsVisibleToMembers", "ConversationId", "dbo.Conversations");
            DropForeignKey("dbo.AspNetUsers", "UserAddress_Id", "dbo.Addresses");
            DropForeignKey("dbo.InviteOrPleas", "Approver_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InviteOrPleas", "Pleader_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrgRoles", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.OrgRoles", "OrgType_Id", "dbo.FamilyTypes");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.InviteOrPleas", "Inviter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FamilyUsers", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FamilyUsers", "FamilyId", "dbo.Families");
            DropForeignKey("dbo.Families", "Type_Id", "dbo.FamilyTypes");
            DropForeignKey("dbo.InviteOrPleas", "Family_Id", "dbo.Families");
            DropForeignKey("dbo.Families", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Conversations", "WhichFam_Id", "dbo.Families");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ConversationsAttendedByMembers", "ConversationId", "dbo.Conversations");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Messages", new[] { "ConversationID" });
            DropIndex("dbo.Messages", new[] { "ContributorId" });
            DropIndex("dbo.ConversationsVisibleToMembers", new[] { "ConversationId" });
            DropIndex("dbo.ConversationsVisibleToMembers", new[] { "MemberId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.OrgRoles", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.OrgRoles", new[] { "OrgType_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.InviteOrPleas", new[] { "Approver_Id" });
            DropIndex("dbo.InviteOrPleas", new[] { "Pleader_Id" });
            DropIndex("dbo.InviteOrPleas", new[] { "Inviter_Id" });
            DropIndex("dbo.InviteOrPleas", new[] { "Family_Id" });
            DropIndex("dbo.Families", new[] { "Type_Id" });
            DropIndex("dbo.Families", new[] { "CreatedBy_Id" });
            DropIndex("dbo.FamilyUsers", new[] { "UserId" });
            DropIndex("dbo.FamilyUsers", new[] { "FamilyId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UserAddress_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.ConversationsAttendedByMembers", new[] { "ConversationId" });
            DropIndex("dbo.ConversationsAttendedByMembers", new[] { "MemberId" });
            DropIndex("dbo.Conversations", new[] { "CreatedBy_Id" });
            DropIndex("dbo.Conversations", new[] { "WhichFam_Id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Messages");
            DropTable("dbo.ConversationsVisibleToMembers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.OrgRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.FamilyTypes");
            DropTable("dbo.InviteOrPleas");
            DropTable("dbo.Families");
            DropTable("dbo.FamilyUsers");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.ConversationsAttendedByMembers");
            DropTable("dbo.Conversations");
            DropTable("dbo.Addresses");
        }
    }
}
