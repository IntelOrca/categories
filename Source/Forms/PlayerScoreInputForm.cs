////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2012    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IntelOrca.Categories
{
	partial class PlayerScoreInputForm : Form
	{
		private Dictionary<Player, Label> mPlayerScoreChangeLabels = new Dictionary<Player, Label>();

		public PlayerScoreInputForm()
		{
			InitializeComponent();

			this.Icon = Program.AppIcon;
			chkRank.Checked = Program.Game.Rank;

			// Create a row of labels for each player
			AddLabels();
		}

		private void AddLabels()
		{
			mPlayerScoreChangeLabels.Clear();

			int currentY = lblInformation.Height + 12;
			int numPlayers = Program.Game.Players.Count;
			foreach (Player player in Program.Game.Players) {
				Label actualScoreLabel = new Label();
				actualScoreLabel.Font = new Font("Calibri", 12);
				actualScoreLabel.AutoSize = false;
				actualScoreLabel.TextAlign = ContentAlignment.MiddleRight;
				actualScoreLabel.Location = new Point(this.ClientSize.Width - 64 - 12, currentY);
				actualScoreLabel.Size = new Size(64, 27);
				actualScoreLabel.Text = "+0";
				mPlayerScoreChangeLabels.Add(player, actualScoreLabel);
				this.Controls.Add(actualScoreLabel);

				NumericUpDown nudPlayerScore = new NumericUpDown();
				nudPlayerScore.Tag = player;
				nudPlayerScore.Font = new Font("Calibri", 12);
				nudPlayerScore.Location = new Point(actualScoreLabel.Left - 64 - 12, currentY);
				nudPlayerScore.Size = new Size(64, 27);
				nudPlayerScore.Minimum = 0;
				nudPlayerScore.Maximum = 255;
				nudPlayerScore.Value = 0;
				nudPlayerScore.ValueChanged += nudPlayerScore_ValueChanged;
				this.Controls.Add(nudPlayerScore);

				Label playerNameLabel = new Label();
				playerNameLabel.Font = new Font("Calibri", 12);
				playerNameLabel.AutoSize = false;
				playerNameLabel.TextAlign = ContentAlignment.MiddleLeft;
				playerNameLabel.Location = new Point(lblInformation.Left, currentY);
				playerNameLabel.Size = new Size(nudPlayerScore.Left - 12 - lblInformation.Left, 27);
				playerNameLabel.Text = player.Name;
				this.Controls.Add(playerNameLabel);


				currentY += playerNameLabel.Height;
				currentY += 3;
			}

			this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height + currentY - 28);
		}

		private void RefreshScoreChangeLabels()
		{
			Dictionary<Player, int> scores = GetPlayerScores();
			foreach (KeyValuePair<Player, int> kvp in scores)
				mPlayerScoreChangeLabels[kvp.Key].Text = "+" + kvp.Value;
		}

		private Dictionary<Player, int> GetPlayerScores()
		{
			Dictionary<Player, int> scores = new Dictionary<Player, int>();

			// Get all the scores from the numeric up down controls
			foreach (Control ctl in this.Controls) {
				NumericUpDown nud = ctl as NumericUpDown;
				if (nud == null)
					continue;

				Player player = nud.Tag as Player;
				if (player == null)
					continue;

				scores.Add(player, (int)nud.Value);
			}

			// Rank the scores if rank is checked
			if (chkRank.Checked)
				scores = GetRankScores(scores);

			// Return the player => score dictionary
			return scores;
		}

		private Dictionary<Player, int> GetRankScores(Dictionary<Player, int> scores)
		{
			Dictionary<Player, int> rankScores = new Dictionary<Player, int>();

			// Sort all the points
			List<int> points = new List<int>();
			foreach (KeyValuePair<Player, int> kvp in scores) {
				points.Add(kvp.Value);
			}
			points.Sort();
			points.Reverse();

			List<Player> donePlayers = new List<Player>();

			// Enum
			int rank = 0;
			int rankStore = 0;
			for (int i = 0; i < scores.Count; i++) {
				foreach (KeyValuePair<Player, int> kvp in scores) {
					if (donePlayers.Contains(kvp.Key))
						continue;

					if (kvp.Value != points[i])
						continue;

					int rankPoints = scores.Count - rank;
					rankScores.Add(kvp.Key, rankPoints);

					donePlayers.Add(kvp.Key);

					if (i < scores.Count - 1) {
						if (points[i + 1] != points[i]) {
							rank += 1 + rankStore;
							rankStore = 0;
						} else {
							rankStore++;
						}
					}

					break;
				}
			}

			return rankScores;
		}

		void nudPlayerScore_ValueChanged(object sender, EventArgs e)
		{
			RefreshScoreChangeLabels();
		}

		private void chkRank_CheckedChanged(object sender, EventArgs e)
		{
			RefreshScoreChangeLabels();
		}

		private void btnContinue_Click(object sender, EventArgs e)
		{
			// Give each player their points
			Dictionary<Player, int> scores = GetPlayerScores();
			foreach (KeyValuePair<Player, int> kvp in scores)
				kvp.Key.GivePoints(kvp.Value);

			// Save rank option
			if (chkRank.Checked)
				Program.Game.Rank = chkRank.Checked;

			// Close the form
			Close();
		}
	}
}
