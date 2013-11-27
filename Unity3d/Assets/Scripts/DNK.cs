using UnityEngine;
using System.Collections;
using System.Collections.Generic;


    public class DNK
    {
        private List<int> genealogicThree;
        private  byte generationCount;
        public int dnk = 0;

        public DNK(int mother,int father){
            
        }

        public int getGeneration()
        {
            return generationCount;
        }

        public void IncGeneration() {
            ++generationCount;
        }

        public static void Encrypt(ref int value,int key) {
            value = value ^ key;
        }

        public static void Decrypt(ref int value, int key)
        {
            Encrypt(ref value, key);
        }


    }
