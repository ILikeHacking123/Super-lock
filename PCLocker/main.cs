using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Resources;
using System.Drawing.Printing;

[assembly: AssemblyVersion("1.2.139.0")]  
[assembly: AssemblyFileVersion("1.2.139.0")]
[assembly: AssemblyTitle("PCLocker v1.2 app by TuanminhDev Team")]
[assembly: AssemblyProduct("PCLocker v1.2")]
[assembly: AssemblyTrademark("PCLocker")]
[assembly: AssemblyCompany("TuanminhDev Team")]
[assembly: AssemblyCopyright("GPL-3.0 Licence")]

namespace PCLocker
{
    public class PCLockerMain : Form 
	{

        private Button passbutton;
		private Button start;
		private RichTextBox textbox;
		private Label label;
		private PictureBox picture;
		private Label warning;
		private Button print;
		public string password;
		private Font printFont;
		private StreamReader srprint;

        public PCLockerMain() 
		{
			StreamReader sr = new StreamReader(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "/resources/password.dat");
			password = sr.ReadLine();
			sr.Close();
            DisplayGUI();
        }

        public void DisplayGUI() 
		{
			this.Name = "PCLocker v1.2";
            this.Text = "PCLocker v1.2";
			this.Size = new Size(500,250);
            this.StartPosition = FormStartPosition.CenterScreen;
			this.FormBorderStyle = FormBorderStyle.Sizable;
			this.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
			this.ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
			this.Font = new Font(this.Font, FontStyle.Bold);
			this.BackgroundImage = new Bitmap(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "/resources/background.png");
			this.Icon = new Icon("icon.ico");

            passbutton = new Button();
            passbutton.Name = "passbutton";
            passbutton.Text = "Change password";
            passbutton.Size = new Size(310, 20);
            passbutton.Location = new Point (1,185);
            passbutton.Click += new System.EventHandler(this.PasswordChange);
			passbutton.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
			this.Controls.Add(passbutton);
			
			print = new Button();
            print.Name = "print";
            print.Text = "Print password";
			print.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
            print.Size = new Size(100, 30);
            print.Location = new Point (317,175);
            print.Click += new System.EventHandler(this.Print);
			this.Controls.Add(print);
			
			start = new Button();
            start.Name = "start";
            start.Text = "START";
			start.Anchor = (AnchorStyles.Right | AnchorStyles.Bottom);
            start.Size = new Size(60, 30);
            start.Location = new Point (420,175);
            start.Click += new System.EventHandler(this.RunApp);
			this.Controls.Add(start);
			
			textbox = new RichTextBox();
			textbox.Name = "textbox";
			textbox.Anchor = (AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Right);
			textbox.Location = new Point(1,40);
			textbox.Size = new Size(310, 140);
			this.Controls.Add(textbox);
			
			label = new Label();
			label.Location = new Point(2,0);
			label.Size = new Size(310, 40);
			label.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
			label.AutoEllipsis  = true;
			label.Text = "Welcome in PCLocker! Click here to go to this project website: https://github.com/rysiu2007/Tuanminh-project.\nCurrent password is: "+password;
			label.BackColor = Color.FromArgb(0,0,0,0);
			label.Click += new System.EventHandler(this.Github);
			this.Controls.Add(label);
			
			warning = new Label();
			warning.Location = new Point(325,145);
			warning.Size = new Size(150, 60);
			warning.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
			warning.Text = "Click here to view\nhazards with this app.";
			warning.BackColor = Color.FromArgb(0,0,0,0);
			warning.Click += new System.EventHandler(this.Hazards);
			this.Controls.Add(warning);
			
			picture = new PictureBox();
			picture.Anchor = (AnchorStyles.Right | AnchorStyles.Top);
			picture.Size = new Size(150, 150);
			picture.Location = new Point(325,0);
			picture.ImageLocation = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "/resources/picture.png";
			picture.BackColor = Color.FromArgb(0,0,0,0);
			picture.SizeMode = PictureBoxSizeMode.StretchImage;
			this.Controls.Add(picture);
        }
		private void pd_PrintPage(object sender, PrintPageEventArgs ev)
		{
			float linesPerPage = 0;
			float yPos = 0;
			int count = 0;
			float leftMargin = ev.MarginBounds.Left;
			float topMargin = ev.MarginBounds.Top;
			string line = null;

			linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);
			while (count < linesPerPage && ((line = srprint.ReadLine()) != null))
			{
				yPos = topMargin + (count *
				printFont.GetHeight(ev.Graphics));
				ev.Graphics.DrawString(line, printFont, Brushes.Black,
				leftMargin, yPos, new StringFormat());
				count++;
			}
			if (line != null)
				ev.HasMorePages = true;
			else
				ev.HasMorePages = false;
		}
		private void Print(object source, EventArgs e) 
		{
			try
			{
				srprint = new StreamReader(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "/resources/password.dat");
				printFont = new Font("Arial", 10);
				PrintDocument pd = new PrintDocument();
				pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
				pd.DocumentName = "password.dat";
				pd.Print();
				srprint.Close();
			}
			catch(Exception exception)
			{
				MessageBox.Show("There was problem with printing: "+exception);
			}
		}
		private void Github(object source, EventArgs e) 
		{
			Process.Start("https://github.com/rysiu2007/Tuanminh-project");
		}
		private void Hazards(object source, EventArgs e) 
		{
			MessageBox.Show("This is PCLocker App, by TuanminhDev Team. You use this app on your rensponsibility. PCLocker works, by changing PC password and logging out, so only risk is you forgetting the password.", "Hazards", MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        private void RunApp(object source, EventArgs e) 
		{
			DialogResult result = MessageBox.Show("This is first warning, if you click no, you can safely return to the app. Otherwise administrator access prompt will po out and this is your last warning. Our team do not take any rensponsibility for our app.", "Warning", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				Process.Start(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "/elevator.bat"); 

				Application.Exit();
			}
		}
		private void PasswordChange(object source, EventArgs e) 
		{
			textbox.Text = textbox.Text.Replace("\n", "");
            StreamWriter sw = File.CreateText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "/resources/password.dat");
			sw.WriteLine(textbox.Text);
			sw.Close();
			StreamReader sr = new StreamReader(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString() + "/resources/password.dat");
			password = sr.ReadLine();
			this.label.Text = "Welcome in PCLocker! Click here to go to this project website: https://github.com/rysiu2007/Tuanminh-project.\nCurrent password is: "+password;
			this.label.Update();
			sr.Close();
        }

        public static void Main(String[] args) 
		{
			Web web = new Web();
			PCLockerMain pcl = new PCLockerMain();
			if (web.UpdateCheck() == 0)
			{
				MessageBox.Show("There is newer version of PCLocker, go to https://github.com/rysiu2007/Tuanminh-project/releases to download newer version.", "Auto-Updater", MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else if (web.UpdateCheck() == 1)
			{
				MessageBox.Show("You have the newest version of PCLocker.", "Auto-Updater", MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else {MessageBox.Show("There was a problem with Auto-Updater.", "Auto-Updater", MessageBoxButtons.OK,MessageBoxIcon.Error);}
			
			Application.Run(new PCLockerMain());	
        }
    }
}
