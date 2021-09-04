using System;
using System.Net;
using System.Globalization;
using System.IO;
using System.Diagnostics;

public class PCLMng
{
	public string UpdateCheck()
	{
		using (var client = new WebClient())
		{
			try
			{	ServicePointManager.Expect100Continue = true;
				ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				var contents = client.DownloadString("https://github.com/rysiu2007/Tuanminh-project/releases");
				const string currentv = "v1.1";
				string[] versions = {"v1.0", "v1.1", "v1.2"};
				int i = 1;
				for (; i < 3; i++)
				{
					if (!contents.Contains(versions[i]))
					{
						break;
					}
				}
				var newestv = versions[i - 1];
				string[] curr = currentv.Split('v','.');
				string[] newv = newestv.Split('v','.');
				float current = float.Parse(curr[1], CultureInfo.InvariantCulture);
				float newest = float.Parse(newv[1], CultureInfo.InvariantCulture);
				if (newest > current)
				{
					return "There's newer version of PCLocker! Go to https://github.com/rysiu2007/Tuanminh-project/releases to download the newest version";
				}
				else
				{
					return "You have the newest version of PCLocker!";
				}
			}
			catch(Exception)
			{
				return "There is problem with version check.";
			}
		}
	}
	public static void Main()
	{
		Console.Title = "PCLocker v1.1";
		PCLMng a = new PCLMng();
		Console.WriteLine(a.UpdateCheck());
		Console.WriteLine("Click any key to proceed...");
		Console.ReadKey();
		Main:
		Console.WriteLine("\r\nWelcome to PCLocker! What do you want to do?\r\nA. Run App\r\nB. Change password\r\nC. Exit App");
		string curpath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
		string inp = Console.ReadLine();
		if (inp == "A" || inp == "a")
		{
			Process.Start(curpath + "/tools/warning.vbs");
			Environment.Exit(0);
		}
		else if (inp == "B" || inp == "b")
		{
			bad:
			Console.WriteLine("Current password is: " + a.Password() + "\r\nWant to change it? Write yes/no.");
			string input = Console.ReadLine();
			if (input == "Yes" || input == "yes")
			{
				StreamWriter sw = File.CreateText(curpath + "/tools/password.dat");
				Console.WriteLine("What password do you want to be? Write it here.");
				string inpt = Console.ReadLine();
				sw.WriteLine(inpt);
				sw.Close();
				if (a.Password() == inpt)
				{
					Console.WriteLine("Password has been changed successfully!");
					goto Main;
				}
				else
				{
					Console.WriteLine("Oops! Something went wrong. Try again.");
					goto bad;
				}	
			}	
			else if (input == "No" || input == "no") {goto Main;}
			else {goto bad;}
		}
		else if (inp == "C" || inp == "c") 
		{
			Environment.Exit(0);
		}
		else {goto Main;}
	}
	public string Password()
	{
		string cupath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location).ToString();
		StreamReader sr = new StreamReader(cupath + "/tools/password.dat");
		var a = sr.ReadLine();
		sr.Close();
		return a;
	}
}