namespace Leitner;

class ReviewFlashcards : State
{
	readonly Flashcard _flashcard;
	Guid giud = Guid.NewGuid();
	public ReviewFlashcards(LeitnerStateContext leitnerStateContext) : base(leitnerStateContext)
	{
        var todayAsNum = DateTime.Now.MapDateToNumber();
		var target = _context.Flashcards
			.Where(x => todayAsNum - x.LastReviewedDay >= x.BoxNumber)
			.FirstOrDefault();

		if (target is null)
		{
			Console.WriteLine("There are no flashcards to review.");
			SetState<State>();
		}
		else
		{
			_flashcard = target;
			Console.WriteLine($"Question: {target.Question}");
			Console.WriteLine("Please enter the answer or press Enter to skip:");

		}
	}

	protected override void Command(string command)
	{
        Console.WriteLine(giud);
		var answer = command;
		if (_flashcard is null)
		{
			SetState(new State(_stateContext));
			return;
		}

		if (answer == "del")
		{
			_context.Remove(_flashcard);
			_context.SaveChanges(true);
			Console.WriteLine($"{_flashcard?.Question} ({_flashcard?.Answer}) has been deleted.");
			return;
		}
		if (answer == _flashcard.Answer)
		{
			Console.WriteLine("Correct!");

			MoveFlashcard(_flashcard, 1);
		}
		else
		{
			Console.WriteLine($"Wrong! The correct answer is: {_flashcard?.Answer}");

			MoveFlashcard(_flashcard, -_flashcard.BoxNumber + 1);
		}

		_flashcard.LastReviewedDay = DateTime.Now.MapDateToNumber();

		_context.SaveChanges();
		SetState<ReviewFlashcards>();
	}

}
