using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DataSaveUsingXML
{
    public partial class MasterEntry : Form
    {
        StringBuilder stringBuilder = new StringBuilder();
        public MasterEntry()
        {
            InitializeComponent();
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            this.errp.Clear();
            if (this.txtMasterValue.Text == "")
            {
                this.errp.SetError((Control)this.txtMasterValue, "Please Enter");
                this.errp.SetIconAlignment((Control)this.txtMasterValue, ErrorIconAlignment.MiddleLeft);
                this.txtMasterValue.Focus();
            }
            else
            {
                try
                {
                    stringBuilder.Clear();
                    stringBuilder.Append("<XMLData>");
                    stringBuilder.Append("<MasterValue>" + this.txtMasterValue.Text.Trim() + "</MasterValue>");
                    stringBuilder.Append("<ParentId>0</ParentId>");
                    stringBuilder.Append("<CreatedId>TestUser</CreatedId>");
                    stringBuilder.Append("<FinYearId>2024</FinYearId>");
                    stringBuilder.Append("<FirmId>1</FirmId>");
                    stringBuilder.Append("<Flag>I</Flag>");  //This Flag represen the operation flag in database stored procedure
                    stringBuilder.Append("</XMLData>");

                    if (Convert.ToInt16(DatabaseOperation.InsertIntoDatabase(stringBuilder.ToString(), "InsertIntoMasterEntry")) != (short)0)
                    {
                        if (MessageBox.Show("Data Saved Successfully, Do You Want To Continue!!", "Success Message", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                            this.txtMasterValue.Text = "";
                        else
                            this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Some Problem In Data Saving", "Success Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MasterEntry_Load(object sender, EventArgs e)
        {

        }
    }
}
