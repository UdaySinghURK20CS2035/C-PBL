using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace projectbased
{
    public class Add : Form
    {
        public static Add instance;
        public Label l1, l2, l3, l4, title;
        public Label lab1;
        public TextBox t1, t2, t3, t4;
        public TextBox textbox;
        private Button btn;



        public Add()
        {
            instance = this;

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
            l1.Text = "Description";
            l1.Size = new Size(180, 20);
            l1.Location = new Point(40, 60);

            t1 = new TextBox();
            t1.Location = new Point(220, 60);
            t1.Size = new Size(180, 20);
            t1.ForeColor = Color.Blue;
            t1.Font = new Font("Arial", 12, FontStyle.Bold);

            l2 = new Label();
            l2.Text = "Amount";
            l2.Size = new Size(180, 20);
            l2.Location = new Point(40, 90);

            t2 = new TextBox();
            t2.Location = new Point(220, 90);
            t2.Size = new Size(180, 20);
            t2.ForeColor = Color.Blue;
            t2.Font = new Font("Arial", 12, FontStyle.Bold);

            //l3 = new Label();
            //l3.Text = "Date";
            //l3.Size = new Size(180, 20);
            //l3.Location = new Point(40, 120);

            //t3 = new TextBox();
            //t3.Location = new Point(220, 120);
            //t3.Size = new Size(180, 20);
            //t3.ForeColor = Color.Blue;
            //t3.Font = new Font("Arial", 12, FontStyle.Bold);

            l4 = new Label();
            l4.Text = "Name";
            l4.Size = new Size(180, 20);
            l4.Location = new Point(40, 120);

            t4 = new TextBox();
            t4.Location = new Point(220, 120);
            t4.Size = new Size(180, 20);
            t4.ForeColor = Color.Blue;
            t4.Font = new Font("Arial", 12, FontStyle.Bold);



            btn = new Button();
            btn.Text = "Add";
            btn.Location = new Point(220, 180);
            btn.Size = new Size(180, 40);
            btn.Click += new System.EventHandler(btn_Click);

            Controls.Add(title);
            Controls.Add(l1);
            Controls.Add(t1);
            Controls.Add(l2);
            Controls.Add(t2);
            //Controls.Add(l3);
            //Controls.Add(t3);
            Controls.Add(l4);
            Controls.Add(t4);
            Controls.Add(btn);

        }


        public void btn_Click(object sender, EventArgs e)
        {
            try
            {


                //database connection parameters
                string dbconstring =
                "server=localhost;database=expenseusers;uid=root;pwd=\"\";";
                //create database connection and open
                MySqlConnection conn = new MySqlConnection(dbconstring);
                conn.Open();


                string name = t4.Text;
                string desc = t1.Text;
                string amount = t2.Text;
                string date = DateTime.Now.ToString("MM/dd/yyyy");

                string sql = "insert into expenses values(@data1, @data2, @data3, @data4)";
                MySqlCommand command = new MySqlCommand(sql, conn);
                command.Parameters.AddWithValue("@data1", name);
                command.Parameters.AddWithValue("@data2", desc);
                command.Parameters.AddWithValue("@data3", amount);
                command.Parameters.AddWithValue("@data4", date);
                command.ExecuteNonQuery();
                DialogResult res = MessageBox.Show("Data Added Successfully !", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    this.Close();
                    //Some task…
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
