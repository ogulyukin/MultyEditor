using System;
using System.IO;

namespace FileLib.Txt
{
    public class TxtFileWorking : IFileWorking
    {
        #region Create_Open

        public SuccesObject Create(out File file)
        {
            file = new TxtFile();
            return new SuccesObject{Success = true, Type = ErrorType.NotError};
        }

        public SuccesObject Open(string path, out File file)
        {
            if (string.IsNullOrEmpty(path))
            {
                file = null;
                return new SuccesObject{Success = false, Type = ErrorType.PathEmpty};
            }

            var content = string.Empty;
            try
            {
                using var input = new StreamReader(path);
                content = input.ReadToEnd();
            }
            catch (Exception)
            {
                file = null;
                return new SuccesObject{Success = false, Type = ErrorType.Unknown};
            }
            file = new TxtFile(path, content);
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
            using var output = new StreamWriter(file.Path, append:false);
            output.WriteAsync(file.Content);
            //TODO Обработать ошибки
            return new SuccesObject { Success = true, Type = ErrorType.NotError };
        }

        #endregion
        
        public SuccesObject Print(File file)
        {
            //TODO Обработать ошибки
            return new SuccesObject { Success = true, Type = ErrorType.NotError };
            //TODO Print
        }

        public SuccesObject Close(File file)
        {
            //TODO Обработать ошибки
            return new SuccesObject { Success = true, Type = ErrorType.NotError };
            //TODO Close
        }
    }
}