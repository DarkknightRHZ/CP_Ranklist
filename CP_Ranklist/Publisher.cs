/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 2/12/2017
 * Time: 12:50 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Net;
using System.IO;
using System.Text;
using System.Linq;
using CP_Ranklist;
using System.Collections.Generic;

namespace CP_Ranklist
{
	/// <summary>
	/// Description of Publisher.
	/// </summary>
	public class Publisher
	{
		public Publisher(List <UserInfo> Lst)
		{
			StreamWriter Writer = new StreamWriter("...\\...\\...\\index.html");
			Writer.WriteLine("<!DOCTYPE html>");
			Writer.WriteLine("\t<head>");
			Writer.WriteLine("\t\t<title>");
			Writer.WriteLine("\t\t\tCompetitive Programming Statistics Ranklist");
			Writer.WriteLine("\t\t</title>");
			Writer.WriteLine("\t\t<link rel = \"stylesheet\" type = \"text/css\" href=\"contents\\style.css\">");
			Writer.WriteLine("\t</head>");
			Writer.WriteLine("\t<body>");
			Writer.WriteLine("\t\t<div class = \"Main\">");
			Writer.WriteLine("\t\t\t<h2 class = \"heading2\">");
			Writer.WriteLine("\t\t\t\t<center>");
			Writer.WriteLine("\t\t\t\t\tCompetitive Programming Statistics Ranklist (Codeforces)");
			Writer.WriteLine("\t\t\t\t</center>");
			Writer.WriteLine("\t\t\t</h2>");
			Writer.WriteLine("\t\t\t<center>");
			Writer.WriteLine("\t\t\t\t<table class = \"MainTable\">");
			Writer.WriteLine("\t\t\t\t\t<tr>");
			Writer.WriteLine("\t\t\t\t\t\t<th>Rank</th>");
			Writer.WriteLine("\t\t\t\t\t\t<th>Name</th>");
			Writer.WriteLine("\t\t\t\t\t\t<th>Handle</th>");
			Writer.WriteLine("\t\t\t\t\t\t<th>Point</th>");
			Writer.WriteLine("\t\t\t\t\t\t<th>Rating</th>");
			Writer.WriteLine("\t\t\t\t\t\t<th>Accepted</th>");
			Writer.WriteLine("\t\t\t\t\t\t<th>Submitted</th>");
			Writer.WriteLine("\t\t\t\t\t</tr>");
			for (int i = 0; i < Lst.Count; i++)
			{
				Writer.WriteLine("\t\t\t\t\t<tr>");
				Writer.WriteLine("\t\t\t\t\t\t<td>{0}</td>", i + 1);
				Writer.WriteLine("\t\t\t\t\t\t<td>{0}</td>", Lst[i].Name);
				Writer.WriteLine("\t\t\t\t\t\t<td><a href = \"http:www.codeforces.com/profile/{0}\" style = \"text-decoration:none;\"><font color = \"{1}\">{0}</font></a></td>", Lst[i].ID, Lst[i].Color);
				Writer.WriteLine("\t\t\t\t\t\t<td>{0}</td>", Lst[i].Point);
				Writer.WriteLine("\t\t\t\t\t\t<td>{0}</td>", Lst[i].Rating);
				Writer.WriteLine("\t\t\t\t\t\t<td>{0}</td>", Lst[i].AC);
				Writer.WriteLine("\t\t\t\t\t\t<td>{0}</td>", Lst[i].Sub);
				Writer.WriteLine("\t\t\t\t\t</tr>");
			}
			Writer.WriteLine("\t\t\t</center>");
			Writer.WriteLine("\t\t\t</table>");
			Writer.WriteLine("\t\t</div>");
			Writer.WriteLine("\t\t<div class = \"footer\">");
			Writer.WriteLine("\t\t\t<center>");
			Writer.WriteLine("\t\t\t\t<h6> Contact: rhzinuk@gmail.com</h6>");
			Writer.WriteLine("\t\t\t</center>");
			Writer.WriteLine("\t\t</div>");
			Writer.WriteLine("\t</body>");
			Writer.WriteLine("</html>");
			Writer.Close();
		}
	}
}
