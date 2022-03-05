/*
* Filename		:	WelcomePage.Designer.cs
* Project		:	PROG2121 - Assignment 05 
* Programmer	:	Purv Ketankumar Pandya & Deep Kalpeshkumar Patel
* First Version	:	05/11/2021
* Description	:	
*/


namespace GuessingGameClient
{

	/* Name     : WelcomPage
    * Purpose   : The purpose of this class is to setup an interesting Hi-Lo game for user.
    */
	partial class WelcomePage
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.button1 = new System.Windows.Forms.Button();
			this.userName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.ipAddr = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.port = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(334, 345);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 46);
			this.button1.TabIndex = 0;
			this.button1.Text = "Start game";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.StartGame_Click);
			// 
			// userName
			// 
			this.userName.Location = new System.Drawing.Point(334, 163);
			this.userName.Name = "userName";
			this.userName.Size = new System.Drawing.Size(100, 22);
			this.userName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(248, 168);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "User Name:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(248, 215);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(76, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "IP Address:";
			// 
			// ipAddr
			// 
			this.ipAddr.Location = new System.Drawing.Point(334, 212);
			this.ipAddr.Name = "ipAddr";
			this.ipAddr.Size = new System.Drawing.Size(100, 22);
			this.ipAddr.TabIndex = 4;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(290, 271);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Port:";
			// 
			// port
			// 
			this.port.Location = new System.Drawing.Point(334, 266);
			this.port.Name = "port";
			this.port.Size = new System.Drawing.Size(100, 22);
			this.port.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
			this.label4.Location = new System.Drawing.Point(144, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(506, 39);
			this.label4.TabIndex = 7;
			this.label4.Text = "Welcome to the Guessing Game";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(302, 106);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(151, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Please enter information";
			// 
			// WelcomePage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.port);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.ipAddr);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.userName);
			this.Controls.Add(this.button1);
			this.Name = "WelcomePage";
			this.Text = "Guessing Game Welcome Page";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox userName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox ipAddr;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox port;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}

