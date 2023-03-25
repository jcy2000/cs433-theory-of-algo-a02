using System;
using System.Collections;
using System.Collections.Generic;

namespace _PA2
{
    class BinaryTreeNodeComparator : IComparer<BinaryTreeNode>
    {
        public int Compare(BinaryTreeNode arg1, BinaryTreeNode arg2)
        {
            return arg1.value - arg2.value;
        }
    }

    public class HuffmanEncoder
    {

        private char[] alphabet;
        private int[] frequencies;
        private int sigma;
        private int encodingLength, tableSize;
        private Hashtable charToEncodingMapping;

        public HuffmanEncoder(char[] alphabet, int[] frequencies, int sigma)
        {
            this.alphabet = alphabet;
            this.sigma = sigma;
            this.frequencies = frequencies;
            encodingLength = tableSize = 0;
            charToEncodingMapping = new Hashtable();
            encode();
        }

        private void encode()
        {   // complete this method, yeeeeeah
            BinaryTreeNode root = buildTree();
            createTable(root, "");

            for(int i = 0; i < this.sigma; i++) {
                char c = this.alphabet[i];
                string str = getEncoding(c);
                this.encodingLength += this.frequencies[i] * str.Length;
                this.tableSize += str.Length + 8;
            }
        }

        private BinaryTreeNode buildTree()
        {   // complete this method, ogie dogie
            // Declare comparator and minimum priority queue
            BinaryTreeNodeComparator comparator = new BinaryTreeNodeComparator();
            PriorityQueue<BinaryTreeNode> pq = new PriorityQueue<BinaryTreeNode>(comparator);

            // Turn all characters with their frequencies into nodes
            for(int i = 0; i < this.sigma; i++) {
                BinaryTreeNode x = new BinaryTreeNode(this.alphabet[i], this.frequencies[i]);
                pq.add(x);
            }

            while(pq.size() > 1) {
                // Get the 2 minimum nodes from priority queue
                BinaryTreeNode min1 = pq.poll(), min2 = pq.poll();

                // Create new node from the 2 minimum nodes
                BinaryTreeNode y = new BinaryTreeNode('\0', min1.value + min2.value);

                // Assign children of new node as the 2 minimum nodes
                y.left = min1; y.right = min2;

                pq.add(y);
            }
            return pq.peek();
        }

        private void createTable(BinaryTreeNode node, String encoding)
        {   // complete this method, the power of command is actually quite strong if you think about it.
            // Wasn't there that one study with the fake electrical shocks on fake testers?

            if(node.left == null && node.right == null)
                this.charToEncodingMapping[node.character] = encoding;
            else
                if (node.left != null)
                    createTable(node.left, encoding + "0");
                if (node.right != null)
                    createTable(node.right, encoding + "1");
        }

        public string getEncoding(char c)
        {
            return charToEncodingMapping[c].ToString();
        }

        public int getSigma()
        {
            return sigma;
        }

        public int[] getFrequencies()
        {
            return frequencies;
        }

        public char[] getAlphabet()
        {
            return alphabet;
        }

        public int getTableSize()
        {
            return tableSize;
        }

        public int getEncodingLength()
        {
            return encodingLength;
        }
    }
}