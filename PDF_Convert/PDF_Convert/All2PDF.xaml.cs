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
using System.Windows.Shapes;
using Microsoft.Win32;
using SautinSoft.Document;

namespace PDF_Convert
{
    public partial class All2PDF : Window
    {
        public All2PDF()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            string path;
            openFile.Filter = "Jpeg Files (*.jpg)|*.jpg";
            if (openFile.ShowDialog() == true)
            {
                path = openFile.FileName;
                DocumentCore dc = DocumentCore.Load($@"{path}");
                dc.Save($@"{System.IO.Path.GetDirectoryName(path)}\{System.IO.Path.GetFileNameWithoutExtension(path)}AfterConvert.pdf");
                MessageBox.Show("Файл был конвертирован и сохранён в смежную с выбраным файлом папку");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            string path;
            openFile.Filter = "DOCK Files (*.docx)|*.docx| TXT Files (*.txt)|*.txt| DOC Files (*.doc)|*.doc";
            if (openFile.ShowDialog() == true)
            {
                path = openFile.FileName;
                DocumentCore dc = DocumentCore.Load($@"{path}");
                dc.Save($@"{System.IO.Path.GetDirectoryName(path)}\{System.IO.Path.GetFileNameWithoutExtension(path)}AfterConvert.pdf");
                MessageBox.Show("Файл был конвертирован и сохранён в смежную с выбраным файлом папку");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            string path;
            openFile.Filter = "XLSX Files (*.xlsx)|*.xlsx";
            if (openFile.ShowDialog() == true)
            {
                path = openFile.FileName;
                DocumentCore dc = DocumentCore.Load($@"{path}");
                dc.Save($@"{System.IO.Path.GetDirectoryName(path)}\{System.IO.Path.GetFileNameWithoutExtension(path)}AfterConvert.pdf");
                MessageBox.Show("Файл был конвертирован и сохранён в смежную с выбраным файлом папку");
            }
        }
    }
}
