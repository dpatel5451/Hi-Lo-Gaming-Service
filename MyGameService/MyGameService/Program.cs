/*
 * FILENAME			:	Program.cs
 * PROJECT			:	Assignment 6
 * PROGRAMMER		:	Purv Ketankumar Pandya and Deep Kalpeshkumar Patel
 * FIRST VERSION	:	11/22/2021
 * PURPOSE			:	Runs the game service required.
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyGameService
{
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main()
		{
			ServiceBase[] ServicesToRun;
			ServicesToRun = new ServiceBase[]
			{
				new GameService()
			};
			ServiceBase.Run(ServicesToRun);

		}
	}
}
