namespace DTOs
{
    [Serializable]
    public class MemberDTO : IDto
    {
        public int ID { get; }
        public string Name { get; }

        public MemberDTO(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }
}
