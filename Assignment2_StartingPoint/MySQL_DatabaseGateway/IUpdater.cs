namespace DatabaseGateway
{
    // This interface illustrates the Interface Segregation Principle
    interface IUpdater<T>
    {
        public int Update(T itemToUpdate);
    }
}
