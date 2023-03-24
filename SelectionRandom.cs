using System;
using static _PA2.Partition;

namespace _PA2
{
	public class SelectionRandom
	{
		private static Random rand = new Random((int)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond));

		private static int generateRandomPivot(int[] array, int left, int right)
		{
			int pivotIndex = left + rand.Next(right - left + 1);
			return array[pivotIndex];
		}

		public static int select(int[] arr, int left, int right, int k)
		{	// complete this method, wait, havne't I done this before?
			// If the array is size of one, then that must be the answer
            if(left == right) return arr[left];

            // Do some prep work for the recursion
            int pivot = generateRandomPivot(arr, left, right);
            int[] partitionIndices = partition(arr, left, right, pivot);
			int lowerPartitionIndex = partitionIndices[0];
			int upperPartitionIndex = partitionIndices[1];

			/* Do the comparisons and recurse accordingly.
			   REMINDER THAT PARTITION "SPLITS" THE ARRAY INTO 3 DIFFERENT PARTS. REFER TO IT IF NEED BE (line 42 of Partition.cs).*/
            if(k >= lowerPartitionIndex - left + 1 && k <= upperPartitionIndex - left + 1)
                return pivot;
            else if(k < lowerPartitionIndex - left + 1) {
                return select(arr, left, lowerPartitionIndex - 1, k);
            }
            else {
                return select(arr, upperPartitionIndex + 1, right, k - (upperPartitionIndex - left + 1));
            }
        }
	}
}
