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
    }
}
