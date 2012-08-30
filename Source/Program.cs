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
	class Program
	{
		public static string AppName = "Categories";
		public static string AppVersion = "v3.1";
		public static string AppCopyright = "Copyright Ted John 2005 - 2012";
		public static string AppWebsite = "http://intelorca.co.uk";

		public static CardBase CardBase = new CardBase();
		public static Game Game = new Game();

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			if (!CardBase.CardsExists) {
				MessageBox.Show("cards.csv not found.", Program.AppName);
				return;
			}

			Program.CardBase.Load();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (!GameWizard.Run())
				return;

			Application.Run(new MainForm());
		}

		public static Icon AppIcon
		{
			get
			{
				return IntelOrca.Categories.Properties.Resources.orca_icon;
			}
		}
	}
}
