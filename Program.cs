using System;
using System.Text;
namespace program
{
    class hangMan
    {
        static void Main(string[] args)
        {
            string word = "secret word";
            string[] hangmanErrors = { "|   O", "|   |", "|  /|\\", "|   |", "|  / \\" };
            string[] hangman = { "|   ", "|   ", "|   ", "|   ", "|   ", "|   ", "|   " };
            List<char> guessedLetters = new List<char>();
            int errorCounter = 0;
            char[] hiddenWordChars = word.ToCharArray();
            for (int i = 0; i < hiddenWordChars.Length; i++)
            {
                if(hiddenWordChars[i] == ' ')
                {
                    hiddenWordChars[i] = ' ';
                }
                else
                {
                hiddenWordChars[i] = '_';
                }
            }
            string hiddenWord = string.Join(" ", hiddenWordChars);
            string? userGuess = "";
            bool onPlay = true;
            Console.WriteLine("Welcome to HangMan game, guess the word below");
            while (onPlay)
            {
                Console.WriteLine("======");
                for (int i = 0; i < hangman.Length; i++)
                {
                    Console.WriteLine(hangman[i]);
                }
                Console.WriteLine("----------------");
                Console.WriteLine(hiddenWord);
                Console.Write("Your guess : ");
                userGuess = Console.ReadLine();
                while (userGuess == null || userGuess == string.Empty || userGuess.Length > 1)
                {
                    Console.WriteLine("please put one letter");
                    userGuess = Console.ReadLine();
                }
                char userGuessChar = Convert.ToChar(userGuess);
                if(guessedLetters.Contains(userGuessChar))
                {
                    Console.Clear();
                    Console.WriteLine("You already guessed that letter");
                    continue;
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
                for(int i = 0; i < hiddenWordChars.Length; i ++)
                {
                    if(hiddenWordChars[i] == word[i])
                    {
                        num++;
                    }
                }
                if(num == word.Length || num == hiddenWordChars.Length)
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

    }

}
