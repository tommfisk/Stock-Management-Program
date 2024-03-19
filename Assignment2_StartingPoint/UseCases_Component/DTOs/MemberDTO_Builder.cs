namespace DTOs
{
    public class MemberDTO_Builder
    {
        private int id;
        private string name;

        public MemberDTO Build()
        {
            return
                new MemberDTO(id, name);
        }

        public MemberDTO_Builder WithId(int id)
        {
            this.id = id;
            return this;
        }

        public MemberDTO_Builder WithName(string name)
        {
            this.name = name;
            return this;
        }
    }
}
