/*
* Filename		:	GameUI.Designer.cs
* Project		:	PROG2121 - Assignment 05 
* Programmer	:	Purv Ketankumar Pandya & Deep Kalpeshkumar Patel
* First Version	:	05/11/2021
* Description	:	
*/





namespace GuessingGameClient
{

	/* Name     : GameUI
    * Purpose   : The purpose of this class is to setup an interesting Hi-Lo game for user.
    */
	partial class GameUI
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
			this.allowedRangeMessage = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.userGuess = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// allowedRangeMessage
			// 
			this.allowedRangeMessage.AutoSize = true;
			this.allowedRangeMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
			this.allowedRangeMessage.Location = new System.Drawing.Point(292, 238);
			this.allowedRangeMessage.Name = "allowedRangeMessage";
			this.allowedRangeMessage.Size = new System.Drawing.Size(228, 24);
			this.allowedRangeMessage.TabIndex = 0;
			this.allowedRangeMessage.Text = "Allowable range message";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.label2.Location = new System.Drawing.Point(242, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(278, 29);
			this.label2.TabIndex = 1;
			this.label2.Text = "Please enter your guess:";
			// 
			// userGuess
			// 
			this.userGuess.Location = new System.Drawing.Point(320, 132);
			this.userGuess.Name = "userGuess";
			this.userGuess.Size = new System.Drawing.Size(142, 22);
			this.userGuess.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(324, 176);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(138, 39);
			this.button1.TabIndex = 3;
			this.button1.Text = "Make the guess";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.MakeGuess_click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(362, 294);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(0, 16);
			this.label3.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(698, 403);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(90, 35);
			this.button2.TabIndex = 5;
			this.button2.Text = "Quit";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.Quit_Click);
			// 
			// GameUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.userGuess);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.allowedRangeMessage);
			this.Name = "GameUI";
			this.Text = "High-Low Game";
			this.Load += new System.EventHandler(this.Form2_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label allowedRangeMessage;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox userGuess;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button2;
	}
}