using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using ViewApp;

namespace ViewApp.Core
{
    partial class XmlModule
    {
        public static string LoadFile() 
        {
            string filePath = string.Empty;
            string fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;

                    MessageBox.Show(filePath);

                    return filePath;
                }

                filePath = "";

                return filePath;
            }
        }
    }
}
