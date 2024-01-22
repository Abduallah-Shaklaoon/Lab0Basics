using System;
using System.Collections.Generic;
using System.IO;

namespace Lab0Basics
{
    class HighLow
    {
        //All variables used across HighLow
        private double low;
        private double high;
        private double dif;
        private List<double> betweenNums = new List<double>();
        private double sumAll;

        //Getters and setters for all necessary variables in HighLow
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
        //Method that calculates the difference between high and low
        public void difference()
        {
            dif = high-low;
            Console.WriteLine("The difference between {0} and {1} is {2}", high, low, dif);
        }
        //Method that adds all numbers between the high and low to a list
        public void betweenList()
        {
            for (double i = high-1; i > low; i--)
            {
                betweenNums.Add(i);
            }
        }
        //Method that takes all data from the list and adds it to a file
        public void writeListToFile()
        {
            List<string> stringNum = new List<string>();
            foreach (double i in betweenNums)
            {
                stringNum.Add(i.ToString());
            }
            File.WriteAllLines("numbers.txt", stringNum);
        }
        //Method that reads data from a file and finds the sum of all numbers from the file
        public void readFromFile()
        {
            List<string> readFile = new List<string>(File.ReadAllLines("numbers.txt"));
            foreach (string line in readFile)
            {
                sumAll += Convert.ToDouble(line);
            }
            Console.WriteLine("The sum of all numbers between {0} and {1} is {2}", high, low, sumAll);
        }
        //Method that finds every prime number and prints a every prime number between low and high
        public void findPrime()
        {   
            List<double> prime = new List<double>();
            bool isPrime;
            for (double i = high-1;  i > low; i--)
            {
                isPrime = true;
                for(double j = 2; j<= i; j++)
                {
                    if (i%j == 0 && (i !=j)) { isPrime = false; }
                }
                if (isPrime)
                {
                    prime.Add(i);
                }
            }
            if (prime.Count != 0)
            {
                Console.WriteLine("The Prime numbers between {0} and {1} are: ", low, high);
                foreach (double num in prime) { Console.WriteLine(num); }
            }
            else { Console.WriteLine("There are no prime numbers between {0} and {1}", low, high); }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {   
            //HighLow object is created
            HighLow user = new HighLow();

            //User is asked for a low and high number, loops itterate till the user enters a number greater than 0 and greater than the low number for the high number
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
            //low and high are set
            user.High = userHigh;
            user.Low = userLow;

            //Methods called from HighLow
            user.difference();
            user.betweenList();
            user.writeListToFile();
            user.readFromFile();
            user.findPrime();
        }
    }
}
