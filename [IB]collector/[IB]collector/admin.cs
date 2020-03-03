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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form back = Application.OpenForms[1];
            back.Show();
        }

        private void admin_Load(object sender, EventArgs e)
        {
            List<string> users = new List<string>();
            SQLiteConnection con = new SQLiteConnection(@"DataSource=Users/Users_info.db;Version=3;");
            SQLiteCommand cmd = new SQLiteCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "Select * " +
                              "From Users " +
                              "";
            SQLiteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                dataGridView1.Rows.Add();
                users.Add(reader.GetValue(0) + "," + 
                          reader.GetValue(1) + "," + 
                          reader.GetValue(2) + "," + 
                          reader.GetValue(3) + "," + 
                          reader.GetValue(4) + "," + 
                          reader.GetValue(5));
            }
            cmd.Reset();
            con.Close();
            for (int i = 0; i < users.Count; i++)
            {
                string[] NoMassive = users[i].Split(',');
                for (int j = 0; j < 6; j++)
                {
                    dataGridView1[j, i].Value = NoMassive[j];
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewRow dgvr = dataGridView1.CurrentRow;

            Form GoToCUI = new ChandeUserInfo(dgvr.Cells[0].Value.ToString(), 
                                              dgvr.Cells[1].Value.ToString(),
                                              dgvr.Cells[2].Value.ToString(),
                                              dgvr.Cells[3].Value.ToString(),
                                              dgvr.Cells[4].Value.ToString(),
                                              dgvr.Cells[5].Value.ToString());
            GoToCUI.Show();
        }
    }
}
