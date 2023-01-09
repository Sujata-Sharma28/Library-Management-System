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
    public partial class ReturnBooks_Form : Form
    {
        String bname;
        String bdate;
        Int64 rowid;
        public ReturnBooks_Form()
        {
            InitializeComponent();
        }

        private void ReturnBooks_Form_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            txtEnterEnroll.Clear();
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Select * from et_issuebook where std_enroll = '" + txtEnterEnroll.Text + "' and book_return_date is NULL ");
            if(ds.Tables[0].Rows.Count != 0)
            {
                dgvReturn.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid id or no book Issued", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvReturn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel3.Visible = true;
            if(dgvReturn.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dgvReturn.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dgvReturn.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dgvReturn.Rows[e.RowIndex].Cells[8].Value.ToString();
            }
            txtBookName.Text = bname;
            dateTimePickerIssue.Text = bdate;
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            DataSet ds = Connection.GetData("Update et_issuebook set book_return_date = '" + dateTimePickerReturn.Text + "' where std_enroll = '" + txtEnterEnroll.Text + "' and id = '" + rowid + "' ");
            MessageBox.Show("Return Successfull", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ReturnBooks_Form_Load(this, null);
        }

        private void txtEnterEnroll_TextChanged(object sender, EventArgs e)
        {
            if(txtEnterEnroll.Text == "")
            {
                panel3.Visible = true;
                dgvReturn.DataSource = null;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnterEnroll.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
    }
}
