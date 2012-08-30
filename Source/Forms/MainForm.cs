////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;

namespace IntelOrca.Categories
{
	partial class MainForm : Form
	{
		private int mOriginalFormHeight;

		public MainForm()
		{
			InitializeComponent();

			this.Icon = Program.AppIcon;
			this.Text = Program.AppName;

			mOriginalFormHeight = this.ClientSize.Height;
			UpdateLabels();
		}

		private void UpdateLabels()
		{
			this.SuspendLayout();

			lblPlayedRounds.Text = String.Format("Played rounds: {0}", Program.Game.PlayedRounds);
			lblLastCategory.Text = String.Format("Last category: {0}", Program.Game.LastCard.Category);

			UpdatePlayerLabels();

			this.ResumeLayout();
		}

		private void UpdatePlayerLabels()
		{
			//Sort the players by highest score
			Program.Game.Players.Sort();

			grpParticipants.Controls.Clear();

            if (Program.Game.Players.Count < 2)
                return;

			int numPlayers = Program.Game.Players.Count;
			int highestScore = Program.Game.Players[0].Score;
			int lowestScore = Program.Game.Players[numPlayers - 1].Score;

			int currentY = 20;
			foreach (Player player in Program.Game.Players) {
				Label playerNameLabel = new Label();
				playerNameLabel.AutoSize = false;
				playerNameLabel.Location = new Point(3, currentY);
				playerNameLabel.Size = new Size(grpParticipants.Width - 32 - 6, 20);
				playerNameLabel.Text = player.Name;
				grpParticipants.Controls.Add(playerNameLabel);

				Label scoreLabel = new Label();
				scoreLabel.AutoSize = false;
				scoreLabel.TextAlign = ContentAlignment.MiddleRight;
				scoreLabel.Location = new Point(grpParticipants.Width - 32 - 6, currentY);
				scoreLabel.Size = new Size(32, 20);
				scoreLabel.Text = player.Score.ToString();
				grpParticipants.Controls.Add(scoreLabel);

				Color forecolour = Color.Black;
				if (highestScore != lowestScore) {
					if (player.Score == highestScore)
						forecolour = Color.Blue;
					else if (player.Score == lowestScore)
						forecolour = Color.Red;
				}
				playerNameLabel.ForeColor = forecolour;
				scoreLabel.ForeColor = forecolour;

				currentY += playerNameLabel.Height;
				currentY += 3;
			}

			//grpParticipants.Height = currentY;
			int formHeight = mOriginalFormHeight + currentY - 16;

			ClientSize = new Size(ClientSize.Width, formHeight);
		}

		private void btnFinishGame_Click(object sender, EventArgs e)
		{
			DialogResult result = MessageBox.Show("Are you sure you want to end the game?", Program.AppName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
			if (result != DialogResult.OK)
				return;

			Program.Game.FinishGame();

			result = MessageBox.Show("HAD FUN?", Program.AppName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (result == DialogResult.Yes) {
				Application.Exit();
			} else {
				Hide();
				if (!GameWizard.Run())
					Application.Exit();
				else
					Show();
			}
		}

		private void btnNextRound_Click(object sender, EventArgs e)
		{
			Program.Game.SetupNextRound();
			if (Program.Game.CurrentCard.Equals(Card.Empty)) {
				MessageBox.Show("No cards to select!", Program.AppName);
				return;
			}

			TimerForm timerForm = new TimerForm();
			timerForm.ShowDialog();

			PlayerScoreInputForm f = new PlayerScoreInputForm();
			f.ShowDialog();

			Program.Game.FinishRound();
			UpdateLabels();
		}
	}
}
