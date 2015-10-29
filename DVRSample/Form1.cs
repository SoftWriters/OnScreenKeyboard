using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVRSample
{
    public partial class Form1 : Form
    {
        StringBuilder strBuilder = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        
        private void ConvertFile(string inputString)
        {
            Dictionary<int, string> mydict = new Dictionary<int, string>();
            mydict.Add(1, "ABCDEF");
            mydict.Add(2, "GHIJKL");
            mydict.Add(3, "MNOPQR");
            mydict.Add(4, "STUVWX");
            mydict.Add(5, "YZ1234");
            mydict.Add(6, "567890");
           
            char[] array = inputString.ToUpper().ToCharArray();
            string previousChar = "A";
            int previousPosition = 1;
            int previousLine = 1;
           
            string output = "";
           
            for (int i = 0; i <= array.Count() - 1; i++)
            {
                string presentChar = array[i].ToString();
                if (previousChar.Equals(presentChar))
                {
                    output = output + "#" + ",";
                    previousChar = array[i].ToString();
                    continue;
                }
                if (presentChar.Equals(" "))
                {
                    output = output + "S" + ",";
                    previousChar = array[i].ToString();
                    continue;
                }

                foreach (KeyValuePair<int, string> item in mydict)
                {

                    if (item.Value.Contains(presentChar))
                    {
                        if (item.Key == previousLine)
                        {
                            int presentPostion = item.Value.IndexOf(presentChar) + 1;
                            if (presentPostion > previousPosition)
                            {
                                for (int j = previousPosition; j < presentPostion; ++j)
                                {
                                    output = output + "R" + ",";
                                }
                                output = output + "#" + ",";
                            }
                            else if (presentPostion < previousPosition)
                            {
                                for (int j = presentPostion; j < previousPosition; ++j)
                                {
                                    output = output + "L" + ",";
                                }
                                output = output + "#" + ",";
                            }
                            else
                            {
                                output = output + "#" + ",";
                            }
                            previousPosition = presentPostion;
                            previousChar = presentChar;
                            break;
                        }
                        else if (item.Key > previousLine)
                        {
                            for (int j = previousLine; j < item.Key; ++j)
                            {
                                output = output + "D" + ",";
                            }
                            int presentPostion = item.Value.IndexOf(presentChar) + 1;
                            if (presentPostion > previousPosition)
                            {
                                for (int j = previousPosition; j < presentPostion; ++j)
                                {
                                    output = output + "R" + ",";
                                }
                                output = output + "#" + ",";
                            }
                            else if (presentPostion < previousPosition)
                            {
                                for (int j = presentPostion; j < previousPosition; ++j)
                                {
                                    output = output + "L" + ",";
                                }
                                output = output + "#" + ",";
                            }
                            else
                            {
                                output = output + "#" + ",";
                            }
                            previousPosition = presentPostion;
                            previousChar = presentChar;
                            previousLine = item.Key;
                            break;
                        }
                        else if (item.Key < previousLine)
                        {
                            for (int j = item.Key; j < previousLine; ++j)
                            {
                                output = output + "U" + ",";
                            }
                            int presentPostion = item.Value.IndexOf(presentChar) + 1;
                            if (presentPostion > previousPosition)
                            {
                                for (int j = previousPosition; j < presentPostion; ++j)
                                {
                                    output = output + "R" + ",";
                                }
                                output = output + "#" + ",";
                            }
                            else if (presentPostion < previousPosition)
                            {
                                for (int j = presentPostion; j < previousPosition; ++j)
                                {
                                    output = output + "L" + ",";
                                }
                                output = output + "#" + ",";
                            }
                            else
                            {
                                output = output + "#" + ",";
                            }
                            previousPosition = presentPostion;
                            previousChar = presentChar;
                            previousLine = item.Key;
                            break;
                        }
                    }

                }
            }
            output = output.Substring(0, output.Length - 1);
            strBuilder.AppendLine(output+Environment.NewLine);
           
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            try { 
            ofdFlatFile.Filter = "Text files | *.txt"; 
            ofdFlatFile.Multiselect = false;
            DialogResult result = ofdFlatFile.ShowDialog();
           
            txtFile.Text = ofdFlatFile.FileName;
            if (result == DialogResult.OK)
            {
                if (!System.IO.Directory.Exists(Application.StartupPath + "\\InputFiles"))
                {
                    System.IO.Directory.CreateDirectory(Application.StartupPath + "\\InputFiles");
                }
                string destinationFileName = System.IO.Path.Combine(Application.StartupPath + "\\InputFiles", Path.GetFileName(ofdFlatFile.FileName));
                if (File.Exists(destinationFileName))
                {
                    File.Delete(destinationFileName);
                }
                File.Copy(txtFile.Text, destinationFileName);
                int counter = 0;
                string line;

                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader(destinationFileName);
                while ((line = file.ReadLine()) != null)
                {
                    ConvertFile(line);
                    counter++;
                }
                if (File.Exists(Application.StartupPath + "\\InputFiles\\OutPutResult.txt"))
                {
                    File.Delete(Application.StartupPath + "\\InputFiles\\OutPutResult.txt");
                }
                TextWriter tw = new StreamWriter(Application.StartupPath + "\\InputFiles\\OutPutResult.txt", true);
                tw.WriteLine(strBuilder.ToString());
                tw.Close();
                MessageBox.Show("File sucessfully processed");
                this.Close();
            }
            }
                catch(Exception ex)
            {
                
            }
        }
    }
    
}
