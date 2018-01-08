namespace OnScreenKeyboard
{
    partial class testOnScreenKeyboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(testOnScreenKeyboard));
            this.groupInfo = new System.Windows.Forms.GroupBox();
            this.labelInfo3 = new System.Windows.Forms.Label();
            this.labelInfo2 = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelInput = new System.Windows.Forms.Label();
            this.textInput = new System.Windows.Forms.TextBox();
            this.labelOutput = new System.Windows.Forms.Label();
            this.textOutput = new System.Windows.Forms.TextBox();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.openFileDlg = new System.Windows.Forms.OpenFileDialog();
            this.optionAsFile = new System.Windows.Forms.RadioButton();
            this.optionAsText = new System.Windows.Forms.RadioButton();
            this.groupInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupInfo
            // 
            this.groupInfo.Controls.Add(this.labelInfo3);
            this.groupInfo.Controls.Add(this.labelInfo2);
            this.groupInfo.Controls.Add(this.labelInfo);
            this.groupInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupInfo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupInfo.Location = new System.Drawing.Point(12, 8);
            this.groupInfo.Name = "groupInfo";
            this.groupInfo.Size = new System.Drawing.Size(749, 218);
            this.groupInfo.TabIndex = 1;
            this.groupInfo.TabStop = false;
            this.groupInfo.Text = "Information !";
            // 
            // labelInfo3
            // 
            this.labelInfo3.AutoSize = true;
            this.labelInfo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelInfo3.Location = new System.Drawing.Point(95, 193);
            this.labelInfo3.Name = "labelInfo3";
            this.labelInfo3.Size = new System.Drawing.Size(640, 13);
            this.labelInfo3.TabIndex = 3;
            this.labelInfo3.Text = "You can enter (or choose) a file OR enter text for immediate translation.  Choose" +
    " \"Treat as Text\" to process immediate text as you type.";
            // 
            // labelInfo2
            // 
            this.labelInfo2.AutoSize = true;
            this.labelInfo2.ForeColor = System.Drawing.Color.Maroon;
            this.labelInfo2.Location = new System.Drawing.Point(10, 193);
            this.labelInfo2.Name = "labelInfo2";
            this.labelInfo2.Size = new System.Drawing.Size(84, 13);
            this.labelInfo2.TabIndex = 2;
            this.labelInfo2.Text = "IMPORTANT:";
            // 
            // labelInfo
            // 
            this.labelInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelInfo.Location = new System.Drawing.Point(10, 18);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(733, 175);
            this.labelInfo.TabIndex = 1;
            this.labelInfo.Text = resources.GetString("labelInfo.Text");
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(9, 242);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(53, 13);
            this.labelInput.TabIndex = 2;
            this.labelInput.Text = "Input File:";
            // 
            // textInput
            // 
            this.textInput.Location = new System.Drawing.Point(81, 239);
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(460, 20);
            this.textInput.TabIndex = 3;
            this.textInput.TextChanged += new System.EventHandler(this.textInputFile_TextChanged);
            // 
            // labelOutput
            // 
            this.labelOutput.AutoSize = true;
            this.labelOutput.Location = new System.Drawing.Point(9, 266);
            this.labelOutput.Name = "labelOutput";
            this.labelOutput.Size = new System.Drawing.Size(66, 13);
            this.labelOutput.TabIndex = 2;
            this.labelOutput.Text = "Output Text:";
            // 
            // textOutput
            // 
            this.textOutput.Location = new System.Drawing.Point(81, 263);
            this.textOutput.Multiline = true;
            this.textOutput.Name = "textOutput";
            this.textOutput.Size = new System.Drawing.Size(680, 251);
            this.textOutput.TabIndex = 3;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(545, 238);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(26, 22);
            this.buttonSelectFile.TabIndex = 4;
            this.buttonSelectFile.Text = "...";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // openFileDlg
            // 
            this.openFileDlg.DefaultExt = "txt";
            this.openFileDlg.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            this.openFileDlg.Title = "Select Input File to Translate...";
            // 
            // optionAsFile
            // 
            this.optionAsFile.AutoSize = true;
            this.optionAsFile.Checked = true;
            this.optionAsFile.Location = new System.Drawing.Point(586, 240);
            this.optionAsFile.Name = "optionAsFile";
            this.optionAsFile.Size = new System.Drawing.Size(83, 17);
            this.optionAsFile.TabIndex = 5;
            this.optionAsFile.TabStop = true;
            this.optionAsFile.Text = "Treat as File";
            this.optionAsFile.UseVisualStyleBackColor = true;
            this.optionAsFile.CheckedChanged += new System.EventHandler(this.option_CheckedChanged);
            // 
            // optionAsText
            // 
            this.optionAsText.AutoSize = true;
            this.optionAsText.Location = new System.Drawing.Point(675, 240);
            this.optionAsText.Name = "optionAsText";
            this.optionAsText.Size = new System.Drawing.Size(88, 17);
            this.optionAsText.TabIndex = 5;
            this.optionAsText.Text = "Treat as Text";
            this.optionAsText.UseVisualStyleBackColor = true;
            this.optionAsText.CheckedChanged += new System.EventHandler(this.option_CheckedChanged);
            // 
            // testOnScreenKeyboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 527);
            this.Controls.Add(this.optionAsText);
            this.Controls.Add(this.optionAsFile);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.textOutput);
            this.Controls.Add(this.textInput);
            this.Controls.Add(this.labelOutput);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.groupInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "testOnScreenKeyboard";
            this.Text = "On Screen Keyboard Testing UI for SoftWriters, by Robb Ryniak";
            this.groupInfo.ResumeLayout(false);
            this.groupInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupInfo;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Label labelOutput;
        private System.Windows.Forms.TextBox textOutput;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDlg;
        private System.Windows.Forms.Label labelInfo3;
        private System.Windows.Forms.Label labelInfo2;
        private System.Windows.Forms.RadioButton optionAsFile;
        private System.Windows.Forms.RadioButton optionAsText;

    }
}

