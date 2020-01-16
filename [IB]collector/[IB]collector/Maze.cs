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
    public partial class Maze : Form
    {
        public Maze()
        {
            InitializeComponent();
        }

        private void Maze_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }

        private void Maze_Load(object sender, EventArgs e)
        {
            Cursor.Position = new Point(this.Location.X + 770, this.Location.Y + 510);
        }

        private void MouseEnterLb(object sender, EventArgs e)
        {
            Cursor.Position = new Point(this.Location.X + 770, this.Location.Y + 510);
        }

        private void finish_MouseEnter(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы прошли лабиринт\n хотите начать новую игру", "Поздравляю", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (res == DialogResult.Yes)
                Cursor.Position = new Point(this.Location.X + 770, this.Location.Y + 510);
            else this.Close();
        }
    }
}
