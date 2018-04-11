namespace Ado.net_PictucreData_
{
    partial class Form1
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
            this.btnFill = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.TxtBxQuery = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnAddFoto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFill
            // 
            this.btnFill.Location = new System.Drawing.Point(13, 39);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(75, 23);
            this.btnFill.TabIndex = 0;
            this.btnFill.Text = "Fill";
            this.btnFill.UseVisualStyleBackColor = true;
            this.btnFill.Click += new System.EventHandler(this.btnFill_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(856, 39);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // TxtBxQuery
            // 
            this.TxtBxQuery.Location = new System.Drawing.Point(13, 13);
            this.TxtBxQuery.Name = "TxtBxQuery";
            this.TxtBxQuery.Size = new System.Drawing.Size(918, 20);
            this.TxtBxQuery.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 68);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(919, 358);
            this.dataGridView1.TabIndex = 3;
            // 
            // btnAddFoto
            // 
            this.btnAddFoto.Location = new System.Drawing.Point(104, 40);
            this.btnAddFoto.Name = "btnAddFoto";
            this.btnAddFoto.Size = new System.Drawing.Size(75, 23);
            this.btnAddFoto.TabIndex = 4;
            this.btnAddFoto.Text = "addPict";
            this.btnAddFoto.UseVisualStyleBackColor = true;
            this.btnAddFoto.Click += new System.EventHandler(this.btnAddFoto_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 438);
            this.Controls.Add(this.btnAddFoto);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.TxtBxQuery);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnFill);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox TxtBxQuery;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnAddFoto;
    }
}

