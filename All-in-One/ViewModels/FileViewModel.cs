using Microsoft.Win32;
using All_In_One.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Xps.Packaging;

namespace All_In_One.ViewModels
{
    public class FileViewModel
    {
        public DocModel Document { get; private set; }

        //Työkalupakin komennot
        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }
        public ICommand PrintCommand { get; }

        public FileViewModel(DocModel document)
        {
            Document = document;
            NewCommand = new Commands(NewFile);
            SaveCommand = new Commands(SaveFile);
            SaveAsCommand = new Commands(SaveFileAs);
            OpenCommand = new Commands(OpenFile);
            PrintCommand = new Commands(PrintFile);
        }



        public void NewFile()
        {
            Document.FileName = string.Empty;
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
        }

        private void SaveFile()
        {
            if ((Document.FileName == string.Empty) || (Document.FileName == null))
                SaveFileAs();
            else
                File.WriteAllText(Document.FilePath, Document.Text);
        }

        private void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text File (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                File.WriteAllText(saveFileDialog.FileName, Document.Text);
            }
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text File (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void PrintFile()
        {
            var printFileDialog = new PrintDialog();
            printFileDialog.PageRangeSelection = PageRangeSelection.AllPages;
            printFileDialog.UserPageRangeEnabled = true;
            

            if (printFileDialog.ShowDialog() == true)
            {
                XpsDocument xpsDocument = new XpsDocument("C:\\FixedDocumentSequence.xps", FileAccess.ReadWrite);
                FixedDocumentSequence fixedDocSeq = xpsDocument.GetFixedDocumentSequence();
                printFileDialog.PrintDocument(fixedDocSeq.DocumentPaginator, "Test print job");
            }

        }

        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
        }
    }
}
