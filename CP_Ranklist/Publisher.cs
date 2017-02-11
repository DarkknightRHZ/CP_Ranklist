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
			int i,j;
			UserInfo User;
			StreamWriter Writer = new StreamWriter("...\\...\\...\\index.html");
			Writer.WriteLine("<!DOCTYPE html>" +
			                 "<html>" +
			                 "<head>" +
			                 "<title>" +
			                 "Competitive Programming Statistics Ranklist" +
			                 "</title>" +
			                 "<link rel = \"stylesheet\" type = \"text/css\" href=\"contents\\style.css\">" +
			                 "</head>" +
			                 "<body>" +
			                 "<div class = \"Main\">" +
			                 "<h2 class = \"heading2\">" +
			                 "<center>" +
			                 "Competitive Programming Statistics Based Ranklist (Codeforces)" +
			                 "</center>" +
			                 "</h2>" +
			                 "<center>" +
			                 "<table class = \"MainTable\">" +
			                 "<tr>" +
			                 "<th>Rank</th>" +
			                 "<th>Name</th>" +
			                 "<th>Handle</th>" +
			                 "<th>Point</th>" +
			                 "<th>Rating</th>" +
			                 "<th>Accepted</th>" +
			                 "<th>Submitted</th>" +
			                 "</tr>");
			for (i = 0; i < Lst.Count; i++)
			{
				User = Lst[i];
				Writer.WriteLine("<tr>" +
				                 "<td>{0}</td>" +
				                 "<td>{1}</td>" +
				                 "<td> <a href = \"http:www.codeforces.com/profile/{2}\" style = \"text-decoration:none;\"><font color = \"{3}\">{2}</a></td>" +
				                 "<td>{4}</td>" +
				                 "<td>{5}</td>" +
				                 "<td>{6}</td>" +
				                 "<td>{7}</td>" +
				                 "</tr>", i+1, User.Name, User.ID, User.Color, User.Point, User.Rating.ToString("#.##"), User.AC, User.Sub);
			}
			Writer.WriteLine("</center>" +
			                 "</table>" +
			                 "</div>" +
			                 "<div class = \"footer\">" +
			                 "<center>" +
			                 "<h6> All Rights Reserved &copy; 2017 By: rhzinuk@gmail.com</h6>" +
			                 "</center>" +
			                 "</div>" +
			                 "</body>" +
			                 "</html>");
			Writer.Close();
		}
	}
}
