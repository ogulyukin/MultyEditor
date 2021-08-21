using System;
using System.Windows;
using System.Windows.Controls;
using FileLib;
using FileLib.Txt;
using FileLib.Binary;
using Microsoft.Win32;

namespace MEdit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string path = string.Empty;
        private IFileWorking fileWorking = null;
        private File file = null;

        public MainWindow()
        {
            InitializeComponent();
            MainView.IsEnabled = false;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (((MenuItem)sender).Name == "HelpAbout")
            {
                MessageBox.Show("Это просто учебная программа", "О Программе");
            }
            if (((MenuItem)sender).Name == "ExitApp")
            {
                this.Close();
            }
            if (((MenuItem)sender).Name == "SaveAsFile")
            {
                if (file == null)
                    return;
                saveAsFile();
                return;
            }
            if (((MenuItem)sender).Name == "SaveFile")
            {
                if (file == null)
                    return;
                if(path == string.Empty)
                {
                    saveAsFile();
                    return;
                }
                file.Content = MainView.Text;
                var result = fileWorking.Save(file);
                if (!result.Success)
                {
                    MessageBox.Show($"Ошибка: {result.Type.ToString()}");
                    return;
                }
            }
            if (((MenuItem)sender).Name == "OpenBinary")
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    fileWorking = new BinaryFileWorking();
                    path = openFileDialog.FileName;
                    var result = fileWorking.Open(path, out file);
                    if (!result.Success)
                    {
                        path = string.Empty;
                        file = null;
                        MessageBox.Show($"Ошибка: {result.Type.ToString()}");
                        return;
                    }
                }
                MainView.IsEnabled = true;
                MainView.Clear();
                MainView.Text = file.Content;
            }
            if (((MenuItem)sender).Name == "OpenText")
            { 
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text files (*.txt)|*.txt";
                if (openFileDialog.ShowDialog() == true)
                {
                    fileWorking = new TxtFileWorking();
                    path = openFileDialog.FileName;
                    var result = fileWorking.Open(path , out file);
                    if(!result.Success)
                    {
                        path = string.Empty;
                        file = null;
                        MessageBox.Show($"Ошибка: {result.Type.ToString()}");
                        return;
                    }
                }
                MainView.IsEnabled = true;
                MainView.Clear();
                MainView.Text = file.Content;
            }
            if (((MenuItem)sender).Name == "CreateBinary")
            {
                MainView.Clear();
                path = string.Empty;
                if (file != null)
                    file = null;
                fileWorking = new BinaryFileWorking();
                SuccesObject result = fileWorking.Create(out file);
                if (!result.Success)
                {
                    MessageBox.Show($"Ошибка: {result.Type.ToString()}");
                    return;
                }
                MainView.IsEnabled = true;
            }
            if (((MenuItem)sender).Name == "CreateText")
            {
                MainView.Clear();
                path = string.Empty;
                if (file != null)
                    file = null;
                fileWorking = new TxtFileWorking();
                SuccesObject result = fileWorking.Create(out file);
                if(!result.Success)
                {
                    MessageBox.Show($"Ошибка: {result.Type.ToString()}");
                    return;
                }
                MainView.IsEnabled = true;
            }
        }

        private void saveAsFile()
        {
            if (fileWorking == null)
                return;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == true)
            {
                if (saveFileDialog.FileName == string.Empty)
                    return;
                path = file.Path = saveFileDialog.FileName;
                file.Content = MainView.Text;
                var result = fileWorking.Save(file);
                if (!result.Success)
                {
                    MessageBox.Show($"Ошибка: {result.Type.ToString()}");
                    return;
                }
            }
        }
    }
}
