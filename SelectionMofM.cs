using System;
using static _PA2.Partition;
using static _PA2.Program;

namespace _PA2
{
	public class SelectionMofM
	{
		private static void insertionSort(int[] arr, int left, int right)
		{
			for (int i = left + 1; i <= right; i++)
			{
				int j = i, temp = arr[j];
				while (j > left && temp < arr[j - 1])
				{
					arr[j] = arr[j - 1];
					j--;
				}
				arr[j] = temp;
			}
		}

		public static int select(int[] arr, int left, int right, int k)
		{// complete this method. Hoh boy, Median of Medians is not my strong suit... Let's do this.
			if(left == right)
				return arr[left];
			
			// If the currently selected group is less than or equal to 5 elements, then just do insertion sort on the group
			if(right - left + 1 <= 5) {
				insertionSort(arr, left, right);
				return arr[left + k - 1];
			}
			
			// Create the median array
			int[] median = new int[(int) Math.Ceiling((right - left) / 5.0)];
			int medianCounter = 0;

			// Fill the median array
			for(int i = left; i < right; i += 5) {
				if(i + 4 > right) {
					// The group's size is less than 5, so grab the first element
					median[medianCounter] = select(arr, i, arr.Length - 1, 0);
				}
				else {
					// The group is size of 5, so grab the middle element
					median[medianCounter] = select(arr, i, i + 4, 3);
				}

				medianCounter++;
			}

			// Recurse on the static median array to find the median of the medians

			int medianOfMedians = select(median, 0, median.Length - 1, median.Length / 2 + 1);

			/* Partitioning the array
			REMINDER THAT PARTITION "SPLITS" THE ARRAY INTO 3 DIFFERENT PARTS. REFER TO IT IF NEED BE (line 42 of Partition.cs).*/
			int[] partitionIndices = partition(arr, left, right, medianOfMedians);
			int lowerPartitionIndex = partitionIndices[0];
			int upperPartitionIndex = partitionIndices[1];

			if(k >= lowerPartitionIndex - left + 1 && k <= upperPartitionIndex - left + 1)
                return medianOfMedians;
            else if(k < lowerPartitionIndex - left + 1) {
                return select(arr, left, lowerPartitionIndex - 1, k);
            }
            else {
                return select(arr, upperPartitionIndex + 1, right, k - (upperPartitionIndex - left + 1));
            }
		}
	}
}
