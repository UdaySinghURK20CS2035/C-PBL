using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectbased
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Landing());
        }
    }

    public class Landing : Form
    {
        private Label title;
        private Button login, singup;
        public Landing()
        {
            this.Size = new Size(530, 500);
            this.Text = "Expense Tracker";
            this.ForeColor = Color.Black;
            this.Font = new Font("Arial", 12, FontStyle.Bold);

            title = new Label();
            title.Text = "Expense Tracker";
            title.Size = new Size(250, 30);
            title.Location = new Point(140, 50);

            login = new Button();
            login.Text = "Login";
            login.Location = new Point(115, 120);
            login.Size = new Size(130, 40);
            login.Click += new System.EventHandler(login_click);

            singup = new Button();
            singup.Text = "Sign Up";
            singup.Location = new Point(260, 120);
            singup.Size = new Size(130, 40);
            singup.Click += new System.EventHandler(signup_click);

            Controls.Add(title);
            Controls.Add(login);
            Controls.Add(singup);

        }
        public void login_click(object sender, EventArgs e)
        {
            (new login()).Show();
        }
        public void signup_click(object sender, EventArgs e)
        {
            (new Signup()).Show();

        }
    }
}
