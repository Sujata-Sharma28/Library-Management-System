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
    public partial class AddBooks_Form : Form
    {
        public AddBooks_Form()
        {
            InitializeComponent();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtAuthor.Text != "" && txtPublication.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {
                String bname = txtName.Text;
                String bAuthor = txtAuthor.Text;
                String publication = txtPublication.Text;
                String pdate = dateTimePickerpurchase.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quan = Int64.Parse(txtQuantity.Text);

                String error = Connection.SetData("Insert Into mst_book (bName, bAuthor, bPubl, bDate, bPrice, bQuan) Values " +
                    "('" + bname + "', '" + bAuthor + "', '" + publication + "', '" + pdate + "', " + price + ", " + quan + " )");
                if (error == "")
                {
                    MessageBox.Show("Data Saved.", " Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearAll();
                }
                else
                {
                    MessageBox.Show("Error in Saving : " + error);
                }
            }
            else
            {
                MessageBox.Show("Empty Field Not Allowed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will DELETE your UNSAVED DATA", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
        public void clearAll()
        {
            txtName.Clear();
            txtAuthor.Clear();
            txtPublication.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
