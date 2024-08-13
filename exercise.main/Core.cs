﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace exercise.main
{
    public class Core
    {
        Dictionary<string, int> _cards;
        public Core()
        {
            _cards = new Dictionary<string, int>()
            {
                { "2", 2 },
                { "3", 3 },
                { "4", 4 },
                { "5", 5 },
                { "6", 6 },
                { "7", 7 },
                { "8", 8 },
                { "9", 9 },
                { "10", 10 },
                { "J", 11 },
                { "Q", 12 },
                { "K", 13 },
                { "A", 14 }
            };
        }
       
        // Note:
        // IEnumerable is a class that the List inherits (ie List has all the functionality of IEnumerable)
        // IEnumerable allows you to use a foreach loop on the variable hands (which is a List of tuples)
        
        //TODO: complete the winningPair method, without chaning the method signature
        public bool winningPair(IEnumerable<Tuple<string, string>> hands, out Tuple<string, string> result)
        {
            result = new Tuple<string,string>(string.Empty, string.Empty);

            int winnerSum = 0;

            foreach (var hand in hands)
            {
                if (hand.Item1.Equals(hand.Item2))
                {
                    int value1 = GetValueOfCard(hand.Item1);
                    int value2 = GetValueOfCard(hand.Item2);
                    int sumValue = value1 + value2;
                    if (sumValue > winnerSum)
                    {
                        winnerSum = sumValue;
                        result = hand;
                    }
                }
            }

            


            return result.Item1!=string.Empty ? true : false;
        }
        public int GetValueOfCard(string card)
        {
            return _cards[card];           
        }
    }
}
