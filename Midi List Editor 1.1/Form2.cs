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
    public partial class Form2 : Form
    {
        List<List<List<int>>> lst = new List<List<List<int>>>();
        List<string> strData = new List<string>();
        List<List<byte>> sysD = new List<List<byte>>();
        midlist ml = new midlist();
        string[] fileData = new string[23];

        public Form2()
        {
            InitializeComponent();
        }

        public Form2(List<List<List<int>>> st, List<string> strD, string[] arrStr, List<List<byte>> sysData)
        {
            lst = st;
            sysD = sysData;
            fileData = arrStr;
            strData = strD;
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void buttonDispl_Click(object sender, EventArgs e)
        {
            /*
            string stTrNb = comboBox1.Text;
            int number;
            bool result = Int32.TryParse(stTrNb, out number);
            if (result)
            {
                int evNb = number;
            }
            //int trNb = Convert.ToInt32(stTrNb);
            //int evNb = Convert.ToInt32(textBoxEN.Text);
            //string stLine = formRun.textExp(trNb, evNb, 0);
            */
            eventList();
        }

        private void textBoxEN_TextChanged(object sender, EventArgs e)
        {
            eventList();
            
        }

        private void eventList()
        {
            textBoxED.Clear();
            string str = textBoxEN.Text;
            int number;
            int eNb = 0;
            bool result = Int32.TryParse(str, out number);
            if (result)
            {
                eNb = number;
            }
            int low = Math.Max(0, eNb - 1);
            int track = comboBox1.SelectedIndex;
            int state;
            int ch;
            int len = lst.Count();
            if (len == 0)
                return;
            if (track >= len)
                return;
            len = lst[track].Count();
            if (len == 0)
                return;
            int high = Math.Min(len, eNb + 2);
            const string format1 = "{0, 6} {1, 6} {2, 6} {3, 6} {4, -20}";
            const string format2 = "{0, 6} {1, 6} {2, 6} {3, 6} {4, 6} {5, 6}";
            int i = low;
            while (i < high)
            {
                state = lst[track][i][1];
                ch = lst[track][i][1] - state * 16 + 1;
                switch (state)
                {
                    case 255:
                        str = string.Format(format1, i, lst[track][i][0], lst[track][i][1], lst[track][i][2], strData[lst[track][i][3]]);
                        break;
                    case 240:
                        str = string.Format(format1, i, lst[track][i][0], lst[track][i][1], lst[track][i][2], sysD[lst[track][i][3]]);
                        break;
                    default:
                        str = string.Format(format2, i, lst[track][i][0], state, lst[track][i][2], lst[track][i][3], ch);
                        break;
                }
                textBoxED.AppendText(str);
                textBoxED.AppendText("\n");
                i++;

            }
            str = "";
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            string str = textBoxEN.Text;
            List<int> vect = new List<int>();
            int number;
            int eNb = 0;
            bool result = Int32.TryParse(str, out number);
            if (result)
            {
                eNb = number;
            }
            int track = comboBox1.SelectedIndex;
            
            int funct = comboBoxFunct.SelectedIndex;
            switch (funct)
            {
                case 0:
                    comboBoxEvT.Visible = true;
                    label9.Visible = true;
                    //Insert
                    int channel = comboBoxCh.SelectedIndex;
                    int evT = comboBoxEvT.SelectedIndex;
                    vect.Add(lst[track][eNb][0]);
                    insert(evT, vect, channel, track, str, eNb);
                    break;
                case 1:
                    //Delete
                    lst[track].RemoveAt(eNb);
                    break;
                case 2:
                    //Replace
                    replace(track, str);
                    break;
                case 3:
                    // Split Track
                    split_track(track, vect);
                    break;
                case 4:
                    //Event editing
                    Form3 myForm;
                    myForm = new Form3(lst, strData, track, eNb);
                    myForm.Show();
                    break;
                case 5:
                    //Change Track order
                    {
                        Form4 myForm4;
                        myForm4 = new Form4(lst, strData);
                        int n = lst.Count;
                        myForm.Height = 100 + n * 20;
                        myForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                        myForm.Show();
                        break;
                    }
                case 6:
                    //Change Midi Channel
                    change_midi_channel(track);
                    break;
                case 7:
                    //Note identification in drum track
                    drum_note_id(track, vect);
                    break;
                case 8:
                    //Brush Kit Correction
                    brush_kit_corr(track);
                    break;
                case 9:
                    break;

                case 10:
                    //Time correction of MIDI signals. Track "track" should contain bar starts in channel 10.
                    time_corr(track);
                    break;
                case 11:
                    //Change of ticks/quarter note
                    str = textBoxD1.Text;
                    fileData[6] = "Number of Ticks/Quarter Note: " + str;
                    break;
                case 12:
                    //Increase brush swirl length
                    //To do: check if channel == 10!!!
                    str = textBoxD1.Text;
                    int swl;
                    bool result1 = Int32.TryParse(str, out number);
                    if (result1)
                    {
                        swl = number;
                    }
                    int tlg = lst[track].Count;
                    break;
            }
            
            
            
            
        }

        private void textBoxED_TextChanged(object sender, EventArgs e)
        {

        }

        private void insert(int evT, List<int> vect, int channel, int track, string str, int eNb)
        {
            switch (evT)
            {
                case 0:
                    //Program Change
                    vect.Add(192 + channel);
                    str = textBoxD1.Text;
                    int number;
                    bool result = Int32.TryParse(str, out number);
                    if (result)
                    {
                        vect.Add(number-1);
                    }

                    vect.Add(0);
                    lst[track].Insert(eNb, vect);
                    str = "";
                    break;
                case 1:
                    //Track Name
                    labelTrName.Visible = true;
                    textTrName.Visible = true;
                    buttonTrN.Visible = true;
                    break;
                case 2:
                    //Master Volume
                    List<byte> sysVect = new List<byte>();
                    List<int> vtt = new List<int>();
                    int sDCnt = sysD.Count;
                    vtt.Add(0);
                    vtt.Add(240);
                    vtt.Add(7);
                    vtt.Add(sDCnt);
                    str = textBoxD1.Text;
                    int vol = 0;
                    result = Int32.TryParse(str, out number);
                    if (result) 
                    {
                        vol = number; 
                    }
                    sysVect.Add(7);
                    sysVect.Add(127); // Hex 7F
                    sysVect.Add(127);
                    sysVect.Add(4);
                    sysVect.Add(1);
                    sysVect.Add(0);
                    byte by = (byte)(vol);
                    sysVect.Add(by);
                    sysVect.Add(247); // Hex F7
                    sysD.Add(sysVect);
                    //strData.Add()
                    lst[track].Insert(1, vtt);
                    break;
                case 3:
                    //Key Signature
                    string key = "C ";
                    string mode = "Major";
                    key = comboBoxKey.Text;
                    mode = comboBoxMode.Text;
                    vect.Add(255);
                    vect.Add(89);
                    vect.Add(strData.Count);
                    lst[track].Insert(eNb, vect);
                    str = "Key Signature: " + key + mode;
                    strData.Add(str);
                    break;
                case 4:
                    //TrackBar Volume
                    vect.Add(176 + channel);
                    vect.Add(7);
                    str = textBoxD1.Text;
                    result = Int32.TryParse(str, out number);
                    if (result)
                    {
                        vect.Add(number);
                    }
                    lst[track].Insert(eNb, vect);
                    break;
                default:
                    break;
            }
        }

        private void replace(int track, string str)
        {
            int note1 = 0;
            int note2 = 0;
            int lg = lst[track].Count;
            str = textBoxD1.Text;
            int number;
            bool result = Int32.TryParse(str, out number);
            if (result)
            {
                note1 = number;
            }
            str = textBoxD2.Text;
            result = Int32.TryParse(str, out number);
            if (result)
            {
                note2 = number;
            }
            int iloop = 0;
            while (iloop < lg)
            {
                if (lst[track][iloop][2] == note1)
                    lst[track][iloop][2] = note2;
                iloop++;
            }
        }

        private void split_track(int track, List<int> vect)
        {
            List<List<int>> lst2 = new List<List<int>>();
            List<List<int>> lstN = new List<List<int>>();
            List<int> lstvect = new List<int>();
            int[] arr1 = new int[5];
            int nmb = lst[track].Count; //Number of events in track to be splitted
            int nbTr = lst.Count;
            int x;
            int flag = 1;
            int chan;
            int i = 0;
            while (i < nmb)
            {
                lst2.Add(lst[track][i]);
                x = lst2[i][1];
                chan = 0;
                if (x < 240)
                    chan = x % 16 + 1;
                lst2[i].Add(chan);
                if (vect.Contains(chan))
                    flag = 0;
                else
                {
                    if (chan < 16)
                        vect.Add(chan);
                }
                i++;
            }
            lst.Remove(lst[track]);
            int nbNtr = vect.Count; //Number of channels in the track to be spilitted.
            if (nbNtr > 1)
            {
                fileData[4] = "Midi Type: 1 \n";
                fileData[5] = "Number of Tracks: " + Convert.ToString(nbTr + nbNtr - 1) + "\n";
                //Program.form.fileData[4] = "Text";
            }
            int j = 0;
            int k;
            int chN; //channel number
            while (j < nbNtr)
            {
                lstN.Clear();
                chN = vect[j];
                i = 0;
                while (i < nmb)
                {
                    if (lst2[i][4] == chN)
                    {
                        k = 0;
                        while (k < 4)
                        {
                            arr1[k] = lst2[i][k];
                            k++;
                        }
                        ml.toTwo(arr1, lstN);
                    }
                    i++;
                }
                // insert EOF here
                arr1[1] = 255;
                arr1[2] = 47;
                x = strData.Count;
                arr1[3] = x;
                ml.toTwo(arr1, lstN);
                strData.Add("End of Track");
                ml.toThree(lstN, lst);
                j++;
            }
            nbNtr = lst.Count;
        }

        private void change_midi_channel(int track)
        {
            int state;
            int x;
            int i = 0;
            int len = lst[track].Count;
            int ch = comboBoxCh.SelectedIndex;
            while (i < len)
            {
                state = lst[track][i][1];
                x = state / 16;
                if (x != 15)
                {
                    state = x * 16 + ch;
                    lst[track][i][1] = state;
                }
                i++;
            }
        }

        private void drum_note_id(int track, List<int> vect)
        {
            List<int> lstvect = new List<int>();
            int nmb = lst[track].Count; //Number of events in track
            int i = 0;
            int note;
            int flag;
            while (i < nmb)
            {
                if (lst[track][i][1] == 153)
                {
                    note = lst[track][i][2];
                    if (vect.Contains(note))
                        flag = 0;
                    else
                        vect.Add(note);
                }
                i++;
            }
            nmb = vect.Count();
            i = 0;
            StringBuilder sb = new StringBuilder();
            while (i < nmb)
            {
                sb.AppendLine(vect[i].ToString() + "\n");
                i++;
            }
            string str = sb.ToString();
            Form5 myForm;
            myForm = new Form5(str);
            //myForm.FormBorderStyle = FormBorderStyle.None;
            myForm.Show();
            myForm.Width = 80;
        }

        private void brush_kit_corr(int track)
        {
            int[] noteCorr = new int[] { 15, 16, 17, 18, 32, 23, 21, 22, 35, 36, 37, 25, 27, 26 };
            int i = 0;
            int nmb = lst[track].Count;
            int note;
            while (i < nmb)
            {
                if (lst[track][i][1] == 153 || lst[track][i][1] == 137)
                {
                    note = lst[track][i][2];
                    if (note < 41 && note > 27)
                    {
                        lst[track][i][2] = noteCorr[note - 27];
                    }
                }
                i++;
            }
        }

        private void time_corr(int track)
        {
            List<int> barMarks = new List<int>();
            int lbm = lst[track].Count();
            for (int i = 0; i < lbm; i++)
                if (i % 32 == 0)
                    barMarks.Add(lst[track][i][0]);
            int llbm = barMarks.Count();
            barMarks.Add(2 * barMarks[llbm - 1] - barMarks[llbm - 2]);
            llbm++;
            string str = textBoxD1.Text;
            int barTime = 0;
            int number;
            bool result = Int32.TryParse(str, out number);
            if (result)
            {
                barTime = number;
            }
            int nTr = lst.Count();
            int kk = 0;
            int m = 0;
            int tr = 1;
            int r;
            int nb;
            int ant;
            bool loop;
            while (tr < nTr)
            {
                kk = 0;
                m = 0;
                ant = lst[tr].Count();
                while (kk < llbm - 1)
                {
                    loop = true;
                    nb = barMarks[kk + 1] - barMarks[kk];
                    while (m < ant && loop == true)
                    {
                        r = lst[tr][m][0];
                        if (r >= barMarks[kk + 1])
                        {
                            loop = false;
                            break;
                        }
                        else
                        {
                            r = (kk + 1) * barTime + (r - barMarks[kk]) * barTime / nb;
                            if (r < 0)
                                r = 0;
                            lst[tr][m][0] = r;
                            m++;
                        }
                    }
                    kk++;
                }
                tr++;
            }
        }

        private void swirl_extension(int track, string str)
        {
            //Increase brush swirl length
            //To do: check if channel == 10!!!
            str = textBoxD1.Text;
            int swl;
            int number;
            bool result1 = Int32.TryParse(str, out number);
            if (result1)
            {
                swl = number;
            }
            int tlg = lst[track].Count;
        }

        private void buttonTrN_Click(object sender, EventArgs e)
        {
            string str = textBoxEN.Text;
            List<int> vect = new List<int>();
            int number;
            int eNb = 0;
            bool result = Int32.TryParse(str, out number);
            if (result)
            {
                eNb = number;
            }
            int track = comboBox1.SelectedIndex;

            string strTB = textTrName.Text;
            int strNum = strData.Count;
            vect.Add(0);
            vect.Add(255);
            vect.Add(3);
            vect.Add(strNum);
            lst[track].Insert(0, vect);
            strData.Add(textTrName.Text);
            labelTrName.Visible = false;
            textTrName.Visible = false;
            buttonTrN.Visible = false;
        }

        private void comboBoxFunct_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoxEvT.Visible = false;
            label9.Visible = false;
            label4.Visible = false;
            label6.Visible = false;
            label7.Visible = false;
            label10.Visible = false;
            comboBoxCh.Visible = false;
            comboBoxKey.Visible = false;
            comboBoxMode.Visible = false;
            textBoxD1.Visible = false;
            textBoxD2.Visible = false;
            int sw = comboBoxFunct.SelectedIndex;
            switch (sw)
            {
                case 0:
                    comboBoxEvT.Visible = true;
                    label9.Visible = true;
                    break;
                case 2:
                    textBoxD1.Visible = true;
                    textBoxD2.Visible = true;
                    label6.Visible = true;
                    label7.Visible = true;
                    break;

                case 6:
                    label10.Visible = true;
                    comboBoxCh.Visible = true;
                    break;
                case 10:
                    textBoxD1.Visible = true;
                    break;
                case 11:
                    textBoxD1.Visible = true;
                    label6.Visible = true;
                    break;
                default:
                    break;
                
            }
            if (comboBoxFunct.SelectedIndex == 0)
            {
                comboBoxEvT.Visible = true;
                label9.Visible = true;
            }
        }

        private void comboBoxEvT_SelectedIndexChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
            label6.Visible = false;
            label10.Visible = false;
            comboBoxCh.Visible = false;
            comboBoxKey.Visible = false;
            comboBoxMode.Visible = false;
            textBoxD1.Visible = false;
            int sw = comboBoxEvT.SelectedIndex;
            switch (sw)
            {
                case 0:
                    label10.Visible = true;
                    comboBoxCh.Visible = true;
                    label6.Visible = true;
                    textBoxD1.Visible = true;
                    break;
                case 2:
                    label6.Visible = true;
                    textBoxD1.Visible = true;
                    break;
                case 3:
                    label4.Visible = true;
                    comboBoxKey.Visible = true;
                    comboBoxMode.Visible = true;
                    break;
                case 4:
                    label10.Visible = true;
                    comboBoxCh.Visible = true;
                    label6.Visible = true;
                    textBoxD1.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void textBoxD1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}