using System;
using System.Collections.Generic;
namespace _PA2
{
	class IntegerComparator : IComparer<int>
	{
		public int Compare(int arg1, int arg2)
		{
			return arg1 - arg2;
		}
	}

	public class GreedyIntervals
	{
		private static void sortIntervalsByStartTime(List<Interval> intervals)
		{
			intervals.Sort((arg1, arg2) => arg1.start - arg2.start);
		}

		private static void sortIntervalsByEndTime(List<Interval> intervals)
		{
			intervals.Sort((arg1, arg2) => arg1.end - arg2.end);
		}

		public static List<Interval> schedule(List<Interval> intervals)
		{ // complete this method, This is a very late assignment. I realize.
			// Sort intervals by end time, says it in the method invokation.
			sortIntervalsByEndTime(intervals);

			// Create optimal interval list and add the first interval to it.
			List<Interval> optimal = new List<Interval>();
			optimal.Add(intervals[0]);

			// Loop through intervals and get optimal intervals.
			for(int i = 1; i < intervals.Count; i++)
				// If start time of current interval >= end time of most recently added interval in optimal
				if(intervals[i].start >= optimal[optimal.Count - 1].end)
					optimal.Add(intervals[i]);

			return optimal;
		}

		public static int color(List<Interval> intervals)
		{ // complete this method, pickles
			// Sort intervals by start time, says it in the method invokation.
			sortIntervalsByStartTime(intervals);

			// Create priority queue to help with color counting. Also create color counter
			PriorityQueue<int> hiThere = new PriorityQueue<int>(Comparer<int>.Create((x, y) => x - y));
			hiThere.add(intervals[0].end);
			int colorCount = 1;
			
			// Loop through intervals
			for(int i = 1; i < intervals.Count; i++) {
				// If current interval > minimum integer in our priority queue, then remove the integer in the priority queue
				if (intervals[i].start >= hiThere.peek())
					hiThere.poll();
				// Else, there's no room with the current amount of colors, so "add" a new color
				else
					colorCount++;

				// No matter what, we add the end time of the current interval
				hiThere.add(intervals[i].end);
			}

			return colorCount;
		}
	}
}
