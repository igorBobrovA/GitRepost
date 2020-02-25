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
    public partial class DB : Form
    {
        public DB()
        {
            InitializeComponent();
        }

        private void DB_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }
        SQLiteConnection Connection = new SQLiteConnection(@"DataSource=Аэропорт.db;Version=3;");
        SQLiteCommand Command = new SQLiteCommand();
        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            Command.Connection = Connection;
            Connection.Open();
            Command.CommandText = "SELECT *" +
                                 " FROM СОТРУДНИКИ";
            SQLiteDataReader reader = Command.ExecuteReader();
            while (reader.Read())
            {
                richTextBox1.Text += reader.GetValue(0) + " " + reader.GetValue(1) + " " + reader.GetValue(2) + " " + reader.GetValue(3) + "\n";
            }
            Command.Reset();
            Connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            Command.Connection = Connection;
            Connection.Open();
            Command.CommandText = "Select count(*)" +
                                 " From ПАССАЖИРЫ";
            richTextBox1.Text += Command.ExecuteScalar();
            Command.Reset();
            Connection.Close();
        }
    }
}
