namespace CommandLineUI.Presenters.Visitor
{
    interface Visitable
    {
        void AcceptVisitFrom(Visitor v);
    }
}
