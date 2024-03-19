namespace DTOs
{
    [Serializable]
    public class MessageDTO : IDto
    {
        public string Message { get; }

        public MessageDTO(string msg)
        {
            this.Message = msg;
        }
    }
}
