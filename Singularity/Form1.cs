using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Singularity
{
    public partial class MainWindow : Form
    {
        String[] args;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Input_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void go_Click(object sender, EventArgs e)
        {
            args = Input.Text.Split(' ');
            ThreadPool.QueueUserWorkItem(state => Launch.Run(args));
            //Launch.Run(args);
            Input.Text = "What's next?";
        }

        private void exit_Click(object sender, EventArgs e)
        {
            //Input.Text = "See you around.";
            //System.Threading.Thread.Sleep(1000);
            this.Close();
        }

        private void logo_Click(object sender, EventArgs e)
        {
            Input.Text = "Hello!";
        }
    }
}
