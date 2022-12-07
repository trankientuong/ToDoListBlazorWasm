namespace ToDoListBlazorWasm.Features
{
    public class PagingLink
    {
        public string Text { get; set; }
        public int Page { get; set; }
        public bool Enabled { get; set; }
        public bool Active { get; set; }
        public PagingLink(string text, int page, bool enabled)
        {
            Text = text;
            Page = page;
            Enabled = enabled;
        }
    }
}
