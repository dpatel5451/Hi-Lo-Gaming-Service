/*
 * FILENAME			:	Logger.cs
 * PROJECT			:	PROG2121 - Assignment 06 
 * PROGRAMMER		:	Purv Ketankumar Pandya & Deep Kalpeshkumar Patel
 * FIRST VERSION	:	11/22/2021
 * PURPOSE			:	Log the message to events as well as in a text file whose 
 *						location is same as the exe location.
 */


using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
namespace MyGameService
{
	public static class Logger
	{

		/* Name     : Log
		*  Purpose  : The purpose of this class is to log the incoming messages.
		*/
		public static void Log(string message)
		{

			EventLog log = new EventLog();
			
			/* If the event does not exist then create a new event source */
			if (!EventLog.SourceExists("MyGameServices"))
			{
				EventLog.CreateEventSource("MyGameServices", "GameServiceLog");
			}

			log.Source = "MyGameServices";
			log.Log = "GameServiceLog";
			
			// Get the exe path
			string path = System.AppDomain.CurrentDomain.BaseDirectory + "MyGameServiceLog.txt";
			
			log.WriteEntry(message);	// log the entry in the events
			File.AppendAllText(path, message);	// log the entry in the text file
		}
	}
}
