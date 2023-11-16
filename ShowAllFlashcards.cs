namespace Leitner;

class ShowAllFlashcards : State
{
	public ShowAllFlashcards(LeitnerStateContext leitnerStateContext) : base(leitnerStateContext)
	{
		var flashcards = _context.Flashcards.ToList();
		foreach (var flashcard in flashcards)
		{
			Console.WriteLine(flashcard.Question);
		}
		SetState<State>();

	}

}
