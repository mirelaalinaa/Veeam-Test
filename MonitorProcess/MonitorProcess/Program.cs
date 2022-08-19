using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Markup;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Threading;

namespace MonitorProcess
{
    class Program
    {
        public static async  Task Main(string[] args)
        {
            string monitor_process = args[0];
            int max_duration = Int32.Parse(args[1]);
            int interval = Int32.Parse(args[2]);
            bool found;

            var program = new Program();

            Dictionary<string, TimeSpan> known_processes = new Dictionary<string, TimeSpan>();

            while(true){
                Process[] runningProcess = Process.GetProcesses();

                found = false;
                    foreach (Process process in runningProcess)
                    {
                        if (process.ProcessName == monitor_process)
                        {
                            program.CheckProcess(process.ProcessName, max_duration, interval, known_processes);
                        found = true;
                        }
                    }
                if (found == false){
                    Console.WriteLine("NotFound");
                }

                Thread.Sleep(interval * 60000);
                }
        }


        public void CheckProcess(string process_name, float max_duration, float interval,
            Dictionary<string,TimeSpan> known_processes)
        {

            var dateTime = DateTime.Now.TimeOfDay;
            Process[] found_processes = Process.GetProcessesByName(process_name);

            foreach (Process process in found_processes)
            {
                if (known_processes.ContainsKey(process.ProcessName) && (dateTime.TotalMinutes - known_processes[process.ProcessName].TotalMinutes >= max_duration))
                {
                    Console.WriteLine($"Omorat {process.ProcessName}");
                    process.Kill();
                }
                else if (!known_processes.ContainsKey(process.ProcessName))
                {
                    known_processes.Add(process.ProcessName, dateTime);
                    Console.WriteLine($"Process {process.ProcessName} has been running for {dateTime.TotalMinutes - known_processes[process.ProcessName].TotalMinutes} \n" +
    $"out of {max_duration}");
                }
                else
                {
                    Console.WriteLine($"Process {process.ProcessName} has been running for {dateTime.TotalMinutes - known_processes[process.ProcessName].TotalMinutes} \n" +
                        $"out of {max_duration}");
                }
                
            }

        }

        private bool checkQ(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)113)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}