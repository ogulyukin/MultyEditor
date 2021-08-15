namespace FileLib
{
    public abstract class File
    {
        public string Path { get; set; }
        public string Content { get; set; }

        protected File()
        {
            Path = string.Empty;
            Content = string.Empty;
        }

        protected File(string path)
        {
            Path = path;
            Content = string.Empty;
        }

        protected File(string path, string content)
        {
            Path = path;
            Content = content;
        }
    }
}