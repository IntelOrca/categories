namespace IntelOrca.Categories
{
	partial class MainForm
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
			this.btnNextRound = new System.Windows.Forms.Button();
			this.btnFinishGame = new System.Windows.Forms.Button();
			this.grpParticipants = new System.Windows.Forms.GroupBox();
			this.lblPlayedRounds = new System.Windows.Forms.Label();
			this.lblLastCategory = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnNextRound
			// 
			this.btnNextRound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNextRound.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnNextRound.Location = new System.Drawing.Point(272, 90);
			this.btnNextRound.Name = "btnNextRound";
			this.btnNextRound.Size = new System.Drawing.Size(183, 32);
			this.btnNextRound.TabIndex = 2;
			this.btnNextRound.Text = "Play a new round";
			this.btnNextRound.UseVisualStyleBackColor = true;
			this.btnNextRound.Click += new System.EventHandler(this.btnNextRound_Click);
			// 
			// btnFinishGame
			// 
			this.btnFinishGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnFinishGame.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnFinishGame.Location = new System.Drawing.Point(83, 90);
			this.btnFinishGame.Name = "btnFinishGame";
			this.btnFinishGame.Size = new System.Drawing.Size(183, 32);
			this.btnFinishGame.TabIndex = 3;
			this.btnFinishGame.Text = "Finish game";
			this.btnFinishGame.UseVisualStyleBackColor = true;
			this.btnFinishGame.Click += new System.EventHandler(this.btnFinishGame_Click);
			// 
			// grpParticipants
			// 
			this.grpParticipants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpParticipants.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.grpParticipants.Location = new System.Drawing.Point(12, 58);
			this.grpParticipants.Name = "grpParticipants";
			this.grpParticipants.Size = new System.Drawing.Size(443, 26);
			this.grpParticipants.TabIndex = 4;
			this.grpParticipants.TabStop = false;
			this.grpParticipants.Text = "Participants";
			// 
			// lblPlayedRounds
			// 
			this.lblPlayedRounds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblPlayedRounds.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPlayedRounds.Location = new System.Drawing.Point(12, 9);
			this.lblPlayedRounds.Name = "lblPlayedRounds";
			this.lblPlayedRounds.Size = new System.Drawing.Size(443, 23);
			this.lblPlayedRounds.TabIndex = 5;
			this.lblPlayedRounds.Text = "Played rounds:";
			// 
			// lblLastCategory
			// 
			this.lblLastCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lblLastCategory.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblLastCategory.Location = new System.Drawing.Point(12, 32);
			this.lblLastCategory.Name = "lblLastCategory";
			this.lblLastCategory.Size = new System.Drawing.Size(443, 23);
			this.lblLastCategory.TabIndex = 6;
			this.lblLastCategory.Text = "Last category:";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(467, 134);
			this.Controls.Add(this.lblLastCategory);
			this.Controls.Add(this.lblPlayedRounds);
			this.Controls.Add(this.grpParticipants);
			this.Controls.Add(this.btnFinishGame);
			this.Controls.Add(this.btnNextRound);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "{NAME}";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnNextRound;
		private System.Windows.Forms.Button btnFinishGame;
		private System.Windows.Forms.GroupBox grpParticipants;
		private System.Windows.Forms.Label lblPlayedRounds;
		private System.Windows.Forms.Label lblLastCategory;
	}
}

