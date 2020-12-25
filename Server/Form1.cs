using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Service;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ServiceHost hostobjek = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            btOn.Enabled = true;
            btOff.Enabled = false;
            textBoxStatus.Enabled = false;
            textBoxStatus.Text = "Server mati...";
        }

        private void btOn_Click(object sender, EventArgs e)
        {
            hostobjek = new ServiceHost(typeof(Service1));
            hostobjek.Open();
            textBoxStatus.Text = "Server ready...";
            hostobjek.Close();

            btOff.Enabled = true;
            btOn.Enabled = false;
        }

        private void btOff_Click(object sender, EventArgs e)
        {
            hostobjek = null;
            textBoxStatus.Text = "Server mati...";

            btOff.Enabled = false;
            btOn.Enabled = true;
        }
    }
}
