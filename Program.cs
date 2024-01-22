using System;
using System.Collections.Generic;
using System.IO;

namespace Lab0Basics
{
    class HighLow
    {
        private double low;
        private double high;
        private double dif;
        private List<double> betweenNums = new List<double>();
        private double sumAll;

        public double Low
        {
            get { return low; }
            set { low = value; }
        }
        public double High
        {
            get { return high; }
            set { high = value; }
        }
        public void difference()
        {
            dif = high-low;
            Console.WriteLine("The difference between {0} and {1} is {2}", high, low, dif);
        }
        public void betweenList()
        {
            for (double i = high-1; i > low; i--)
            {
                betweenNums.Add(i);
                Console.WriteLine(i);
            }
        }
        public void writeListToFile()
        {
            List<string> stringNum = new List<string>();
            foreach (double i in betweenNums)
            {
                stringNum.Add(i.ToString());
            }
            File.WriteAllLines("numbers.txt", stringNum);
        }
        public void readFromFile()
        {
            List<string> readFile = new List<string>(File.ReadAllLines("numbers.txt"));
            foreach (string line in readFile)
            {
                sumAll += Convert.ToDouble(line);
            }
            Console.WriteLine("The sum of all numbers between {0} and {1} is {2}", high, low, sumAll);
        }
        public void findPrime()
        {   
            List<double> prime = new List<double>();
            bool isPrime = true;
            for (double i = high-1;  i > low; i--)
            {
                isPrime = true;
                for(double j = 2; j<= i; j++)
                {
                    Console.WriteLine("{0} {1} {2}",(i % j == 0 && (i != j)), i , j);
                    Console.WriteLine("{0}, {1}", (i % j == 0), (i != j));
                    if (i%j == 0 && (i !=j)) { isPrime = false; }
                }
                if (isPrime)
                {
                    prime.Add(i);
                }
            }
            Console.WriteLine("The Prime numbers between {0} and {1} are: ", low, high);
            foreach (double num in prime) { Console.WriteLine(num); }

        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {   
            HighLow user = new HighLow();
            Console.Write("Please enter a number greater than 0: ");
            double userLow = Convert.ToDouble(Console.ReadLine());
            while (userLow <= 0)
            {
                Console.Write("Number is less than or equal to 0, please enter one that is greater: ");
                userLow = Convert.ToDouble(Console.ReadLine());
            }
            Console.Write("Please enter a number greater than your previous number: ");
            double userHigh = Convert.ToDouble(Console.ReadLine());
            while (userHigh <= userLow)
            {
                Console.Write("{0} is less than or equal to {1}, please enter one that is greater: ", userHigh, userLow);
                userHigh = Convert.ToDouble(Console.ReadLine());
            }
            user.High = userHigh;
            user.Low = userLow;
            user.difference();
            user.betweenList();
            user.writeListToFile();
            user.readFromFile();
            user.findPrime();
        }
    }
}
