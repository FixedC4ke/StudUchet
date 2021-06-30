using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Megalaba3
{
    public partial class Auth : Form
    {
        public Auth()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (DBEntities db = new DBEntities())
            {
                var users = db.Users.Where(x => x.Username == textBox1.Text && x.Password == textBox2.Text).ToList();
                if (users.Count==0)
                {
                    MessageBox.Show("Неверный логин и/или пароль");
                }
                else
                {
                    this.Hide();
                    new Form1(users[0].ID, users[0].Role, users[0].Fullname).ShowDialog();
                    this.Show();
                }
            }
        }

        private void Auth_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }
    }
}
