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
    public partial class AddActivity : Form
    {
        public string ActName { get; set; }
        public string Description { get; set;}
        public int Cost { get; set; }
        public AddActivity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActName = textBox1.Text;
            Description = richTextBox1.Text;
            Cost = Int32.Parse(textBox3.Text);
        }
    }
}
