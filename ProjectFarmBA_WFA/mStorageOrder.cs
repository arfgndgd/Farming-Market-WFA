using ProjectFarmBA_WFA.DesingPatterns.SingletonPattern;
using ProjectFarmBA_WFA.ModelContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectFarmBA_WFA
{
    public partial class mStorageOrder : Form
    {

        ProjectFarmBAEntities db;

        public mStorageOrder()
        {
            InitializeComponent();
            db = DBTool.DBInstance;

        }

        SqlConnection connection = new SqlConnection("Data Source=LENOVO-PC\\SQLEXPRESS;Initial Catalog=ProjectFarmBA;Integrated Security=True;MultipleActiveResultSets=True");

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            mCustomer customer = new mCustomer();
            customer.ShowDialog();
        }

        private void btnAddStorage_Click(object sender, EventArgs e)
        {
            mStorage storage = new mStorage();
            storage.ShowDialog();
        }
        
        private void OrderShow()
        {
            connection.Open();
            SqlDataAdapter sqlData = new SqlDataAdapter("select * from StorageOrders", connection);
            DataSet dataSet = new DataSet();
            sqlData.Fill(dataSet);
            dGVStorageOrder.DataSource = dataSet.Tables[0];
            connection.Close();
        }

        private void mStorageOrder_Load(object sender, EventArgs e)
        {
            OrderShow();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (txtPhone.Text == "")
            {
                txtFirstName.Text = "";
                txtLastName.Text = "";
                txtEmail.Text = "";
            }

            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Customers where Phone like '" + txtPhone.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                txtFirstName.Text = dataReader["FirstName"].ToString();
                txtLastName.Text = dataReader["LastName"].ToString();
                txtEmail.Text = dataReader["Email"].ToString();

            }
            connection.Close();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                foreach (Control item in grbStorage.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item!=txtTotalWeight)
                        {
                            item.Text = "";
                        }
                    }
                    
                }
            }
            connection.Open();
            SqlCommand selectQuery = new SqlCommand("select * from Storages where ID like '" + txtID.Text + "'", connection);
            SqlDataReader dataReader = selectQuery.ExecuteReader();
            while (dataReader.Read())
            {
                txtStorageName.Text = dataReader["ProductName"].ToString();
                txtUnitPrice.Text = dataReader["UnitInPrice"].ToString();

            }
            connection.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
        }
    }
}
 