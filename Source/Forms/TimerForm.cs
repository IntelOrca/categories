////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Windows.Forms;

namespace IntelOrca.Categories
{
	partial class TimerForm : Form
	{
		private bool mStarted;
		private int mTimeRemaining;

		public TimerForm()
		{
			InitializeComponent();

			this.Icon = Program.AppIcon;
			this.Text = Program.AppName;

			lblCategory.Text = Program.Game.CurrentCard.Category;
			mTimeRemaining = Program.Game.RoundDuration;
			UpdateTimeLabel();

			btnEnd.Text = "Start";
		}

		private void UpdateTimeLabel()
		{
			lblTimeRemaining.Text = mTimeRemaining.ToString();
		}

		private void StartRound()
		{
			mStarted = true;
			tmrUpdate.Start();
		}

		private void EndRound()
		{
			//Play sound
			Audio.PlaySound(Audio.Sounds.TimeUp);

			tmrUpdate.Stop();
			Close();
		}

		private void lblCategory_MouseDown(object sender, MouseEventArgs e)
		{
			Program.Game.PickRandomCard();
			lblCategory.Text = Program.Game.CurrentCard.Category;
		}

		private void btnEnd_Click(object sender, EventArgs e)
		{
			if (!mStarted) {
				btnEnd.Text = "End";
				StartRound();
				return;
			}

			DialogResult result = MessageBox.Show("Are you sure you want to end the round?", Program.AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (result != DialogResult.OK)
				return;

			EndRound();
		}

		private void tmrUpdate_Tick(object sender, EventArgs e)
		{
			mTimeRemaining--;
			UpdateTimeLabel();

			if (mTimeRemaining == 0) {
				EndRound();
			} else if (mTimeRemaining <= 10) {
				//Play sound
				Audio.PlaySound(Audio.Sounds.Tick);
			}
		}
	}
}
