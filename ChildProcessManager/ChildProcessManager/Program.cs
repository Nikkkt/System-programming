using System.Diagnostics;

Console.Write("Enter the name of the application you want to run (notepad.exe by default) >>> ");
string appName = Console.ReadLine();

if (string.IsNullOrEmpty(appName)) appName = "notepad.exe";

Process childProcess = new Process();
childProcess.StartInfo.FileName = appName;

try { childProcess.Start(); }
catch (Exception ex) { Console.WriteLine("Error when starting a process: " + ex.Message); return; }

Console.Write("Enter 1 to wait for the process to complete, or 2 to force the process to complete >>> ");
string userInput = Console.ReadLine();

if (userInput == "1")
{
    childProcess.WaitForExit();
    Console.WriteLine("Completion code: " + childProcess.ExitCode);
}
else if (userInput == "2")
{
    try { childProcess.Kill(); Console.WriteLine("The process was forcibly terminated"); }
    catch (Exception ex) { Console.WriteLine("Error when completing the process: " + ex.Message); }
}
else Console.WriteLine("Unknown command: " + userInput);
