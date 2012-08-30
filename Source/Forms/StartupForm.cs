////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace IntelOrca.Categories
{
	partial class StartupForm : Form
	{
		public enum Result
		{
			NewGame,
			ResumeLastGame,
		}

		private Result mResult;

		public StartupForm()
		{
			InitializeComponent();

			this.Icon = Program.AppIcon;
			this.Text = Program.AppName;

			btnResume.Enabled = Game.ResumeGamePossible;

			lblInformation.Text = lblInformation.Text.Replace("{NAME}", Program.AppName);
			lblVersion.Text = Program.AppVersion;
			lblCopyright.Text = Program.AppCopyright;
		}

		private void btnNew_Click(object sender, EventArgs e)
		{
			mResult = StartupForm.Result.NewGame;
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnResume_Click(object sender, EventArgs e)
		{
			mResult = StartupForm.Result.ResumeLastGame;
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void lblCopyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start(Program.AppWebsite);
		}

		public Result WizardResult
		{
			get
			{
				return mResult;
			}
		}
	}
}
