using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Midi_List_Editor_1._1
{
    public partial class Form1 : Form
    {
        string[] fileData = new string[23];  // information in Header Chunk
        int nbTr = new int();
        int nTicks = new int();    //number of ticks/ quarternote
        int[][] trStL = new int[17][];  // Track start, Track length
        List<int> lst = new List<int>();
        List<List<int>> lst20 = new List<List<int>>();
        List<List<int>> lst21 = new List<List<int>>();
        List<List<int>> lst22 = new List<List<int>>();
        List<List<int>> lst23 = new List<List<int>>();
        List<List<int>> lst24 = new List<List<int>>();
        List<List<int>> lst25 = new List<List<int>>();
        List<List<int>> lst26 = new List<List<int>>();
        List<List<int>> lst27 = new List<List<int>>();
        List<List<int>> lst28 = new List<List<int>>();
        List<List<int>> lst29 = new List<List<int>>();
        List<List<int>> lst210 = new List<List<int>>();
        List<List<int>> lst211 = new List<List<int>>();
        List<List<int>> lst212 = new List<List<int>>();
        List<List<int>> lst213 = new List<List<int>>();
        List<List<int>> lst214 = new List<List<int>>();
        List<List<int>> lst215 = new List<List<int>>();
        List<List<List<int>>> lst3 = new List<List<List<int>>>(); // all numeric event data
        List<List<int>> timeSign = new List<List<int>>();
        int nTqn = new int();  //number of ticks/ quarternote
        midlist ml = new midlist(); 
        List<string> strTr = new List<string>(); // all text event data
        int strCount = 0; // number of text events

        public Form1()
        {
            InitializeComponent();
        }

        private void bList_Click(object sender, EventArgs e)
        {
            //int time = delta(8);
            if (lst3.Count == 0)
            {
                MessageBox.Show("Please load a midi file!");
                return;
            }
            textBoxList.Clear();
            int trackNr = comboBox1.SelectedIndex;
            int nextTime = 0;
            if (trackNr == 0)
            {
                general();
            }
            if (trackNr > 0)
            {
                if (timeSign.Count == 0)
                {
                    int[] vect = { 0, 4, 4};
                    List<int> dList = vect.ToList();
                    timeSign.Add(dList);
                    nextTime = 100000000;
                }
                else
                {
                    if (timeSign.Count == 1)
                    {
                        nextTime = 100000000;
                    }
                    else
                    {
                        nextTime = timeSign[1][0];
                    }
                }
                int nr = trackNr - 1;
                int trLength = lst3[nr].Count; // Number of Track events
                int time = new int();
                int tpbU = nTicks; // ticks per beat unit; default beat unit = quatrer note.
                int bar = new int();
                int bt = 4;
                int beatst = new int();
                int beat = new int();
                int state = new int();
                int midiEv = new int();
                int channel = new int();
                StringBuilder sb = new StringBuilder();
                string str = "";
                const string format = "{0, 6} {1, 6} {2, 5} {3, 5} {4,5}";
                const string format1 = "{0,3} {1,1} {2,-2}";
                string slash ="/";

                int i = 0;
                int refI = 0;
                int baseT = timeSign[0][0];
                int tsN = timeSign[0][1];
                int tsD = timeSign[0][2];
                int baseB = 1;
                int fract = 0;
                int sw = 0;
                int nc = 0;
 
                while (i < trLength)
                //while (i < 100)
                {
                    time = lst3[nr][i][0];
                    while (time > nextTime)
                    {
                        refI++;
                        baseB = baseB + (nextTime - baseT) / tpbU / tsN;
                        baseT = nextTime;
                        //baseT = timeSign[refI][0];
                        tsN = timeSign[refI][1];
                        tsD = timeSign[refI][2];
                        tpbU = nTicks *  4 / tsD;
                        //baseB = baseB + (baseT - timeSign[refI - 1][0]) / tpbU / tsN;
                        if (refI + 1 < timeSign.Count)
                            nextTime = timeSign[refI + 1][0];
                        else
                            nextTime = 100000000;
                    }
                    beat = (time - baseT) / tpbU;
                    fract = time - baseT - beat * tpbU;
                    bar = baseB + beat / tsN;
                    beat = beat % tsN + 1;
                    
                    str = string.Format(format, i, time, bar, beat, fract);
                    str = str + "   ";
                    state = lst3[nr][i][1];
                    if (time == 2846)
                        time = time * 1;
                    sw = state/16;
                    switch (state)
                    {
                        case 240:
                            sysex();
                            break;
                        case 255:
                            str = str + listMetaEv(lst3[nr][i][3]);
                            break;
                        default:
                            str = str + listMidEv(state, lst3[nr][i][2], lst3[nr][i][3]);
                            nc++;
                            break;
                    }
                    if (state != 255)
                        str = str + string.Format(format1, tsN, slash, tsD);
                    sb.AppendLine(str + "\n");
                    i++;
                }
                str = sb.ToString();
                textBoxList.AppendText(str);

            }
            listMid(trackNr);
        }

        public string listMidEv(int state, int d1, int d2)
        {
            string str = "";
            string st = "";
            const string format = "{0, -22} {1, 4} {2, 5} {3, 4}";
            int midiEv = state / 16;
            int channel = state - midiEv * 16 + 1;
            switch (midiEv)
            {
                case 8:
                    st = note(d1);
                    str = string.Format(format, "Note Off", st, d2, channel);
                    break;
                case 9:
                    st = note(d1);
                    str = string.Format(format, "Note On", st, d2, channel);
                    break;
                case 10:
                    str = string.Format(format, "Aftertouch", d1, d2, channel);
                    break;
                case 11:
                    switch (d1)
                    {
                        case 0:
                            str = string.Format(format, "Bank Select", "CC", d2, channel);
                            break;
                        case 1:
                            str = string.Format(format, "Modulation Wheel", "CC", d2, channel);
                            break;
                        case 2:
                            str = string.Format(format, "Breath Control", "CC", d2, channel);
                            break;
                        case 4:
                            str = string.Format(format, "Foot Controller", "CC", d2, channel);
                            break;
                        case 5:
                            str = string.Format(format, "Portamento Time", "CC", d2, channel);
                            break;
                        case 6:
                            str = string.Format(format, "Data Entry", "CC", d2, channel);
                            break;
                        case 7:
                            str = string.Format(format, "Channel Volume", "CC", d2, channel);
                            break;
                        case 8:
                            str = string.Format(format, "Balance", "CC", d2, channel);
                            break;
                        case 10:
                            str = string.Format(format, "Pan", "CC", d2, channel);
                            break;
                        case 11:
                            str = string.Format(format, "Expression Controller", "CC", d2, channel);
                            break;
                        case 12:
                            str = string.Format(format, "Effect Control 1", "CC", d2, channel);
                            break;
                        case 13:
                            str = string.Format(format, "Effect Control 2", "CC", d2, channel);
                            break;
                        case 16:
                            str = string.Format(format, "Gen. Purp. Contr. #1", "CC", d2, channel);
                            break;
                        case 17:
                            str = string.Format(format, "Gen. Purp. Contr. #2", "CC", d2, channel);
                            break;
                        case 18:
                            str = string.Format(format, "Gen. Purp. Contr. #3", "CC", d2, channel);
                            break;
                        case 19:
                            str = string.Format(format, "Gen. Purp. Contr. #4", "CC", d2, channel);
                            break;
                        case 32:
                            str = string.Format(format, "Bank Select", "CC", d2, channel);
                            break;
                        case 33:
                            str = string.Format(format, "Modulation Wheel", "CC", d2, channel);
                            break;
                        case 34:
                            str = string.Format(format, "Breath Control", "CC", d2, channel);
                            break;
                        case 36:
                            str = string.Format(format, "Foot Controller", "CC", d2, channel);
                            break;
                        case 37:
                            str = string.Format(format, "Portamento Time", "CC", d2, channel);
                            break;
                        case 38:
                            str = string.Format(format, "Data Entry", "CC", d2, channel);
                            break;
                        case 39:
                            str = string.Format(format, "Channel Volume", "CC", d2, channel);
                            break;
                        case 40:
                            str = string.Format(format, "Balance", "CC", d2, channel);
                            break;
                        case 42:
                            str = string.Format(format, "Pan", "CC", d2, channel);
                            break;
                        case 43:
                            str = string.Format(format, "Expression controller", "CC", d2, channel);
                            break;
                        case 44:
                            str = string.Format(format, "Effect control 1", "CC", d2, channel);
                            break;
                        case 45:
                            str = string.Format(format, "Effect Control 2", "CC", d2, channel);
                            break;
                        case 48:
                            str = string.Format(format, "Gen. Purp. Contr. #1", "CC", d2, channel);
                            break;
                        case 49:
                            str = string.Format(format, "Gen. Purp. Contr. #2", "CC", d2, channel);
                            break;
                        case 50:
                            str = string.Format(format, "Gen. Purp. Contr. #3", "CC", d2, channel);
                            break;
                        case 51:
                            str = string.Format(format, "Gen. Purp. Contr. #4", "CC", d2, channel);
                            break;
                        case 64:
                            str = string.Format(format, "Sustain", "CC", d2, channel);
                            break;
                        case 65:
                            str = string.Format(format, "Portamento", "CC", d2, channel);
                            break;
                        case 66:
                            str = string.Format(format, "Sustenuto", "CC", d2, channel);
                            break;
                        case 67:
                            str = string.Format(format, "Soft Pedal", "CC", d2, channel);
                            break;
                        case 68:
                            str = string.Format(format, "Legato Footswitch", "CC", d2, channel);
                            break;
                        case 69:
                            str = string.Format(format, "Hold 2", "CC", d2, channel);
                            break;
                        case 70:
                            str = string.Format(format, "Sound Controller #1", "CC", d2, channel);
                            break;
                        case 71:
                            str = string.Format(format, "Sound Controller #2", "CC", d2, channel);
                            break;
                        case 72:
                            str = string.Format(format, "Sound Controller #3", "CC", d2, channel);
                            break;
                        case 73:
                            str = string.Format(format, "Sound Controller #4", "CC", d2, channel);
                            break;
                        case 74:
                            str = string.Format(format, "Sound Controller #5", "CC", d2, channel);
                            break;
                        case 75:
                            str = string.Format(format, "Sound Controller #6", "CC", d2, channel);
                            break;
                        case 76:
                            str = string.Format(format, "Sound Controller #7", "CC", d2, channel);
                            break;
                        case 77:
                            str = string.Format(format, "Sound Controller #8", "CC", d2, channel);
                            break;
                        case 78:
                            str = string.Format(format, "Sound Controller #9", "CC", d2, channel);
                            break;
                        case 79:
                            str = string.Format(format, "Sound Controller #10", "CC", d2, channel);
                            break;
                        case 80:
                            str = string.Format(format, "Gen. Purp. Contr. #5", "CC", d2, channel);
                            break;
                        case 81:
                            str = string.Format(format, "Gen. Purp. Contr. #6", "CC", d2, channel);
                            break;
                        case 82:
                            str = string.Format(format, "Gen. Purp. Contr. #7", "CC", d2, channel);
                            break;
                        case 83:
                            str = string.Format(format, "Gen. Purp. Contr. #8", "CC", d2, channel);
                            break;
                        case 84:
                            str = string.Format(format, "Portamento Control", "CC", d2, channel);
                            break;
                        case 91:
                            str = string.Format(format, "Effect 1 Depth", "CC", d2, channel);
                            break;
                        case 92:
                            str = string.Format(format, "Effect 2 Depth", "CC", d2, channel);
                            break;
                        case 93:
                            str = string.Format(format, "Effect 3 Depth", "CC", d2, channel);
                            break;
                        case 94:
                            str = string.Format(format, "Effect 4 Depth", "CC", d2, channel);
                            break;
                        case 95:
                            str = string.Format(format, "Effect 5 Depth", "CC", d2, channel);
                            break;
                        case 96:
                            str = string.Format(format, "Data Entry +1", "CC", d2, channel);
                            break;
                        case 97:
                            str = string.Format(format, "Data Entry -1", "CC", d2, channel);
                            break;
                        case 98:
                            str = string.Format(format, "Non Reg. Par. No LSB", "CC", d2, channel);
                            break;
                        case 99:
                            str = string.Format(format, "Non Reg. Par. No MSB", "CC", d2, channel);
                            break;
                        case 100:
                            str = string.Format(format, "Reg. Par. No LSB", "CC", d2, channel);
                            break;
                        case 101:
                            str = string.Format(format, "Non Reg. Par. No MSB", "CC", d2, channel);
                            break;
                        case 120:
                            str = string.Format(format, "All Sounds Off", "CC", d2, channel);
                            break;
                        case 121:
                            str = string.Format(format, "Reset All Controllers", "CC", d2, channel);
                            break;
                        case 123:
                            str = string.Format(format, "All Notes Off", "CC", d2, channel);
                            break;
                        case 124:
                            str = string.Format(format, "Omni Mode Off (+ANO)", "CC", d2, channel);
                            break;
                        case 125:
                            str = string.Format(format, "Omni Mode On (+ANO)", "CC", d2, channel);
                            break;
                        case 126:
                            str = string.Format(format, "Poly Mode (+ANO)", "CC", d2, channel);
                            break;
                        case 127:
                            str = string.Format(format, "Poly Mode On", "CC", d2, channel);
                            break;
                    }

                    //str = string.Format(format, "Control Change", d1, d2, channel);
                    break;
                case 12:
                    str = string.Format(format, "Program Change", d1+1, d2, channel);
                    break;
                case 13:
                    str = string.Format(format, "Channel Pressure", d1, d2, channel);
                    break;
                case 14:
                    str = string.Format(format, "Pitch Whwwl Change", d1, d2, channel);
                    break;
                case 15:
                    str = string.Format(format, "Channel mode Message", d1, d2, channel);
                    break;
            }
            return str;
        }

        public string listMetaEv(int d2)
        {
            string str = strTr[d2];
            return str;
        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            Form2 myForm;
            myForm = new Form2(lst3, strTr);
            myForm.Show();
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result.
            lst3.Add(lst20);
            lst3.Add(lst21);
            lst3.Add(lst22);
            lst3.Add(lst23);
            lst3.Add(lst24);
            lst3.Add(lst25);
            lst3.Add(lst26);
            lst3.Add(lst27);
            lst3.Add(lst28);
            lst3.Add(lst29);
            lst3.Add(lst210);
            lst3.Add(lst211);
            lst3.Add(lst212);
            lst3.Add(lst213);
            lst3.Add(lst214);
            lst3.Add(lst215);
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                string str = openFileDialog1.FileName;

                //textBoxList.AppendText("\n");
                //textBoxList.AppendText("File Name: " + str + "\r\n");
                fileData[0] = "File Name: " + str + "\n";
                int i = new int();
                int iLoop = 0;
                int Time = 0;
                int State = 0;
                int Bar = 0;
                int[] vect = { 0, 0, 0, 0 };
                byte[] array = File.ReadAllBytes(str);
                byte[] arraySb = new byte[4];
                int aLength = array.Length;
                //MessageBox.Show(aLength.ToString());
                if (array[0] == 77 && array[1] == 84 && array[2] == 104 && array[3] == 100)
                    fileData[1] = "File Header OK. \n";
                else
                    fileData[1] = "Incorrect File Header. \n";

                if (array[4] == 0 && array[5] == 0 && array[6] == 0 && array[7] == 6)
                    fileData[2] = "";
                else
                    fileData[2] = "Felaktig File Header. \n";
                
                fileData[3] = "Length: " + Convert.ToString(aLength) + "\n";
                fileData[4] = "Midi Type: " + Convert.ToString(array[9]) + " \n";
                //
                //string[] sspl = fileData[4].Split(' ');

                fileData[5] = "Number of Tracks: " + Convert.ToString(array[11]) + "\n";
                nbTr = array[11];
                ml.nTr = array[11];
                nTicks = array[12] * 256 + array[13];
                nTqn = nTicks;
                //textBoxList.AppendText("Number of Ticks/Quarter Note: " + Convert.ToString(nTicks) + "\n");
                fileData[6] = "Number of Ticks/Quarter Note: " + Convert.ToString(nTicks);
                // Track start och Track length
                int arrpos = 14;
                int trlength = 0;
                int nTr = array[11];
                int trNum = 1;
                while (trNum < nTr + 1)
                {
                    trlength = array[arrpos + 4] * 16777216 + array[arrpos + 5] * 65536 + array[arrpos + 6] * 256 + array[arrpos + 7];
                    trStL[trNum] = new int[] {arrpos, trlength};
                    str = "Track " + Convert.ToString(trNum) + " starts at " + Convert.ToString(arrpos) + "; ";
                    str = str + "Track Length: " + Convert.ToString(trlength);
                    fileData[6 + trNum] = str + "\n";
                    arrpos = arrpos + 8 + trlength;
                    trNum++;
                }

                arrpos = 14;
                trNum = 1;
                while (trNum < nTr + 1)
                {
                    Time = 0;
                    i=0;
                    while (i < 4)
                    {
                        arraySb[i] = array[arrpos + i];
                        i++;
                    }
                    str = ASCIIEncoding.ASCII.GetString(arraySb,0,4);
                    //MessageBox.Show(str);
                    arrpos = arrpos + 8;
                    iLoop = arrpos + trStL[trNum][1];
                    while (arrpos < iLoop)
                    {
                        Time = Time + delta(array, ref arrpos);
                        vect[0] = Time;
                        if (array[arrpos] > 127)
                        {
                            State = array[arrpos];
                            arrpos++;
                        }
                        vect[1] = State;
                        //MessageBox.Show(Convert.ToString(State) + "; " + Convert.ToString(arrpos));
                        switch (State)
                        {
                            case 240:
                                sysex();
                                break;
                            case 255:
                                arrpos = metaEv(vect, array, arrpos,Time, ref Bar);
                                break;
                            default:
                                arrpos = midEv(vect, array, arrpos);
                                break;
                        }
          
                        ml.to3(vect, lst3, trNum - 1);

                    }

                    //MessageBox.Show("lst3 " + lst3.Count().ToString());

                    trNum++;

                }

            }
            //MessageBox.Show("Klar");
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            string strFileName = saveFileDialog1.FileName;
            List<byte> outarr = new List<byte>();
            byte[] arr = { 77, 84, 104, 100, 0, 0, 0, 6 };
            string[] spls;
            int x;
            int y;
            byte xx = 0;
            int i = 0;
            int j = 0;
            int num = 0;
            int time0 = 0;
            int time = 0;
            int dtime = 0;
            int nb = 0;
            int trLen = 0;
            int state = 0;
            int stateEv = 0;
            int sw = 0;
            int trStart = 0;
            string st = "";
            byte[] vect;
            int len;
            while (i < 8)
            {
                outarr.Add(arr[i]);
                i++;
            }
            outarr.Add(0);
            spls = fileData[4].Split(' ');
            xx = Convert.ToByte(spls[2]);
            outarr.Add(xx);
            outarr.Add(0);
            xx = Convert.ToByte(nbTr);
            outarr.Add(xx);
            //outarr.Add(1);
            //outarr.Add(224);
            spls = fileData[6].Split(' ');
            x = Convert.ToInt32(spls[4]);
            vect = BitConverter.GetBytes(x);
            outarr.Add(vect[1]);
            outarr.Add(vect[0]);
            // Tracks begin here.
            i=0;
            while (i < nbTr)
            {
                time0 = 0;
                int stateOld = 0;
                outarr.Add(77);
                outarr.Add(84);
                outarr.Add(114);
                outarr.Add(107);
                trStart = outarr.Count;
                j = 0;
                while (j < 4)
                {

                    outarr.Add(0); // Must be modified with the actual track length.
                    j++;
                }
                trLen = lst3[i].Count;
                nb = 0;
                while (nb<trLen)
                {
                    time = lst3[i][nb][0];
                    dtime = time - time0;
                    time0 = time;
                    toDelta(dtime, outarr);
                    state = lst3[i][nb][1];
                    if (state != stateOld||state==255)
                    {
                        outarr.Add(Convert.ToByte(state));
                        stateOld = state;
                    }
                    switch (state)
                    {
                        case 224:
                            // Sysex event; code to be added
                            break;
                        case 255:
                            sw = lst3[i][nb][2];
                            outarr.Add(Convert.ToByte(sw));
                            switch (sw)
                            {
                                case 0:
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                case 5:
                                case 6:
                                case 7:
                                case 9:
                                    st = strTr[lst3[i][nb][3]];
                                    addTextEvent(st, outarr);
                                    break;
                                case 32:
                                    outarr.Add(1);
                                    outarr.Add(0);
                                    // Code to be modified
                                    break;
                                case 33:
                                    outarr.Add(1);
                                    outarr.Add(0);
                                    // Code to be modified
                                    break;
                                case 47:
                                    outarr.Add(0);
                                    break;
                                case 81:
                                    outarr.Add(3);
                                    st = strTr[lst3[i][nb][3]];
                                    spls = st.Split(' ');
                                    num = Convert.ToInt32(spls[2]);
                                    num = 60000000 / num;
                                    int nmr = num / 65536;
                                    outarr.Add(Convert.ToByte(nmr));
                                    num = num % 65536;
                                    nmr = num / 256;
                                    outarr.Add((Convert.ToByte(nmr)));
                                    nmr = nmr % 256;
                                    outarr.Add((Convert.ToByte(nmr)));
                                    break;
                                case 84:
                                    outarr.Add(5);
                                    outarr.Add(0);
                                    outarr.Add(0);
                                    outarr.Add(0);
                                    outarr.Add(0);
                                    outarr.Add(0);
                                    // code to be added
                                    break;
                                case 88:
                                    outarr.Add(4);
                                    st = strTr[lst3[i][nb][3]];
                                    spls = st.Split(' ');
                                    st = spls[2];
                                    spls = st.Split('/');
                                    outarr.Add(Convert.ToByte(spls[0]));
                                    num = Convert.ToInt32(spls[1]);
                                    nmr = 0;
                                    while (num > 1)
                                    {
                                        num = num / 2;
                                        nmr++;
                                    }
                                    outarr.Add((Convert.ToByte(nmr)));
                                    outarr.Add(24);
                                    outarr.Add(8);
                                    break;
                                case 89:
                                    outarr.Add(2);
                                    outarr.Add(0);
                                    outarr.Add(0);
                                    break;
                                    // code to be modified
                                case 127:
                                    outarr.Add(0);
                                    break;
                                default:
                                // code to be added
                                    break;
                            }
                            break;
                        default:
                            outarr.Add(Convert.ToByte(lst3[i][nb][2]));
                            stateEv = state/16;
                            if (stateEv == 12 || stateEv == 13)
                                break;
                            outarr.Add(Convert.ToByte(lst3[i][nb][3]));
                            break;
                    }
                    nb++;
                }
                int trackEnd = outarr.Count;
                lengthCorr(trStart, trackEnd, outarr);
                i++;
                
            }
            File.WriteAllBytes(strFileName, outarr.ToArray());    

        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void general()
        {
            int nTr = nbTr;
            string str = fileData[5];
            //MessageBox.Show(nTr.ToString());
            StringBuilder s = new StringBuilder();
            int i = 0;
            while (i < nTr + 7)
            {
                s.Append(fileData[i]);
                s.AppendLine();
                i++;
            }
            textBoxList.AppendText(s.ToString());
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public int delta(byte[] bl, ref int nT )
        {
            byte j = 0;
            int y = 0;
            int x = 128;
            int n = 0;
            do
            {
                x = bl[nT];
                y = y * 128 + x % 128;
                j++;
                nT++;
                n++;
                if (n > 4)
                {
                    return y;
                }
            } while (x > 127);
            return y;
        }

        public void toDelta(int dtime, List<byte> outarr)
        {
            int x = dtime;
            int i = 0;
            int j = 0;
            int[] a = { 0, 0, 0, 0 };
            while (x > 127)
            {
                a[i] = x % 128;
                x = x / 128;
                i++;
            }
            a[i] = x;
            while (j < i)
            {
                outarr.Add(Convert.ToByte(a[i - j] + 128));
                j++;
            }
            outarr.Add(Convert.ToByte(a[0]));
        }

        public void addTextEvent(string str, List<byte> arr)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] vect;
            vect = encoding.GetBytes(str);
            int len = vect.Length;
            arr.Add(Convert.ToByte(len));
            int j = 0;
            while (j < len)
            {
                arr.Add(vect[j]);
                j++;
            }

        }

        public static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }

        public int sysex()
        {
            MessageBox.Show("Sysex");
            return 0;
        }

        public int metaEv(int[] vect, byte[] arr, int nT, int Time, ref int Bar)
        {
            //MessageBox.Show("Metaev");
            string st = "";
            vect[2] = arr[nT];
            int sw = vect[2];
            int num = 0;
            nT++;
            int len = arr[nT];
            nT++;
            switch (sw)
            {
                case 0:
                    num = arr[nT] * 256 + arr[nT + 1];
                    st = "Sequence Number: " + num.ToString();
                    break;
                case 32:
                    num = arr[nT];
                    st = "Channel Prefix: " + num.ToString();
                    break;
                case 33:
                    num = arr[nT];
                    st = "Port Prefix: " + num.ToString();
                    break;
                case 47:
                    st = "End of Track";
                    break;
                case 81:
                    
                    num = arr[nT] * 256 * 256 + arr[nT + 1] * 256 + arr[nT + 2];
                    num = 60000000 / num;
                    st = "Tempo (QNPM): " + num.ToString();
                    break;
                case 84:
                    st = "SMPTE Offset";
                    // Code to be added
                    break;
                case 88:
                    num = arr[nT + 1];
                    switch (num)
                    {
                        case 0:
                            num = 1;
                            break;
                        case 1:
                            num = 2;
                            break;
                        case 2:
                            num = 4;
                            break;
                        case 3:
                            num = 8;
                            break;
                        case 4:
                            num = 16;
                            break;
                        default:
                            num = 32;
                            break;
                    }
                    st = "Time Signature: " + arr[nT].ToString() + "/" + num.ToString();
                    List<int> ts = new List<int>();
                    int[] vct = {Time, arr[nT], num};
                    ts = vct.ToList();
                    timeSign.Add(ts);
                    break;
                case 89:
                    st = "Key Signature: ";
                    // Code to be added
                    break;
                case 127:
                    st = "Sequencer-Specific";
                    break;
                default:
                    st = ASCIIEncoding.ASCII.GetString(arr,nT,len);
                    break;
            }
            strTr.Add(st);
            vect[3] = strCount;
            strCount++;
            nT = nT + len;
            //MessageBox.Show(st);
            return nT;
        }

        public int midEv(int[] vect, byte[] arr, int nT)
        {
            //MessageBox.Show("Midiev");
            vect[2] = arr[nT];
            nT++;
            int sw = arr[nT - 2] / 16;
            switch (sw)
            {
                case 12:
                case 13:
                    vect[3] = 0;
                    return nT;
                default:
                    vect[3] = arr[nT];
                    nT++;
                    return nT;
            }
            
        }


        public void listMid(int trNr)
        {
            if (trNr > ml.nTr)
            {
                textBoxList.AppendText("Track number " + trNr.ToString() + " does not exsist");
                return;
            }
        }
        public string note(int nr)
        {
            string st = "";
            int sw = nr % 12;
            int oct = nr / 12 - 1;
            string soct = oct.ToString();
            switch (sw)
            {
                case 0:
                    st = "C " + soct;
                    break;
                case 1:
                    st = "C#" + soct;
                    break;
                case 2:
                    st = "D " + soct;
                    break;
                case 3:
                    st = "D#" + soct;
                    break;
                case 4:
                    st = "E " + soct;
                    break;
                case 5:
                    st = "F " + soct;
                    break;
                case 6:
                    st = "F#" + soct;
                    break;
                case 7:
                    st = "G " + soct;
                    break;
                case 8:
                    st = "G#" + soct;
                    break;
                case 9:
                    st = "A " + soct;
                    break;
                case 10:
                    st = "A#" + soct;
                    break;
                case 11:
                    st = "B " + soct;
                    break;
            }
            return st;
        }
        public void lengthCorr(int trS, int trE, List<Byte> lb)
        {
            int length = trE - trS - 4;
            int a=256*256;
            int b=a*256;
            int x = length / b;
            lb[trS] = Convert.ToByte(x);
            int y = length % b;
            x = y / a;
            lb[trS+1] = Convert.ToByte(x);
            y = y % a;
            x = y / 256;
            lb[trS + 2] = Convert.ToByte(x);
            x = y % 256;
            lb[trS + 3] = Convert.ToByte(x);
        }
        public string textExp(int x, int y, int z)
        {
            return lst3[x][y][z].ToString();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string name = saveFileDialog1.FileName;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
    
 
    public class midlist
    {
        //public midlist();
        // nTr = number of Tracks.
        private int mn = 0;
        public int nTr
        {
            get
            {
                return mn;
            }
            set
            {
                mn = value;
            }
        }
        public void to2(int[] vect, List<List<int>> lst2)
        {
            List<int> lst1 = new List<int>();
            int[] arr = new int[4];
            arr = vect;
            lst1 = arr.ToList();
            lst2.Add(lst1);

        }
        public void to3(int[] vect, List<List<List<int>>> lst3, int n)
        {
            List<int> lst1 = new List<int>();
            lst1 = vect.ToList();
            lst3[n].Add(lst1);
        }
        public void strm(List<string> slst, string str, int strAnt)
        {
            slst.Add(str);
            strAnt++;
        }
    }

}
