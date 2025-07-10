using System;
using System.Collections.Generic;
using System.Linq;
using book_lib.Entities;

namespace book_lib.Service
{
    public class LoanService
    {
        private List<Loan> loans = new List<Loan>();

        public void LoanBook(int memberId, long isbn) => loans.Add(new Loan(memberId, isbn));

        public bool ReturnBook(int memberId, long isbn)
        {
            var loan = loans.FirstOrDefault(l => l.MemberId == memberId && l.BookISBN == isbn && l.ReturnDate == null);
            if (loan != null) { loan.ReturnDate = DateTime.Now; return true; }
            return false;
        }

        public List<Loan> GetLoansByMember(int memberId) => loans.Where(l => l.MemberId == memberId).ToList();
        public List<Loan> GetActiveLoans() => loans.Where(l => l.ReturnDate == null).ToList();
        public List<Loan> GetLateReturns(int maxDays = 7) => loans.Where(l => l.ReturnDate.HasValue && (l.ReturnDate.Value - l.LoanDate).TotalDays > maxDays).ToList();
        public List<Loan> GetOverdueLoans(int maxDays = 7) => loans.Where(l => l.ReturnDate == null && (DateTime.Now - l.LoanDate).TotalDays > maxDays).ToList();

        public Dictionary<long, int> GetMostLoanedBooks() => loans.GroupBy(l => l.BookISBN).ToDictionary(g => g.Key, g => g.Count());
        public Dictionary<int, int> GetMostActiveMembers() => loans.GroupBy(l => l.MemberId).ToDictionary(g => g.Key, g => g.Count());
    }
}