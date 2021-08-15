namespace FileLib
{
    public interface IFileWorking
    {
        #region Create_Open

        public File Create();
        public File Open(string path);

        #endregion

        #region Save

        public void SaveAs(string path, File file);
        public void Save(File file);

        #endregion

        public void Print(File file);
        public void Close(File file);
    }
}