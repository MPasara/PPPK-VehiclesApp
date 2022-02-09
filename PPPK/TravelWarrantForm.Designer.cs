namespace PPPK
{
    partial class TravelWarrantForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TravelWarrantForm));
            this.tbDays = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbDestination = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbStart = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbWarrantNumber = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCommander = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTravelWarrants = new System.Windows.Forms.ListBox();
            this.btnClearForm = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbDateOfClosing = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDateOfOpening = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbVehicleId = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDriverId = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tbDays
            // 
            this.tbDays.Location = new System.Drawing.Point(239, 256);
            this.tbDays.Name = "tbDays";
            this.tbDays.Size = new System.Drawing.Size(337, 22);
            this.tbDays.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 256);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 24);
            this.label5.TabIndex = 36;
            this.label5.Text = "Days:";
            // 
            // tbDestination
            // 
            this.tbDestination.Location = new System.Drawing.Point(239, 196);
            this.tbDestination.Name = "tbDestination";
            this.tbDestination.Size = new System.Drawing.Size(337, 22);
            this.tbDestination.TabIndex = 35;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 196);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 24);
            this.label3.TabIndex = 34;
            this.label3.Text = "Destination:";
            // 
            // tbStart
            // 
            this.tbStart.Location = new System.Drawing.Point(239, 135);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(337, 22);
            this.tbStart.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 24);
            this.label4.TabIndex = 32;
            this.label4.Text = "Start:";
            // 
            // tbWarrantNumber
            // 
            this.tbWarrantNumber.Location = new System.Drawing.Point(239, 78);
            this.tbWarrantNumber.Name = "tbWarrantNumber";
            this.tbWarrantNumber.Size = new System.Drawing.Size(337, 22);
            this.tbWarrantNumber.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 24);
            this.label2.TabIndex = 30;
            this.label2.Text = "Warrant number:";
            // 
            // tbCommander
            // 
            this.tbCommander.Location = new System.Drawing.Point(239, 24);
            this.tbCommander.Name = "tbCommander";
            this.tbCommander.Size = new System.Drawing.Size(337, 22);
            this.tbCommander.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "Commander:";
            // 
            // lbTravelWarrants
            // 
            this.lbTravelWarrants.FormattingEnabled = true;
            this.lbTravelWarrants.ItemHeight = 16;
            this.lbTravelWarrants.Location = new System.Drawing.Point(628, 58);
            this.lbTravelWarrants.Name = "lbTravelWarrants";
            this.lbTravelWarrants.Size = new System.Drawing.Size(481, 596);
            this.lbTravelWarrants.TabIndex = 38;
            this.lbTravelWarrants.SelectedIndexChanged += new System.EventHandler(this.lbTravelWarrants_SelectedIndexChanged);
            // 
            // btnClearForm
            // 
            this.btnClearForm.Location = new System.Drawing.Point(29, 664);
            this.btnClearForm.Name = "btnClearForm";
            this.btnClearForm.Size = new System.Drawing.Size(550, 44);
            this.btnClearForm.TabIndex = 42;
            this.btnClearForm.Text = "Clear form";
            this.btnClearForm.UseVisualStyleBackColor = true;
            this.btnClearForm.Click += new System.EventHandler(this.btnClearForm_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.DarkRed;
            this.btnDelete.ForeColor = System.Drawing.Color.Transparent;
            this.btnDelete.Location = new System.Drawing.Point(414, 578);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(165, 44);
            this.btnDelete.TabIndex = 41;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(217, 578);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(165, 44);
            this.btnUpdate.TabIndex = 40;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(29, 578);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(165, 44);
            this.btnAdd.TabIndex = 39;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // tbDateOfClosing
            // 
            this.tbDateOfClosing.Location = new System.Drawing.Point(239, 370);
            this.tbDateOfClosing.Name = "tbDateOfClosing";
            this.tbDateOfClosing.Size = new System.Drawing.Size(337, 22);
            this.tbDateOfClosing.TabIndex = 46;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 370);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(138, 24);
            this.label6.TabIndex = 45;
            this.label6.Text = "Date of closing:";
            // 
            // tbDateOfOpening
            // 
            this.tbDateOfOpening.Location = new System.Drawing.Point(239, 310);
            this.tbDateOfOpening.Name = "tbDateOfOpening";
            this.tbDateOfOpening.Size = new System.Drawing.Size(337, 22);
            this.tbDateOfOpening.TabIndex = 44;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 310);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 24);
            this.label7.TabIndex = 43;
            this.label7.Text = "Date of opening:";
            // 
            // tbVehicleId
            // 
            this.tbVehicleId.Location = new System.Drawing.Point(242, 505);
            this.tbVehicleId.Name = "tbVehicleId";
            this.tbVehicleId.Size = new System.Drawing.Size(337, 22);
            this.tbVehicleId.TabIndex = 50;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(22, 503);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 24);
            this.label8.TabIndex = 49;
            this.label8.Text = "Vehicle id:";
            // 
            // tbDriverId
            // 
            this.tbDriverId.Location = new System.Drawing.Point(239, 443);
            this.tbDriverId.Name = "tbDriverId";
            this.tbDriverId.Size = new System.Drawing.Size(337, 22);
            this.tbDriverId.TabIndex = 48;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 443);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 24);
            this.label9.TabIndex = 47;
            this.label9.Text = "Driver id:";
            // 
            // TravelWarrantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 723);
            this.Controls.Add(this.tbVehicleId);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbDriverId);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbDateOfClosing);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbDateOfOpening);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnClearForm);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lbTravelWarrants);
            this.Controls.Add(this.tbDays);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbDestination);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbWarrantNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCommander);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TravelWarrantForm";
            this.Text = "Travel warrants";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDays;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbDestination;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbWarrantNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCommander;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbTravelWarrants;
        private System.Windows.Forms.Button btnClearForm;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbDateOfClosing;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDateOfOpening;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbVehicleId;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDriverId;
        private System.Windows.Forms.Label label9;
    }
}