/*
 * FILENAME			:	GameService.cs
 * PROJECT			:	PROG2121 - Assignment 06 
 * PROGRAMMER		:	Purv Ketankumar Pandya & Deep Kalpeshkumar Patel
 * FIRST VERSION	:	11/21/2021
 * PURPOSE			:	This service runs a server that gets the requests from the game client
 *						and sends the response.
 * 
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Configuration;


namespace MyGameService
{
	/* Name      : GameService
    *  Purpose   : The purpose of this class is to manage the server.
    */
	public partial class GameService : ServiceBase
    {

        //Declaring private Thread named as ServerThread for handling the server
        private Thread ServerThread;

		private TcpListener server = null;	
        private GameEngine gameProcessing = new GameEngine();



		/*  -- Constructor Header Comment
	        Name	:	GameService()
	        Purpose :	Initialize the components and set CanPauseAndContinue to false.
	        Inputs	:	NONE
	        Returns	:	NONE
        */
		public GameService()
        {
            InitializeComponent();
            CanPauseAndContinue = false;
        }



		/*  -- Method Header Comment
	        Name	:	OnStart() 
	        Purpose :	Starts the server as a new thread.
	        Inputs	:	args			 string[]
	        Returns	:	NOTHING		
        */
		protected override void OnStart(string[] args)
        {
            DateTime date = DateTime.Now;

			Logger.Log(date.ToString() + " Service Started\n");		// log that the service has started
			try
			{
				ServerThread = new Thread(new ThreadStart(Start));
				ServerThread.Start();
			}
			catch
			{
				throw;
			}
		}


		/*  -- Method Header Comment
           Name		:	Start 
           Purpose  :	To instantiate Start method.
           Inputs	:	NONE
           Returns	:	Nothing
       */
		private void Start()
		{

			//Instantiating server as TcpListener object.
			try
			{
				DateTime date = DateTime.Now;

				//Gets ipAddress and port from the config file and stores it in strings
				string ip = ConfigurationManager.AppSettings.Get("ipAddr");
				string portNum = ConfigurationManager.AppSettings.Get("port");

				//Instantiating localAddr as an IPAddress object.
				IPAddress localAddr = IPAddress.Parse(ip);

				//Passes localAddr & parsed portNum to TcpListener and will store into server. 
				server = new TcpListener(localAddr, Int32.Parse(portNum));

				//Starts the server.
				server.Start();

				//While loop will continue until Run variable is true. 
				while (true)
				{

					//Checks if there are any pending connection requests.
					if (!server.Pending())
					{
						// do nothing
					}
					else
					{
						//Instantiating ServerThread and starting server thread.
						date = DateTime.Now;

						Byte[] bytes = new Byte[256];
						string data = null;

						//Instantiating gameProcessing as an GameEngine object.

						//Instantiating client as an TcpClient object & It also accepts a pending server connection request.
						TcpClient client = server.AcceptTcpClient();

						data = null;

						//Instantiating stream as an NetworkStream object and It also sends and recieve data.
						NetworkStream stream = client.GetStream();

						int length = 0;

						//Loop will continue until all data is not read.
						while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
						{
							//Stores the incoming message.
							data = System.Text.Encoding.ASCII.GetString(bytes, 0, length);
							string response = gameProcessing.ProcessData(data);
							//Stores the outgoing response message by calling the ProcessData method in GameEngine.
							byte[] msg = System.Text.Encoding.ASCII.GetBytes(response);
							//Writes data to NetworkStream.
							stream.Write(msg, 0, msg.Length);

						}

						//Disposes TcpClient instance and requests that underlying TCP connection to be closed. 
						client.Close();
					}


				}
				//Wait for ServerThread to finish.
				server.Stop();


			}
			catch (Exception er)
			{
				Logger.Log("[Exception]: " + er.Message + "\n");

			}

		}




		/*  -- Method Header Comment
	        Name	:	OnStop() 
	        Purpose :	Logs that the service has stopped.
	        Inputs	:	NONE
	        Returns	:	NOTHING		
        */
		protected override void OnStop()
		{

			DateTime date = DateTime.Now;
			Logger.Log(date.ToString() + " Service Stopped\n");
			
		}



		
	}
}
