using System.IO;

namespace FileLib.Txt
{
    public class TxtFileWorking : IFileWorking
    {
        #region Create_Open

        public File Create()
        {
            return new TxtFile();
        }

        public File Open(string path)
        {
            using var file = new StreamReader(path);
            var content = file.ReadToEnd();

            return new TxtFile(path, content);
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
            using var output = new StreamWriter(file.Path, append:false);
            output.WriteAsync(file.Content);
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