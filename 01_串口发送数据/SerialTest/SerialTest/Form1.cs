using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SerialTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//窗口创建初始化函数
        {
            string str;//用来临时存储i大写的十六进制格式字符串
            for (int i = 0; i < 256; i++)
            {
                str = i.ToString("x").ToUpper();//ToString是转化为16进制，ToUpper是把字母变成大写
                if (str.Length == 1)//如果16进制只有一位，比如A,B，加一个0
                {
                    str = "0" + str;
                }
                comboBox1.Text = "0X00";//初始化
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = comboBox1.Text;//缓存区，用于存放选中的数据
            string convertdata = data.Substring(2, 2);//舍弃0X，只保留后面的有效位
            byte[] buffer = new byte[1];//byte类型，c#中向单片机发送数据的类型
            buffer[0] = Convert.ToByte(convertdata, 16);//16进制转化为byte
            try//异常，如果try下面的内容出差，直接跳转到catch中
            {
                serialPort1.Open();
                serialPort1.Write(buffer, 0, 1);
                serialPort1.Close();
            }
            catch 
            {
                if (serialPort1.IsOpen)
                {
                    serialPort1.Close();
                }
                MessageBox.Show("端口错误", "错误");
            }
        }
    }
}
