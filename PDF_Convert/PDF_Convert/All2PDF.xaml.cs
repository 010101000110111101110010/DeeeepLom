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
using System.Threading;
using System.ComponentModel;

namespace PDF_Convert
{
    public partial class All2PDF : Window
    {
        public All2PDF()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "All files |*.jpg;*.docx;*.txt;*.doc";
            if (openFile.ShowDialog() == true)
            {
                tbPath.Text = openFile.FileName;
                
            }
        }

        public void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string pathSave;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                DocumentCore dc = DocumentCore.Load($@"{tbPath.Text}");
                pathSave = saveFileDialog.FileName;
                PB.Visibility = Visibility.Visible;
                dc.Save($@"{pathSave}.pdf");

                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;
                worker.RunWorkerAsync();
                //if (worker.) PB.Visibility = Visibility.Hidden;
            }
        }




        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                (sender as BackgroundWorker).ReportProgress(i);
                Thread.Sleep(35);
            }
            
        }



        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            PB.Value = e.ProgressPercentage;
        }
    }
}
