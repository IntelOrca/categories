namespace IntelOrca.Categories
{
	partial class StartupForm
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
			if (disposing && (components != null)) {
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
			this.lblInformation = new System.Windows.Forms.Label();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnResume = new System.Windows.Forms.Button();
			this.lblCopyright = new System.Windows.Forms.LinkLabel();
			this.pnlLine = new System.Windows.Forms.Panel();
			this.lblVersion = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblInformation
			// 
			this.lblInformation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblInformation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblInformation.Location = new System.Drawing.Point(9, 9);
			this.lblInformation.Name = "lblInformation";
			this.lblInformation.Size = new System.Drawing.Size(362, 63);
			this.lblInformation.TabIndex = 0;
			this.lblInformation.Text = "Welcome to {NAME}, select whether you would like to play a new game or continue y" +
    "our previous game if applicable.";
			// 
			// btnNew
			// 
			this.btnNew.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNew.Location = new System.Drawing.Point(13, 75);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(183, 32);
			this.btnNew.TabIndex = 1;
			this.btnNew.Text = "Start a new game";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnResume
			// 
			this.btnResume.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnResume.Location = new System.Drawing.Point(13, 113);
			this.btnResume.Name = "btnResume";
			this.btnResume.Size = new System.Drawing.Size(183, 32);
			this.btnResume.TabIndex = 2;
			this.btnResume.Text = "Resume previous game";
			this.btnResume.UseVisualStyleBackColor = true;
			this.btnResume.Click += new System.EventHandler(this.btnResume_Click);
			// 
			// lblCopyright
			// 
			this.lblCopyright.ActiveLinkColor = System.Drawing.Color.Blue;
			this.lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCopyright.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCopyright.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
			this.lblCopyright.Location = new System.Drawing.Point(139, 159);
			this.lblCopyright.Name = "lblCopyright";
			this.lblCopyright.Size = new System.Drawing.Size(235, 23);
			this.lblCopyright.TabIndex = 6;
			this.lblCopyright.TabStop = true;
			this.lblCopyright.Text = "{COPYRIGHT}";
			this.lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lblCopyright.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblCopyright_LinkClicked);
			// 
			// pnlLine
			// 
			this.pnlLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.pnlLine.BackColor = System.Drawing.SystemColors.ControlDark;
			this.pnlLine.Location = new System.Drawing.Point(12, 155);
			this.pnlLine.Name = "pnlLine";
			this.pnlLine.Size = new System.Drawing.Size(362, 1);
			this.pnlLine.TabIndex = 7;
			// 
			// lblVersion
			// 
			this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblVersion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblVersion.Location = new System.Drawing.Point(9, 159);
			this.lblVersion.Name = "lblVersion";
			this.lblVersion.Size = new System.Drawing.Size(124, 23);
			this.lblVersion.TabIndex = 8;
			this.lblVersion.Text = "{VERSION}";
			this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// StartupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(386, 191);
			this.Controls.Add(this.lblVersion);
			this.Controls.Add(this.pnlLine);
			this.Controls.Add(this.lblCopyright);
			this.Controls.Add(this.btnResume);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.lblInformation);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "StartupForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "{NAME}";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblInformation;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnResume;
		private System.Windows.Forms.LinkLabel lblCopyright;
		private System.Windows.Forms.Panel pnlLine;
		private System.Windows.Forms.Label lblVersion;
	}
}