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
    public partial class Fifteen : Form
    {
        public Fifteen()
        {
            InitializeComponent();
        }

        public void WIN()
        {
            int x = 10,
                y = 10,
                labelCount = 1;
            bool IsWon = true;
            for (int i = 0; i < 4; i++)
            {
                for (int a = 0; a < 4; a++)
                {
                    Label lb = Controls["label" + labelCount] as Label;
                    if (lb.Location.X != x || lb.Location.Y != y)
                    {
                        IsWon = false;
                    }
                    x += 60;
                    labelCount++;
                }
                x = 10;
                y += 60;
            }
            if (IsWon == true)
            {
                DialogResult res = MessageBox.Show("You Win\nRestart game?", "Congratilations", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (res == DialogResult.Yes)
                {

                }
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            Label label = sender as Label;
            //MessageBox.Show(label.Name);
            int ibX = label.Location.X,
                ibY = label.Location.Y;
            if (label16.Location.X== ibX + 60 && label16.Location.Y == ibY )
            {
                label.Location = new Point(ibX + 60, ibY);
                label16.Location = new Point(ibX, ibY);
            }
            if (label16.Location.X == ibX && label16.Location.Y == ibY + 60)
            {
                label.Location = new Point(ibX, ibY + 60);
                label16.Location = new Point(ibX, ibY);
            }
            if (label16.Location.X == ibX - 60 && label16.Location.Y == ibY)
            {
                label.Location = new Point(ibX - 60, ibY);
                label16.Location = new Point(ibX, ibY);
            }
            if (label16.Location.X == ibX && label16.Location.Y == ibY - 60)
            {
                label.Location = new Point(ibX, ibY - 60);
                label16.Location = new Point(ibX, ibY);
            }
            WIN();
        }

        private void Fifteen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>() 
            {
             "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16"
            };
        }
    }
}
