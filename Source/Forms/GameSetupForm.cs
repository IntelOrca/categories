////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IntelOrca.Categories
{
	partial class GameSetupForm : Form
	{
		public enum Result
		{
			Back,
			Continue,
		}

		private Result mResult;
		private int mRoundDuration;
		private string[] mSuperCategories;
		private bool mResetReleventCards;

		public GameSetupForm()
		{
			InitializeComponent();

			this.Icon = Program.AppIcon;
			this.Text = Program.AppName;

			string[] scList = Program.CardBase.GetSuperCategories();
			foreach (string sc in scList)
				chkSuperCategories.Items.Add(sc);

			for (int i = 0; i < chkSuperCategories.Items.Count; i++)
				chkSuperCategories.SetItemChecked(i, true);
		}

		private void btnSelectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < chkSuperCategories.Items.Count; i++)
				chkSuperCategories.SetItemChecked(i, true);
		}

		private void btnUnselectAll_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < chkSuperCategories.Items.Count; i++)
				chkSuperCategories.SetItemChecked(i, false);
		}

		private void btnBack_Click(object sender, EventArgs e)
		{
			mResult = Result.Back;
			this.DialogResult = DialogResult.OK;
			Close();
		}

		private void btnContinue_Click(object sender, EventArgs e)
		{
			mRoundDuration = (int)nudRoundDuration.Value;

			List<string> scList = new List<string>();
			foreach (object obj in chkSuperCategories.CheckedItems) {
				scList.Add((string)obj);
			}
			mSuperCategories = scList.ToArray();

			if (mSuperCategories.Length == 0) {
				MessageBox.Show("You must select at least one super category.", Program.AppName);
				return;
			}

			mResetReleventCards = chkResetReleventCards.Checked;

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

		public int RoundDuration
		{
			get
			{
				return mRoundDuration;
			}
		}

		public string[] SuperCategories
		{
			get
			{
				return mSuperCategories;
			}
		}

		public bool ResetReleventCards
		{
			get
			{
				return mResetReleventCards;
			}
		}
	}
}
