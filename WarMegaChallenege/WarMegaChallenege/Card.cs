using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarMegaChallenege
{
    public class Card
    {
        public string Suit { get; set; }
        public string Kind { get; set; }

        public int CardValue()
        {
            int value = 0;

            switch(this.Kind)
            {
                case "2":
                    value = 2;
                    break;
                case "3":
                    value = 3;
                    break;
                case "4":
                    value = 4;
                    break;
                case "5":
                    value = 5;
                    break;
                case "6":
                    value = 6;
                    break;
                case "7":
                    value = 7;
                    break;
                case "8":
                    value = 8;
                    break;
                case "9":
                    value = 9;
                    break;
                case "10":
                    value = 10;
                    break;
                case "Jack":
                    value = 11;
                    break;
                case "Qeen":
                    value = 12;
                    break;
                case "King":
                    value = 13;
                    break;
                case "Ace":
                    value = 14;
                    break;
            }

            return value;
        }
    }
}