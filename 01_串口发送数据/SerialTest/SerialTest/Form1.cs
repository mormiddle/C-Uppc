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
                str = i.ToString("x").ToUpper();
                if (str.Length == 1)
                {
                    str = "0" + str;
                }
                comboBox1.Text = "0X00";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = comboBox1.Text;
            string convertdata = data.Substring(2, 2);
            byte[] buffer = new byte[1];
            buffer[0] = Convert.ToByte(convertdata, 16);
            try
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
