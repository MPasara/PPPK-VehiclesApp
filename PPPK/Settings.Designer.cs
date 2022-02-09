namespace PPPK
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCleanDb = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(43, 210);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(242, 61);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import rnd data";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnCleanDb
            // 
            this.btnCleanDb.BackColor = System.Drawing.Color.DarkRed;
            this.btnCleanDb.ForeColor = System.Drawing.Color.Transparent;
            this.btnCleanDb.Location = new System.Drawing.Point(43, 294);
            this.btnCleanDb.Name = "btnCleanDb";
            this.btnCleanDb.Size = new System.Drawing.Size(242, 61);
            this.btnCleanDb.TabIndex = 1;
            this.btnCleanDb.Text = "Clean Db";
            this.btnCleanDb.UseVisualStyleBackColor = false;
            this.btnCleanDb.Click += new System.EventHandler(this.btnCleanDb_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Location = new System.Drawing.Point(43, 27);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(242, 61);
            this.btnBackup.TabIndex = 2;
            this.btnBackup.Text = "Backup Db";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Location = new System.Drawing.Point(43, 116);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(242, 61);
            this.btnRestore.TabIndex = 3;
            this.btnRestore.Text = "Restore Db";
            this.btnRestore.UseVisualStyleBackColor = true;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 367);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnCleanDb);
            this.Controls.Add(this.btnImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "Db operations";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnCleanDb;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button btnRestore;
    }
}