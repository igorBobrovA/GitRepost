using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection(@"DataSource=Users/Users_info.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "UPDATE Users " +
                              "SET login = '" + textBox1.Text + "', " +
                              "password = '" + textBox2.Text + "', " +
                              "email = '" + textBox3.Text + "', " +
                              "rights = '" + comboBox1.Text +"', " +
                              "ban = '" + checkBox1.Checked + "' " +
                              "WHERE id = " + id;
            cmd.ExecuteNonQuery();
            cmd.Reset();
            con.Close();
        }
    }
}
