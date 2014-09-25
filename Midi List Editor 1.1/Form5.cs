using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Midi_List_Editor_1._1
{
    public partial class Form5 : Form
    {
        string st;
        public Form5(string str)
        {
            InitializeComponent();
            st = str;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            textBox1.AppendText(st);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
