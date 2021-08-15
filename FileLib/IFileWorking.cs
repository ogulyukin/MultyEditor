namespace FileLib
{
    public interface IFileWorking
    {
        #region Create_Open

        public SuccesObject Create(out File file);
        public SuccesObject Open(string path, out File file);

        #endregion

        #region Save

        public SuccesObject SaveAs(string path, File file);
        public SuccesObject Save(File file);

        #endregion

        public SuccesObject Print(File file);
        public SuccesObject Close(File file);
    }
}