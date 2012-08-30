////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace IntelOrca.Categories
{
	class Game
	{
		private int mRoundDuration;
		private PlayerCollection mPlayers = new PlayerCollection();
		private int mPlayedRounds;
		private Card mLastCard;
		private Card mCurrentCard;
		private bool mRank;
		private string[] mActiveSuperCategories;

		public string[] GetPlayerNames()
		{
			List<string> players = new List<string>();
			foreach (Player p in mPlayers) {
				players.Add(p.Name);
			}
			return players.ToArray();
		}

		public void SetupNextRound()
		{
			PickRandomCard();
		}

		public void PickRandomCard()
		{
			mCurrentCard = Program.CardBase.GetRandomCard();
			if (mCurrentCard.Equals(Card.Empty)) {
				Program.CardBase.ResetReleventCards();
				mCurrentCard = Program.CardBase.GetRandomCard();
			}
		}

		public bool IsCardSuperCategoryOmitted(Card card)
		{
			return !mActiveSuperCategories.Contains(card.SuperCategory, StringComparer.CurrentCultureIgnoreCase);
		}

		public void FinishRound()
		{
			Program.CardBase.PlayCard(mCurrentCard);

			mLastCard = mCurrentCard;
			mPlayedRounds++;

			Program.CardBase.Save();
			SaveGame();
		}

		public void FinishGame()
		{
			try {
				if (File.Exists("save.dat"))
					File.Delete("save.dat");
			} catch {

			}
		}

		public void LoadGame()
		{	FileStream fs = null;
			BinaryReader br = null;

			try {
				fs = new FileStream("save.dat", FileMode.Open);
				br = new BinaryReader(fs);

				mRoundDuration = br.ReadInt32();
				mPlayedRounds = br.ReadInt32();
				mLastCard = new Card(br.ReadString(), br.ReadString());

				mPlayers.Clear();
				int numPlayers = br.ReadInt32();
				for (int i = 0; i < numPlayers; i++) {
					Player p = new Player(br.ReadString(), br.ReadInt32());
					mPlayers.Add(p);
				}

				int numSuperCategories = br.ReadInt32();
				mActiveSuperCategories = new string[numSuperCategories];
				for (int i = 0; i < numSuperCategories; i++)
					mActiveSuperCategories[i] = br.ReadString();
			} catch {

			} finally {
				if (br != null)
					br.Close();

				if (fs != null)
					fs.Close();
			}
		}

		public void SaveGame()
		{
			FileStream fs = null;
			BinaryWriter bw = null;

			try {
				fs = new FileStream("save.dat", FileMode.Create);
				bw = new BinaryWriter(fs);

				bw.Write(mRoundDuration);
				bw.Write(mPlayedRounds);
				bw.Write(mLastCard.Category);
				bw.Write(mLastCard.SuperCategory);

				bw.Write(mPlayers.Count);
				foreach (Player p in mPlayers) {
					bw.Write(p.Name);
					bw.Write(p.Score);
				}

				bw.Write(mActiveSuperCategories.Length);
				foreach (string superCategory in mActiveSuperCategories)
					bw.Write(superCategory);
			} catch {

			} finally {
				if (bw != null)
					bw.Close();

				if (fs != null)
					fs.Close();
			}
		}

		public static bool ResumeGamePossible
		{
			get
			{
				return File.Exists("save.dat");
			}
		}

		public Card LastCard
		{
			get
			{
				return mLastCard;
			}
		}

		public int PlayedRounds
		{
			get
			{
				return mPlayedRounds;
			}
		}

		public Card CurrentCard
		{
			get
			{
				return mCurrentCard;
			}
		}

		public int RoundDuration
		{
			get
			{
				return mRoundDuration;
			}
			set
			{
				mRoundDuration = value;
			}
		}

		public PlayerCollection Players
		{
			get
			{
				return mPlayers;
			}
		}

		public bool Rank
		{
			get
			{
				return mRank;
			}
			set
			{
				mRank = value;
			}
		}

		public string[] ActiveSuperCategories
		{
			get
			{
				return mActiveSuperCategories;
			}
			set
			{
				mActiveSuperCategories = value;
			}
		}
	}
}
