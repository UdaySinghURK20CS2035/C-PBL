using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projectbased
{
    public class Expense : Form
    {
        private Label title, l1;
        public TextBox t1;
        private Button Add, display;
        public Expense(string message)
        {
            this.Size = new Size(530, 500);
            this.Text = "Expense Tracker";
            this.ForeColor = Color.Black;
            this.Font = new Font("Arial", 12, FontStyle.Bold);
            title = new Label();
            title.Text = "Expense Tracker";
            title.Size = new Size(250, 30);
            title.Location = new Point(140, 50);


            l1 = new Label();
            l1.Text = "Username";
            l1.Size = new Size(180, 20);
            l1.Location = new Point(40, 100);

            t1 = new TextBox();
            t1.Location = new Point(220, 100);
            t1.Size = new Size(180, 20);
            t1.ForeColor = Color.Blue;
            t1.Font = new Font("Arial", 12, FontStyle.Bold);

            t1.Text = message;  
           

            display = new Button();
            display.Text = "Display";
            display.Location = new Point(115, 200);
            display.Size = new Size(130, 40);
            display.Click += new System.EventHandler(display_click);

            Add = new Button();
            Add.Text = "Add";
            Add.Location = new Point(260, 200);
            Add.Size = new Size(130, 40);
            Add.Click += new System.EventHandler(Add_click);

            //Controls.Add(l1);
            //Controls.Add(t1);
            Controls.Add(title);
            Controls.Add(display);
            Controls.Add(Add);



        }

        public void display_click(object sender, EventArgs e)
        {
            Display display = new Display();
            (new Display()).Show();
        }
        public void Add_click(object sender, EventArgs e)
        {
            (new Add()).Show();

        }
    }
}
