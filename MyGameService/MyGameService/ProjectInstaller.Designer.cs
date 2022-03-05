﻿namespace MyGameService
{
	partial class ProjectInstaller
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.MyGameServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			this.MyGameServiceInstaller = new System.ServiceProcess.ServiceInstaller();
			// 
			// MyGameServiceProcessInstaller
			// 
			this.MyGameServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.MyGameServiceProcessInstaller.Password = null;
			this.MyGameServiceProcessInstaller.Username = null;
			// 
			// MyGameServiceInstaller
			// 
			this.MyGameServiceInstaller.ServiceName = "MyGameService";
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.MyGameServiceProcessInstaller,
            this.MyGameServiceInstaller});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller MyGameServiceProcessInstaller;
		private System.ServiceProcess.ServiceInstaller MyGameServiceInstaller;
	}
}