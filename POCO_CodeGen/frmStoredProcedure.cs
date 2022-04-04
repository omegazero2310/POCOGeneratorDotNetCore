using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POCO_CodeGen
{
    public partial class frmStoredProcedure : Form
    {
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable("Parameters");
        private DataColumn colName = new DataColumn("ParmName", Type.GetType("System.String"));
        private DataColumn colValue = new DataColumn("ParmValue", Type.GetType("System.String"));
        public string StoredProcedureName;
        public List<string> Parameters = new List<string>();

        public frmStoredProcedure()
        {
            InitializeComponent();
            dt.Columns.Add(colName);
            dt.Columns.Add(colValue);
            this.dataGridView1.DataSource = dt;
            this.dataGridView1.Columns[0].Width = (int)(this.dataGridView1.Width * 0.25);
            this.dataGridView1.Columns[1].Width = (int)(this.dataGridView1.Width * 0.75);
        }

        private void btnSave_Click(System.Object sender, System.EventArgs e)
        {
            StoredProcedureName = this.textBox1.Text;
            foreach (DataRow dr in dt.Rows)
            {
                var parmLine = dr[0] + "\t" + dr[1];
                Parameters.Add(parmLine);
            }
            this.Close();
        }

        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            StoredProcedureName = string.Empty;
            Parameters.Clear();
            this.Close();
        }
    }
}
