using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using famiLYNX.Infrastructure;
using Moq;
using famiLYNX.Domain;
using System.Collections.Generic;
using famiLYNX.Models;
using famiLYNX.Services;
using famiLYNX.Controllers;

namespace famiLYNX.Tests {
    [TestClass]
    public class FamilysControllerTests {
        [TestMethod]
        public void CreateMessageTest() {
            //Arrange
            var testConversation = new Conversation {
                //AttenderIds = new List<string>(),
                Attenders = new List<ConversationsAttendedByMembers>(),
                CreatedBy = new ApplicationUser(),
                //CreatedById = "123jkl",
                CreatedDate = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                //FamilyId = 123,
                Id = 3245,
                IsEvent = false,
                MessageList = new List<Message>(),
                Recurs = false,
                Topic = "Some Topic",
                VisibleTo = new List<ConversationsVisibleToMembers>(),
                //VisibleToIds = new List<string>(),
                WhichFam = new Family()
            };

            var testFamilys = new List<Family> { new Family {
                Id = 1,
                ConversationList = new List<Conversation> { testConversation },
                CreatedBy = new Models.ApplicationUser(),
                FamilyUserName = "username",
                InviteOrPleas = new List<InviteOrPlea>(),
                MemberList = new List<FamilyUser>(),
                OrgName = "Organization"
            } };
            var userID = "tmichael";


            var mockRepo = new Mock<IRepositoryG>();
            mockRepo.Setup(r => r.Query<Family>()).Returns(testFamilys.AsQueryable());
            var controller = new FamilysController(new Services.Services(mockRepo.Object));

            //Act


            //Assert
        }
    }
}
