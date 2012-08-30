////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace IntelOrca.Categories
{
	partial class PlayerSetupForm : Form
	{
		public enum Result
		{
			Back,
			Continue,
		}

		private Result mResult;
		private string[] mPlayers;

		public PlayerSetupForm()
		{
			InitializeComponent();

			this.Icon = Program.AppIcon;
			this.Text = Program.AppName;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (mPlayers != null) {
				StringBuilder sb = new StringBuilder();
				foreach (string p in mPlayers)
					sb.AppendLine(p);
				txtPlayers.Text = sb.ToString();
			}
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			mResult = Result.Back;
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnContinue_Click(object sender, EventArgs e)
		{
			List<string> players = new List<string>();
			foreach (string line in txtPlayers.Lines) {
				string playerName = line.Trim();
				if (playerName.Length == 0)
					continue;

				if (players.Contains(playerName)) {
					MessageBox.Show(playerName + " exists more than once.", Program.AppName);
					return;
				}

				players.Add(playerName);
			}
			mPlayers = players.ToArray();

            if (mPlayers.Length < 2) {
				MessageBox.Show("There must be at least two players.", Program.AppName);
                return;
            }

			mResult = Result.Continue;
			this.DialogResult = DialogResult.OK;
			Close();
		}

		public Result WizardResult
		{
			get
			{
				return mResult;
			}
		}

		public string[] Players
		{
			get
			{
				return mPlayers;
			}
			set
			{
				mPlayers = value;
			}
		}
	}
}
