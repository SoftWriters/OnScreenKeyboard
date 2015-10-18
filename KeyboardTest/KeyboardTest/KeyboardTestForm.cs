using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OnScreenKeyboard;

namespace KeyboardTest
{
    public partial class KeyboardTestForm : Form
    {
        public KeyboardTestForm()
        {
            InitializeComponent();
        }

        private void processFileButton_click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            //Clean up old file runs
                            File.Delete(FileManager.CreateOutputFileName(openFileDialog1.FileName));

                            //Create Streamreader with file stream
                            StreamReader reader = new StreamReader(myStream);

                            //Read file line by line for search terms
                            string searchCommand = "";
                            while ((searchCommand = reader.ReadLine()) != null)
                            {
                                //If empty line skip and warn
                                if (searchCommand != String.Empty)
                                {
                                    //translate search command
                                    Navigator navigationPath = new Navigator(searchCommand);

                                    //append translation to output file
                                    FileManager.WriteStringToFile(openFileDialog1.FileName, navigationPath.NavigationPath);
                                }
                                else
                                {
                                    MessageBox.Show("Search Command is empty");
                                }
                            }
                            //Release file resource
                            openFileDialog1.Dispose();
                        }
                    }
                }
                catch (Exception ex)
                {
                    //Should only be reached in the event that a file with invalid characters is used, allows program to continue and process next file selection
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void exitButton_click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
