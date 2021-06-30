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
    public partial class AddRequest : Form
    {
        public string ActivityName { get; set; }
        public int ActivityCost { get; set; }
        public AddRequest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ActivityName = textBox1.Text;
            ActivityCost = Int32.Parse(textBox2.Text);
        }
    }
}
