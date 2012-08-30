namespace IntelOrca.Categories
{
	partial class TimerForm
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
			this.components = new System.ComponentModel.Container();
			this.lblCategory = new System.Windows.Forms.Label();
			this.lblTimeRemaining = new System.Windows.Forms.Label();
			this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
			this.btnEnd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblCategory
			// 
			this.lblCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCategory.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblCategory.Location = new System.Drawing.Point(12, 9);
			this.lblCategory.Name = "lblCategory";
			this.lblCategory.Size = new System.Drawing.Size(353, 81);
			this.lblCategory.TabIndex = 0;
			this.lblCategory.Text = "{CATEGORY}";
			this.lblCategory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.lblCategory.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblCategory_MouseDown);
			// 
			// lblTimeRemaining
			// 
			this.lblTimeRemaining.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblTimeRemaining.Font = new System.Drawing.Font("Consolas", 99.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblTimeRemaining.Location = new System.Drawing.Point(12, 90);
			this.lblTimeRemaining.Name = "lblTimeRemaining";
			this.lblTimeRemaining.Size = new System.Drawing.Size(353, 167);
			this.lblTimeRemaining.TabIndex = 1;
			this.lblTimeRemaining.Text = "000";
			this.lblTimeRemaining.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// tmrUpdate
			// 
			this.tmrUpdate.Interval = 1000;
			this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
			// 
			// btnEnd
			// 
			this.btnEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEnd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnEnd.Location = new System.Drawing.Point(12, 270);
			this.btnEnd.Name = "btnEnd";
			this.btnEnd.Size = new System.Drawing.Size(353, 32);
			this.btnEnd.TabIndex = 5;
			this.btnEnd.Text = "End";
			this.btnEnd.UseVisualStyleBackColor = true;
			this.btnEnd.Click += new System.EventHandler(this.btnEnd_Click);
			// 
			// TimerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(377, 314);
			this.ControlBox = false;
			this.Controls.Add(this.btnEnd);
			this.Controls.Add(this.lblTimeRemaining);
			this.Controls.Add(this.lblCategory);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "TimerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "{NAME}";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label lblCategory;
		private System.Windows.Forms.Label lblTimeRemaining;
		private System.Windows.Forms.Timer tmrUpdate;
		private System.Windows.Forms.Button btnEnd;
	}
}