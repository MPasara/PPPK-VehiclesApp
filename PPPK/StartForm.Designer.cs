namespace PPPK
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.btnDrivers = new System.Windows.Forms.Button();
            this.btnVehicles = new System.Windows.Forms.Button();
            this.btnDbOperations = new System.Windows.Forms.Button();
            this.btnTravelWarrants = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnDaab = new System.Windows.Forms.Button();
            this.btnIshod7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnDrivers
            // 
            this.btnDrivers.Location = new System.Drawing.Point(69, 36);
            this.btnDrivers.Name = "btnDrivers";
            this.btnDrivers.Size = new System.Drawing.Size(132, 67);
            this.btnDrivers.TabIndex = 0;
            this.btnDrivers.Text = "Drivers";
            this.btnDrivers.UseVisualStyleBackColor = true;
            this.btnDrivers.Click += new System.EventHandler(this.btnDrivers_Click);
            // 
            // btnVehicles
            // 
            this.btnVehicles.Location = new System.Drawing.Point(317, 36);
            this.btnVehicles.Name = "btnVehicles";
            this.btnVehicles.Size = new System.Drawing.Size(132, 67);
            this.btnVehicles.TabIndex = 1;
            this.btnVehicles.Text = "Vehicles";
            this.btnVehicles.UseVisualStyleBackColor = true;
            this.btnVehicles.Click += new System.EventHandler(this.btnVehicles_Click);
            // 
            // btnDbOperations
            // 
            this.btnDbOperations.Location = new System.Drawing.Point(317, 167);
            this.btnDbOperations.Name = "btnDbOperations";
            this.btnDbOperations.Size = new System.Drawing.Size(132, 67);
            this.btnDbOperations.TabIndex = 2;
            this.btnDbOperations.Text = "Db operations";
            this.btnDbOperations.UseVisualStyleBackColor = true;
            this.btnDbOperations.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnTravelWarrants
            // 
            this.btnTravelWarrants.Location = new System.Drawing.Point(69, 167);
            this.btnTravelWarrants.Name = "btnTravelWarrants";
            this.btnTravelWarrants.Size = new System.Drawing.Size(132, 67);
            this.btnTravelWarrants.TabIndex = 3;
            this.btnTravelWarrants.Text = "Travel Warrants";
            this.btnTravelWarrants.UseVisualStyleBackColor = true;
            this.btnTravelWarrants.Click += new System.EventHandler(this.btnTravelWarrants_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.DarkRed;
            this.btnExit.ForeColor = System.Drawing.Color.Transparent;
            this.btnExit.Location = new System.Drawing.Point(69, 398);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(380, 67);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnDaab
            // 
            this.btnDaab.Location = new System.Drawing.Point(69, 282);
            this.btnDaab.Name = "btnDaab";
            this.btnDaab.Size = new System.Drawing.Size(132, 67);
            this.btnDaab.TabIndex = 5;
            this.btnDaab.Text = "DAAB";
            this.btnDaab.UseVisualStyleBackColor = true;
            this.btnDaab.Click += new System.EventHandler(this.btnDaab_Click);
            // 
            // btnIshod7
            // 
            this.btnIshod7.Location = new System.Drawing.Point(317, 282);
            this.btnIshod7.Name = "btnIshod7";
            this.btnIshod7.Size = new System.Drawing.Size(132, 67);
            this.btnIshod7.TabIndex = 6;
            this.btnIshod7.Text = "Service report";
            this.btnIshod7.UseVisualStyleBackColor = true;
            this.btnIshod7.Click += new System.EventHandler(this.btnIshod7_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 477);
            this.Controls.Add(this.btnIshod7);
            this.Controls.Add(this.btnDaab);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnTravelWarrants);
            this.Controls.Add(this.btnDbOperations);
            this.Controls.Add(this.btnVehicles);
            this.Controls.Add(this.btnDrivers);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.Text = "Vegicle Manager";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnDrivers;
        private System.Windows.Forms.Button btnVehicles;
        private System.Windows.Forms.Button btnDbOperations;
        private System.Windows.Forms.Button btnTravelWarrants;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnDaab;
        private System.Windows.Forms.Button btnIshod7;
    }
}

