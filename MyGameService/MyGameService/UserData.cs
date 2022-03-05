/*
* Filename		:	UserData.cs
* Project		:	PROG2121 - Assignment 06
* Programmer	:	Purv Ketankumar Pandya & Deep Kalpeshkumar Patel
* First Version	:	05/11/2021
* Description	:	It declares 4 variables for game such as userName, maxGuessNumber,
*					minGuessNumber & answer. It also gets and sets all 4 variables for
*					Hi-Lo game to create a fantastic experience for user.
*/




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGameService
{

	/* Name     : UserData
    * Purpose   : The purpose of this class is to setup an interesting Hi-Lo game for user.
    */
	class UserData
	{
		//Declaring userName variable as an private string.
		private string userName;


		/*  -- Method Header Comment
	        Name	:	UserName 
	        Purpose :	To get and set UserName variable.
	        Inputs	:	NONE
	        Returns	:	string		-		userName
        */
		public string UserName
		{
			get
			{ return userName; }
			set
			{ userName = value; }
		}


		//Declaring maxGuessNumber variable as an private int.
		private int maxGuessNumber;


		/*  -- Method Header Comment
	        Name	:	MaxGuessNumber 
	        Purpose :	To get and set MaxGuessNumber variable.
	        Inputs	:	NONE
	        Returns	:	int		-		MaxGuessNumber
        */
		public int MaxGuessNumber
		{
			get
			{ return maxGuessNumber; }
			set
			{
				//Checks if value is greater than 0.
				if (value > 0)
				{
					maxGuessNumber = value;
				}
			}
		}


		//Declaring minGuessNumber variable as an private int.
		private int minGuessNumber;


		/*  -- Method Header Comment
	        Name	:	MinGuessNumber 
	        Purpose :	To get and set MinGuessNumber variable.
	        Inputs	:	NONE
	        Returns	:	int		-		MinGuessNumber
        */
		public int MinGuessNumber
		{
			get
			{ return minGuessNumber; }
			set
			{
				//Checks if value is greater than 0.
				if (value > 0)
				{
					minGuessNumber = value;
				}
			}
		}


		//Declaring answer variable as an private int.
		private int answer;


		/*  -- Method Header Comment
	        Name	:	Answer 
	        Purpose :	To get and set Answer variable.
	        Inputs	:	NONE
	        Returns	:	int		-		Answer
        */
		public int Answer
		{
			get
			{ return answer; }
			set
			{
				//Checks if value is greater than 0.
				if (value > 0)
				{
					answer = value;
				}
			}
		}

	}
}
