using System;
using System.Collections.Generic;
using System.Text;

namespace Entropia.Models
{
    class Character  
    {
        public char Word { get; set; }
        public double Amount { get; set; }
        public double Average { get; set; }

        public Character()
        {
                
        }
        public Character(char word, double amount,double average)
        {
            this.Word = word;
            this.Amount = amount;
            this.Average = average;
        }

    }
}
