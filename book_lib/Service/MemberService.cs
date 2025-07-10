using System.Collections.Generic;
using book_lib.Entities;

namespace book_lib.Service
{
    public class MemberService
    {
        private List<Member> members = new List<Member>();

        public void AddMember(Member member) => members.Add(member);
        public List<Member> GetAllMembers() => members;

        public bool RemoveMember(int id)
        {
            var member = members.Find(m => m.Id == id);
            if (member != null) { members.Remove(member); return true; }
            return false;
        }
    }
}