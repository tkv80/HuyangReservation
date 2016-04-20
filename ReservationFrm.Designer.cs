namespace HuyangReservation
{
    partial class ReservationFrm
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
            this.cbLodge = new System.Windows.Forms.ComboBox();
            this.cbFacility = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbSite = new System.Windows.Forms.GroupBox();
            this.cbAll = new System.Windows.Forms.CheckBox();
            this.cblSite = new System.Windows.Forms.CheckedListBox();
            this.gbReservation = new System.Windows.Forms.GroupBox();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.txtLog = new System.Windows.Forms.RichTextBox();
            this.gbAccont = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.gboption = new System.Windows.Forms.GroupBox();
            this.cbPeriod = new System.Windows.Forms.ComboBox();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.cbReservation = new System.Windows.Forms.CheckedListBox();
            this.gbSite.SuspendLayout();
            this.gbReservation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.gbLog.SuspendLayout();
            this.gbAccont.SuspendLayout();
            this.gboption.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbLodge
            // 
            this.cbLodge.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbLodge.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLodge.FormattingEnabled = true;
            this.cbLodge.Location = new System.Drawing.Point(8, 21);
            this.cbLodge.Name = "cbLodge";
            this.cbLodge.Size = new System.Drawing.Size(124, 20);
            this.cbLodge.TabIndex = 0;
            // 
            // cbFacility
            // 
            this.cbFacility.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFacility.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFacility.FormattingEnabled = true;
            this.cbFacility.Location = new System.Drawing.Point(138, 21);
            this.cbFacility.Name = "cbFacility";
            this.cbFacility.Size = new System.Drawing.Size(129, 20);
            this.cbFacility.TabIndex = 2;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(170, 384);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(97, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "예약추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbSite
            // 
            this.gbSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbSite.Controls.Add(this.cbAll);
            this.gbSite.Controls.Add(this.cblSite);
            this.gbSite.Controls.Add(this.cbLodge);
            this.gbSite.Controls.Add(this.cbFacility);
            this.gbSite.Controls.Add(this.btnAdd);
            this.gbSite.Location = new System.Drawing.Point(12, 157);
            this.gbSite.Name = "gbSite";
            this.gbSite.Size = new System.Drawing.Size(278, 416);
            this.gbSite.TabIndex = 8;
            this.gbSite.TabStop = false;
            this.gbSite.Text = "사이트";
            // 
            // cbAll
            // 
            this.cbAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAll.AutoSize = true;
            this.cbAll.Location = new System.Drawing.Point(8, 386);
            this.cbAll.Name = "cbAll";
            this.cbAll.Size = new System.Drawing.Size(72, 16);
            this.cbAll.TabIndex = 4;
            this.cbAll.Text = "전체선택";
            this.cbAll.UseVisualStyleBackColor = true;
            this.cbAll.CheckedChanged += new System.EventHandler(this.cbAll_CheckedChanged);
            // 
            // cblSite
            // 
            this.cblSite.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cblSite.FormattingEnabled = true;
            this.cblSite.Location = new System.Drawing.Point(8, 47);
            this.cblSite.Name = "cblSite";
            this.cblSite.Size = new System.Drawing.Size(259, 324);
            this.cblSite.TabIndex = 3;
            // 
            // gbReservation
            // 
            this.gbReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbReservation.Controls.Add(this.cbReservation);
            this.gbReservation.Controls.Add(this.numInterval);
            this.gbReservation.Controls.Add(this.btnDelete);
            this.gbReservation.Controls.Add(this.btnStart);
            this.gbReservation.Location = new System.Drawing.Point(296, 17);
            this.gbReservation.Name = "gbReservation";
            this.gbReservation.Size = new System.Drawing.Size(774, 326);
            this.gbReservation.TabIndex = 11;
            this.gbReservation.TabStop = false;
            this.gbReservation.Text = "예약";
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(643, 298);
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(44, 21);
            this.numInterval.TabIndex = 14;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(6, 297);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "선택삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(693, 297);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "예약시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbLog
            // 
            this.gbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLog.Controls.Add(this.txtLog);
            this.gbLog.Location = new System.Drawing.Point(296, 349);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(774, 224);
            this.gbLog.TabIndex = 13;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "로그";
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(6, 20);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(762, 194);
            this.txtLog.TabIndex = 0;
            this.txtLog.Text = "";
            // 
            // gbAccont
            // 
            this.gbAccont.Controls.Add(this.label2);
            this.gbAccont.Controls.Add(this.label1);
            this.gbAccont.Controls.Add(this.textBox2);
            this.gbAccont.Controls.Add(this.textBox1);
            this.gbAccont.Controls.Add(this.btnLogin);
            this.gbAccont.Location = new System.Drawing.Point(12, 17);
            this.gbAccont.Name = "gbAccont";
            this.gbAccont.Size = new System.Drawing.Size(278, 73);
            this.gbAccont.TabIndex = 19;
            this.gbAccont.TabStop = false;
            this.gbAccont.Text = "계정정보";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 12);
            this.label2.TabIndex = 23;
            this.label2.Text = "PWD : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "ID : ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(52, 44);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(159, 21);
            this.textBox2.TabIndex = 2;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(52, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(159, 21);
            this.textBox1.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(216, 15);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(55, 50);
            this.btnLogin.TabIndex = 19;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // gboption
            // 
            this.gboption.Controls.Add(this.cbPeriod);
            this.gboption.Controls.Add(this.dateTime);
            this.gboption.Location = new System.Drawing.Point(12, 96);
            this.gboption.Name = "gboption";
            this.gboption.Size = new System.Drawing.Size(278, 48);
            this.gboption.TabIndex = 20;
            this.gboption.TabStop = false;
            this.gboption.Text = "조건";
            // 
            // cbPeriod
            // 
            this.cbPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbPeriod.FormattingEnabled = true;
            this.cbPeriod.Location = new System.Drawing.Point(189, 21);
            this.cbPeriod.Name = "cbPeriod";
            this.cbPeriod.Size = new System.Drawing.Size(82, 20);
            this.cbPeriod.TabIndex = 11;
            // 
            // dateTime
            // 
            this.dateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateTime.Location = new System.Drawing.Point(10, 21);
            this.dateTime.Name = "dateTime";
            this.dateTime.Size = new System.Drawing.Size(173, 21);
            this.dateTime.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 576);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1082, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // cbReservation
            // 
            this.cbReservation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReservation.FormattingEnabled = true;
            this.cbReservation.Location = new System.Drawing.Point(6, 12);
            this.cbReservation.Name = "cbReservation";
            this.cbReservation.Size = new System.Drawing.Size(762, 276);
            this.cbReservation.TabIndex = 15;
            // 
            // ReservationFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 598);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.gboption);
            this.Controls.Add(this.gbAccont);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbReservation);
            this.Controls.Add(this.gbSite);
            this.Name = "ReservationFrm";
            this.Text = "예약";
            this.gbSite.ResumeLayout(false);
            this.gbSite.PerformLayout();
            this.gbReservation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.gbLog.ResumeLayout(false);
            this.gbAccont.ResumeLayout(false);
            this.gbAccont.PerformLayout();
            this.gboption.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbLodge;
        private System.Windows.Forms.ComboBox cbFacility;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbSite;
        private System.Windows.Forms.CheckedListBox cblSite;
        private System.Windows.Forms.CheckBox cbAll;
        private System.Windows.Forms.GroupBox gbReservation;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.RichTextBox txtLog;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.GroupBox gbAccont;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox gboption;
        private System.Windows.Forms.ComboBox cbPeriod;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.CheckedListBox cbReservation;
    }
}