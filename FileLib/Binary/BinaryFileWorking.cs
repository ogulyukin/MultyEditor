using System.IO;

namespace FileLib.Binary
{
    public class BinaryFileWorking : IFileWorking
    {
        #region Create_Open

        public SuccesObject Create(out File file)
        {
             file = new BinaryFile();
            //TODO Обработать ошибки
            return new SuccesObject { Success = true, Type = ErrorType.NotError };
        }

        public SuccesObject Open(string path, out File file)
        {
            using var input = System.IO.File.OpenRead(path);
            var array = new byte[input.Length];
            input.Read(array, 0, array.Length);
            var content = System.Text.Encoding.Default.GetString(array);

            file = new BinaryFile(path, content);
            //TODO Обработать ошибки
            return new SuccesObject { Success = true, Type = ErrorType.NotError };
        }

        #endregion

        #region Save

        public SuccesObject SaveAs(string path, File file)
        {
            file.Path = path;
            Save(file);
            //TODO Обработать ошибки
            return new SuccesObject { Success = true, Type = ErrorType.NotError };
        }

        public SuccesObject Save(File file)
        {
            using var output = new FileStream(file.Path, FileMode.OpenOrCreate);
            var array = System.Text.Encoding.Default.GetBytes(file.Content);
            output.WriteAsync(array, 0, array.Length);
            //TODO Обработать ошибки
            return new SuccesObject { Success = true, Type = ErrorType.NotError };
        }

        #endregion

        public SuccesObject Print(File file)
        {
            //TODO Print
            //TODO Обработать ошибки
            return new SuccesObject { Success = true, Type = ErrorType.NotError };
        }

        public SuccesObject Close(File file)
        {
            //TODO Close
            //TODO Обработать ошибки
            return new SuccesObject { Success = true, Type = ErrorType.NotError };
        }
    }
}