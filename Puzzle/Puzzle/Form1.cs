using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle
{
    public partial class Form1 : Form
    {
        Point[] dsToaDo = new Point[17];
        Point[] K = new Point[17];
        int dem = 0;
        private int time;
        public Form1()
        {
            InitializeComponent();
        }

        public void doiCho(Button btn1, Button btn2)
        {
            if (btn1.BackColor == Color.White && btn2.BackColor == Color.Crimson)
            {
                Point pt = btn1.Location;
                string n = btn1.Name;

                btn1.Location = btn2.Location;
                btn1.Name = btn2.Name;

                btn2.Location = pt;
                btn2.Name = n;

                dem++; //dem so click
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            dsToaDo[1] = button1.Location;
            dsToaDo[2] = button2.Location;
            dsToaDo[3] = button3.Location;
            dsToaDo[4] = button4.Location;
            dsToaDo[5] = button5.Location;
            dsToaDo[6] = button6.Location;
            dsToaDo[7] = button7.Location;
            dsToaDo[8] = button8.Location;
            dsToaDo[9] = button9.Location;
            dsToaDo[10] = button10.Location;
            dsToaDo[11] = button11.Location;
            dsToaDo[12] = button12.Location;
            dsToaDo[13] = button13.Location;
            dsToaDo[14] = button14.Location;
            dsToaDo[15] = button15.Location;
            dsToaDo[16] = button16.Location;
            foreach (Control cl in this.Controls)
            {
                cl.Visible = false;
                btnEndgame.Visible = true;
                btnStart.Visible = true;
                btnReset.Visible = true;
                btnReset.Enabled = false;
                label1.Visible = true;
                label2.Visible = true;
                textBox1.Visible = true;
                timer1.Start();
            }
        }
        private void xaoMang()
        {
                for (int i = 1; i < 16; i++)
                {
                    Random rnd = new Random();
                    int a = rnd.Next(1, 16);
                    K[i] = dsToaDo[a];
                    int kt = 0;
                    for (int j = 0; j < i; j++)
                        if (K[j] == K[i])
                        {
                            kt = 1;
                            break;
                        }
                    if (kt == 1)
                        i--;
                }
                button1.Location = K[1];
                button2.Location = K[2];
                button3.Location = K[3];
                button4.Location = K[4];
                button5.Location = K[5];
                button6.Location = K[6];
                button7.Location = K[7];
                button8.Location = K[8];
                button9.Location = K[9];
                button10.Location = K[10];
                button11.Location = K[11];
                button12.Location = K[12];
                button13.Location = K[13];
                button14.Location = K[14];
                button15.Location = K[15];
                xepTen();
            btnStart.Enabled = false;
        }
        void xepTen()
        {
            foreach(Control tk in this.Controls)
            {
                if (tk.Location == dsToaDo[0])
                    tk.Name = "button0";
                if (tk.Location == dsToaDo[1])
                    tk.Name = "button1";
                if (tk.Location == dsToaDo[2])
                    tk.Name = "button2";
                if (tk.Location == dsToaDo[3])
                    tk.Name = "button3";
                if (tk.Location == dsToaDo[4])
                    tk.Name = "button4";
                if (tk.Location == dsToaDo[5])
                    tk.Name = "button5";
                if (tk.Location == dsToaDo[6])
                    tk.Name = "button6";
                if (tk.Location == dsToaDo[7])
                    tk.Name = "button7";
                if (tk.Location == dsToaDo[8])
                    tk.Name = "button8";
                if (tk.Location == dsToaDo[9])
                    tk.Name = "button9";
                if (tk.Location == dsToaDo[10])
                    tk.Name = "button10";
                if (tk.Location == dsToaDo[11])
                    tk.Name = "button11";
                if (tk.Location == dsToaDo[12])
                    tk.Name = "button12";
                if (tk.Location == dsToaDo[13])
                    tk.Name = "button13";
                if (tk.Location == dsToaDo[14])
                    tk.Name = "button14";
                if (tk.Location == dsToaDo[15])
                    tk.Name = "button15";
                if (tk.Location == dsToaDo[16])
                    tk.Name = "button16";
            }
        }
        private void btnEndgame_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn thoát", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            switch (result)
            {
                case DialogResult.Yes:
                    this.Close();
                    break;
                case DialogResult.No:
                    break;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = true;
                c.Enabled = true;
            }
            timer1.Start();
            label1.Visible = false;
            pictureBox1.Visible = true;
            btnReset.Enabled = true;
            dem = 0;
            textBox1.Text = Convert.ToString(dem);
            xaoMang();
        }
        private void youWin()
        {
            if(dem>150)
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                btnEndgame.Enabled = true;
                btnReset.Enabled = true;
                MessageBox.Show("You had move over 150 steps! You lose!", "Just a loser", MessageBoxButtons.OK);
                return;
            }
            textBox1.Text = Convert.ToString(dem);
            if(button1.Location == dsToaDo[1] && button2.Location == dsToaDo[2] && button3.Location == dsToaDo[3] && button4.Location == dsToaDo[4] && button5.Location == dsToaDo[5] &&
                button6.Location == dsToaDo[6] && button7.Location == dsToaDo[7] && button8.Location == dsToaDo[8] && button9.Location == dsToaDo[9] && button10.Location == dsToaDo[10] && button11.Location == dsToaDo[11] &&
                button12.Location == dsToaDo[12] && button13.Location == dsToaDo[13] && button14.Location == dsToaDo[14] && button15.Location == dsToaDo[15] && button16.Location == dsToaDo[16])
            {
                foreach (Control c in this.Controls)
                    c.Enabled = false;
                btnStart.Enabled = true;
                btnEndgame.Enabled = true;
                btnReset.Enabled = false;
                MessageBox.Show("Hay lắm, bạn đã thắng!", "OK you win", MessageBoxButtons.OK);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if(btn.Name=="button1")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button2")
                    {
                        doiCho(btn, (Button)bt);

                        youWin();
                        return;
                    }
                    if (bt.Name == "button5")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }
            }
            if(btn.Name=="button2")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button1")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button3")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button6")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }
               
            }
            if (btn.Name == "button3")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button2")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button4")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button7")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button4")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button3")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button8")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button5")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button1")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button6")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button9")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button6")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button2")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button5")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button7")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button10")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button7")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button3")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button6")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button8")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button11")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }
 
            }
            if (btn.Name == "button8")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button4")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button7")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button12")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button9")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button5")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button10")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button13")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button10")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button6")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button9")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button11")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button14")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button11")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button7")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button10")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button12")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button15")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button12")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button8")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button11")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button16")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button13")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button9")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button14")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button14")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button13")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button10")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button15")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button15")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button14")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button11")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button16")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button16")
            {
                foreach (Control bt in this.Controls)
                {
                    if (bt.Name == "button15")
                    {
                        doiCho(btn,(Button) bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button12")
                    {
                        doiCho(btn, (Button)bt);
                        youWin();
                        return;
                    }
                    if (bt.Name == "button0")
                    {
                        doiCho(btn,(Button) bt);
                        youWin();
                    }
                }

            }
            if (btn.Name == "button0")
            {
                foreach (Control bt in this.Controls)
                    if (bt.Name == "button16")
                    {
                        doiCho(btn,(Button) bt);
                        youWin();
                        return;
                    }
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            dem = 0;
            textBox1.Text = Convert.ToString(dem);           
            button1.Location=dsToaDo[1];
            button2.Location= dsToaDo[2];
            button3.Location= dsToaDo[3];
            button4.Location= dsToaDo[4];
            button5.Location= dsToaDo[5];
            button6.Location= dsToaDo[6];
            button7.Location= dsToaDo[7];
            button8.Location= dsToaDo[8];
            button9.Location= dsToaDo[9];
            button10.Location= dsToaDo[10];
            button11.Location= dsToaDo[11];
            button12.Location= dsToaDo[12];
            button13.Location= dsToaDo[13];
            button14.Location= dsToaDo[14];
            button15.Location= dsToaDo[15];
            button16.Location= dsToaDo[16];
            foreach (Control c in this.Controls)
                c.Enabled = false;
            btnStart.Enabled = true;
            btnEndgame.Enabled = true;
            time = 0;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_time.Text = (time / 60).ToString() + " Phút :" + (time % 60) + " Giây";
            time++;
        }
    }
}
