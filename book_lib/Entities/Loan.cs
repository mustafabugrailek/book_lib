using System;

namespace book_lib.Entities
{
    public class Loan
    {
        public int MemberId { get; set; }
        public long BookISBN { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public Loan(int memberId, long bookISBN)
        {
            MemberId = memberId;
            BookISBN = bookISBN;
            LoanDate = DateTime.Now;
            ReturnDate = null;
        }
    }
}