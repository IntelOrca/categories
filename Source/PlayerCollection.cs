////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System.Collections;

namespace IntelOrca.Categories
{
	class PlayerCollection : CollectionBase
	{
		public void Add(Player player)
		{
			this.List.Add(player);
		}

		public void Sort()
		{
			this.InnerList.Sort();
		}
		
		public Player this[int index]
		{
			get
			{
				return this.List[index] as Player;
			}
			set
			{
				this.List[index] = value;
			}
		}
	}
}
