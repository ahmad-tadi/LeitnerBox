namespace Leitner;

class CreateFlashcard : State
{
		string? question;
		string? answer;
	public CreateFlashcard(LeitnerStateContext leitnerStateContext) : base(leitnerStateContext)
	{
		Console.WriteLine("Please enter the question or term to be learned:");
	}

	protected override void Command(string command)
	{
		if (question is null)
		{
			question = command;
			SetState(this);
		Console.WriteLine("Please enter the answer or definition to be recalled:");
		}
		else
		{
			answer = command;
			var flashcard = new Flashcard
			{
				Question = question,
				Answer = answer,
				BoxNumber = 1,
				LastReviewedDay = DateTime.Now.MapDateToNumber()
			};

			_context.Flashcards.Add(flashcard);

			_context.SaveChanges();

			Console.WriteLine("The flashcard has been created successfully.");
			SetState(new State(_stateContext));
		}
	}
}
