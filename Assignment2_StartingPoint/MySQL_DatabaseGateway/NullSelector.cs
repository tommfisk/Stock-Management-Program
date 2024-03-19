namespace DatabaseGateway
{
    class NullSelector<T> : ISelector<T>
    {
        public T Select() 
        {
            throw new Exception("Selection not supported");
        }
    }
}
