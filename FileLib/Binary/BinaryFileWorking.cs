using System.IO;

namespace FileLib.Binary
{
    public class BinaryFileWorking : IFileWorking
    {
        #region Create_Open

        public File Create()
        {
            return new BinaryFile();
        }

        public File Open(string path)
        {
            using var file = System.IO.File.OpenRead(path);
            var array = new byte[file.Length];
            file.Read(array, 0, array.Length);
            var content = System.Text.Encoding.Default.GetString(array);

            return new BinaryFile(path, content);
        }

        #endregion

        #region Save

        public void SaveAs(string path, File file)
        {
            file.Path = path;
            Save(file);
        }

        public void Save(File file)
        {
            using var output = new FileStream(file.Path, FileMode.OpenOrCreate);
            var array = System.Text.Encoding.Default.GetBytes(file.Content);
            output.WriteAsync(array, 0, array.Length);
        }

        #endregion

        public void Print(File file)
        {
            //TODO Print
        }

        public void Close(File file)
        {
            //TODO Close
        }
    }
}