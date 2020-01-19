using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind
{
	/// <summary>
	/// Class represents MasterMind Game.
	/// </summary>
	public class MasterMind
	{
		public MasterMind()
		{

		}

		/// <summary>
		/// Generate a 4 digit random number
		/// </summary>
		private static int GenerateRandom4DigitNumber()
		{
			Random rnd = new Random();
			int[] numbers = new int[4];
			for (int i = 0; i < 4; i++)
			{
				numbers[i] = rnd.Next(1, 6);
				
			}
			return Convert.ToInt32(string.Concat(numbers));
		}

		/// <summary>
		/// Verify the user number with answer
		/// </summary>
		/// <param name="guessNumber">User guess number</param>
		/// <param name="correctAnswer">Correct answer</param>
		private static bool VerifyNumber(int guessNumber, int correctAnswer)
		{
			if(guessNumber == correctAnswer) { return true; }
			return false;
		}

		/// <summary>
		/// Convert user number to partial number if any digits match
		/// </summary>
		/// <param name="guessNumber">User guess number</param>
		/// <param name="correctAnswer">Correct answer</param>
		private static string PartialAnswer(int guessNumber,int correctAnswer)
		{
			string[] guessNumberArray = guessNumber.ToString().ToCharArray().Select(x => x.ToString()).ToArray();
			string[] correctAnswerArray = correctAnswer.ToString().ToCharArray().Select(x => x.ToString()).ToArray();

			// Replace correct digit with + if it is in same place as the correct answer.
			for(int i = 0; i < 4; i++)
			{
				if(guessNumberArray[i] == correctAnswerArray[i])
			    {
					guessNumberArray[i] = "+";
				}
			}

			// Replace correct digit with - if it is present in the correct answer.
			for (int i = 0; i < 4; i++)
			{
				if(correctAnswerArray.Contains(guessNumberArray[i]) && guessNumberArray[i] != "+")
				{
					guessNumberArray[i] = "-";
				}
			}

			return string.Concat(guessNumberArray);
		}

		/// <summary>
		/// Process the number giver by user
		/// If the number matches return answer
		/// If the number partially matches return partial number
		/// If the number doesnot match return the user number
		/// </summary>
		/// <param name="correctAnswer"></param>
		public void ProcessNumber(int correctAnswer)
		{
			string partialAnswer = string.Empty;
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("Enter your {0} number", i+1);

				int userGuessNumber = Convert.ToInt32(Console.ReadLine());

				if(userGuessNumber.ToString().Length > 4) { Console.WriteLine("Please Enter 4 digit Number"); continue; }

				bool isCorrectAnswer = VerifyNumber(userGuessNumber, correctAnswer);

				if (isCorrectAnswer)
				{
					Console.WriteLine("Hurray your answer is right !!! : {0}", correctAnswer);
					return;
				}
				else
				{
					partialAnswer = PartialAnswer(userGuessNumber, correctAnswer);
					if (!partialAnswer.Contains("+"))
					{
						Console.WriteLine("Your number is not matched or not partially matched");
					}
					else
					{
						Console.WriteLine("Your number is partially matched");
					}
				}
				Console.WriteLine(partialAnswer);
			}
			Console.WriteLine("Better Luck Next Time!!!, The Correct Answer is {0}", correctAnswer);
		}


		public static void Main(string[] args)
		{
			Console.WriteLine("Welcome to the MasterMind");
			var masterMind = new MasterMind();
			masterMind.ProcessNumber(GenerateRandom4DigitNumber());
			Console.ReadLine();
		}
	}
}
