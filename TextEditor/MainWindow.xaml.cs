using Microsoft.Win32; // add
using System.IO; // add
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CreateNewFile_Click(object sender, RoutedEventArgs e)
        {
            if(textBox.Text != "")
            {
                SaveFile();
            }
            textBox.Text = "";
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            bool? resultOFD = openFileDialog.ShowDialog(); // bool? - it mean bool can be null (not true, not false - null)

            if(resultOFD != false) 
            {
                Stream stream = openFileDialog.OpenFile();

                if (stream != null)
                {
                    string fileName = openFileDialog.FileName;
                    string fileText = File.ReadAllText(fileName);

                    textBox.Text = fileText;
                }
            } 
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void SaveFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            bool? resSFD = saveFileDialog.ShowDialog(); // bool? - it mean bool can be null (not true, not false - null)

            if(resSFD != false)
            {
                using (Stream stream = File.Open(saveFileDialog.FileName, FileMode.OpenOrCreate))
                {
                    using (StreamWriter streamWriter = new StreamWriter(stream))
                    {
                        streamWriter.Write(textBox.Text);
                    }
                }
            }
        }

        private void FontTimesNewRoman_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Times New Roman");

            fontVerdana.IsChecked = false;
            fontTimesNewRoman.IsChecked = true;
        }

        private void FontVerdana_Click(object sender, RoutedEventArgs e)
        {
            textBox.FontFamily = new FontFamily("Verdana");

            fontTimesNewRoman.IsChecked = false;
            fontVerdana.IsChecked = true;
        }

        private void SelectFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontSize = selectFontSize.SelectedItem.ToString();
            fontSize = fontSize.Substring(fontSize.Length - 4);

            // for Visual Studio 2022 // fontSize = fontSize.Substring(fontSize.Length - 4);
            // for Visual Studio 2019 // fontSize = fontSize.Substring(fontSize.Length - 2);

            switch (fontSize) //for for Visual Studio 2019 "10px" -> "10"
            {
                case "10px":
                    textBox.FontSize = 10;
                    break;
                case "14px":
                    textBox.FontSize = 14;
                    break;
                case "16px":
                    textBox.FontSize = 16;
                    break;
                case "18px":
                    textBox.FontSize = 18;
                    break;
                case "20px":
                    textBox.FontSize = 20;
                    break;
                case "24px":
                    textBox.FontSize = 24;
                    break;
                case "32px":
                    textBox.FontSize = 32;
                    break;
            }
        }
    }
}
