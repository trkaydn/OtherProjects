using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Northwind
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void RefreshDatagrid()
        {
            this.customersTableAdapter.Fill(this.northwindDataSet.Customers);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDatagrid();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtadress.Text == "" || txtcity.Text == "" || txtcompname.Text == "" || txtcontname.Text == "" || txtconttitle.Text == "" || txtcountry.Text == "" || txtfax.Text == "" || txtid.Text == "" || txtphone.Text == "" || txtpostalcode.Text == "" || txtregion.Text == "")
            {
                MessageBox.Show("Please do not leave blank");
                return;
            }

            try
            {
                SqlClass obj = new SqlClass();
                if (obj.AddCustomer(txtid.Text, txtcompname.Text, txtcontname.Text, txtconttitle.Text, txtadress.Text, txtcity.Text, txtregion.Text, txtpostalcode.Text, txtcountry.Text, txtphone.Text, txtfax.Text))
                    MessageBox.Show("New customer added succesfully.");
                else
                    MessageBox.Show("Sorry, something went wrong");
            }
            catch(Exception)
            {
                MessageBox.Show("This ID already exists");
            }

            RefreshDatagrid();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearch.Enabled = false;
            txtupid.Enabled = false;

            string id = txtupid.Text;
            SqlClass obj = new SqlClass();
            obj.GetCustomer(id);

            List<string> values = obj.GetCustomer(id);
            if (values.Count <= 0)
            {
                MessageBox.Show("This ID not found");
                btnSearch.Enabled = true;
                txtupid.Enabled = true;
                return;
            }
            txtupcompname.Text = values[0];
            txtupcontname.Text = values[1];
            txtupconttitle.Text = values[2];
            txtupcaddress.Text = values[3];
            txtupcity.Text = values[4];
            txtupregion.Text = values[5];
            txtuppostalcode.Text = values[6];
            txtupcountry.Text = values[7];
            txtupphone.Text = values[8];
            txtupfax.Text = values[9];
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtupid.Enabled = true;
            btnSearch.Enabled = true;
            txtupid.Clear();
            txtupcaddress.Clear();
            txtupcity.Clear();
            txtupcompname.Clear();
            txtupcontname.Clear();
            txtupconttitle.Clear();
            txtupcountry.Clear();
            txtupfax.Clear();
            txtupphone.Clear();
            txtuppostalcode.Clear();
            txtupregion.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtupid.Text == "" || txtupcaddress.Text == "" || txtupcity.Text == "" || txtupcompname.Text == "" || txtupcontname.Text == "" || txtupconttitle.Text == "" || txtupcountry.Text == "" || txtupfax.Text == "" || txtupid.Text == "" || txtupphone.Text == "" || txtuppostalcode.Text == "" || txtupregion.Text == "")
            {
                MessageBox.Show("Please do not leave blank");
                return;
            }
            SqlClass obj = new SqlClass();
            if (obj.UpdateCustomer(txtupid.Text, txtupcompname.Text, txtupcontname.Text, txtupconttitle.Text, txtupcaddress.Text, txtupcity.Text, txtupregion.Text, txtuppostalcode.Text, txtupcountry.Text, txtupphone.Text, txtupfax.Text))
                MessageBox.Show("Customer updated succesfully.");
            else
                MessageBox.Show("Sorry, something went wrong");

            RefreshDatagrid();

        }

        private void btndelclear_Click(object sender, EventArgs e)
        {
            txtdelid.Enabled = true;
            btndelsearch.Enabled = true;
            txtdelid.Clear();
            txtdeladdress.Clear();
            txtdelcity.Clear();
            txtdelcompname.Clear();
            txtdelcontname.Clear();
            txtdelconttitle.Clear();
            txtdelcountry.Clear();
            txtdelfax.Clear();
            txtdelphone.Clear();
            txtdelpostalcode.Clear();
            txtdelregion.Clear();
        }

        private void btndelsearch_Click(object sender, EventArgs e)
        {
            btndelsearch.Enabled = false;
            txtdelid.Enabled = false;

            string id = txtdelid.Text;
            SqlClass obj = new SqlClass();
            obj.GetCustomer(id);
            List<string> values = obj.GetCustomer(id);
            if (values.Count <= 0)
            {
                MessageBox.Show("This ID not found");
                btndelsearch.Enabled = true;
                txtdelid.Enabled = true;
                return;
            }
            txtdelcompname.Text = values[0];
            txtdelcontname.Text = values[1];
            txtdelconttitle.Text = values[2];
            txtdeladdress.Text = values[3];
            txtdelcity.Text = values[4];
            txtdelregion.Text = values[5];
            txtdelpostalcode.Text = values[6];
            txtdelcountry.Text = values[7];
            txtdelphone.Text = values[8];
            txtdelfax.Text = values[9];
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = txtdelid.Text;
                SqlClass obj = new SqlClass();
                if (obj.DeleteCustomer(id))
                {
                    MessageBox.Show("Customer deleted succesfully.");
                    btndelclear.PerformClick();
                }
                else
                    MessageBox.Show("Sorry, something went wrong");
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            RefreshDatagrid();

        }
    }
}
