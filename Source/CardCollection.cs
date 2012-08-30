////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System.Collections;
using System.Collections.Generic;

namespace IntelOrca.Categories
{
	class CardCollection : CollectionBase
	{
		public void Add(Card card)
		{
			this.List.Add(card);
		}

		public void Remove(Card card)
		{
			this.List.Remove(card);
		}

		public Card[] GetPlayedCards()
		{
			List<Card> cards = new List<Card>();
			foreach (Card c in this.List) {
				if (c.Played)
					cards.Add(c);
			}

			return cards.ToArray();
		}

		public Card[] GetUnplayedCards()
		{
			List<Card> cards = new List<Card>();
			foreach (Card c in this.List) {
				if (!c.Played)
					cards.Add(c);
			}

			return cards.ToArray();
		}

		public int GetUnplayedCardsCount()
		{
			return GetUnplayedCards().Length;
		}

		public int IndexOf(Card card)
		{
			return this.List.IndexOf(card);
		}

		public Card this[int index]
		{
			get
			{
				return (Card)this.List[index];
			}
			set
			{
				this.List[index] = value;
			}
		}
	}
}
