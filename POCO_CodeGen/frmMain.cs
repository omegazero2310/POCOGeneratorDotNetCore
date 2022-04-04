using System.Collections;
using System.Data;
namespace POCO_CodeGen
{
    public partial class frmMain : Form
    {
        public frmMain()
        {

            // This call is required by the designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            txtConnectionString.Text = @"Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;";
        }

        private void btnGenerate_Click(System.Object sender, System.EventArgs e)
        {
            string CodeText = string.Empty;
            DataTable SchemaTable = new DataTable();

            try
            {
                bool forVB = this.rbVB.Checked;
                GenerateCode(this.txtConnectionString.Text, this.txtQuery.Text, this.txtObjectName.Text, ref SchemaTable, ref CodeText, ref forVB, null/* TODO Change to default(_) if this is not a reference type */);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            this.dgvSchemaColumns.DataSource = SchemaTable;
            this.dgvSchemaColumns.AutoGenerateColumns = true;
            this.txtCode.Text = CodeText;
        }

        private void GenerateCode(string ConnectionString, string Query, string ObjectName, ref DataTable SchemaTable, ref string Code, ref bool ForVB, ArrayList spParms = null/* TODO Change to default(_) if this is not a reference type */)
        {
            if (string.IsNullOrEmpty(ConnectionString))
                throw new Exception("Database Connection String is Required");

            if (string.IsNullOrEmpty(Query))
                throw new Exception("Query String is Required");

            if (string.IsNullOrEmpty(ObjectName))
                throw new Exception("Code Object Name is Required");

            var adoHelper = new ADOHelper.ADOHelper();
            var Columns = adoHelper.GetFields(ConnectionString, Query, ref SchemaTable);

            if (Columns != null && Columns.Count > 0)
            {
                string[] codeLines;
                if (ForVB == true)
                    codeLines = adoHelper.GenerateCodeVB(ref Columns, ObjectName);
                else
                    codeLines = adoHelper.GenerateCodeCS(ref Columns, ObjectName);
                Code = adoHelper.StringArrayToText(codeLines, Environment.NewLine);
            }
        }

        private void txtCode_Click(System.Object sender, System.EventArgs e)
        {
            var text = this.txtCode.Text;
            if (string.IsNullOrEmpty(text) == false)
            {
                DialogResult dr = MessageBox.Show("Copy Text to Clipboard?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.Yes)
                    Clipboard.SetText(this.txtCode.Text);
            }
        }

        private void rbStoredProcedure_Click(System.Object sender, System.EventArgs e)
        {
            var txtSP = GetStoredProcedureText();
            this.txtQuery.Text = txtSP;
        }

        private void FileToolStripMenuItem_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private string GetStoredProcedureText()
        {
            var storedProcedureText = string.Empty;
            frmStoredProcedure frmSP = new frmStoredProcedure();
            frmSP.ShowDialog();
            if (string.IsNullOrEmpty(frmSP.StoredProcedureName) == false)
            {
                storedProcedureText = frmSP.StoredProcedureName;
                if (frmSP.Parameters.Count > 0)
                {
                    foreach (string s in frmSP.Parameters)
                    {
                        var fields = s.Split("\t");
                        if ((fields != null) && (fields.Count() == 2))
                            storedProcedureText += string.Format(" | `{0}`,`{1}`", fields[0], fields[1]);
                    }
                }
            }
            return storedProcedureText;
        }

        private void ClearQueryCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtQuery.Text = string.Empty;
            this.txtCode.Text = string.Empty;
        }

        private void ClearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.txtQuery.Text = string.Empty;
            this.dgvSchemaColumns.DataSource = null;
            this.txtObjectName.Text = string.Empty;
            this.txtCode.Text = string.Empty;
            rbIsQuery.Checked = true;
        }
    }
}
