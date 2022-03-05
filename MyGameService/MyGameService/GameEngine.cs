/*
* Filename		:	GameEngine.cs
* Project		:	PROG2121 - Assignment 06 
* Programmer	:	Purv Ketankumar Pandya & Deep Kalpeshkumar Patel
* First Version	:	11/05/2021
* Description	:	It manages Hi-Lo game logic. It checks if user entered guess 
*					is too low and too high than answer and prompts according statement
*					to the user.
*/




using System;
using System.Collections.Generic;
using System.Configuration;

namespace MyGameService
{

	/* Name     : GameEngine
    * Purpose   : The purpose of this class is to handle the entire game logic for the High low game.
    */
	class GameEngine
	{

		//Instantiating userInfoMap as an Dictionary(int, userData) object to store all users state info
		Dictionary<int, UserData> userInfoMap = new Dictionary<int, UserData>();

		// Get the max guess value from the config file
		string maxGuess = ConfigurationManager.AppSettings.Get("maxRangeNumber");
		


		/*  -- Method Header Comment
	        Name	:	ProcessData 
	        Purpose :	To show user their range of game.
	        Inputs	:	data			 string
	        Returns	:	string		-	 Response for the game.
        */
		public string ProcessData(string data)
		{
			string response;    // The string that is to be returned

			//Checks if data string contains "connect". If it does then a new user need to be added.
			if (data.Contains("Connect"))
			{
				//Generates random number.
				Random rnd = new Random();

				int minGuessNumber = 1;

				//Splits the info string into substring and stores it into "info" string array.
				string[] info = data.Split('|');

				//Parses maxGuess and stores it in maxGuessNumber.
				int maxGuessNumber = Int32.Parse(maxGuess);

				//Generates random number using minGuessNumber and maxGuessNumber and stores it into answer int.
				int answer = rnd.Next(minGuessNumber, maxGuessNumber + 1);

				//Instatiating newUser as an UserData class.
				UserData newUser = new UserData();

				//Stores userName taken from "info" string array.
				newUser.UserName = info[2];

				//Stores maxGuessNumber for the current user
				newUser.MaxGuessNumber = maxGuessNumber;

				//Stores minGuessNUmber for the current user
				newUser.MinGuessNumber = minGuessNumber;

				//Stores answer for the current user
				newUser.Answer = answer;
				// Adds the new user to the dictionary
				userInfoMap.Add(Int32.Parse(info[1]), newUser);

				//Prompts user their guessing range.
				response = newUser.UserName + "- Your allowable range is from " +
					minGuessNumber + " to " + maxGuessNumber + ".";

			}

			//If the data stirng contains "Check guess" then engine needs to check if the guessed number is too low or too high
			else if (data.Contains("Check guess"))
			{

				//Splits a string into substring and stores it into "info" string array.
				string[] info = data.Split('|');
				int currentUserID = Int32.Parse(info[1]);

				//Copy the minGuessNumber for the current user from the Dictionary.
				int minGuessNumber = userInfoMap[currentUserID].MinGuessNumber;

				//Copy the maxGuessNumber for the current user from the Dictionary.
				int maxGuessNumber = userInfoMap[currentUserID].MaxGuessNumber;

				//Copy the answer for the current user from the Dictionary.
				int answer = userInfoMap[currentUserID].Answer;

				string guessed = info[2];

				//Parses "guessed" and stores it into int guessedNumber. 
				int guessedNumber = Int32.Parse(guessed);

				//Checks if user enetered guess is out of range.
				if (guessedNumber < minGuessNumber || guessedNumber > maxGuessNumber)
				{
					//Prompts user their guessing range.
					response = "Your guessed number was outside of the allowable range\n" +
								"Your allowable range is from " +
								minGuessNumber + " to " + maxGuessNumber;
				}
				else
				{
					//Checks if user entered guess is bigger than answer.
					if (guessedNumber > answer)
					{
						//Subtracts 1 from maxGuessNumber.
						maxGuessNumber = guessedNumber - 1;

						// update the maxGuessNmber for the current user
						userInfoMap[currentUserID].MaxGuessNumber = maxGuessNumber;

						//Prompts user their guessing range.
						response = "Your guess was slightly high!" +
									"\nNow your allowable range is from " +
									minGuessNumber + " to " + maxGuessNumber;

					}

					//Checks if user entered guess is lower than answer.
					else if (guessedNumber < answer)
					{
						//Adds 1 to minimumGuessNumber.
						minGuessNumber = guessedNumber + 1;

						// update the minGuessNumber for the current user
						userInfoMap[currentUserID].MinGuessNumber = minGuessNumber;

						//Prompts user their guessing range.
						response = "Your guess was slightly low!" +
									"\nNow your allowable range is from " +
									minGuessNumber + " to " + maxGuessNumber;
					}
					else
					{
						//If user entered guess is same as answer, it will prompt user that they WON.
						response = "You won";
					}
				}
			}

			// If data string contains "Restart" then engine needs to restart the game for the user
			else if (data.Contains("Restart"))
			{
				Random rnd = new Random();

				//Set minGuessNumber to 1.
				int minGuessNumber = 1;

				//Parses maxGuess and stores it into maxGuessNumber.
				int maxGuessNumber = Int32.Parse(maxGuess);

				//Generates new  random number using minGuessNumber and maxGuessNumber and stores it into answer int.
				int answer = rnd.Next(minGuessNumber, maxGuessNumber + 1);

				//Splits a string into substring and stores it into "info" string array.
				string[] info = data.Split('|');

				//Parses info string array[1] and stores it into currentUserID int.
				int currentUserID = Int32.Parse(info[1]);

				//Stores maxGuessNumber for the current user into dictionary.
				userInfoMap[currentUserID].MaxGuessNumber = maxGuessNumber;

				//Stores minGuessNumber for the current user into dictionary.
				userInfoMap[currentUserID].MinGuessNumber = minGuessNumber;

				//Stores answer for the current user into dictionary.
				userInfoMap[currentUserID].Answer = answer;

				//Prompts user their guessing range.
				response = "OK" + userInfoMap[currentUserID].UserName + "- Your allowable range is from " +
					minGuessNumber + " to " + maxGuessNumber;
			}

			// If data string contains "Delete" then engine needs to delete the user from the dictionary
			else if (data.Contains("Delete"))
			{
				//Splits a string into substring and stores it into "info" string array.
				string[] info = data.Split('|');

				//Parses info string array and stores it into deleteUser int.
				int deleteUser = Int32.Parse(info[1]);
				userInfoMap.Remove(deleteUser);

				response = "OK";
			}
			else
			{
				//If any other msgs are contained in Data string, it will store error in response string.
				response = "Unidentified message!!";
			}
			return response;
		}
	}
}
