﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace StringCalculator_Library
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int sum = 0;
            List<char> defaultDelimiters = new List<char>();
            defaultDelimiters.Add(',');
            defaultDelimiters.Add('\n');

            if (!String.IsNullOrEmpty(numbers))
            {
                if (numbers.StartsWith("//"))
                {
                    char customDelimiter = numbers.Substring(2, 2).ToCharArray()[0];

                    defaultDelimiters.Add(customDelimiter);
                    numbers = numbers.Substring(3);
                }

                var numberArray = numbers.Split(defaultDelimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                var negativeNumbers = string.Join(",", numberArray.Where(x => x < 0).Select(x => x.ToString()).ToArray());

                if (negativeNumbers == null || negativeNumbers.Length > 0)
                {
                    throw new FormatException($"negatives not allowed '{negativeNumbers}'");
                }
                
                foreach (int num in numberArray)
                {
                    if (num <= 1000)
                    {
                        sum += num;
                    }
                }
            }

            return sum;
        }
    }
}
