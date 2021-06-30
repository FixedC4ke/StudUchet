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
    public partial class AddUser : Form
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fullname { get; set; }
        public bool Role { get; set; }
        public Guid GroupOrDisc { get; set; }
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Username = textBox1.Text;
            Password = textBox2.Text;
            Fullname = textBox3.Text;
            Role = comboBox1.SelectedIndex == 0;
            GroupOrDisc = (Guid)comboBox2.SelectedValue;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (comboBox1.SelectedValue == null) return;
            using (DBEntities db = new DBEntities())
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    comboBox2.DataSource = db.Discipline.ToList();
                    comboBox2.DisplayMember = "Name";
                    comboBox2.ValueMember = "ID";
                }
                else if (comboBox1.SelectedIndex == 1)
                {
                    comboBox2.DataSource = db.Groups.ToList();
                    comboBox2.DisplayMember = "Name";
                    comboBox2.ValueMember = "ID";
                }
            }
        }
    }
}
