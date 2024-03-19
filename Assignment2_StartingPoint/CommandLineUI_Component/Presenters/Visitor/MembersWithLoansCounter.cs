using System.Collections.Generic;

namespace CommandLineUI.Presenters.Visitor
{
    class MembersWithLoansCounter : Visitor
    {
        private HashSet<int> idOfMembersWithLoans = new HashSet<int>();

        public int NumberOfMembersWithLoans 
        { 
            get
            {
                return idOfMembersWithLoans.Count;
            }
        }

        public void VisitLoan(VisitableLoan loan)
        {
            idOfMembersWithLoans.Add(loan.Member.ID);
        }
    }
}
