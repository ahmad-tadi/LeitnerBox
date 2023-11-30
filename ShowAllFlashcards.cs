namespace Leitner;

class ShowAllFlashcards : State
{
	public ShowAllFlashcards(LeitnerStateContext leitnerStateContext) : base(leitnerStateContext)
	{
		var flashcards = _context.Flashcards.ToList();
		foreach (var flashcard in flashcards)
		{
			Console.WriteLine($"{flashcard.Question} \t {flashcard.Answer} \t\t\t box:{flashcard.BoxNumber}\t reveiwed:{flashcard.LastReviewedDay.MapNumberToDate():yyyy:MM:dd}");
		}
		SetState<State>();

	}

}
