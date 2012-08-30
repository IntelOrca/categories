using System.Windows.Forms;

namespace IntelOrca.Categories
{
	class GameWizard
	{
		private delegate StepAction StepAction();
		private bool mCompleted;

		public static bool Run()
		{
			GameWizard wizard = new GameWizard();
			StepAction stepAction = wizard.ShowStartupForm;
			while (stepAction != null)
				stepAction = stepAction();
			return wizard.mCompleted;
		}

		private GameWizard()
		{
			mCompleted = false;
		}

		private StepAction ShowStartupForm()
		{
			StartupForm startupForm = new StartupForm();
			if (startupForm.ShowDialog() != DialogResult.OK)
				return null;

			if (startupForm.WizardResult == StartupForm.Result.ResumeLastGame) {
				Program.Game.LoadGame();

				mCompleted = true;
				return null;
			}

			Program.Game = new Game();

			return ShowPlayerForm;
		}

		private StepAction ShowPlayerForm()
		{
			PlayerSetupForm playerSetupForm = new PlayerSetupForm();
			playerSetupForm.Players = Program.Game.GetPlayerNames();

			if (playerSetupForm.ShowDialog() != DialogResult.OK)
				return null;

			if (playerSetupForm.WizardResult == PlayerSetupForm.Result.Back)
				return ShowStartupForm;

			Program.Game.Players.Clear();
			foreach (string p in playerSetupForm.Players)
				Program.Game.Players.Add(new Player(p));

			return ShowGameSetupForm;
		}

		private StepAction ShowGameSetupForm()
		{
			//Show game setup form
			GameSetupForm gameSetupForm = new GameSetupForm();
			if (gameSetupForm.ShowDialog() != DialogResult.OK)
				return null;

			if (gameSetupForm.WizardResult == GameSetupForm.Result.Back)
				return ShowPlayerForm;

			Program.Game.RoundDuration = gameSetupForm.RoundDuration;
			Program.Game.ActiveSuperCategories = gameSetupForm.SuperCategories;

			if (gameSetupForm.ResetReleventCards)
				Program.CardBase.ResetReleventCards();

			Program.Game.SaveGame();

			mCompleted = true;
			return null;
		}
	}
}
