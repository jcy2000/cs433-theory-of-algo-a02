using System;
using System.Collections;
namespace _PA2
{
    public class HuffmanDecoder
    {
        public static String decode(String encodedMsg, Hashtable encodingToCharMapping)
        {   // complete this method, wait I think I've heard this several times before... Deja vu?

            // Declare encode and decodedMsg among a few other variables
            String encode = "", decodedMsg = "";
            int n = encodedMsg.Length;

            for(int i = 0; i < n; i++) {
                encode += encodedMsg[i];

                if(encodingToCharMapping.Contains(encode)) {
                    String c = encodingToCharMapping[encode].ToString();
                    decodedMsg += c;
                    encode = "";
                }
            }

            return decodedMsg;
        }
    }
}
