using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace sudokuplay
{
    public partial class sudokuplay : Form
    {
        public static ArrayList textbaby = new ArrayList();
        public sudokuplay()
        {
            InitializeComponent();
        }

        private void sudokuplay_Load(object sender, EventArgs e)
        {
            textbaby.Add(textBox11);
            textbaby.Add(textBox12);
            textbaby.Add(textBox13);
            textbaby.Add(textBox14);
            textbaby.Add(textBox15);
            textbaby.Add(textBox16);
            textbaby.Add(textBox17);
            textbaby.Add(textBox18);
            textbaby.Add(textBox19);
            textbaby.Add(textBox21);
            textbaby.Add(textBox22);
            textbaby.Add(textBox23);
            textbaby.Add(textBox24);
            textbaby.Add(textBox25);
            textbaby.Add(textBox26);
            textbaby.Add(textBox27);
            textbaby.Add(textBox28);
            textbaby.Add(textBox29);
            textbaby.Add(textBox31);
            textbaby.Add(textBox32);
            textbaby.Add(textBox33);
            textbaby.Add(textBox34);
            textbaby.Add(textBox35);
            textbaby.Add(textBox36);
            textbaby.Add(textBox37);
            textbaby.Add(textBox38);
            textbaby.Add(textBox39);
            textbaby.Add(textBox41);
            textbaby.Add(textBox42);
            textbaby.Add(textBox43);
            textbaby.Add(textBox44);
            textbaby.Add(textBox45);
            textbaby.Add(textBox46);
            textbaby.Add(textBox47);
            textbaby.Add(textBox48);
            textbaby.Add(textBox49);
            textbaby.Add(textBox51);
            textbaby.Add(textBox52);
            textbaby.Add(textBox53);
            textbaby.Add(textBox54);
            textbaby.Add(textBox55);
            textbaby.Add(textBox56);
            textbaby.Add(textBox57);
            textbaby.Add(textBox58);
            textbaby.Add(textBox59);
            textbaby.Add(textBox61);
            textbaby.Add(textBox62);
            textbaby.Add(textBox63);
            textbaby.Add(textBox64);
            textbaby.Add(textBox65);
            textbaby.Add(textBox66);
            textbaby.Add(textBox67);
            textbaby.Add(textBox68);
            textbaby.Add(textBox69);
            textbaby.Add(textBox71);
            textbaby.Add(textBox72);
            textbaby.Add(textBox73);
            textbaby.Add(textBox74);
            textbaby.Add(textBox75);
            textbaby.Add(textBox76);
            textbaby.Add(textBox77);
            textbaby.Add(textBox78);
            textbaby.Add(textBox79);
            textbaby.Add(textBox81);
            textbaby.Add(textBox82);
            textbaby.Add(textBox83);
            textbaby.Add(textBox84);
            textbaby.Add(textBox85);
            textbaby.Add(textBox86);
            textbaby.Add(textBox87);
            textbaby.Add(textBox88);
            textbaby.Add(textBox89);
            textbaby.Add(textBox91);
            textbaby.Add(textBox92);
            textbaby.Add(textBox93);
            textbaby.Add(textBox94);
            textbaby.Add(textBox95);
            textbaby.Add(textBox96);
            textbaby.Add(textBox97);
            textbaby.Add(textBox98);
            textbaby.Add(textBox99);
        }

        public static int count = 0;
        static void FillGrid()
        { //从文件中读取数独题目
            StreamReader sr = new StreamReader(@"sudokuQuestions_1000.txt");
            for(int i = 0;i < 10 * count ; i++)
            {
                string lineadd = sr.ReadLine();
            }
            for (int i=0;i<9;i++)  
            {
                string line = sr.ReadLine();
                for(int k=0;k<9;k++)
                {
                    TextBox t = textbaby[i * 9 + k] as TextBox;
                    t.BackColor = Color.PaleGoldenrod;
                    if (line[2*k]=='0')
                    {
                        t.Text = "";
                        t.ForeColor = Color.DarkBlue;
                        t.ReadOnly = false;
                    }
                    else
                    {
                        t.Text = line[2 * k].ToString();
                        t.ForeColor = Color.Brown;
                        t.ReadOnly = true;
                    }
                }
                count++;
            }
        }

        static void Submit_Click()
        { //将每一次输入的信息存入boss字符数组中
            string[] boss;
            boss = new string[10];
            for (int i = 0; i < 9; i++)
            {
                boss[i] = "";
                for (int k = 0; k < 9; k++)
                {
                    TextBox t = textbaby[i * 9 + k] as TextBox;
                    if (t.Text == "")
                    {
                        MessageBox.Show("你还没有作答完成喔！", "提示");
                        return;
                    }
                    else boss[i] += t.Text;
                }
            }
            int[] check_row = { 0, 3, 6, 27, 30, 33, 54, 57, 60 };
            int[] check_plus = { 0, 1, 2, 9, 10, 11, 18, 19, 20 };
            for (int i = 0; i < 9; i++)
            {//检查输入的数独是否合法
                int[] ROW = new int[10]; //每一行计数
                int[] COL = new int[10]; //每一列计数
                int[] THREE = new int[10]; //每一个3x3的格子计数
                for (int j = 0; j < 9; j++)
                {//初始化计数为0
                    ROW[j] = 0;
                    COL[j] = 0;
                    THREE[j] = 0;
                }
                for (int j = 0; j < 9; j++)//记录数字出现次数
                {
                    ROW[boss[i][j] - '0']++;
                    COL[boss[j][i] - '0']++;
                    int a1 = (check_row[i] + check_plus[j]) / 9;
                    int a2 = (check_row[i] + check_plus[j]) % 9;
                    THREE[boss[a1][a2] - '0']++;
                }
                for (int j = 1; j <= 9; j++)
                {
                    if (ROW[j] != 1 || COL[j] != 1 || THREE[j] != 1)
                    { //如果某一个数字在某行、某列或某个3x3方格中没有出现或出现了不止一次，就报错~
                        MessageBox.Show("你做错了喔！", "提示");
                        return;
                    }
                }
                MessageBox.Show("你是真滴厉害，做对了喔！", "提示");
            }
        }
 
        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {//开始游戏按钮
            FillGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {//下一题按钮
            FillGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {//提交按钮
            Submit_Click();
        }
    }
}
