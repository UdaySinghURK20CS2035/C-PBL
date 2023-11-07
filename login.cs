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
    public class login : Form
    {

        private Label l1, l2, title;
        public TextBox t1, t2;
        private Button btn;
        public string username;



        public login()
        {
            this.Size = new Size(500, 400);
            this.Text = "Sign In";
            this.ForeColor = Color.Blue;
            this.Font = new Font("Arial", 12, FontStyle.Bold);

            title = new Label();
            title.Text = "Sign In";
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
            l2.Text = "Password";
            l2.Size = new Size(180, 20);
            l2.Location = new Point(40, 90);

            t2 = new TextBox();
            t2.Location = new Point(220, 90);
            t2.Size = new Size(180, 20);
            t2.ForeColor = Color.Blue;
            t2.Font = new Font("Arial", 12, FontStyle.Bold);



            btn = new Button();
            btn.Text = "Login";
            btn.Location = new Point(220, 180);
            btn.Size = new Size(180, 40);
            btn.Click += new System.EventHandler(loginbtn_Click);

            Controls.Add(title);
            Controls.Add(l1);
            Controls.Add(t1);
            Controls.Add(l2);
            Controls.Add(t2);
            Controls.Add(btn);

        }

        public void loginbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(t1.Text) || string.IsNullOrEmpty(t2.Text))
            {
                MessageBox.Show("Please Enter username and password","Empty Fields",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    //database connection parameters
                    string dbconstring =
                    "server=localhost;database=expenseusers;uid=root;pwd=\"\";";
                    //create database connection and open
                    MySqlConnection conn = new MySqlConnection(dbconstring);
                    conn.Open();


                    username = t1.Text;
                    string password = t2.Text;

                    string sql = "select Password from users where Username = @data1;";
                    MySqlCommand command = new MySqlCommand(sql, conn);
                    command.Parameters.AddWithValue("@data1", username);

                    var password_db = command.ExecuteScalar().ToString();
                    if (password_db.Equals(password))
                    {
                        DialogResult res1 = MessageBox.Show("Login Sucessfull !",
                            "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (res1 == DialogResult.OK)
                        {
                            this.Close();
                            
                        }
                    }
                    else
                    {
                        DialogResult res = MessageBox.Show("Login Failed !", "Confirmation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (res == DialogResult.OK)
                        {
                            this.Close();
                            //Some task…
                        }

                    }
                    conn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Expense expense = new Expense(t1.Text);
                expense.Show();
            }
        }
        public string myuser()
        {
            return username;
        }
    }
}
