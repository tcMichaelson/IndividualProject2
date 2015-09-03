using famiLYNX.Presentation.Web;
using famiLYNX.Infrastructure;
using famiLYNX.Domain;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace famiLYNX.Services {
    public class Services {
        IRepositoryG _repo;

        public Services(IRepositoryG repo) {
            _repo = repo;

        }

        /*Done*/
        public void CreateMessage(string msgText, string contributorUserName, int conversationId) {
            Message newMessage = new Message();
            newMessage.Contributor = GetMemberByUserName(contributorUserName);
            newMessage.Conversation = _repo.Find<Conversation>(conversationId);
            newMessage.Text = msgText;
            newMessage.TimeSubmitted = DateTime.Now;
            _repo.Add<Message>(newMessage);
            _repo.SaveChanges();
        }

        /*Done*/
        public void CreateConversation(CreateConversationViewModel model) {
            Conversation newConvo = new Conversation {
                Topic = model.NewTopic,
                CreatedBy = GetMemberByUserName(model.UserName),
                WhichFam = _repo.Find<Family>(model.FamId),
                IsEvent = model.IsEvent,
                Recurs = model.Recurs,
                ExpirationDate = model.ExpirationDate,
                CreatedDate = DateTime.Now,
                MessageList = new List<Message>(),
                VisibleTo = (from f in _repo.Query<Family>() where f.Id == model.FamId select f.MemberList).FirstOrDefault(),
                AttenderList = new List<Member> { GetMemberByUserName(model.UserName) }
            };
            if (model.FirstMessage != null && model.FirstMessage != "") {
                Message newMessage = new Message { Text = model.FirstMessage, Contributor = newConvo.CreatedBy, Conversation = newConvo, TimeSubmitted = DateTime.Now };
                newConvo.MessageList.Add(newMessage);
                _repo.Add<Message>(newMessage);
            }
            _repo.Add<Conversation>(newConvo);
            _repo.SaveChanges();
        }

        //List method -- need Member and Family
        public FamilyViewModel GetConversations(string userID, string famName) {
            Member member = GetMemberByUserName(userID);  //This is not returning anything.
            List<Family> families = GetFamilysByName(famName);  //This is also returning null.
            foreach (var fam in families) {
                if (fam.MemberList.Contains(member)) {
                    var convoList = (from m in _repo.Query<Conversation>().Include(m => m.MessageList) where m.WhichFam.Id == fam.Id select m).ToList();
                    var dtoConvoList = Mapper.Map<List<ConversationDTO>>(convoList);
                    return new FamilyViewModel { ConversationList = dtoConvoList, FamilyId = fam.Id, FamilyName = fam.OrgName, UserName = userID };
                }
            }
            return new FamilyViewModel();
        }

        private bool IsMemberInFamily(Member member, Family family) {
            if (member != null && family != null) {
                return member.Families.Contains(family);
            }
            return false;
        }

        //List method - 
        public ConversationViewModel GetConversationData(int conversationId, int familyId, string familyName, string userName) {
            ConversationViewModel vm = new ConversationViewModel {
                Conversation = Mapper.Map<ConversationDTO>(_repo.Find<Conversation>(conversationId)),
                FamilyId = familyId,            //The service should be able to find this without passing it to the view model.  
                                                //or maybe this can be retrieved by using authentication.
                FamilyName = familyName,
                UserName = userName
            };
            return (vm);
        }

        public string GetFamilyNameById(int id) {
            return (from m in _repo.Query<Family>() where m.Id == id select m.OrgName).FirstOrDefault();
        }

        public Member GetMemberByUserName(string userName) {
            return (from m in _repo.Query<Member>() where m.UserName == userName select m).Include(m => m.Families).FirstOrDefault();
        }

        public List<Family> GetFamilysByName(string famName) {
            return (from f in _repo.Query<Family>() where f.OrgName.ToLower() == famName.ToLower() select f).Include(f => f.MemberList).ToList();
        }
    }
}