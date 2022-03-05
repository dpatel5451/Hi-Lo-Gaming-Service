/*
* Filename		:	Program.cs
* Project		:	PROG2121 - Assignment 05 
* Programmer	:	Purv Ketankumar Pandya & Deep Kalpeshkumar Patel
* First Version	:	05/11/2021
* Description	:	Run the welcome page for the High Low WPF game.
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGameClient
{

	/* Name     : Program
    * Purpose   : The purpose of this class is to setup an interesting Hi-Lo game for user.
    */
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new WelcomePage());
		}
	}
}
