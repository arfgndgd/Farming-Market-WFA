﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions; //Regex kütüphanesi; güvenli parola ile kullanıcı oluşturur
using System.IO; //Giriş çıkış işlemleri
using ProjectFarmBA_WFA.ModelContext;
using ProjectFarmBA_WFA.DesingPatterns.SingletonPattern;

namespace ProjectFarmBA_WFA
{
    public partial class Form2 : Form
    {
        ProjectFarmBAEntities db;
        public Form2()
        {
            InitializeComponent();
            db = DBTool.DBInstance;
        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");
        //formdan birden fazla istek alacağım zaman multipleActiveResultSets=true eklemek lazım

        private void EmployeeShow()
        {
            try
            {
                connection.Open();
                SqlDataAdapter employeeList = new SqlDataAdapter("select TCNO as [Tc Kimlik No], Password as [Parola], FirstName as [Ad], LastName as [Soyad], ERole as [Yetki], Phone as [Telefon], Address as [Adres], City as [Şehir], DepartmentID as [Departman] from Employees", connection);
                DataSet dataSet = new DataSet();
                employeeList.Fill(dataSet);
                dGVEmployee.DataSource = dataSet.Tables[0];

                cmbDepartment.DataSource = db.Departments.ToList();
                cmbDepartment.DisplayMember = "DepartmentName";

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
            }
        }

        //private void ProductShow()
        //{
        //    try
        //    { //TODO: veriyaratma gibi tarihler yok
        //        connection.Open();
        //        SqlDataAdapter productList = new SqlDataAdapter("select ID , ProductName as [Ürün Adı], UnitPrice as [Fiyat], UnitInStock as [Stok], ImagePath as [Görsel], CategoryID as [Kategori], SupplierID as [Tedarikçi], Features as [Özellikler] from Products", connection);
        //        DataSet dataSet = new DataSet();
        //        productList.Fill(dataSet);
        //        dataGridView2.DataSource = dataSet.Tables[0];
        //        connection.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Farming Market", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        connection.Close();
        //    }
        //}

        private void Form2_Load(object sender, EventArgs e)
        {
            //Çalışan resmini ekleme
            //Form2
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

            //Çalışan İşlemleri Sekmesi
            this.Text = "Çalışan İşlemleri";
            lblEmployee.ForeColor = Color.Green;
            lblEmployee.Text = Login.name + " " + Login.surname;
            txtTcNo.MaxLength = 11;
            txtPhone.MaxLength = 10;
            txtPassword.MaxLength = 3;
            toolTip1.SetToolTip(this.txtTcNo, "TC Kimlik No 11 karakter olmalıdır");
            rdbWorker.Checked = true;
            txtFirstName.CharacterCasing = CharacterCasing.Upper;
            txtLastName.CharacterCasing = CharacterCasing.Upper;
            //TODO: Parola sınırlama 
            //TODO: Departman Ekle 48den önce

            EmployeeShow();

            ////Ürün İşlemleri Sekmesi
            //pctProduct.SizeMode = PictureBoxSizeMode.StretchImage;
            //pctProduct.Width = 100;
            //pctProduct.Height = 100;
            //pctProduct.BorderStyle = BorderStyle.Fixed3D;
            //mtxtProductName.Mask = "LL????????????????????"; //iki karakter zorunlu soru işareti sayısı kadar da limit var
            //mtxtProductName.Text.ToUpper();

        }

        private void txtTcNo_TextChanged(object sender, EventArgs e)
        {
            if (txtTcNo.Text.Length < 11)
            {
                errorProvider1.SetError(txtTcNo, "TC Kimlik No 11 karakter olmalı");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void txtTcNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            //ascıı kodları sayesinde tcno yazarken harf seçilmiyor 0-9 arası serbest
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            //IsLetter = harf, IsControl = back space, ısSeparator = boşluk
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) == true || char.IsControl(e.KeyChar) == true || char.IsSeparator(e.KeyChar) == true)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length != 3)
                errorProvider1.SetError(txtPassword, "Şifre en fazla 3 haneli olmalı");
            else
                errorProvider1.Clear();
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar >= 48 && (int)e.KeyChar <= 57) || (int)e.KeyChar == 8)
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }


        // Çalışan sekme temizleme
        private void CleanEmployeeTabPage()
        {
            txtTcNo.Clear(); txtFirstName.Clear(); txtLastName.Clear(); txtEmail.Clear(); txtPhone.Clear(); txtAddress.Clear(); txtPassword.Clear(); cmbDepartment.SelectedIndex = -1;
        }

        //Product sekmesi
        //private void CleanProductTabPage()
        //{
        //    pctProduct.Image = null; mtxtProductName.Clear(); mtxtUnitPrice.Clear(); mtxtUnitInStock.Clear(); mtxtFeatures.Clear(); cmbSupplier.SelectedIndex = -1; cmbCategory.SelectedIndex = -1;
        //}


        
        

        

        
    }
}