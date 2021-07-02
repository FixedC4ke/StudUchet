using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudUchet
{
    public partial class SimpleAdd : Form
    {
        public string Value { get; set; }
        private string tag;
        public SimpleAdd(string tag)
        {
            this.tag = tag;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Value = textBox1.Text;
        }

        private void SimpleAdd_Load(object sender, EventArgs e)
        {
            label1.Text += tag + ":";
        }
    }
}
