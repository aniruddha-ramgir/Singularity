using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Singularity
{
    public partial class Dialog : Form
    {
        public Dialog(string operation,string quote)
        {
            InitializeComponent();
            text.Text = "Are you sure you want to " + operation + " " + quote;
        }

        private void text_Click(object sender, EventArgs e)
        {

        }

        private void YES_Click(object sender, EventArgs e)
        {
            //return 1;
            //Launch.answer = 1;
            this.Close();
        }

        private void NO_Click(object sender, EventArgs e)
        {
            //Launch.answer = 0;
            this.Close();
        }
    }
}
