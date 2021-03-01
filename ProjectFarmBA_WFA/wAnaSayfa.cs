using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFarmBA_WFA
{
    public partial class wAnaSayfa : Form
    {
        public wAnaSayfa()
        {
            InitializeComponent();
        }

        private void wAnaSayfa_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme
            pctEmployee.Height = 150;
            pctEmployee.Width = 150;
            pctEmployee.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\" + Login.tcno + ".jpg");
            }
            catch
            {
                pctEmployee.Image = Image.FromFile(Application.StartupPath + "\\ImageEmployee\\resimyok.jpg");
            }
            this.Text = "Çalışan İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wForm2 wForm2 = new wForm2();
            wForm2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wForm3 wForm3 = new wForm3();
            wForm3.Show();
        }
    }
}
