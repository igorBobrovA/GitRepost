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
    public partial class ChandeUserInfo : Form
    {
        public ChandeUserInfo(string id, string l, string p, string E, string r, string BAN_IGNOR)
        {
            InitializeComponent();
            textBox1.Text = l;
            textBox2.Text = p;
            textBox3.Text = E;
            comboBox1.Text = r;
            checkBox1.Checked = Convert.ToBoolean(BAN_IGNOR);
            this.id = id;
        }
        string id;
    }
}
