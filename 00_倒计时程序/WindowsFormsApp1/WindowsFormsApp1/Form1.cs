using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int count = 0;//定义变量存储当前计算的时间
        int time = 0;//定义需要定时的总时间
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)//设定1-99的定时范围
            {
                comboBox1.Items.Add(i.ToString() + " 秒");//初始化下拉框列表

            }
        }

        private void timer1_Tick(object sender, EventArgs e)//设定定时器时间
        {
            count++;//每过一秒，计时加一
            label3.Text = (time - count).ToString() + "秒";//设置剩余时间
            progressBar1.Value = count;//设置进度条
            if (count == time)//设置结束条件
            {
                timer1.Stop();
                System.Media.SystemSounds.Asterisk.Play();//设置接受提示音
                MessageBox.Show("时间到了！", "提示");//设置结束提示弹窗
            }
        }

        private void button1_Click(object sender, EventArgs e)//设置按钮点击事件
        {
            string str = comboBox1.Text;//设置变量存储下拉框里面选择的内容
            time = Convert.ToInt32(str.Substring(0, 2));//将下拉框中的内容，从0开始的2位，转化为整数型
            progressBar1.Maximum = time;//设置下拉框最大值
            timer1.Start();//定时器开始

        }
    }
}
