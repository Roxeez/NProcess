namespace NProcess.Module
{
    public sealed class Pattern
    {
        public string Content { get; }
        public int Offset { get; }
        
        public Pattern(string content, int offset = 0)
        {
            Content = content;
            Offset = offset;
        }
    }
}