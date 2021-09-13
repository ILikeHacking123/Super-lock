using System;
using System.Windows.Forms;
using System.Globalization;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace PCLocker
{
	class Web:Form
	{
		public CultureInfo culture = CultureInfo.CurrentUICulture;
		public int UpdateCheck()
		{
			using (WebClient client = new WebClient())
			{
				try
				{	
					ServicePointManager.Expect100Continue = true;
					ServicePointManager.SecurityProtocol = (SecurityProtocolType)(0xc0 | 0x300 | 0xc00);
					string contents = client.DownloadString("https://github.com/rysiu2007/Tuanminh-project/releases");
					const string currentv = "v1.2";
					string[] versions = {"1.1", "v1.2", "v1.3"};
					int i = 0;
					for (; i < 3; i++)
					{
						if (!contents.Contains(versions[i])) {break;}
					}
					string newestv = versions[i-1];
					string[] curr = currentv.Split('v');
					string[] newv = newestv.Split('v');
					float current = float.Parse(curr[1], CultureInfo.InvariantCulture);
					float newest = float.Parse(newv[1], CultureInfo.InvariantCulture);
					if (newest > current)
					{
						return 0;
					}
					else 
					{
						return 1;
					}
				}
				catch(Exception)
				{
					return 2;
				}
			}
		}
	}
}