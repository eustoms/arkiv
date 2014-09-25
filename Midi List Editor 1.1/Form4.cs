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
    public partial class Form4 : Form
    {
        List<List<List<int>>> lst = new List<List<List<int>>>();
        List<string> strData = new List<string>();
        int rank;
        int len;

        public Form4()
        {
            InitializeComponent();
        }

        public Form4(List<List<List<int>>> st, List<string> strD)
        {
            InitializeComponent();
            lst = st;
            strData = strD;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Label[] lbarr = { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11, l12, l13, l14, l15, l16 };
            TextBox[] tarr = { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16 };
            Button[] barr = { b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16 };
            rank = 1;
            //int n = lst.Count;
            len = lst.Count;
            int i=1;
            while (i < len + 1)
            {
                if ((lst[i-1][0][1] == 255) && (lst[i-1][0][2] == 3))
                {
                    string stg = strData[lst[i-1][0][3]];
                    lbarr[i-1].Text += stg;
                    //lbarr[i-1].Visible = true;
                    //tarr[i-1].Visible = true;
                    //barr[i-1].Visible = true;
                }
                i++;
            }
            i = len;
            while (i < 16)
            {
                lbarr[i].Visible = false;
                tarr[i].Visible = false;
                barr[i].Visible = false;
                i++;
            }
            //formInit(lbarr, tarr, barr);
            //MessageBox.Show("Här");
            
   
        }

        private void b1_Click(object sender, EventArgs e)
        {
            t1.AppendText(rank.ToString());
            rank++;
            b1.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b2_Click(object sender, EventArgs e)
        {
            t2.AppendText(rank.ToString());
            rank++;
            b2.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b3_Click(object sender, EventArgs e)
        {
            t3.AppendText(rank.ToString());
            rank++;
            b3.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b4_Click(object sender, EventArgs e)
        {
            t4.AppendText(rank.ToString());
            rank++;
            b4.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
            
        }

        private void b5_Click(object sender, EventArgs e)
        {
            t5.AppendText(rank.ToString());
            rank++;
            b5.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b6_Click(object sender, EventArgs e)
        {
            t6.AppendText(rank.ToString());
            rank++;
            b6.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b7_Click(object sender, EventArgs e)
        {
            t7.AppendText(rank.ToString());
            rank++;
            b7.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b8_Click(object sender, EventArgs e)
        {
            t8.AppendText(rank.ToString());
            rank++;
            b8.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b9_Click(object sender, EventArgs e)
        {
            t9.AppendText(rank.ToString());
            rank++;
            b9.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b10_Click(object sender, EventArgs e)
        {
            t10.AppendText(rank.ToString());
            rank++;
            b10.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b11_Click(object sender, EventArgs e)
        {
            t11.AppendText(rank.ToString());
            rank++;
            b11.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b12_Click(object sender, EventArgs e)
        {
            t12.AppendText(rank.ToString());
            rank++;
            b12.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b13_Click(object sender, EventArgs e)
        {
            t13.AppendText(rank.ToString());
            rank++;
            b13.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b14_Click(object sender, EventArgs e)
        {
            t14.AppendText(rank.ToString());
            rank++;
            b14.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b15_Click(object sender, EventArgs e)
        {
            t15.AppendText(rank.ToString());
            rank++;
            b15.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void b16_Click(object sender, EventArgs e)
        {
            t16.AppendText(rank.ToString());
            rank++;
            b16.Enabled = false;
            if (rank > len)
                buttonGo.Enabled = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            TextBox[] tarr = { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16 };
            Button[] barr = { b1, b2, b3, b4, b5, b6, b7, b8, b9, b10, b11, b12, b13, b14, b15, b16 };
            int i = 1;
            while (i < 17)
            {
                tarr[i-1].Clear();
                barr[i-1].Enabled = true;
                i++;
            }
            rank = 1;
            buttonGo.Enabled = false;
        }

        private void buttonGo_Click(object sender, EventArgs e)
        {
            midlist ml=new midlist();
            List<List<List<int>>> lstDum = new List<List<List<int>>>();
            List<List<int>> lst2 = new List<List<int>>();
            TextBox[] tarr = { t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, t16 };
            int[] vect= new int[16];
            string str;
            int number;
            bool result;
            int x;
            List<int> trOrd=new List<int>();
            ml.listClone(lst, lstDum);
            lst.Clear();
            int j=0;
            str = tarr[0].Text;
           
            while (j<len)
            {
                str=tarr[j].Text;
                result = Int32.TryParse(str, out number);
                if (result)
                    vect[j]=number;
                j++;
            }
            int i = 1;
            while (i<len+1)
            {
                j=0;
                lst2.Clear();
                while (j<len)
                {
                    if (vect[j]==i)
                    {
                        lst2=lstDum[j];
                        ml.toThree(lst2,lst);
                    }
                    j++;
                }
                i++;
            }
            this.Close();
        }

        /*public void formInit(Label[] lab, TextBox[] tbx, Button[] btn)
        {
            int n = lst.Count;
            int i = 1;
            while (i < n + 1)
            {
                if ((lst[i][0][1] == 255) && (lst[i][0][2] == 3))
                {
                    string stg = strData[lst[i][0][3]];
                    lab[i].Text += stg;
                }
                i++;
            }
            i = n;
            while (i < 17)
            {
                lab[i].Visible = false;
                tbx[i].Visible = false;
                btn[i].Visible = false;
                i++;
            }*/
        
    }
}
