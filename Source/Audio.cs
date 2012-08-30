////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.IO;
using System.Media;
using IntelOrca.Categories.Properties;

namespace IntelOrca.Categories
{
	static class Audio
	{
		public enum Sounds
		{
			Tick,
			TimeUp,
		}

		public static void PlaySound(Sounds sound)
		{
            Stream stream = Resources.ResourceManager.GetStream(sound.ToString().ToLower());
            SoundPlayer sp = new SoundPlayer(stream);
			sp.Play();
		}
	}
}
