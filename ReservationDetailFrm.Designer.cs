namespace HuyangReservation
{
    partial class ReservationDetailFrm
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cbLodgeTime = new System.Windows.Forms.ComboBox();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.gb = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.clbForestLodge = new System.Windows.Forms.CheckedListBox();
            this.clbFacility = new System.Windows.Forms.CheckedListBox();
            this.gb.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 6);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(150, 21);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // cbLodgeTime
            // 
            this.cbLodgeTime.FormattingEnabled = true;
            this.cbLodgeTime.Location = new System.Drawing.Point(12, 6);
            this.cbLodgeTime.Name = "cbLodgeTime";
            this.cbLodgeTime.Size = new System.Drawing.Size(69, 20);
            this.cbLodgeTime.TabIndex = 2;
            // 
            // gbLocation
            // 
            this.gbLocation.Location = new System.Drawing.Point(12, 33);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(641, 44);
            this.gbLocation.TabIndex = 3;
            this.gbLocation.TabStop = false;
            this.gbLocation.Text = "지역";
            // 
            // gb
            // 
            this.gb.Controls.Add(this.clbForestLodge);
            this.gb.Location = new System.Drawing.Point(12, 83);
            this.gb.Name = "gb";
            this.gb.Size = new System.Drawing.Size(641, 79);
            this.gb.TabIndex = 4;
            this.gb.TabStop = false;
            this.gb.Text = "휴양림";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.clbFacility);
            this.groupBox3.Location = new System.Drawing.Point(12, 168);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(641, 79);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "시설";
            // 
            // clbForestLodge
            // 
            this.clbForestLodge.FormattingEnabled = true;
            this.clbForestLodge.Location = new System.Drawing.Point(7, 21);
            this.clbForestLodge.Name = "clbForestLodge";
            this.clbForestLodge.Size = new System.Drawing.Size(628, 52);
            this.clbForestLodge.TabIndex = 0;
            // 
            // clbFacility
            // 
            this.clbFacility.FormattingEnabled = true;
            this.clbFacility.Location = new System.Drawing.Point(7, 21);
            this.clbFacility.Name = "clbFacility";
            this.clbFacility.Size = new System.Drawing.Size(628, 52);
            this.clbFacility.TabIndex = 1;
            // 
            // ReservationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 479);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gb);
            this.Controls.Add(this.gbLocation);
            this.Controls.Add(this.cbLodgeTime);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "ReservationFrm";
            this.Text = "ReservationFrm";
            this.gb.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox cbLodgeTime;
        private System.Windows.Forms.GroupBox gbLocation;
        private System.Windows.Forms.GroupBox gb;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckedListBox clbForestLodge;
        private System.Windows.Forms.CheckedListBox clbFacility;
    }
}