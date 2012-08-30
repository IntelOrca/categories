////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;

namespace IntelOrca.Categories
{
	class Player : IComparable
	{
		private string mName;
		private int mScore;

		public Player(string name)
		{
			mName = name;
			mScore = 0;
		}

		public Player(string name, int score)
		{
			mName = name;
			mScore = score;
		}

		public void GivePoints(int points)
		{
			mScore += points;
		}

		public int CompareTo(object obj)
		{
			Player cp = obj as Player;
			if (cp == null)
				return 1;

			if (mScore == cp.Score)
				return mName.CompareTo(cp.Name);

			return -mScore.CompareTo(cp.Score);
		}

		public string Name
		{
			get
			{
				return mName;
			}
		}

		public int Score
		{
			get
			{
				return mScore;
			}
		}
	}
}
