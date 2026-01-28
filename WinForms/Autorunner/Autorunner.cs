using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

namespace Autorunner
{
	public partial class Autorunner : Form
	{
		public Autorunner()
		{
			InitializeComponent();
		}

		private void buttonComplete_Click(object sender, EventArgs e)
		{
			AllocConsole();
			Directory.SetCurrentDirectory($"{Application.ExecutablePath}\\..");
			FileInfo settings = new FileInfo("..\\..\\Settings.ini");
			FileSecurity security = settings.GetAccessControl();
			//security.SetOwner()
			//Console.WriteLine(security.);
			string user = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
			Console.WriteLine(user);
			AuthorizationRuleCollection rules = security.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount));
			foreach (FileSystemAccessRule i in rules)
			{
				Console.WriteLine(i.IdentityReference.Value);
				Console.WriteLine(i.FileSystemRights);
				Console.WriteLine(i.AccessControlType);
				Console.WriteLine(i.IsInherited);
				Console.WriteLine(i.PropagationFlags);
				Console.WriteLine(i.InheritanceFlags);
				Console.WriteLine("\n------------------------------------\n");
			}
			Console.WriteLine("\n=========================================\n");
			security.AddAccessRule
			(
				new FileSystemAccessRule(user, 
				FileSystemRights.FullControl, 
				AccessControlType.Allow)
			);
			foreach (FileSystemAccessRule i in rules)
			{
				Console.WriteLine(i.IdentityReference.Value);
				Console.WriteLine(i.FileSystemRights);
				Console.WriteLine(i.AccessControlType);
				Console.WriteLine(i.IsInherited);
				Console.WriteLine(i.PropagationFlags);
				Console.WriteLine(i.InheritanceFlags);
				Console.WriteLine("\n------------------------------------\n");
			}
			settings.SetAccessControl(security);
			//settings.OpenWrite();
			if (checkBoxLaunch.Checked)
			{
				Console.WriteLine(Directory.GetCurrentDirectory());
				string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
				foreach (string i in files)
				{
					Console.WriteLine(i);
				}
				Process.Start("Clock.exe");
			}
			//this.Close();
		}
		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();
		[DllImport("kernel32.dll")]
		public static extern bool FreeConsole();

	}
}
