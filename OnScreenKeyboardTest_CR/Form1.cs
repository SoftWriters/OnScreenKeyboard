using OnscreenKeyboardTranslation;
using System;
using System.Windows.Forms;


namespace OnScreenKeyboardTest_CR
{


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                lblChosenFile.Text = openFileDialog1.FileName;
                if (lblChosenFile.Text.Length > 0)
                {
                    ScreenTranslator translation = new ScreenTranslator();
                    txtTranslation.Text = string.Join(Environment.NewLine, translation.TranslateLines(lblChosenFile.Text));
                    textBox1.Text = string.Join(Environment.NewLine, translation.GetFileLines());
                    chkUnrecognized.Enabled = true;
                    chkUnrecognized.Checked = translation.GetContainsUnknownChars();
                    chkUnrecognized.Enabled = false;
                }
            }
        }
    }

}
