using System;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace SeznamSmtpTest
{
	class Program
	{
		static void Main(string[] args)
		{
			if (args.Length != 2)
			{
				ShowHelp();
				Console.ReadKey();
				return;
			}

			string username = args[0];
			string password = args[1];

			string server = "smtp.seznam.cz";
			int port = 465;

			using (SmtpClient client = new SmtpClient())
			{
				client.Connect(server, port, SecureSocketOptions.SslOnConnect);
				try
				{
					client.Authenticate(username, password);
					Console.WriteLine("{0};{1};Success", username, password);
				}
				catch (Exception exc)
				{
					Console.WriteLine("{0};{1};ERROR {2}", username, password, exc.Message);
				}
				client.Disconnect(true);
			}

			Console.ReadKey();
		}

		private static void ShowHelp()
		{
			Console.WriteLine("SeznamSmtpTest (c) 2023 Zdenek K.");
			Console.WriteLine("Usage: \tSeznamSmtpTest.exe username password");
			Console.WriteLine();
			Console.WriteLine("Example");
			Console.WriteLine("SeznamSmtpTest.exe user@seznam.cz secretpassword");
		}
	}
}