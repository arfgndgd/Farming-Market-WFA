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
    public partial class mHomePage : Form
    {
        public mHomePage()
        {
            InitializeComponent();
        }

        private void mHomePage_Load(object sender, EventArgs e)
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

        private void btnPageProduct_Click(object sender, EventArgs e)
        {
            mProduct product = new mProduct();
            product.Show();
        }

        private void btnPageEmployee_Click(object sender, EventArgs e)
        {
            mEmployee employee = new mEmployee();
            employee.Show();
        }

        private void btnPageCategory_Click(object sender, EventArgs e)
        {
            mProductCategory productCategory = new mProductCategory();
            productCategory.Show();
        }

        private void btnPageDepartment_Click(object sender, EventArgs e)
        {
            mDepartment department = new mDepartment();
            department.Show();
        }

        private void btnPageShipper_Click(object sender, EventArgs e)
        {
            mShipper shipper = new mShipper();
            shipper.Show();
        }

        private void btnPageStorageCategory_Click(object sender, EventArgs e)
        {
            mStorageCategory storageCategory = new mStorageCategory();
            storageCategory.Show();
        }

        private void btnPageSupplier_Click(object sender, EventArgs e)
        {
            mSupplier supplier = new mSupplier();
            supplier.Show();
        }

        private void btnPageStorage_Click(object sender, EventArgs e)
        {
            mStorage storage = new mStorage();
            storage.Show();
        }

        private void btnBlog_Click(object sender, EventArgs e)
        {
            mBlog blog = new mBlog();
            blog.Show();
        }
    }
}
