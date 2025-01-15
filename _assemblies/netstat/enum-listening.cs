using System;
using System.Net;
using System.Net.NetworkInformation;
using System.Collections.Generic;

namespace MyNetstat
{
	class Program    
	{
		static void Main(string[] args)
		{
			IPGlobalProperties ipProperties = IPGlobalProperties.GetIPGlobalProperties();
			IPEndPoint[] tendPoints = ipProperties.GetActiveTcpListeners();
			IPEndPoint[] uendPoints = ipProperties.GetActiveUdpListeners();
			// TCP Port Listeners
			Dictionary<string, List<string>> tlistAddr = new Dictionary<string, List<string>>();
			foreach (IPEndPoint e in tendPoints)
			{
				string teaddr = e.Address.ToString();
				string tpaddr = e.Port.ToString();
				
				if (tlistAddr.ContainsKey(teaddr))
				{
					List<string> tportlist = tlistAddr[teaddr];
					if (tportlist.Contains(tpaddr) == false)
					{
						tportlist.Add(tpaddr);
					}
				}
				else
				{
					List<string> tportlist = new List<string>();
					tportlist.Add(tpaddr);
					tlistAddr.Add(teaddr, tportlist);
				}
			}
			// UDP Port Listeners
			Dictionary<string, List<string>> ulistAddr = new Dictionary<string, List<string>>();
			foreach (IPEndPoint e in uendPoints)
			{
				string ueaddr = e.Address.ToString();
				string upaddr = e.Port.ToString();
				
				if (ulistAddr.ContainsKey(ueaddr))
				{
					List<string> uportlist = ulistAddr[ueaddr];
					if (uportlist.Contains(upaddr) == false)
					{
						uportlist.Add(upaddr);
					}
				}
				else
				{
					List<string> uportlist = new List<string>();
					uportlist.Add(upaddr);
					ulistAddr.Add(ueaddr, uportlist);
				}
			}
			// Print Title
			string listtitle = String.Format("{0,-7}{1,-23}{2,-23}{3,-16}{4}", "Proto", "Local Address", "Foreign Address", "State", "Port(s)");
			Console.WriteLine(listtitle);
			// Print TCP Listeners
			foreach (KeyValuePair<string, List<string>> kvp in tlistAddr)
			{
				string tportcomb = string.Join(", ", kvp.Value.ToArray());
				string tlistdata = String.Format("{0,-7}{1,-23}{2,-23}{3,-16}{4}", "TCP", kvp.Key, "0.0.0.0:0", "LISTENING", tportcomb);
				Console.WriteLine(tlistdata);
			}
			// Print UDP Listeners
			foreach (KeyValuePair<string, List<string>> kvp in ulistAddr)
			{
				string uportcomb = string.Join(", ", kvp.Value.ToArray());
				string ulistdata = String.Format("{0,-7}{1,-23}{2,-23}{3,-16}{4}", "UDP", kvp.Key, "0.0.0.0:0", "LISTENING", uportcomb);
				Console.WriteLine(ulistdata);
			}
		}
	}
}