using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintenance.Entities;

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<User> users = new BindingList<User>();

        public Form1()
        {
            InitializeComponent();

            lblFullName.Text = Resource1.FullName; 
            btnAdd.Text = Resource1.Write;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfv = new SaveFileDialog();
            sfv.FileName = "fullname.txt";

            if (sfv.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfv.FileName))
                    sw.WriteLine(txtFullName.Text);
            }
        }
    }
}
