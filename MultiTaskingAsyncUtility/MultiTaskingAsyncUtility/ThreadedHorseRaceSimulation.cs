// To check this code comment all code in AsyncFileWordCounter.cs

using MultiTaskingAsyncUtility;

Horse[] horses = new Horse[] { new Horse("Horse 1"), new Horse("Horse 2"), new Horse("Horse 3"), new Horse("Horse 4"), new Horse("Horse 5") };
Task[] tasks = new Task[horses.Length];

Console.WriteLine("Press Enter to start the race");
Console.ReadLine();

for (int i = 0; i < horses.Length; i++)
{
    int index = i;
    tasks[index] = Task.Run(() => horses[index].Run());
}

Task.WaitAll(tasks);

Console.WriteLine("\nRace finished!\n");
Console.WriteLine("Race Results:");

var sortedHorses = horses.OrderBy(h => h.FinishTime).ToArray();

for (int i = 0; i < Math.Min(3, sortedHorses.Length); i++) Console.WriteLine($"{sortedHorses[i].Name}: ended at {sortedHorses[i].FinishTime}");