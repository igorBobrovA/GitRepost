using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _IB_collector
{
    public partial class MAIN : Form
    {
        public MAIN(string User, string Rights)
        {
            InitializeComponent();
            this.User = User; 
            this.Rights = Rights;
        }
        string User, Rights;

        private void MAIN_Load(object sender, EventArgs e)
        {
            if (Rights == "a")
            {
                button1.Visible = true;
            }
            if (User.IndexOf('@') == -1)
                label1.Text = "Добро пожаловать " + User;
            else
                label1.Text = "Добро пожаловать";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form Maze = new Maze();
            Maze.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form Paint = new Paint();
            Paint.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form test = new test();
            test.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form Shop = new Shop();
            Shop.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form Fifteen = new Fifteen();
            Fifteen.Show();
            this.Hide();
        }

        private void MAIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
