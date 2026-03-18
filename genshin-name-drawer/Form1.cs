using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Timers;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Windows.Forms;
using AxWMPLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace _894UP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //生成字节数组
        public static int GetName()
        {
            string[] names = File.ReadAllLines(".\\AllNames.txt");
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iRoot = BitConverter.ToInt32(buffer, 0);//利用BitConvert方法把字节数组转换为整数
            Random rdmNum = new Random(iRoot);//以这个生成的整数为种子
            return rdmNum.Next(0, names.Length);
        }
        
        public static void OneGold(AxWindowsMediaPlayer axWindowsMediaPlayer1)
        {
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = ".\\1Gold.mp4"; //指定音频文件
            axWindowsMediaPlayer1.settings.volume = 70;//指定音量
            axWindowsMediaPlayer1.Ctlcontrols.play();//开始播放
        }
        public static void OneBlue(AxWindowsMediaPlayer axWindowsMediaPlayer1)
        {
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = ".\\1Blue.mp4"; //指定音频文件
            axWindowsMediaPlayer1.settings.volume = 70;//指定音量
            axWindowsMediaPlayer1.Ctlcontrols.play();//开始播放
        }
        public static void OnePurple(AxWindowsMediaPlayer axWindowsMediaPlayer1)
        {
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = ".\\1Purple.mp4"; //指定音频文件
            axWindowsMediaPlayer1.settings.volume = 70;//指定音量
            axWindowsMediaPlayer1.Ctlcontrols.play();//开始播放
        }
        public static void TenPurple(AxWindowsMediaPlayer axWindowsMediaPlayer1)
        {
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = ".\\10Purple.mp4"; //指定音频文件
            axWindowsMediaPlayer1.settings.volume = 70;//指定音量
            axWindowsMediaPlayer1.Ctlcontrols.play();//开始播放
        }
        public static void TenGold(AxWindowsMediaPlayer axWindowsMediaPlayer1)
        {
            axWindowsMediaPlayer1.Visible = true;
            axWindowsMediaPlayer1.uiMode = "none";
            axWindowsMediaPlayer1.URL = ".\\10Gold.mp4"; //指定音频文件
            axWindowsMediaPlayer1.settings.volume = 70;//指定音量
            axWindowsMediaPlayer1.Ctlcontrols.play();//开始播放
        }
        string[] purple = File.ReadAllLines(".\\Purple.txt");
        string[] gold = File.ReadAllLines(".\\Gold.txt");
        public static void Judge(string name,int time,AxWindowsMediaPlayer axWindowsMediaPlayer1)

        {
            string[] purple= File.ReadAllLines(".\\Purple.txt");
            string[] gold = File.ReadAllLines(".\\Gold.txt");
            if (gold.Contains<string>(name)&&time==1)
            {
                OneGold(axWindowsMediaPlayer1);

            }
            else if(purple.Contains<string>(name) &&time == 1) 
            {
                OnePurple(axWindowsMediaPlayer1);
            }
            else if (!(purple.Contains<string>(name)&&gold.Contains<string>(name))&&time==1)
            {
                OneBlue(axWindowsMediaPlayer1);
            }
            else
            {
                TenGold(axWindowsMediaPlayer1);
            }
        }
        public static void HandleNameList() 
        {
        
        }
        int time = 0;
        private void buOneTime_Click(object sender, EventArgs e)
        {
            GC.Collect();
            time = 1;
            string[] names = File.ReadAllLines(".\\AllNames.txt");
            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
            label4.Text = "";
            label6.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            button1.Visible = false;
            buClean.Visible = false;
            string[] name= { names[GetName()] };
            label3.ForeColor = Color.White;
            label3.BackColor = Color.Black;
            if (name[0].Length==3)
            {
                label3.Text = name[0][0] + Environment.NewLine + name[0][1] + Environment.NewLine + name[0][2];
            }
            else
            {
                label3.Text = name[0][0] + Environment.NewLine + name[0][1];
            }
            timer1.Start();
            Judge(name[0], 1, axWindowsMediaPlayer1);
            string[] already = File.ReadAllLines(".\\Already.txt");
            if (!already.Contains<string>(name[0]))
            {
                File.AppendAllLines(".\\Already.txt", name);
            }
        }
        int i = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
           
           
            
        }

        private void buFourTime_Click(object sender, EventArgs e)
        {
            GC.Collect();
            time = 4;
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button1.Visible = false;
            buClean.Visible = false;
            label3.ForeColor = Color.Black;
            label3.BackColor = Color.FromArgb(166, 174, 159);
            string[] names = File.ReadAllLines(".\\AllNames.txt");
            string[] already = File.ReadAllLines(".\\Already.txt");
            if (already.Length >= names.Length - 4)
            {
                label1.Visible= true;
                label1.Text = "已经抽取"+already.Length+"\r\n请重启软件进行下一次抽取";
            }
            string[] name = {"","","",""};
            name[0] = names[GetName()];
            name[1] = names[GetName()];
            name[2] = names[GetName()];
            name[3]= names[GetName()];
            while (already.Contains<string>(name[0]))
            {
                name[0] = names[GetName()];
            }
            while(name[0]==name[1]||already.Contains<string>(name[1]))
            {
                name[1]= names[GetName()];
            }
            while (name[2] == name[1] || name[2] == name[0] || already.Contains<string>(name[2]))
            {
                name[2] = names[GetName()];
            }
            while (name[3]==name[2]||name[3]==name[1]||name[3]==name[0]||already.Contains<string>(name[3]))
            {
                name[3] = names[GetName()];
            }
           // while ((name[0] == name[1] || name[0] == name[2] || name[0] == name[3] || name[1] == name[2] || name[1] == name[3] || name[2] == name[3]) ||(already.Contains<string>(name[0])|| already.Contains<string>(name[1]) || already.Contains<string>(name[2]) || already.Contains<string>(name[3])))
           // {
           //     name[0] = names[GetName()];
           //     name[1] = names[GetName()];
           //     name[2] = names[GetName()];
           //     name[3] = names[GetName()];
           // }
            int GoldOrPurpleorBlue=0;//2 1 0
            for (int i = 0; i < 4; i++)
            {
                if (i == 0) {
                    if (gold.Contains<string>(name[i]))
                    {
                        GoldOrPurpleorBlue = 2;
                        label1.ForeColor = Color.Gold;
                        pictureBox1.BackgroundImage = Image.FromFile(".\\gold.jpg");
                    }
                    else if (purple.Contains<string>(name[i]))
                    {
                        GoldOrPurpleorBlue = 1;
                        label1.ForeColor = Color.Fuchsia;
                        pictureBox1.BackgroundImage = Image.FromFile(".\\purple.jpg");
                    }
                    else
                    {
                        pictureBox1.BackgroundImage = Image.FromFile(".\\blue.jpg");
                    }
                    if (name[i].Length == 3)
                    {
                        label1.Text = name[i][0] + Environment.NewLine + name[i][1] + Environment.NewLine + name[i][2];
                    }
                    else
                    {
                        label1.Text = name[i][0] + Environment.NewLine + name[i][1];
                    }
                };
                if (i == 1) {
                    if (gold.Contains<string>(name[i]))
                    {
                        GoldOrPurpleorBlue = 2;
                        label2.ForeColor = Color.Gold;
                        pictureBox2.BackgroundImage = Image.FromFile(".\\gold.jpg");
                    }
                    else if (purple.Contains<string>(name[i]))
                    {
                        GoldOrPurpleorBlue = 1;
                        label2.ForeColor = Color.Fuchsia;
                        pictureBox2.BackgroundImage = Image.FromFile(".\\purple.jpg");
                    }
                    else
                    {
                        pictureBox2.BackgroundImage = Image.FromFile(".\\blue.jpg");
                    }
                    if (name[i].Length == 3)
                    {
                        label2.Text = name[i][0] + Environment.NewLine + name[i][1] + Environment.NewLine + name[i][2];
                    }
                    else
                    {
                        label2.Text = name[i][0] + Environment.NewLine + name[i][1];
                    }
                };
                if (i == 2) {
                    if (gold.Contains<string>(name[i]))
                    {
                        GoldOrPurpleorBlue = 2;
                        label3.ForeColor = Color.Gold;
                        pictureBox3.BackgroundImage = Image.FromFile(".\\gold.jpg");
                    }
                    else if (purple.Contains<string>(name[i]))
                    {
                        GoldOrPurpleorBlue = 1;
                        label3.ForeColor = Color.Fuchsia;
                        pictureBox3.BackgroundImage = Image.FromFile(".\\purple.jpg");
                    }
                    else
                    {
                        pictureBox3.BackgroundImage = Image.FromFile(".\\blue.jpg");
                    }
                    if (name[i].Length == 3)
                    {
                        label3.Text = name[i][0] + Environment.NewLine + name[i][1] + Environment.NewLine + name[i][2];
                    }
                    else
                    {
                        label3.Text = name[i][0] + Environment.NewLine + name[i][1];
                    }
                     };
                if (i == 3) {
                    if (gold.Contains<string>(name[i]))
                    {
                        GoldOrPurpleorBlue = 2;
                        label4.ForeColor = Color.Gold;
                        pictureBox4.BackgroundImage = Image.FromFile(".\\gold.jpg");
                    }
                    else if (purple.Contains<string>(name[i]))
                    {
                        GoldOrPurpleorBlue = 1;
                        label4.ForeColor =Color.Fuchsia;
                        pictureBox4.BackgroundImage = Image.FromFile(".\\purple.jpg");
                    }
                    else
                    {
                        pictureBox4.BackgroundImage = Image.FromFile(".\\blue.jpg");
                    }
                    if (name[i].Length == 3)
                    {
                        label4.Text = name[i][0] + Environment.NewLine + name[i][1] + Environment.NewLine + name[i][2];
                    }
                    else
                    {
                        label4.Text = name[i][0] + Environment.NewLine + name[i][1];
                    }
                };
            }
            if (GoldOrPurpleorBlue==2)
            {
                TenGold(axWindowsMediaPlayer1);
            }
            else if(GoldOrPurpleorBlue==1)
            {
                TenPurple(axWindowsMediaPlayer1);
            }
            else
            {
                OneBlue(axWindowsMediaPlayer1);
                
            }
            timer1.Start();
            File.AppendAllLines(".\\Already.txt", name);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GC.Collect();
            label5.BackColor = Color.Transparent;
            label4.BackColor = Color.FromArgb(166, 174, 159);
            label1.BackColor = Color.FromArgb(166,174,159);
            label2.BackColor = Color.FromArgb(166,174,159);
            label3.BackColor = Color.FromArgb(166,174,159);
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            string[] lines;
            lines=File.ReadAllLines(".\\Already.txt");
            label6.Text= lines.Length.ToString()+"(点击可以查看记录)";
            int num = File.ReadAllLines(".\\AllNames.txt").Length;
            label5.Text = "单次抽取每人概率为" + "1/"+num +"。四连每"+num+"个无重复。\r\n\r\n另：若动画加载不出来，请重启。每两次抽取中间\r\n至少间隔3秒。\r\n四连已提问人数：\r\n";
            if (lines.Length>=num)
            {
                buClean_Click(null,null);
            }
        }

        private void label5_Click(object sender, EventArgs e){}

        private void timer1_Tick(object sender, EventArgs e)
        {
            GC.Collect();
            if (i < 6)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                pictureBox1.Visible = false;
                pictureBox2.Visible = false;
                pictureBox3.Visible = false;
                pictureBox4.Visible = false;
                axWindowsMediaPlayer1.Visible = true;
                buOneTime.Visible = false;
                buFourTime.Visible = false; i++;
            }
            else
            {
                if (time==4)
                {
                    buFourTime.Visible = true;
                    buOneTime.Visible = true;
                    i = 0;
                    timer1.Enabled = false;
                    label1.Visible = true;
                    pictureBox1.Visible = true;
                    label2.Visible = true;
                    pictureBox2.Visible = true;
                    label3.Visible = true;
                    pictureBox3.Visible = true;
                    label4.Visible = true;
                    pictureBox4.Visible = true;
                }
                else
                {
                    buFourTime.Visible = true;
                    buOneTime.Visible = true;
                    i = 0;
                    timer1.Enabled = false;
                    label2.Visible = false;
                    label1.Visible= false;
                    label3.Visible = true;
                    label4.Visible = false;
                    pictureBox1.Visible = false;
                    pictureBox2.Visible = false;
                    pictureBox3.Visible = false;
                    pictureBox4.Visible = false;
                }
            }
        }

        private void label5_Click_1(object sender, EventArgs e){}

        private void buClean_Click(object sender, EventArgs e)
        {
           
                File.Delete(".\\Already.txt");
                File.WriteAllText(".\\Already.txt", "");
            Application.Restart();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2=new Form2();
            form2.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Windows\\System32\\notepad.exe", ".\\Already.txt");
        }
    }
}
