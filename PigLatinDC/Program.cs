using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PigLatinDC
{
    class Program
    {
        static void Main(string[] args)
        {

            string words;

            //Recieve input from user
            Console.WriteLine("Enter a sentence with only letters and spaces: ");
            words = Console.ReadLine();

            //Checks that the string doesn't contain letters or symbols
            while(Regex.IsMatch(words, @"\d")){
                Console.WriteLine("That contains numbers or symbols, try again");
                Console.ReadLine();
            }

            

            //Calls the method and outputs the string in pig latin
            Console.Write(GetPigLatin(words));
            Console.ReadLine();            
        }

        public static string GetPigLatin(string words)
        {
            //This variable will be put at the end of the word
            string ay = "ay";

            //This will build the new string to output
            StringBuilder pigLatinConvert = new StringBuilder();

            //This checks to see if there are multiple spaces between words and changes it to one
            words = Regex.Replace(words, @"\s+", " ");
            
            //This takes the input string and separates each into an array
            string[] elements = Regex.Split(words, " ");
            foreach(string word in elements)
            {

                //First I remove the first letter of each word and put "ay" at the end of it
                string firstLetter = word[0].ToString() + ay;

                //Then remove the first letter from the word
                string removeFirstLetter = word.ToString().Remove(0,1);

                //Then construct the new word
                string pigWord = removeFirstLetter.ToLower() + firstLetter.ToLower();

                //Puts the new word in the StringBuilder
                pigLatinConvert.Append(pigWord + " ");
                
            }
            //Output the Pig Latin phrase
            return pigLatinConvert.ToString();
        }

        
    }
}
