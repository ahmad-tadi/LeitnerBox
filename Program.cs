using Microsoft.EntityFrameworkCore;

namespace Leitner;

class Program
{
	static void Main(string[] args)
	{
		Console.WriteLine("Welcome to the Leitner Box!");
		Console.WriteLine("1.Create 2.Review 3.Show All 4.Clear 0.Exit");

		// Create an instance of the DbContext class
		using var context = new LeitnerBoxContext();
		context.Database.Migrate();

		LeitnerStateContext start = new(context);
		while (true) {
			var command = Console.ReadLine();
			if (command is null) continue;
			start.State.Handle(command);
		}

		/*
		// Display the menu options
		do
		{
			Console.WriteLine("Please choose an option:");
			Console.WriteLine("1. Create a new flashcard");
			Console.WriteLine("2. Review the flashcards");
			Console.WriteLine("3. Show All the flashcards");
			Console.WriteLine("0. Exit the application");
			// Read the user input
			var input = Console.ReadLine();

			// Switch on the input
			switch (input)
			{
				case "1":
					CreateFlashcard(context);
					break;
				case "2":
					ReviewFlashcards(context);
					break;
				case "3":
					ShowAllFlashcards(context);
					break;
				case "0":
					Console.WriteLine("Thank you for using the Leitner Box!");
					Environment.Exit(0);
					break;
				default:
					Console.WriteLine("Invalid option. Please try again.");
					break;
			}
		}while (true);*/
	}
	/*
	// The method to create a new flashcard
	static void CreateFlashcard(LeitnerBoxContext context)
	{
		// Ask the user to enter the question and the answer
		Console.WriteLine("Please enter the question or term to be learned:");
		var question = Console.ReadLine();
		Console.WriteLine("Please enter the answer or definition to be recalled:");
		var answer = Console.ReadLine();

		// Create a new flashcard object with the question and the answer
		var flashcard = new Flashcard
		{
			Question = question,
			Answer = answer,
			BoxNumber = 1, // The new flashcard starts from the first box
			LastReviewed = DateTime.Now // The current date and time
		};

		// Add the flashcard to the DbSet
		context.Flashcards.Add(flashcard);

		// Save the changes to the database
		context.SaveChanges();

		// Display a confirmation message
		Console.WriteLine("The flashcard has been created successfully.");
	}

	// The method to review the flashcards
	static void ShowAllFlashcards(LeitnerBoxContext context)
	{
		// Get the flashcards from the DbSet
		var flashcards = context.Flashcards.ToList();
		foreach (var flashcard in flashcards)
		{
                Console.WriteLine(flashcard.Question);
            }
	}
	// The method to review the flashcards
	static void ReviewFlashcards(LeitnerBoxContext context)
	{
		// Get the flashcards from the DbSet
		var flashcards = context.Flashcards.ToList();

		// Check if there are any flashcards
		if (flashcards.Count == 0)
		{
			// Display a message that there are no flashcards
			Console.WriteLine("There are no flashcards to review.");
		}
		else
		{
			// Loop through the flashcards
			foreach (var flashcard in flashcards)
			{
				// Check if the flashcard is due for review
				if (IsDueForReview(flashcard))
				{
					// Display the question and ask the user to enter the answer
					Console.WriteLine($"Question: {flashcard.Question}");
					Console.WriteLine("Please enter the answer or press Enter to skip:");
					var answer = Console.ReadLine();

					if(answer =="del")
					{
						context.Remove(flashcard);
						context.SaveChanges(true);
						Console.WriteLine($"{flashcard.Question} ({flashcard.Answer}) has been deleted.");
                            return;
					}
					// Check if the answer is correct
					if (answer == flashcard.Answer)
					{
						// Display a message that the answer is correct
						Console.WriteLine("Correct!");

						// Move the flashcard to the next box
						MoveFlashcard(flashcard, 1);
					}
					else
					{
						// Display a message that the answer is wrong
						Console.WriteLine($"Wrong! The correct answer is: {flashcard.Answer}");

						// Move the flashcard to the first box
						MoveFlashcard(flashcard, -flashcard.BoxNumber + 1);
					}

					// Update the last reviewed date and time
					flashcard.LastReviewed = DateTime.Now;

					// Save the changes to the database
					context.SaveChanges();
				}
			}

			// Display a message that the review is completed
			Console.WriteLine("The review is completed.");
		}
	}

	// The method to check if a flashcard is due for review
	static bool IsDueForReview(Flashcard flashcard)
	{
		// Calculate the number of days since the last review
		var days = (DateTime.Now - flashcard.LastReviewed).Days;

		// Check if the number of days is equal or greater than the box number
		return days >= flashcard.BoxNumber;
	}

	// The method to move a flashcard to a different box
	static void MoveFlashcard(Flashcard flashcard, int delta)
	{
		// Calculate the new box number
		var newBoxNumber = flashcard.BoxNumber + delta;

		// Check if the new box number is valid
		if (newBoxNumber >= 1 && newBoxNumber <= 5)
		{
			// Assign the new box number to the flashcard
			flashcard.BoxNumber = newBoxNumber;
		}
	}*/
}