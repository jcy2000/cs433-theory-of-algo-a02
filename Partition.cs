using System;
namespace _PA2
{
	public class Partition
	{
		private static void swap(int[] array, int x, int y)
		{
			int temp = array[x];
			array[x] = array[y];
			array[y] = temp;
		}

		public static int[] partition(int[] array, int left, int right, int pivot) // complete this method. Yep yep.
		{ 
			// These are set to the first and second just for now because we don't know where they are in the array.
            int pivotIndex = left, partitionIndex = left - 1;

            // Go through the array, count all numbers <= pivot and increment count by 1 everytime. Also find out which index holds pivot.
            for(int k = left; k <= right; k++) {
                if (array[k] == pivot)
                    pivotIndex = k;
                if (array[k] <= pivot)
                    partitionIndex++;
            }

            swap(array, pivotIndex, partitionIndex);
            int i = left, j = right;

            /*  The arduous partition while-loop. This loop goes through the entire array and swaps the numbers left
                of the pivot that are greater than the pivot with numbers right of the pivot that are less than the pivot.
                It's a little confusing to explain, so just look it up online or refer to your notes.*/
            while(i < j) {
                if(array[i] <= pivot) i++;
                else if(array[j] > pivot) j--;
                else {
                    swap(array, i, j);
                    i++;
                    j--;
                }
            }

			/* Organize the array into 3 parts.| 1st part: All #'s < pivot.| 2nd part: All #'s == pivot | 3rd pivot: All #'s > pivot
			We utilize partitionIndex, to make it easier for us. Also gonna reuse variables i and j, because reusability is good.*/
			i = left; j = partitionIndex - 1;
            int pivotOccurences = 1;

            while (i < j) {
                if(array[i] != pivot)
                    i++;
                else if(array[j] == pivot) {
                    pivotOccurences++;
                    j--;
                }
                else {
                    swap(array, i, j);
                    pivotOccurences++;
                    i++;
                    j--;
                }
            }
            if(array[i] == pivot)
                pivotOccurences++;

            // Returns an array of size 2 that holds the lower partition index and upper partition index
            int[] partitionArray = {partitionIndex - pivotOccurences + 1, partitionIndex};
            return partitionArray;
		}
	}
}
