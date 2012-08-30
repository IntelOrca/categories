////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace IntelOrca.Categories
{
	partial class PlayerScoreInputForm : Form
	{
		public PlayerScoreInputForm()
		{
			InitializeComponent();

			this.Icon = Program.AppIcon;
			chkRank.Checked = Program.Game.Rank;

			AddLabels();
		}

		private void AddLabels()
		{
			int currentY = lblInformation.Height + 12;
			int numPlayers = Program.Game.Players.Count;
			foreach (Player player in Program.Game.Players) {
				Label playerNameLabel = new Label();
				playerNameLabel.Font = new Font("Calibri", 12);
				playerNameLabel.AutoSize = false;
				playerNameLabel.TextAlign = ContentAlignment.MiddleLeft;
				playerNameLabel.Location = new Point(lblInformation.Left, currentY);
				playerNameLabel.Size = new Size(this.ClientSize.Width - 64 - 24 - 3, 27);
				playerNameLabel.Text = player.Name;
				this.Controls.Add(playerNameLabel);

				NumericUpDown nudPlayerScore = new NumericUpDown();
				nudPlayerScore.Tag = player;
				nudPlayerScore.Font = new Font("Calibri", 12);
				nudPlayerScore.Location = new Point(this.ClientSize.Width - 64 - 12, currentY);
				nudPlayerScore.Size = new Size(64, 27);
				nudPlayerScore.Minimum = 0;
				nudPlayerScore.Maximum = 255;
				nudPlayerScore.Value = 0;
				this.Controls.Add(nudPlayerScore);

				currentY += playerNameLabel.Height;
				currentY += 3;
			}

			this.ClientSize = new Size(this.ClientSize.Width, this.ClientSize.Height + currentY - 28);
		}

		private void btnContinue_Click(object sender, EventArgs e)
		{
			Dictionary<Player, int> rankScores = new Dictionary<Player, int>();

			foreach (Control ctl in this.Controls) {
				NumericUpDown nud = ctl as NumericUpDown;
				if (nud == null)
					continue;

				Player player = nud.Tag as Player;
				if (player == null)
					continue;

				if (chkRank.Checked)
					rankScores.Add(player, (int)nud.Value);
				else
					player.GivePoints((int)nud.Value);
			}

			if (chkRank.Checked) {
				RankScores(rankScores);
				Program.Game.Rank = chkRank.Checked;
			}

			Close();
		}

		private void RankScores(Dictionary<Player, int> rankScores)
		{
			//Sort all the points
			List<int> points = new List<int>();
			foreach (KeyValuePair<Player, int> kvp in rankScores) {
				points.Add(kvp.Value);
			}
			points.Sort();
			points.Reverse();

			List<Player> donePlayers = new List<Player>();

			//Enum
			int rank = 0;
			int rankStore = 0;
			for (int i = 0; i < rankScores.Count; i++) {
				foreach (KeyValuePair<Player, int> kvp in rankScores) {
					if (donePlayers.Contains(kvp.Key))
						continue;

					if (kvp.Value == points[i]) {
						int rankPoints = rankScores.Count - rank;
						kvp.Key.GivePoints(rankPoints);
						donePlayers.Add(kvp.Key);

						if (i < rankScores.Count - 1) {
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
			}
		}
	}
}
