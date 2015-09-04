namespace famiLYNX.Migrations {
    using famiLYNX.Domain;
    using famiLYNX.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<famiLYNX.Models.ApplicationDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(famiLYNX.Models.ApplicationDbContext context) {
            context.FamilyTypes.AddOrUpdate(
                     f => f.OrgType,
                     new FamilyType { OrgType = "Family" },
                     new FamilyType { OrgType = "Church" },
                     new FamilyType { OrgType = "Roommates" },
                     new FamilyType { OrgType = "Friends" },
                     new FamilyType { OrgType = "Scout Troop" },
                     new FamilyType { OrgType = "Business" }
                     );


            var famtypes = (from f in context.FamilyTypes select f).ToList();

            context.Addresses.AddOrUpdate(
                a => a.Street,
                new Address { Street = "1507 Prairiewind Dr.", City = "Sandwich", State = StName.Illinois, Zip = "60548" },
                new Address { Street = "45 Main St.", City = "Plano", State = StName.Illinois, Zip = "60545" },
                new Address { Street = "349 Broadway St.", City = "Houston", State = StName.Texas, Zip = "66451" },
                new Address { Street = "2354 Magnolia St.", City = "San Diego", State = StName.California, Zip = "92021" }
                );

            var addressList = (from a in context.Addresses select a).ToList();


            context.Users.AddOrUpdate(
                m => m.UserName,
                new ApplicationUser { FirstName = "Tom", LastName = "Michaelson", UserAddress = addressList[0], UserName = "tmichael", Email = "a@a.com" },
                new ApplicationUser { FirstName = "Jon", LastName = "Johnson", UserAddress = addressList[1], UserName = "jjohnson", Email = "b@a.com" },
                new ApplicationUser { FirstName = "Alex", LastName = "Gunderson", UserAddress = addressList[2], UserName = "agunderson", Email = "c@a.com" },
                new ApplicationUser { FirstName = "Bobby", LastName = "Masterson", UserAddress = addressList[3], UserName = "bmasterson", Email = "d@a.com" }
                );

            var memberList1 = (from m in context.Users orderby m.UserName ascending select m).Take(2).ToList();
            var memberList2 = (from m in context.Users orderby m.UserName ascending select m).Skip(2).Take(2).ToList();

            context.Families.AddOrUpdate(
                f => f.OrgName,
                new Family { OrgName = "Stevenson", MemberList = new List<ApplicationUser> { memberList1[0], memberList1[1] }, Type = famtypes[0] },
                new Family { OrgName = "Michaelson", MemberList = new List<ApplicationUser> { memberList2[0], memberList2[1] }, Type = famtypes[0] }
                );

            List<Family> familyList = (from c in context.Families select c).ToList();

            context.Messages.AddOrUpdate(
                m => m.Text,
                new Message { Text = "Hey let's all get together on Monday for lunch!", Contributor = memberList1[0], TimeSubmitted = new DateTime(2015, 8, 21) },
                new Message { Text = "Hey let's all get together on Tuesday for lunch!", Contributor = memberList1[1], TimeSubmitted = new DateTime(2015, 8, 22) },
                new Message { Text = "Hey let's all get together on Wednesday for lunch!", Contributor = memberList2[0], TimeSubmitted = new DateTime(2015, 8, 23) },
                new Message { Text = "Hey let's all get together on Thursday for lunch!", Contributor = memberList2[1], TimeSubmitted = new DateTime(2015, 8, 24) },
                new Message { Text = "Hey let's all get together on Friday for lunch!", Contributor = memberList1[0], TimeSubmitted = new DateTime(2015, 8, 25) },
                new Message { Text = "I've stopped trying to get together for lunch!", Contributor = memberList1[1], TimeSubmitted = new DateTime(2015, 8, 26) },
                new Message { Text = "Hey let's all get together on Monday for dinner!", Contributor = memberList2[0], TimeSubmitted = new DateTime(2015, 8, 27) },
                new Message { Text = "Hey let's all get together on Tuesday for dinner!", Contributor = memberList2[1], TimeSubmitted = new DateTime(2015, 8, 28) },
                new Message { Text = "Hey let's all get together on Wednesday for dinner!", Contributor = memberList1[0], TimeSubmitted = new DateTime(2015, 8, 29) }

                );

            List<Message> messageList = (from m in context.Messages select m).ToList();

            context.Conversations.AddOrUpdate(
                m => m.Topic,
                new Conversation { Topic = "Lunch, Man!", CreatedBy = memberList1[0], WhichFam = familyList[0], CreatedDate = messageList[0].TimeSubmitted, Recurs = false, IsEvent = false, MessageList = new List<Message> { messageList[0], messageList[1], messageList[2], messageList[3], messageList[4], messageList[5] } },
                new Conversation { Topic = "Dinner, Yo!", CreatedBy = memberList2[0], WhichFam = familyList[1], CreatedDate = messageList[6].TimeSubmitted, Recurs = false, IsEvent = false, MessageList = new List<Message> { messageList[6], messageList[7], messageList[8] } }
                );

            context.OrgRoles.AddOrUpdate(
                r => r.RoleName,
                new OrgRole { RoleName = "Father", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Mother", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Grandmother", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Grandfather", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Grandmother", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Grandfather", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Great Grandmother", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Great Grandfather", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Sister", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Brother", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Aunt", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Uncle", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Granduncle", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Grandaunt", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Granduncle", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Grandaunt", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Daughter", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Son", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Granddaughter", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Grandson", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Granddaughter", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Grandson", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Great Granddaughter", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Great Great Grandson", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Son-in-law", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Daughter-in-law", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Mother-in-law", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Father-in-law", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Cousin", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Nephew", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Neice", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Grandnephew", OrgType = famtypes[0] },
                new OrgRole { RoleName = "Grandneice", OrgType = famtypes[0] }
                );

        }
    }
}
