using System.Collections.Generic;

namespace CommandLineUI.Presenters.Visitor
{
    class LoanPrinter : Visitor
    {

        public List<string> Lines { get; } = new List<string>();

        public void VisitLoan(VisitableLoan loan)
        {
            Lines.Add(
                string.Format(
                    "\t{0, -20} {1, -20} {2, -12} {3, -12}    {4}",
                    loan.Book.Title,
                    loan.Member.Name,
                    loan.LoanDate.ToString("dd/MM/yyyy"),
                    loan.DueDate.ToString("dd/MM/yyyy"),
                    loan.NumberOfRenewals));
        }
    }
}
