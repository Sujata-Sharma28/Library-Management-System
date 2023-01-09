using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_Syatem
{
    public partial class ViewBooks_Form : Form
    {
        int id;
        Int64 rowid;
        public ViewBooks_Form()
        {
            InitializeComponent();
        }
        private void ViewBooks_Form_Load(object sender, EventArgs e)
        {
            panel2.Visible = true;
            DataSet ds = Connection.GetData("Select * from mst_book");
            dgvViewBooks.DataSource = ds.Tables[0];
        }

        private void dgvViewBooks_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvViewBooks.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                id = int.Parse(dgvViewBooks.Rows[e.RowIndex].Cells[0].Value.ToString());
                {
                    //MessageBox.Show(DataGridViewBook.Rows[e.RowIndex].Cells.[0].Value.ToString());
                }
                panel2.Visible = true;
                DataSet ds = Connection.GetData("Select * from mst_book where id= " + id + "");

                rowid = (Int64.Parse(ds.Tables[0].Rows[0][0].ToString()));
                txtName.Text = ds.Tables[0].Rows[0][1].ToString();
                txtAuthor.Text = ds.Tables[0].Rows[0][2].ToString();
                txtPublication.Text = ds.Tables[0].Rows[0][3].ToString();
                txtPurchase.Text = ds.Tables[0].Rows[0][4].ToString();
                txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
                txtQuantity.Text = ds.Tables[0].Rows[0][6].ToString();

            }

        }
       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {
                DataSet ds = Connection.GetData("Select * from mst_book where bName LIKE'" + txtBookName.Text + "%'");
                dgvViewBooks.DataSource = ds.Tables[0];
            }
            else
            {
                DataSet ds = Connection.GetData("Select * from mst_book");
                dgvViewBooks.DataSource = ds.Tables[0];

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data Will Be Updated. Confirm", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                String bname = txtName.Text;
                String bAuthor = txtAuthor.Text;
                String publication = txtPublication.Text;
                String pdate = txtPurchase.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);


                String error = Connection.SetData("Update mst_book set bName = '" + bname + "', bAuthor = '" + bAuthor + "', " +
                    " bPubl ='" + publication + "' , bDate = '" + pdate + "' , bPrice = " + price + ",  bQuan =  " + quan + " where id= " + rowid + " ");
                if (error == "")
                {
                    MessageBox.Show("Data Saved.", " Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error in Saving : " + error);
                }

            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Deleted. Confirm", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {

                String error = Connection.SetData("Delete from mst_book where id= '" + rowid + "' ");
                if (error == "")
                {
                    MessageBox.Show("Employee Record Deleted..");

                }
                else
                {
                    MessageBox.Show("Error is Delete Messgae.." + error);
                }

            }
        }

        private void dgvViewBooks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
