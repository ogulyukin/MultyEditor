using System;
using FileLib;
using FileLib.Binary;
using FileLib.Txt;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = string.Empty;
            IFileWorking fileWorking = null;
            File file = null;
            
            Console.WriteLine("Выберите тип файла");
            Console.WriteLine("1. TXT");
            Console.WriteLine("2. Binary");
            var select = Console.ReadLine();
            switch (select)
            {
                case "1":
                    path = @"c:\Users\Stari\Desktop\Новый текстовый документ.txt";
                    fileWorking = new TxtFileWorking();
                    break;
                case "2":
                    path = @"d:\IT за Edu\Logo\logo.jpg";
                    fileWorking = new BinaryFileWorking();
                    break;
            }

            file = fileWorking.Open(path);

            Show(file);
        }

        private static void Show(File file)
        {
            var type = file.GetType().FullName;

            switch (type)
            {
                case "FileLib.Binary.BinaryFile":
                    ShowBinary((BinaryFile)file);
                    break;
                case "FileLib.Txt.TxtFile":
                    ShowTxt((TxtFile)file);
                    break;
            }
        }

        private static void ShowBinary(BinaryFile file)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"File name: {file.Path}");
            Console.WriteLine(file.Content);
            Console.ResetColor();
        }
        
        private static void ShowTxt(TxtFile file)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"File name: {file.Path}");
            Console.WriteLine(file.Content);
            Console.ResetColor();
        }
    }
}