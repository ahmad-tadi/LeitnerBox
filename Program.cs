using Microsoft.EntityFrameworkCore;

namespace Leitner;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Welcome to the Leitner Box!");
		Console.WriteLine("1.Create 2.Review 3.Show All 4.Clear 0.Exit");
		using var context = new LeitnerBoxContext();
		context.Database.EnsureCreated();

		LeitnerStateContext start = new(context);
		while (true)
		{
			var command = Console.ReadLine();
			if (command is null) continue;
			start.State?.Handle(command);
		}

	}
}