namespace TestJuniorWF
{
    partial class Mapping
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelFileName = new System.Windows.Forms.Label();
            this.dataGridViewMapping = new System.Windows.Forms.DataGridView();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.labelWarning = new System.Windows.Forms.Label();
            this.header = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueExamples = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataErrors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMapping)).BeginInit();
            this.SuspendLayout();
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Location = new System.Drawing.Point(12, 25);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(73, 13);
            this.labelFileName.TabIndex = 0;
            this.labelFileName.Text = "labelFileName";
            // 
            // dataGridViewMapping
            // 
            this.dataGridViewMapping.AllowUserToAddRows = false;
            this.dataGridViewMapping.AllowUserToDeleteRows = false;
            this.dataGridViewMapping.AllowUserToResizeColumns = false;
            this.dataGridViewMapping.AllowUserToResizeRows = false;
            this.dataGridViewMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.header,
            this.valueExamples,
            this.dataErrors});
            this.dataGridViewMapping.Location = new System.Drawing.Point(3, 57);
            this.dataGridViewMapping.Name = "dataGridViewMapping";
            this.dataGridViewMapping.RowHeadersVisible = false;
            this.dataGridViewMapping.Size = new System.Drawing.Size(1344, 283);
            this.dataGridViewMapping.TabIndex = 1;
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(925, 365);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(161, 35);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(1120, 365);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(161, 35);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // labelWarning
            // 
            this.labelWarning.AutoSize = true;
            this.labelWarning.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWarning.ForeColor = System.Drawing.Color.Red;
            this.labelWarning.Location = new System.Drawing.Point(12, 376);
            this.labelWarning.Name = "labelWarning";
            this.labelWarning.Size = new System.Drawing.Size(0, 16);
            this.labelWarning.TabIndex = 4;
            // 
            // header
            // 
            this.header.HeaderText = "Header";
            this.header.Name = "header";
            this.header.ReadOnly = true;
            // 
            // valueExamples
            // 
            this.valueExamples.HeaderText = "Value examples";
            this.valueExamples.Name = "valueExamples";
            this.valueExamples.ReadOnly = true;
            this.valueExamples.Width = 700;
            // 
            // dataErrors
            // 
            this.dataErrors.FillWeight = 200F;
            this.dataErrors.HeaderText = "Data Errors";
            this.dataErrors.Name = "dataErrors";
            this.dataErrors.ReadOnly = true;
            this.dataErrors.Width = 450;
            // 
            // Mapping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 424);
            this.Controls.Add(this.labelWarning);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.dataGridViewMapping);
            this.Controls.Add(this.labelFileName);
            this.Name = "Mapping";
            this.Text = "Mapping";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMapping)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.DataGridView dataGridViewMapping;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label labelWarning;
        private System.Windows.Forms.DataGridViewTextBoxColumn header;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueExamples;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataErrors;
    }
}