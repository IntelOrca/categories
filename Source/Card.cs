////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;

namespace IntelOrca.Categories
{
	struct Card
	{
		string mCategory;
		string mSuperCategory;
		bool mPlayed;

		public Card(string category, string superCategory)
		{
			mCategory = category;
			mSuperCategory = superCategory;
			mPlayed = false;
		}

		public Card(string category, string superCategory, bool played)
		{
			mCategory = category;
			mSuperCategory = superCategory;
			mPlayed = played;
		}

		public override bool Equals(object obj)
		{
			if (obj is Card) {
				Card c = (Card)obj;
				if (c.mCategory == mCategory)
					return true;
			}
			
			return false;
		}

		public override int GetHashCode()
		{
			return mCategory.GetHashCode() ^ mSuperCategory.GetHashCode() ^ mPlayed.GetHashCode();
		}

		public override string ToString()
		{
			return mCategory;
		}

		public string Category
		{
			get
			{
				if (mCategory == null)
					return String.Empty;
				return mCategory;
			}
		}

		public string SuperCategory
		{
			get
			{
				if (mSuperCategory == null)
					return String.Empty;
				return mSuperCategory;
			}
		}

		public bool Played
		{
			get
			{
				return mPlayed;
			}
			set
			{
				mPlayed = value;
			}
		}

		public static Card Empty
		{
			get
			{
				return new Card();
			}
		}
	}
}
