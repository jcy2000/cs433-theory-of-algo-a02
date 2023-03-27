using System;
using System.Collections.Generic;
using static _PA2.Program;

namespace _PA2
{
	public class StringSorter
	{
		public static void radixSort(String[] strings, int n)
		{ 	// complete this method, yeah
			int[] digits = new int[n];

			// Find the longest string
			int maxLength = strings[0].Length;
			for(int i = 1; i < n; i++)
				if(strings[i].Length > maxLength)
					maxLength = strings[i].Length;

			// Go through the count sort rounds, starting with the last character.

			int currentRound = 1;
			while(maxLength - currentRound + 1 > 0) {
				for(int i = 0; i < n; i++) {
					if(maxLength - currentRound >= strings[i].Length)
						digits[i] = 0;
					else
						digits[i] = ((int) strings[i][maxLength - currentRound] - 96);
				}

				countSortOnLowerCaseCharacters(strings, n, digits);
				currentRound++;
			}

		}

		private static void countSortOnLowerCaseCharacters(String[] strings, int n, int[] digits)
		{ 	// complete this method, ho boy, let's do this, shall we?
			// Declare counter array and output array.
			// Counter array is length 27 because a-z is 1-26 respectively, and no letter is 0
            int[] C = new int[27];
            String[] T = new String[n];

            // Init counter array
            for(int i = 0; i < C.Length; i++)
                C[i] = 0;

            // Init output array
            for(int i = 0; i < n; i ++)
                T[i] = "";

            // Get counters for all digits
            for(int i = 0; i < n; i++)
                C[digits[i]]++;

            // Make counter array cummalative
            for(int i = 1; i < C.Length; i++)
                C[i] = C[i - 1] + C[i];

            // Use the counter array to figure out where to put elements of strings
            for(int i = n - 1; i >= 0; i--) {
                T[C[digits[i]] - 1] = strings[i];
                C[digits[i]]--;
            }
                
            // Overwrite strings with T
            for(int i = 0; i < n; i++)
                strings[i] = T[i];
		}
	}
}
