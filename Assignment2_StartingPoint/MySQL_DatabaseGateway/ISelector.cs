namespace DatabaseGateway
{
    // This interface illustrates the Interface Segregation Principle
    interface ISelector<T>
    {
        public T Select();
    }
}
