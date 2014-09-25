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
    public partial class Form3 : Form
    {
        List<List<List<int>>> lst = new List<List<List<int>>>();
        List<string> strData = new List<string>();
        int trNr;
        int evNr;
        midlist ml = new midlist(); 

        public Form3()
        {
            InitializeComponent();
        }

        public Form3(List<List<List<int>>> st, List<string> strD, int trackNr, int eventNr)
        {
            InitializeComponent();
            lst = st;
            strData = strD;
            trNr = trackNr;
            evNr = eventNr;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            int d1 = lst[trNr][evNr][0];
            int d2 = lst[trNr][evNr][1];
            int d3 = lst[trNr][evNr][2]; 
            int d4 = lst[trNr][evNr][3];
            const string format1 = "{0, 4}";
            const string format2 = "{0, 7}";
            textBox1.AppendText(string.Format(format2, d1));
            textBox2.AppendText(string.Format(format1, d2));
            textBox3.AppendText(string.Format(format1, d3));
            textBox4.AppendText(string.Format(format1, d4));
            if (d2 == 255)
            {
                string str = strData[d4];
                textMess.AppendText(str);
                textBox4.Enabled = false;
            }
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            int d2 = Convert.ToInt32(textBox2.Text);
            int d3 = Convert.ToInt32(textBox3.Text);
            int d4 = Convert.ToInt32(textBox4.Text);
            lst[trNr][evNr][1] = d2;
            lst[trNr][evNr][2] = d3;
            lst[trNr][evNr][3] = d4;
            if (d2 == 255)
                strData[d4] = textMess.Text;
            this.Close();
        }
    }
}
