/*
 * Created by SharpDevelop.
 * User: PC
 * Date: 2/11/2017
 * Time: 7:30 PM
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
	/// Description of Class1.
	/// </summary>
	public class UserInfo : IComparable < UserInfo >
	{
		public string ID = "";
		public string Name = "";
		public string Color = "Black";
		public int Rating = 0;
		public int AC = 0;
		public int Sub = 0;
		public double Point = 0.0;
		
		public UserInfo(string ID)
		{
			this.ID = ID;
		}
		
		public void CalculatePoint() 
		{
			if (Sub == 0) Sub++;
			Point = ((Rating * 85.0) / 1500.0) +  (AC * 15.0 / Sub);
		}
		
		public int CompareTo(UserInfo Other)
		{
			return Other.Point.CompareTo(this.Point); 
		}
	}
	public class Build
	{
		public List <UserInfo> Lst;
		private string ReqUrl;
		private string ID;
		private string RetString;
		private string Name;
		private WebRequest RetUrl;
		int tmp,cns;
		private Stream RetStream;
		private StreamReader RetReader;
		
		public Build(List <UserInfo> Lst)
		{
			this.Lst = Lst;
		}
		
		public void Process()
		{
			for (int i = 0; i < Lst.Count; i++)
			{
				ProcessRating(i);
				ProcessInfo(i);
				ProcessStatus(i);
				Lst[i].CalculatePoint();
				System.Threading.Thread.Sleep( 100 );
			}
			Lst.Sort();
		}
		
		private void ProcessRating(int Idx)
		{
			ID = Lst[Idx].ID;
			tmp = 0;
			ReqUrl = "http://codeforces.com/api/user.rating?handle=";
			RetUrl = WebRequest.Create(ReqUrl + ID);
			RetStream = RetUrl.GetResponse().GetResponseStream();
			RetReader = new StreamReader(RetStream);
			RetString = RetReader.ReadLine();
			for (int i = RetString.Length - 7; i <= RetString.Length - 4; i++)
			{
				if (RetString[i] < '0' || RetString[i] > '9') break;
				tmp *= 10;
				tmp += (RetString[i] - '0');
			}
			Name = "Black";
			if (tmp < 1200) Name = "d3d1c2";
			else if (tmp >= 1200 && tmp < 1400) Name = "008000";
			else if (tmp >= 1400 && tmp < 1600) Name = "00cccc";
			else if (tmp >= 1600 && tmp < 1900) Name = "0000FF";
			else if (tmp >= 1900 && tmp < 2200) Name = "ff33cc";
			else if (tmp >= 2200 && tmp < 2400) Name = "FFA500";
			else Name = "FF0000";
			Lst[Idx].Color = Name;
			Lst[Idx].Rating = tmp;
		}
		
		private void ProcessInfo(int Idx)
		{
			ID = Lst[Idx].ID;
			tmp = 0;
			ReqUrl = "http://codeforces.com/api/user.info?handles=";
			RetUrl = WebRequest.Create(ReqUrl + ID);
			RetStream = RetUrl.GetResponse().GetResponseStream();
			RetReader = new StreamReader(RetStream);
			RetString = RetReader.ReadLine();
			Name = "";
			for (int i = RetString.IndexOf("\"firstName\":\"") + 13; RetString[i] != '\"'; i++)
			{
				Name += RetString[i];
			}
			Name += ' ';
			for (int i = RetString.IndexOf("\"lastName\":\"") + 12; RetString[i]  != '\"'; i++)
			{
				Name += RetString[i];
			}
			if (Name == "K OK") Name = "No Names!";
			Lst[Idx].Name = Name;
		}
		
		private void ProcessStatus(int Idx)
		{
			ID = Lst[Idx].ID;
			tmp = 0;
			ReqUrl = "http://codeforces.com/api/user.status?handle=";
			RetUrl = WebRequest.Create(ReqUrl + ID);
			RetStream = RetUrl.GetResponse().GetResponseStream();
			RetReader = new StreamReader(RetStream);
			RetString = RetReader.ReadLine();
			tmp = cns = 0;
			for (int i = 0; i < RetString.Length - 10; i++)
			{
				Name = "";
				Name += RetString[i];
				Name += RetString[i+1];
				Name += RetString[i+2];
				Name += RetString[i+3];
				Name += RetString[i+4];
				Name += RetString[i+5];
				if (Name == "t\":\"OK")
				{
					tmp++;
				}
			}
			for (int i = 0; i < RetString.Length - 10; i++)
			{
				Name = "";
				Name += RetString[i];
				Name += RetString[i+1];
				if (Name == "id")
				{
					cns++;
				}
			}
			Lst[Idx].AC = tmp;
			Lst[Idx].Sub = cns;
		}
	}
}
