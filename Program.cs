using System;
using System.Text;
namespace program
{

#nullable disable
    class hangMan
    {
        static void Main(string[] args)
        {
            string word = "secret word";
            string[] hangmanErrors = { "|   O", "|   |", "|  /|\\", "|   |", "|  / \\" };
            string[] hangman = { "|   ", "|   ", "|   ", "|   ", "|   ", "|   ", "|   " };
            List<char> guessedLetters = new List<char>();
            List<char> wordList = word.ToList<char>();
            int errorCounter = 0;
            char[] hiddenWordChars = word.ToCharArray();
            for (int i = 0; i < hiddenWordChars.Length; i++)
            {
                if (hiddenWordChars[i] == ' ')
                {
                    hiddenWordChars[i] = ' ';
                }
                else
                {
                    hiddenWordChars[i] = '_';
                }
            }
            string hiddenWord = string.Join(" ", hiddenWordChars);
            string userGuess = "";
            bool onPlay = true;
            Console.WriteLine("Welcome to HangMan game, guess the word below");
            while (onPlay)
            {
                bool alreadyGuessed = true;
                Console.WriteLine("======");
                for (int i = 0; i < hangman.Length; i++)
                {
                    Console.WriteLine(hangman[i]);
                }
                Console.WriteLine("----------------");
                Console.WriteLine(hiddenWord);
                Console.Write("Your guess : ");
                userGuess = Console.ReadLine();
                char userGuessChar = emptyStringCheck(userGuess);
                while (alreadyGuessed)
                {
                    if (guessedLetters.Contains(userGuessChar) && !hiddenWordChars.Contains(userGuessChar))
                    {
                        userGuess = Console.ReadLine();
                        userGuessChar = emptyStringCheck(userGuess);
                    }
                    else
                    {
                        alreadyGuessed = false;
                    }
                }
                bool letterFound = false;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i] == userGuessChar)
                    {
                        hiddenWordChars[i] = word[i];
                        hiddenWord = string.Join(" ", hiddenWordChars);
                        Console.WriteLine(hiddenWord);
                        letterFound = true;
                        guessedLetters.Add(userGuessChar);
                    }
                }
                if (!letterFound)
                {
                    hangman[errorCounter] = hangmanErrors[errorCounter];
                    errorCounter++;
                }
                Console.Clear();
                int num = 0;
                for (int i = 0; i < hiddenWordChars.Length; i++)
                {
                    if (hiddenWordChars[i] == word[i])
                    {
                        num++;
                    }
                }
                if (num == word.Length || num == hiddenWordChars.Length)
                {
                    Console.WriteLine("You won");
                    onPlay = false;
                }
                if (errorCounter == hangmanErrors.Length)
                {
                    Console.WriteLine("Game Over");
                    onPlay = false;
                }
            }
            Console.WriteLine("======");
            for (int i = 0; i < hangman.Length; i++)
            {
                Console.WriteLine(hangman[i]);
            }
        }

        private static char emptyStringCheck(string str)
        {
            char c = ' ';
            while (str == null || str == string.Empty || str.Length != 1)
            {
                Console.WriteLine("Please put one letter");
                str = Console.ReadLine();
            }
            return c = str[0];
        }

    }
}