namespace Midi_List_Editor_1._1
{
    partial class Form2
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
            this.buttonDispl = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.textBoxED = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxEN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxD1 = new System.Windows.Forms.TextBox();
            this.textBoxD2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxFunct = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxEvT = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxCh = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textTrName = new System.Windows.Forms.TextBox();
            this.labelTrName = new System.Windows.Forms.Label();
            this.buttonTrN = new System.Windows.Forms.Button();
            this.comboBoxKey = new System.Windows.Forms.ComboBox();
            this.comboBoxMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonDispl
            // 
            this.buttonDispl.Location = new System.Drawing.Point(272, 23);
            this.buttonDispl.Name = "buttonDispl";
            this.buttonDispl.Size = new System.Drawing.Size(101, 23);
            this.buttonDispl.TabIndex = 0;
            this.buttonDispl.Text = "Display Event";
            this.buttonDispl.UseVisualStyleBackColor = true;
            this.buttonDispl.Click += new System.EventHandler(this.buttonDispl_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(745, 134);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(59, 23);
            this.buttonApply.TabIndex = 1;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // textBoxED
            // 
            this.textBoxED.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxED.Location = new System.Drawing.Point(24, 93);
            this.textBoxED.Multiline = true;
            this.textBoxED.Name = "textBoxED";
            this.textBoxED.Size = new System.Drawing.Size(409, 65);
            this.textBoxED.TabIndex = 2;
            this.textBoxED.TextChanged += new System.EventHandler(this.textBoxED_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Tr 01",
            "Tr 02",
            "Tr 03",
            "Tr 04",
            "Tr 05",
            "Tr 06",
            "Tr 07",
            "Tr 08",
            "Tr 09",
            "Tr 10",
            "Tr 11",
            "Tr 12",
            "Tr 13",
            "Tr 14",
            "Tr 15",
            "Tr 16"});
            this.comboBox1.Location = new System.Drawing.Point(154, 23);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(75, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // textBoxEN
            // 
            this.textBoxEN.Location = new System.Drawing.Point(24, 24);
            this.textBoxEN.Name = "textBoxEN";
            this.textBoxEN.Size = new System.Drawing.Size(94, 20);
            this.textBoxEN.TabIndex = 4;
            this.textBoxEN.Text = "0";
            this.textBoxEN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxEN.TextChanged += new System.EventHandler(this.textBoxEN_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Event Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(154, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Track Number";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(352, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "     No   Time   State  Data1  Data2   Chan\r\n";
            // 
            // textBoxD1
            // 
            this.textBoxD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxD1.Location = new System.Drawing.Point(452, 135);
            this.textBoxD1.Name = "textBoxD1";
            this.textBoxD1.Size = new System.Drawing.Size(39, 22);
            this.textBoxD1.TabIndex = 10;
            this.textBoxD1.Visible = false;
            this.textBoxD1.TextChanged += new System.EventHandler(this.textBoxD1_TextChanged);
            // 
            // textBoxD2
            // 
            this.textBoxD2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxD2.Location = new System.Drawing.Point(504, 136);
            this.textBoxD2.Name = "textBoxD2";
            this.textBoxD2.Size = new System.Drawing.Size(39, 22);
            this.textBoxD2.TabIndex = 11;
            this.textBoxD2.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(455, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "D1";
            this.label6.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(508, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "D2";
            this.label7.Visible = false;
            // 
            // comboBoxFunct
            // 
            this.comboBoxFunct.FormattingEnabled = true;
            this.comboBoxFunct.Items.AddRange(new object[] {
            "Insert",
            "Delete",
            "Replace",
            "Split Track",
            "Event Edit",
            "Change Track Order",
            "Change Midi Channel",
            "Drum Note Identify",
            "Brush Kit Correction",
            "Track Volume",
            "Timing Correction",
            "Ticks/Quarter Note"});
            this.comboBoxFunct.Location = new System.Drawing.Point(450, 86);
            this.comboBoxFunct.Name = "comboBoxFunct";
            this.comboBoxFunct.Size = new System.Drawing.Size(149, 21);
            this.comboBoxFunct.TabIndex = 16;
            this.comboBoxFunct.SelectedIndexChanged += new System.EventHandler(this.comboBoxFunct_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(447, 63);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Function";
            // 
            // comboBoxEvT
            // 
            this.comboBoxEvT.FormattingEnabled = true;
            this.comboBoxEvT.Items.AddRange(new object[] {
            "Program Change",
            "Track Name",
            "Master Volume",
            "Key Signature",
            "Track Volume"});
            this.comboBoxEvT.Location = new System.Drawing.Point(681, 86);
            this.comboBoxEvT.Name = "comboBoxEvT";
            this.comboBoxEvT.Size = new System.Drawing.Size(125, 21);
            this.comboBoxEvT.TabIndex = 18;
            this.comboBoxEvT.Visible = false;
            this.comboBoxEvT.SelectedIndexChanged += new System.EventHandler(this.comboBoxEvT_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(676, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Event Type";
            this.label9.Visible = false;
            // 
            // comboBoxCh
            // 
            this.comboBoxCh.AutoCompleteCustomSource.AddRange(new string[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.comboBoxCh.FormattingEnabled = true;
            this.comboBoxCh.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.comboBoxCh.Location = new System.Drawing.Point(615, 86);
            this.comboBoxCh.Name = "comboBoxCh";
            this.comboBoxCh.Size = new System.Drawing.Size(50, 21);
            this.comboBoxCh.TabIndex = 20;
            this.comboBoxCh.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(612, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(46, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Channel";
            this.label10.Visible = false;
            // 
            // textTrName
            // 
            this.textTrName.Location = new System.Drawing.Point(450, 24);
            this.textTrName.Name = "textTrName";
            this.textTrName.Size = new System.Drawing.Size(287, 20);
            this.textTrName.TabIndex = 22;
            this.textTrName.Visible = false;
            // 
            // labelTrName
            // 
            this.labelTrName.AutoSize = true;
            this.labelTrName.Location = new System.Drawing.Point(447, 7);
            this.labelTrName.Name = "labelTrName";
            this.labelTrName.Size = new System.Drawing.Size(69, 13);
            this.labelTrName.TabIndex = 23;
            this.labelTrName.Text = "Track Name:";
            this.labelTrName.Visible = false;
            // 
            // buttonTrN
            // 
            this.buttonTrN.Location = new System.Drawing.Point(745, 24);
            this.buttonTrN.Name = "buttonTrN";
            this.buttonTrN.Size = new System.Drawing.Size(61, 23);
            this.buttonTrN.TabIndex = 24;
            this.buttonTrN.Text = "Insert";
            this.buttonTrN.UseVisualStyleBackColor = true;
            this.buttonTrN.Visible = false;
            this.buttonTrN.Click += new System.EventHandler(this.buttonTrN_Click);
            // 
            // comboBoxKey
            // 
            this.comboBoxKey.FormattingEnabled = true;
            this.comboBoxKey.Items.AddRange(new object[] {
            "C  ",
            "G  ",
            "D  ",
            "A  ",
            "E  ",
            "H  ",
            "F# ",
            "F  ",
            "Bb ",
            "Eb ",
            "Ab ",
            "Db "});
            this.comboBoxKey.Location = new System.Drawing.Point(555, 135);
            this.comboBoxKey.Name = "comboBoxKey";
            this.comboBoxKey.Size = new System.Drawing.Size(44, 21);
            this.comboBoxKey.TabIndex = 25;
            this.comboBoxKey.Visible = false;
            // 
            // comboBoxMode
            // 
            this.comboBoxMode.FormattingEnabled = true;
            this.comboBoxMode.Items.AddRange(new object[] {
            "Major",
            "Minor"});
            this.comboBoxMode.Location = new System.Drawing.Point(615, 135);
            this.comboBoxMode.Name = "comboBoxMode";
            this.comboBoxMode.Size = new System.Drawing.Size(50, 21);
            this.comboBoxMode.TabIndex = 26;
            this.comboBoxMode.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(555, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Key Signature";
            this.label4.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(838, 190);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxMode);
            this.Controls.Add(this.comboBoxKey);
            this.Controls.Add(this.buttonTrN);
            this.Controls.Add(this.labelTrName);
            this.Controls.Add(this.textTrName);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.comboBoxCh);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxEvT);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxFunct);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxD2);
            this.Controls.Add(this.textBoxD1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEN);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBoxED);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonDispl);
            this.Name = "Form2";
            this.Text = "Edit";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDispl;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.TextBox textBoxED;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxEN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxD1;
        private System.Windows.Forms.TextBox textBoxD2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxFunct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxEvT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxCh;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textTrName;
        private System.Windows.Forms.Label labelTrName;
        private System.Windows.Forms.Button buttonTrN;
        private System.Windows.Forms.ComboBox comboBoxKey;
        private System.Windows.Forms.ComboBox comboBoxMode;
        private System.Windows.Forms.Label label4;
    }
}