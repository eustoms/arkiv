namespace Midi_List_Editor_1._1
{
    partial class Form1
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
            this.textBoxList = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.bList = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bOpen = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bExit = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // textBoxList
            // 
            this.textBoxList.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxList.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxList.Location = new System.Drawing.Point(1, 34);
            this.textBoxList.Multiline = true;
            this.textBoxList.Name = "textBoxList";
            this.textBoxList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxList.Size = new System.Drawing.Size(788, 500);
            this.textBoxList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.label1.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(728, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "   No    Time    Bar  Beat Fract   Message               Data1 Data2 Chan T-Sign";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // bList
            // 
            this.bList.BackColor = System.Drawing.SystemColors.ControlLight;
            this.bList.Location = new System.Drawing.Point(831, 89);
            this.bList.Name = "bList";
            this.bList.Size = new System.Drawing.Size(75, 23);
            this.bList.TabIndex = 2;
            this.bList.Text = "List";
            this.bList.UseVisualStyleBackColor = false;
            this.bList.Click += new System.EventHandler(this.bList_Click);
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(831, 128);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(75, 23);
            this.bEdit.TabIndex = 3;
            this.bEdit.Text = "Edit";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(831, 373);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(75, 23);
            this.bOpen.TabIndex = 4;
            this.bOpen.Text = "Open File";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(831, 411);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 5;
            this.bSave.Text = "Save File";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "General",
            "Track 1",
            "Track 2",
            "Track 3",
            "Track 4",
            "Track 5",
            "Track 6",
            "Track 7",
            "Track 8",
            "Track 9",
            "Track 10",
            "Track 11",
            "Track 12",
            "Track 13",
            "Track 14",
            "Track 15",
            "Track 16"});
            this.comboBox1.Location = new System.Drawing.Point(831, 34);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Text = "General";
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(831, 449);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 7;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "MIDI File | *.mid";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "MIDI File | *.mid";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(945, 512);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.bEdit);
            this.Controls.Add(this.bList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxList);
            this.Name = "Form1";
            this.Text = "Midi List Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bList;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bOpen;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

