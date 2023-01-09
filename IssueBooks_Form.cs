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
    public partial class IssueBooks_Form : Form
    {
        int count;
        public IssueBooks_Form()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IssueBooks_Form_Load(object sender, EventArgs e)
        {
            SetControlProperty();
        }
        public void SetControlProperty()
        {
            cmbBookName.DropDownStyle = ComboBoxStyle.DropDownList;
            DataSet ds1 = Connection.GetData("Select bName from mst_book");
            if (ds1 != null && ds1.Tables.Count > 0 && ds1.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds1.Tables[0].Rows)
                {
                    cmbBookName.Items.Add(dr["bName"]);
                }
            }
        }

        private void btnSearchStudent_Click(object sender, EventArgs e)
        {
            if (txtEnterEnroll.Text != "")
            {
                String eid = txtEnterEnroll.Text;
                DataSet ds = Connection.GetData("Select * from mst_student where enroll = '" + eid + "' ");

                //***********************************************************//
                //Code to count how many book has been issued on this enrollment //
                DataSet ds1 = Connection.GetData("Select count(std_enroll) from et_issuebook where std_enroll = '" + eid + "' and book_return_date is null ");
                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                //***********************************************************//

                if (ds.Tables[0].Rows.Count != 0)
                {
                    txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDepartment.Text = ds.Tables[0].Rows[0][2].ToString();
                    txtSemester.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    clearAll();
                    MessageBox.Show("Invalid Enrollment No", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
            public void clearAll()
            {
                 txtStudentName.Clear();
                 txtDepartment.Clear();
                 txtSemester.Clear();
                 txtContact.Clear();
                 txtEmail.Clear();
                 cmbBookName.SelectedIndex = -1;
            }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != "")
            {
                if (cmbBookName.SelectedIndex != -1 && count <= 2)
                {
                    String enroll = txtEnterEnroll.Text;
                    String sname = txtStudentName.Text;
                    String sdep = txtDepartment.Text;
                    String sem = txtSemester.Text;
                    String contact = txtContact.Text;
                    String email = txtEmail.Text;
                    String bookname = cmbBookName.Text;
                    String issueDate = dateTimePickerIssue.Text;

                    String error = Connection.SetData("Insert INTO et_issuebook (std_enroll, std_name, std_dep, std_sem, std_contact, std_email, book_name, book_issue_date)"+
                        " Values ('" + enroll + "', '" + sname + "', '" + sdep + "', '" + sem + "', '" + contact + "', '" + email + "', '" + bookname + "', '" + issueDate + "' ) ");
                    if (error == "")
                    {
                        MessageBox.Show("Book Issued.", " Successful..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearAll();
                    }
                    else
                    {
                        MessageBox.Show("Error in Saving : " + error);
                    }


                }
                else
                {
                    MessageBox.Show("Select Book. OR Maximum number of Book Has been ISSUED ", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Enter Valid Enrollement No ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEnterEnroll_TextChanged(object sender, EventArgs e)
        {
            clearAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtEnterEnroll.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
    }

