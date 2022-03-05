/*
* Filename		:	GameUI.cs
* Project		:	PROG2121 - Assignment 05 
* Programmer	:	Purv Ketankumar Pandya & Deep Kalpeshkumar Patel
* First Version	:	05/11/2021
* Description	:	Handles the main game component for the user. 
*					It sends the user guessed number to the server for processing.
*/



using System;
using System.Windows.Forms;
using System.Net.Sockets;


namespace GuessingGameClient
{

	/* Name     : GameUI
    * Purpose   : The purpose of this class is to setup the Game UI for the user.
    */
	public partial class GameUI : Form
	{

		private int clientID;	// stores the current user's client ID



		/*  -- Method Header Comment
	        Name	:	GameUI --- CONSTRUCTOR 
	        Purpose :	To instantiate all the components of GameUI().
	        Inputs	:	NONE
	        Returns	:	Nothing
        */
		public GameUI()
		{
			InitializeComponent();
		}




		/*  -- Method Header Comment
	        Name	:	Form2_Load 
	        Purpose :	Display the allowed range message that is returned by the server 
						and initialize the clientID for the user using the 
						allowedRange and clientID variables from the WelcomePage window.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
		private void Form2_Load(object sender, EventArgs e)
		{
			allowedRangeMessage.Text = WelcomePage.allowedRange;
			clientID = WelcomePage.clientID - 1;
		}





		/*  -- Method Header Comment
	        Name	:	MakeGuess_click 
	        Purpose :	Sends the guessed number to the server.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
		private void MakeGuess_click(object sender, EventArgs e)
		{
			try
			{
				// If the guessed number input field is not empty then proceed else show error
				if (InputValid())
				{
					int guessedNumber;	// stores the number guessed by the user

					// If the user entered a valid integer then send the guessed number to the server else show error
					if (Int32.TryParse(userGuess.Text, out guessedNumber))
					{
						if (guessedNumber >= 1)
						{
							string IpAddress = WelcomePage.IpAddress;	// copy the IP address from the IpAddress variable populated in WelcomePage window
							string portNumber = WelcomePage.portNumber; // copy the port from the portNumber variable populated in WelcomePage window

							// Send data to the server for checking the guessed number by sending a message with command "Check guess" and data like the clientID and the guessed number
							string response = WelcomePage.ConnectClient(IpAddress, Int32.Parse(portNumber), "Check guess" + "|" + clientID.ToString() + "|" + guessedNumber.ToString());
							
							// If the response string is "You won" then the user guessed the correct number
							if (response == "You won")
							{
								// Ask the user if they wishes to play again or quit
								DialogResult dr = MessageBox.Show("You guessed the number... You Won!!\nDo you wish to play again?", "Play again", MessageBoxButtons.YesNo);
								
								// If the user wishes to play again then restart the user's game by sending a message to the server
								if (dr == DialogResult.Yes)
								{
									// Send data to the server for restarting the game by sending a message with command "Restart" and data like the clientID
									response = WelcomePage.ConnectClient(IpAddress, Int32.Parse(portNumber), "Restart|" + clientID);

									// If the server was successfully able to restart the game for the server then display the allowed range message again
									if (response.Contains("OK"))
									{
										response = response.Remove(0, 2);
										allowedRangeMessage.Text = response;
										userGuess.Text = "";
									}
								}
								// Else the user does not want to play again. So tell the server to delete the user 
								else
								{
									// Send data to the server for deleting the user by sending a message with command "Delete" and the clientID
									response = WelcomePage.ConnectClient(IpAddress, Int32.Parse(portNumber), "Delete|" + clientID);
									
									// If the server cannot delete the user then show error
									if (response != "OK")
									{
										MessageBox.Show("Unable to delete the user!");
									}
									else
									{
										this.Close();
									}
								}
							}
							else if (response == "Failed")
							{
								// The client is not able to reach the server
								MessageBox.Show("Unable to connect to the server..Make sure the server is running!");
							}
							else
							{
								allowedRangeMessage.Text = response;
							}
						}
						else
						{
							// The user guessed a number less than 1
							MessageBox.Show("Guessed number must be greater than or equal to 1!!", "Input error");
						}
					}
					else
					{
						// The user entered a non-integer value for the guessed number input field
						MessageBox.Show("Guessed number needs to be an integer!!", "Input error");
					}
				}
				else
				{
					// The user did not make a guess and pressed the button
					MessageBox.Show("Guessed number cannot be blank!!", "Input error");
				}
			}
			catch (ArgumentNullException error)
			{
				//Catches ArgumentNullException exception and prints appropriate error to user.   
				MessageBox.Show("Null exception..\nException: " + error.Message + "\nPlease try again!", "Connection error");
			}
			catch (SocketException error)
			{
				//Catches SocketException exception and prints appropriate error to user.   
				MessageBox.Show("Cannot connect to the server..\nException: " + error.Message + "\nPlease try again!", "Connection error");
			}
			catch (Exception error)
			{
				//Catches any other type of exception and prints appropriate error to user.   
				MessageBox.Show("Hmm..You tried something irregular..\nException: " + error.Message + "\nPlease try again!", "Connection error");
			}
			finally
			{
				userGuess.Text = "";
			}
		}




		/*  -- Method Header Comment
	        Name	:	InputValid 
	        Purpose :	Validate if the userGuess input field is not empty.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Returns true if the input field is not empty else return false
        */
		private bool InputValid()
		{

			if (userGuess.Text.Length != 0)
			{
				return true;
			}
			return false;
		}




		/*  -- Method Header Comment
	        Name	:	Quit_Click 
	        Purpose :	This button is used by the user to end the game session at any point during the game.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
		private void Quit_Click(object sender, EventArgs e)
		{

			// Ask the user if they really wish to quit the game session
			DialogResult dr = MessageBox.Show("Are you sure you wish to quit the game?", "Quit", MessageBoxButtons.YesNo);
			
			// If the user wishes to end the game session then send the info to the server
			if (dr == DialogResult.Yes)
			{
				// Send data to the server to delete the user by sending a message with command "Delete" and the clientID
				string response = WelcomePage.ConnectClient(WelcomePage.IpAddress, Int32.Parse(WelcomePage.portNumber), "Delete|" + clientID);

				// If the server cannot delete the user then show error
				if (response != "OK")
				{
					MessageBox.Show("Unable to delete the user!");
				}
				else
				{
					this.Close();
				}
			}

		}

	}
}
