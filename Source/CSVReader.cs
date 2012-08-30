////////////////////////////////////
// Categories                     //
// Copyright (C) Ted John 2011    //
// http://intelorca.co.uk         //
////////////////////////////////////

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace IntelOrca.Categories
{
	/// <summary>
	/// Class for reading CSV files.
	/// </summary>
	class CSVReader : IEnumerable
	{
		/// <summary>
		/// The list of string arrays representing the rows and fields.
		/// </summary>
		List<string[]> _values = new List<string[]>();

		/// <summary>
		/// Creates and loads a new CSV file.
		/// </summary>
		/// <param name="path">The path of the CSV file to load.</param>
		public CSVReader(string path)
		{
			//Read the CSV file specified.
			ReadCSV(path);
		}

		/// <summary>
		/// Read the CSV file specified.
		/// </summary>
		/// <param name="path">The path to the CSV file to read.</param>
		private void ReadCSV(string path)
		{
			//Read in all the lines of the CSV file
			string[] lines = File.ReadAllLines(path);

			//Enumerate through all the lines
			for (int l = 0; l < lines.Length; l++) {
				string sl;

				//Replace the double quotes with something that would normally exist e.g. @#@
				string line = lines[l].Replace("\"\"", "@#@");

				//Create a new list of strings to represent the fields
				List<string> args = new List<string>();

				//Initialise the field parsing information
				int argStart = 0;
				bool inQuotes = false;

				//Enumerate through each character on the line
				for (int i = 0; i < line.Length; i++) {
					//If the character is a quote, toggle the inQuotes flag
					if (line[i] == '"')
						inQuotes = !inQuotes;

					//If the character is a comma and is not currently in quotes
					if (line[i] == ',' && !inQuotes) {
						//Get the text between the arg start and the current position and remove the quotes
						sl = line.Substring(argStart, i - argStart).Replace("\"", "");

						//Replace back the quote subsitute with quotes again
						args.Add(sl.Replace("@#@", "\""));

						//Set the arg start to after the current position
						argStart = i + 1;
					}
				}

				//Same thing as above but for the last argument, current to end of the line as there is no comma
				sl = line.Substring(argStart, line.Length - argStart).Replace("\"", "");
				args.Add(sl.Replace("@#@", "\""));

				//Add the fields to the values list (list of rows)
				_values.Add(args.ToArray());
			}
		}

		/// <summary>
		/// Searches for the column with the specified header and returns the index.
		/// </summary>
		/// <param name="key">The header to look for.</param>
		/// <returns>The index of the column. -1 if it does not exist.</returns>
		public int GetColumnIndex(string key)
		{
			//Enumerate through all the fields on the first row
			for (int i = 0; i < _values[0].Length; i++) {
				//Check if the header equals the specified header, case in-sensitive
				if (String.Compare(_values[0][i], key, true) == 0) {
					//Return the column index
					return i;
				}
			}

			//Return -1 meaning, column not found
			return -1;
		}

		/// <summary>
		/// Return a row using the specified index.
		/// </summary>
		/// <param name="index">The row index to return.</param>
		/// <returns>The row (array of fields).</returns>
		public string[] this[int index]
		{
			get
			{
				return Values[index];
			}
		}

		/// <summary>
		/// Gets the values of the CSV file.
		/// </summary> 
		public string[][] Values
		{
			get
			{
				return _values.ToArray();
			}
		}

		/// <summary>
		/// Gets the enumerator for the CSV reader.
		/// </summary>
		/// <returns>A new enumerator for the CSV reader.</returns>
		public IEnumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		/// <summary>
		/// Class to represent a CSV reader enumerator.
		/// </summary>
		public class Enumerator : IEnumerator
		{
			CSVReader _csvReader;
			int _index;

			public Enumerator(CSVReader reader)
			{
				_csvReader = reader;
				Reset();
			}

			public object Current
			{
				get
				{
					return _csvReader[_index];
				}
			}

			public bool MoveNext()
			{
				_index++;

				if (_index == _csvReader.Values.Length)
					return false;
				else
					return true;
			}

			public void Reset()
			{
				_index = -1;
			}
		}
	}
}
