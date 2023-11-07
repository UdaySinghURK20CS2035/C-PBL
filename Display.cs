using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projectbased
{
    public class Display : Form
    {
        public string username;
        private Label l1, l2, title;
        private TextBox t1, t2;
        private Button btn;
        private DataGridView dataGridView1;

        public Display()
        {
            this.Size = new Size(500, 400);
            this.Text = "Expense Tracker";
            this.ForeColor = Color.Blue;
            this.Font = new Font("Arial", 12, FontStyle.Bold);
            title = new Label();
            title.Text = "Expense Tracker";
            title.Size = new Size(250, 30);
            title.ForeColor = Color.Black;
            title.Location = new Point(140, 20);

            l1 = new Label();
            l1.Text = "Username";
            l1.Size = new Size(180, 20);
            l1.Location = new Point(40, 60);

            t1 = new TextBox();
            t1.Location = new Point(220, 60);
            t1.Size = new Size(180, 20);
            t1.ForeColor = Color.Blue;
            t1.Font = new Font("Arial", 12, FontStyle.Bold);

            l2 = new Label();
            l2.Size = new Size(400, 20);
            l2.Location = new Point(40, 100);

            dataGridView1 = new DataGridView();
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new System.Drawing.Point(20, 50); // Set initial location
            


            


            //Controls.Add(title);
            //Controls.Add(btn);
            //Controls.Add(l1);
            //Controls.Add(t1);
            Controls.Add(dataGridView1);

            //MessageBox.Show(username);

            string dbconstring = "server=localhost;database=expenseusers;uid=root;pwd=\"\";";
            //create database connection and open

            string query = "SELECT * FROM expenses WHERE Username = \"Uday@1\""; // Replace with your table name

            using (MySqlConnection connection = new MySqlConnection(dbconstring))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dataTable;
                    }
                }
            }


        }

        public void setlabeltext(string text)
        {
            username = text;
        }
       
    }
}
