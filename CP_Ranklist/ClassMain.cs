/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 2/11/2017
 * Time: 7:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Text;
using System.Linq;
using CP_Ranklist;
using System.Collections.Generic;

namespace CP_Ranklist
{
	class MainClass
	{
		static void Main (string[] args) 
		{
			StreamReader Reader = new StreamReader ("...\\...\\...\\input.txt");
			StreamWriter Writer = new StreamWriter ("...\\...\\...\\output.txt");
			List <UserInfo> Lst = new List<UserInfo> ();
			string ID;
			while ((ID = Reader.ReadLine()) != null)
			{
				Lst.Add(new UserInfo(ID));
			}
			Build Bld = new Build(Lst);
			Bld.Process();
			Publisher Pbl = new Publisher(Bld.Lst);
			Reader.Close();
			Writer.Close();
			Console.WriteLine("Press any key to exit");
			Console.ReadKey();
		}
	}
}