namespace Entities
{
    public class MemberBuilder
    {
        private int id;
        private string name;

        public MemberBuilder()
        {
            this.id = -1;
            this.name = "";
        }

        public Member Build()
        {
            return new Member(id, name);
        }

        public MemberBuilder WithId(int id)
        {
            this.id = id;
            return this;
        }

        public MemberBuilder WithName(string name)
        {
            this.name = name;
            return this;
        }
    }
}
