namespace POCO_CodeGen
{
    public partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnectionString = new System.Windows.Forms.TextBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtObjectName = new System.Windows.Forms.TextBox();
            this.rbVB = new System.Windows.Forms.CheckBox();
            this.dgvSchemaColumns = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.rbIsQuery = new System.Windows.Forms.RadioButton();
            this.rbIsProc = new System.Windows.Forms.RadioButton();
            this.btnGenCode = new System.Windows.Forms.Button();
            this.btnClearCode = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchemaColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection String:";
            // 
            // txtConnectionString
            // 
            this.txtConnectionString.Location = new System.Drawing.Point(148, 2);
            this.txtConnectionString.Name = "txtConnectionString";
            this.txtConnectionString.Size = new System.Drawing.Size(620, 27);
            this.txtConnectionString.TabIndex = 1;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(148, 35);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(620, 126);
            this.txtQuery.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Query:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Class Name (TableName):";
            // 
            // txtObjectName
            // 
            this.txtObjectName.Location = new System.Drawing.Point(196, 174);
            this.txtObjectName.Name = "txtObjectName";
            this.txtObjectName.Size = new System.Drawing.Size(209, 27);
            this.txtObjectName.TabIndex = 5;
            this.txtObjectName.Text = "POCO";
            // 
            // rbVB
            // 
            this.rbVB.AutoSize = true;
            this.rbVB.Location = new System.Drawing.Point(411, 177);
            this.rbVB.Name = "rbVB";
            this.rbVB.Size = new System.Drawing.Size(125, 24);
            this.rbVB.TabIndex = 6;
            this.rbVB.Text = "Is VB.Net class";
            this.rbVB.UseVisualStyleBackColor = true;
            // 
            // dgvSchemaColumns
            // 
            this.dgvSchemaColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchemaColumns.Location = new System.Drawing.Point(12, 264);
            this.dgvSchemaColumns.Name = "dgvSchemaColumns";
            this.dgvSchemaColumns.RowHeadersWidth = 51;
            this.dgvSchemaColumns.RowTemplate.Height = 29;
            this.dgvSchemaColumns.Size = new System.Drawing.Size(756, 188);
            this.dgvSchemaColumns.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Code:";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(12, 491);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(756, 260);
            this.txtCode.TabIndex = 9;
            this.txtCode.Click += new System.EventHandler(this.txtCode_Click);
            // 
            // rbIsQuery
            // 
            this.rbIsQuery.AutoSize = true;
            this.rbIsQuery.Checked = true;
            this.rbIsQuery.Location = new System.Drawing.Point(539, 177);
            this.rbIsQuery.Name = "rbIsQuery";
            this.rbIsQuery.Size = new System.Drawing.Size(83, 24);
            this.rbIsQuery.TabIndex = 10;
            this.rbIsQuery.TabStop = true;
            this.rbIsQuery.Text = "Is Query";
            this.rbIsQuery.UseVisualStyleBackColor = true;
            // 
            // rbIsProc
            // 
            this.rbIsProc.AutoSize = true;
            this.rbIsProc.Location = new System.Drawing.Point(625, 177);
            this.rbIsProc.Name = "rbIsProc";
            this.rbIsProc.Size = new System.Drawing.Size(111, 24);
            this.rbIsProc.TabIndex = 11;
            this.rbIsProc.Text = "Is Procedure";
            this.rbIsProc.UseVisualStyleBackColor = true;
            this.rbIsProc.Click += new System.EventHandler(this.rbStoredProcedure_Click);
            // 
            // btnGenCode
            // 
            this.btnGenCode.Location = new System.Drawing.Point(148, 207);
            this.btnGenCode.Name = "btnGenCode";
            this.btnGenCode.Size = new System.Drawing.Size(92, 27);
            this.btnGenCode.TabIndex = 12;
            this.btnGenCode.Text = "Run";
            this.btnGenCode.UseVisualStyleBackColor = true;
            this.btnGenCode.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // btnClearCode
            // 
            this.btnClearCode.Location = new System.Drawing.Point(265, 207);
            this.btnClearCode.Name = "btnClearCode";
            this.btnClearCode.Size = new System.Drawing.Size(92, 27);
            this.btnClearCode.TabIndex = 13;
            this.btnClearCode.Text = "ClearCode";
            this.btnClearCode.UseVisualStyleBackColor = true;
            this.btnClearCode.Click += new System.EventHandler(this.ClearQueryCodeToolStripMenuItem_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(390, 207);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(92, 27);
            this.btnClearAll.TabIndex = 14;
            this.btnClearAll.Text = "ClearAll";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.ClearAllToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 767);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnClearCode);
            this.Controls.Add(this.btnGenCode);
            this.Controls.Add(this.rbIsProc);
            this.Controls.Add(this.rbIsQuery);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvSchemaColumns);
            this.Controls.Add(this.rbVB);
            this.Controls.Add(this.txtObjectName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.txtConnectionString);
            this.Controls.Add(this.label1);
            this.Name = "frmMain";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchemaColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtConnectionString;
        private TextBox txtQuery;
        private Label label2;
        private Label label3;
        private TextBox txtObjectName;
        private CheckBox rbVB;
        private DataGridView dgvSchemaColumns;
        private Label label4;
        private TextBox txtCode;
        private RadioButton rbIsQuery;
        private RadioButton rbIsProc;
        private Button btnGenCode;
        private Button btnClearCode;
        private Button btnClearAll;
    }
}