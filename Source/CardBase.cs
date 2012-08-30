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
	class CardBase
	{
		private Random mRandom = new Random();
		private CardCollection mCardCollection = new CardCollection();
		private string[] mSuperCategories;

		public void Load()
		{
			mCardCollection.Clear();

			List<string> playedCategories = new List<string>(GetPlayedCategories());

			CSVReader reader = new CSVReader("cards.csv");
			foreach (string[] row in reader.Values) {
				Card card = new Card(row[0], row[1]);
				if (playedCategories.Contains(card.Category, StringComparer.CurrentCultureIgnoreCase))
					card.Played = true;

				mCardCollection.Add(card);
			}

			mSuperCategories = GetSuperCategories();
		}

		public void Save()
		{
			SavePlayedCategories();
		}

		private string[] GetPlayedCategories()
		{
			if (!File.Exists("played.txt"))
				return new string[0];

			return File.ReadAllLines("played.txt");
		}

		private void SavePlayedCategories()
		{
			List<string> lines = new List<string>();
			foreach (Card card in mCardCollection.GetPlayedCards()) {
				lines.Add(card.Category);
			}
			File.WriteAllLines("played.txt", lines);
		}

		public string[] GetSuperCategories()
		{
			List<string> sc = new List<string>();
			foreach (Card c in mCardCollection)
				if (!sc.Contains(c.SuperCategory))
					sc.Add(c.SuperCategory);
			return sc.ToArray();
		}

		public void ResetCards()
		{
			for (int i = 0; i < mCardCollection.Count; i++) {
				Card card = mCardCollection[i];
				card.Played = false;
				mCardCollection[i] = card;
			}
		}

		public void ResetReleventCards()
		{
			for (int i = 0; i < mCardCollection.Count; i++) {
				if (Program.Game.IsCardSuperCategoryOmitted(mCardCollection[i]))
					continue;

				Card card = mCardCollection[i];
				card.Played = false;
				mCardCollection[i] = card;
			}
		}

		public Card GetRandomCard()
		{
			List<Card> cards = new List<Card>(mCardCollection.GetUnplayedCards());
			cards.RemoveAll(new Predicate<Card>(Program.Game.IsCardSuperCategoryOmitted));

			if (cards.Count == 0)
				return Card.Empty;

			int index = mRandom.Next(0, cards.Count);
			return cards[index];
		}

		public void PlayCard(Card card)
		{
			int index = mCardCollection.IndexOf(card);
			if (index == -1)
				return;

			card.Played = true;
			mCardCollection[index] = card;
		}

		public static bool CardsExists
		{
			get
			{
				return File.Exists("cards.csv");
			}
		}
	}
}
