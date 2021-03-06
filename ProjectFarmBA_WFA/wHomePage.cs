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
    public partial class wHomePage : Form
    {
        public wHomePage()
        {
            InitializeComponent();
        }


        private void wHomePage_Load(object sender, EventArgs e)
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

        private void btnPageEmployee_Click(object sender, EventArgs e)
        {
            wEmployee employee = new wEmployee();
            employee.Show();
        }

        private void btnPageProduct_Click(object sender, EventArgs e)
        {
            wProduct product = new wProduct();
            product.Show();
        }

        private void btnPageCategory_Click(object sender, EventArgs e)
        {
            wProductCategory wProductCategory = new wProductCategory();
            wProductCategory.Show();
        }

        private void btnPageDepartment_Click(object sender, EventArgs e)
        {
            wDepartment wDepartment = new wDepartment();
            wDepartment.Show();
        }

        private void btnPageStorage_Click(object sender, EventArgs e)
        {
            wStorage wStorage = new wStorage();
            wStorage.Show();
        }

        private void btnPageStorageCategory_Click(object sender, EventArgs e)
        {
            wStorageCategory wStorageCategory = new wStorageCategory();
            wStorageCategory.Show();
        }

        private void btnPageShipper_Click(object sender, EventArgs e)
        {
            wShipper wShipper = new wShipper();
            wShipper.Show();
        }

        private void btnPageSupplier_Click(object sender, EventArgs e)
        {
            wSupplier wSupplier = new wSupplier();
            wSupplier.Show();
        }

        private void btnBlog_Click(object sender, EventArgs e)
        {
            wBlog blog = new wBlog();
            blog.Show();
        }
    }
}
