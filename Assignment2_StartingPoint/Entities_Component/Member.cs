namespace Entities
{
    public class Member : IEntity
    {
        public int ID { get; }
        public string Name { get; }

        public Member(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public override string ToString()
        {
            return ID + ": " + Name;
        }
    }
}
