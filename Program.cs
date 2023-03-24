// See https://aka.ms/new-console-template for more information
using static _PA2.TestCorrectness;
using static _PA2.SelectionMofM;

namespace _PA2 {
    public static class Program {
        public static void Main(String[] args) {
            martin();
            // testTime();
        }

        public static void print_array(int[] arr) {
            Console.Write("[");
            for (int j = 0; j < arr.Length - 1; j++)
                Console.Write(arr[j] + ", ");
                
            Console.WriteLine(arr[arr.Length - 1] + "]");
        }

        public static void print_array(String[] arr) {
            Console.Write("[");
            for (int j = 0; j < arr.Length - 1; j++)
                Console.Write(arr[j] + ", ");
                
            Console.WriteLine(arr[arr.Length - 1] + "]");
        }
    }
}


