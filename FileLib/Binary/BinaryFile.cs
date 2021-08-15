namespace FileLib.Binary
{
    public class BinaryFile : File
    {
        public BinaryFile() : base() { }

        public BinaryFile(string path) : base(path) { }

        public BinaryFile(string path, string content) : base(path, content) { }
    }
}