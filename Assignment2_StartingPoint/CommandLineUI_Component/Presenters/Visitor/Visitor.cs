namespace CommandLineUI.Presenters.Visitor
{

    interface Visitor
    {
        void VisitLoan(VisitableLoan loan);
    }
}
