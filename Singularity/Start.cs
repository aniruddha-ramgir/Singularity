using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace Singularity
{
    public class Launch
    {
        public static string quote = "";
        public static string operation = "";
        //public static readonly string ADomain = @"AssemblyName.Actions.txt";
        //public static readonly string ADomain = @"C:\Temp\Actions.txt";
        //public static readonly string FDomain = @"C:\Temp\Files.txt";
        //public static readonly string SDomain = @"C:\Temp\Engines.txt";
        //public static readonly string SEDomain = @"C:\Temp\Services.txt";
        internal static void Run(string[] input)
        {
            quote = "";
            operation = "";
            Action A1 = new Action();
            File F1 = new File();
            Search S1 = new Search();
            NativeMethods SE1 = new NativeMethods();
            Format(input);
            if (    (!operation.Equals("")) && Action.Names.Contains(operation, StringComparer.OrdinalIgnoreCase))
            {
                if (FormRunner())
                    A1.activity(operation, quote);
            }
            else if (   (!operation.Equals("")) && Search.Names.Contains(operation, StringComparer.OrdinalIgnoreCase))
            {
                if (FormRunner())
                    S1.activity(operation, quote);
            }
            else if (   (!operation.Equals("")) && NativeMethods.Names.Contains(operation, StringComparer.OrdinalIgnoreCase))
            {
                if (FormRunner())
                    SE1.activity(operation);
            }
            else
            {
                MessageBox.Show("I did not catch that!");
            }
        }
        static void Format(string[] args)
        {
            int i = 0;
            for (i = 0; i < args.Length; i++)
            {
                if (Action.Names.Contains(args[i], StringComparer.OrdinalIgnoreCase))
                {
                    operation = args[i];
                    if (args[i].Equals("search", StringComparison.OrdinalIgnoreCase))
                    {
                        breakDown(args, i, false);
                    }
                    else
                    {
                        breakDown(args, i, true);
                    }
                    break;
                }
                else if (Search.Names.Contains(args[i], StringComparer.OrdinalIgnoreCase))
                {
                    operation = args[i];
                    breakDown(args, i, false);
                    break;
                }
                else if (NativeMethods.Names.Contains(args[i], StringComparer.OrdinalIgnoreCase))
                {
                    operation = args[i];
                }
                else
                {
                    operation = "";
                    breakDown(args, 0, true);
                    break;
                }
            }
        }
        static void breakDown(String[] args, int i, bool type)
        {
            bool coc = false;
            if (type)
            {
                for (int j = i + 1; j < args.Length; j++)
                {
                    if (!(string.IsNullOrEmpty(args[j])))
                    {
                        if (File.Names.Contains(args[j], StringComparer.OrdinalIgnoreCase))
                        {
                            quote = args[j];
                            break;
                        }
                        else if (!string.IsNullOrWhiteSpace(args[j]))
                        {
                            if (!coc)
                            {
                                quote = args[j];
                                coc = true;
                                continue;
                            }
                            quote = quote + args[j];
                            coc = true;
                            continue;
                        }
                    }
                }
            }
            else
            {
                for (int j = i + 1; j < args.Length; j++)
                {
                    if (!(string.IsNullOrEmpty(args[j])))
                    {
                        if (File.Names.Contains(args[j], StringComparer.OrdinalIgnoreCase))
                        {
                            quote = args[j];
                            break;
                        }
                        else if (!string.IsNullOrWhiteSpace(args[j]))
                        {
                            if (!coc)
                            {
                                quote = args[j];
                                coc = true;
                                continue;
                            }
                            quote = quote + "+";
                            quote = quote + args[j];
                            coc = true;
                            continue;
                        }
                    }
                }
            }
        }
        static bool FormRunner()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to " + operation +" "+ quote+"?", "Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                return true;
            }
            else if (dialogResult == DialogResult.No)
            {
                return false;
            }
            return false;
        }
        /*static bool isMatch(String path,String domain)
        {
            //lines = File.ReadAllLines(path);
            if (File.ReadAllText(path).Contains(domain))
            {
                return true;
            }
            else return false;
        } */
    }
    class Action
    {
        public static List<string> Names = new List<string>();
       /* public Action()
        {
            String line;
            StreamReader file = new StreamReader(Launch.ADomain);
            while ((line = file.ReadLine()) != null)
            {
                Names.Add(line);
            }
            file.Close();
        }*/
        public Action()
        {
            string resource_data = Properties.Resources.Actions;
            Names = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public void activity(string op, string act)
        {
            if (op.Equals("search", StringComparison.OrdinalIgnoreCase))
            {
                Search S1 = new Search();
                S1.activity(act);
            }
            else if (op.Equals("kill", StringComparison.OrdinalIgnoreCase) || op.Equals("close", StringComparison.OrdinalIgnoreCase) || op.Equals("stop", StringComparison.OrdinalIgnoreCase) || op.Equals("end", StringComparison.OrdinalIgnoreCase) || op.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                try
                {
                    foreach (var process in Process.GetProcessesByName(act))
                    {
                        process.Kill();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                }
            }
            else
            {
                try
                {
                    Process.Start(act);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
                }
            }
        }
    }
    class File
    {
        public static List<string> Names = new List<string>();
        /*public File()
        {
            String line;
            StreamReader file = new StreamReader(Launch.FDomain);
            while ((line = file.ReadLine()) != null)
            {
                Names.Add(line);
            }
            file.Close();
        }*/
        public File()
        {
            string resource_data = Properties.Resources.Files;
            Names = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
    }
    class Search
    {
        public static List<string> Names = new List<string>();
        /*public Search()
        {
            string line;
            StreamReader file = new StreamReader(Launch.SDomain);
            while ((line = file.ReadLine()) != null)
            {
                Names.Add(line);
            }
            file.Close();
        }*/
        public Search()
        {
            string resource_data = Properties.Resources.Engines;
            Names = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public void activity(string act)
        {
            try
            {
                string link = "www.google.com/search?q=" + act;
                Process.Start(link);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }
        public void activity(string eng, string act)
        {
            eng = eng.ToLower();
            Console.WriteLine("start www." + eng + ".com/search?q=" + act);
            try
            {
                string link = "www." + eng + ".com/search?q=" + act;
                Process.Start(link);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }
    }
    class NativeMethods
    {
        public static List<string> Names = new List<string>();
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        [DllImport("user32")]
        public static extern void LockWorkStation();
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        /*public Service()
        {
            string line;
            StreamReader file = new StreamReader(Launch.SEDomain);
            while ((line = file.ReadLine()) != null)
            {
                Names.Add(line);
            }
            file.Close();
        }*/
        public NativeMethods()
        {
            string resource_data = Properties.Resources.Services;
            Names = resource_data.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        public void activity(string op)
        {
            try
            {
                switch (op.ToLower())
                {
                    case "shutdown":
                        {
                            Console.WriteLine("Shutdown");
                            Process.Start("shutdown", "/s /t 0");
                            break;
                        }
                    case "restart":
                        {
                            Console.WriteLine("Restart");
                            Process.Start("shutdown", "/r /t 0");
                            break;
                        }
                    case "logoff":
                        {
                            Console.WriteLine("Log Off");
                            ExitWindowsEx(0, 0);
                            break;
                        }
                    case "logout":
                        {
                            Console.WriteLine("Log Off");
                            ExitWindowsEx(0, 0);
                            break;
                        }
                    case "lock":
                        {
                            Console.WriteLine("Lock");
                            LockWorkStation();
                            break;
                        }
                    case "hibernate":
                        {
                            Console.WriteLine("Hibernate");
                            SetSuspendState(true, true, true);
                            break;
                        }
                    case "sleep":
                        {
                            Console.WriteLine("Sleep");
                            SetSuspendState(false, true, true);
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Error! Service unvailable.");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Occurred :{0},{1}", ex.Message, ex.StackTrace.ToString());
            }
        }
    }
}