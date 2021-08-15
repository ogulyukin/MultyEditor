namespace FileLib.Txt
{
    public class TxtFile : File
    {
        public TxtFile() : base() { }

        public TxtFile(string path) : base(path) { }

        public TxtFile(string path, string content) : base(path, content) { }
    }
}