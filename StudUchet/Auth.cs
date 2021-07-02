using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Diagnostics;

namespace StudUchet
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
                string salt;
                SHA256 hashfunc = SHA256.Create();
                var user = db.Users.SingleOrDefault(x => x.Username == textBox1.Text);
                if (user==null)
                {
                    MessageBox.Show("Пользователя с таким именем не существует");
                    return;
                }
                salt = user.ID.ToString();
                string password = Convert.ToBase64String(hashfunc.ComputeHash(Encoding.UTF8.GetBytes(salt + textBox2.Text)));
                if (user.Password!=password)
                {
                    MessageBox.Show("Неверный пароль");
                }
                else
                {
                    this.Hide();
                    new Form1(user.ID, user.Role, user.Fullname).ShowDialog();
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
