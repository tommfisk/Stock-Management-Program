namespace CommandLineUI.Menu
{
    abstract class MenuElement
    {
        public int Id { get; }
        public string Text { get; }

        public MenuElement(int id, string text)
        {
            this.Id = id;
            this.Text = text;
        }

        public abstract void Print(string indent);
    }
}
