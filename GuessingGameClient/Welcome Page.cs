/*
* Filename		:	WelcomePage.cs
* Project		:	PROG2121 - Assignment 05 
* Programmer	:	Purv Ketankumar Pandya & Deep Kalpeshkumar Patel
* First Version	:	05/11/2021
* Description	:	Handles the connecting of a user to the game and 
*					creates a new game window for the new user. All users 
*					start their game from this welcome page.
*/




using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Configuration;


namespace GuessingGameClient
{

	/* Name     : WelcomePage
    * Purpose   : The purpose of this class is to connect a new user to the game and start their game instance window.
    */
	public partial class WelcomePage : Form
	{

		public static string allowedRange = "";		// used to pass the allowedRange message to the new GameUI window
		public static string IpAddress = "";		// used to pass the IP Address info to the new GameUI window
		public static string portNumber = "";		// used to pass the port number info to the new GameUI window
		public static int clientID = 0;				// used to specify the clientID to each new GameUI window for different users.




		/*  -- Method Header Comment
	        Name	:	WelcomePage --- CONSTRUCTOR 
	        Purpose :	To initialize the WelcomePage window.
	        Inputs	:	NONE
	        Returns	:	Nothing
        */
		public WelcomePage()
		{
			InitializeComponent();

		}




		/*  -- Method Header Comment
	        Name	:	Form1_Load 
	        Purpose :	To instantiate Form1_Load method.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
		private void Form1_Load(object sender, EventArgs e)
		{

		}




		/*  -- Method Header Comment
	        Name	:	StartGame_Click() 
	        Purpose :	To connect the user to the game and 
						open a new game window for the user.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Nothing
        */
		private void StartGame_Click(object sender, EventArgs e)
		{
			try
			{
				// Check if all input fields are provided by the user
				if (InputValid())
				{
					int portValue = 0;	// store the port number
					
					// Check if the port entered by the user is a valid integer
					if (Int32.TryParse(port.Text, out portValue))
					{
						IpAddress = ipAddr.Text;	// copy the IP address entered by the user from the input field 
						portNumber = port.Text;     // copy the port entered by the user from the input field 

						// Connect the new client to the server by passing the command "Connect" and data like the clientID and the userName
						string response = ConnectClient(ipAddr.Text, Int32.Parse(port.Text), "Connect" + "|" + clientID + "|" + userName.Text);

						// If the server was able to connect the client then start a GameUI window for the new user
						// Else show error message
						if (response != "Failed")
						{
							clientID++;		// increment the clientID for the new user/GameUI window
							allowedRange = response;	
							GameUI game = new GameUI();	
							game.Show();	// open the new GameUI window for the new user
						}
						else
						{
							MessageBox.Show("Unable to connect to the game server\n" +
								"Please make sure the IP address and the port are correct", "Connection Error");
							ipAddr.Text = "";
							port.Text = "";
						}

					}
					else
					{
						MessageBox.Show("You need to enter a number", "Input error");
						ipAddr.Text = "";
						port.Text = "";
					}
				}
				else
				{
					MessageBox.Show("Please provide all information", "Input error");
				}
			}
			catch (ArgumentNullException error)
			{
				//Catches ArgumentNullException exception and prints appropriate error to user.   
				MessageBox.Show("Null exception..\nException: " + error.Message + "/nPlease try again!!", "Connection error");
				ipAddr.Text = "";
				port.Text = "";
			}
			catch (SocketException error)
			{
				//Catches SocketException exception and prints appropriate error to user.   
				MessageBox.Show("Cannot connect to the server..\nException: " + error.Message + "\nPlease try again!", "Connection error");
				ipAddr.Text = "";
				port.Text = "";
			}
			catch (ArgumentOutOfRangeException error)
			{
				//Catches ArgumentOutOfRangeException exception and prints appropriate error to user.   
				MessageBox.Show("Out of range exception..\nException: " + error.Message + "\nPlease try again!", "Connection error");
				ipAddr.Text = "";
				port.Text = "";
			}
			catch (AggregateException error)
			{
				//Catches AggregateException exception and prints appropriate error to user.   
				MessageBox.Show("Invalid data..\nException: " + error.Message + "\nPlease try again!", "Connection error");
			}
			catch (Exception error)
			{
				//Catches any other type of exception and prints appropriate error to user.   
				MessageBox.Show("Hmm..You tried something irregular..\nException: " + error.Message + "\nPlease try again!", "Connection error");
			}

		}




		/*  -- Method Header Comment
	        Name	:	InputValid 
	        Purpose :	Validate if the user name, IP address and the port are not empty.
	        Inputs	:	sender				object				
                        e                   RoutedEventArgs
	        Returns	:	Returns true if all fields are not empty otherwise returns false.
        */
		private bool InputValid()
		{
			if (userName.Text.Length != 0 && ipAddr.Text.Length != 0 && port.Text.Length != 0)
			{
				return true;
			}
			return false;
		}




		/*  -- Method Header Comment
	        Name	:	ConnectClient 
	        Purpose :	Connects the client to the game server using the provided IP, port 
						and sends the provided message.
	        Inputs	:	ip				string
                        port            int
						message			string
	        Returns	:	Returns the response string returned by the server.
        */
		public static string ConnectClient(string ip, int port, string message)
		{
			string response = "Failed";		// stores the response returned by the server

			try
			{
				TcpClient client = new TcpClient();
				// If the connection is not successful for a second then there is a problem so quit
				if (!client.ConnectAsync(IPAddress.Parse(ip), port).Wait(1000))
				{
					response = "Failed";
					return response;
				}


				Byte[] data = System.Text.Encoding.ASCII.GetBytes(message);	// used to send the message to the server

				NetworkStream stream = client.GetStream();

				stream.Write(data, 0, data.Length);		// write the message to the server

				data = new Byte[256];

				int bytes = stream.Read(data, 0, data.Length);	// read the response string from the server
				response = System.Text.Encoding.ASCII.GetString(data, 0, bytes);	// parse the response string
				stream.Close();		// close the network stream
				client.Close();		// close the Tcp client 
			}
			catch
			{
				throw;
			}

			return response;

		}

	}

}



