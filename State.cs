namespace Leitner;
public class State
{
	protected LeitnerStateContext _stateContext;
	protected LeitnerBoxContext _context;
	public State(LeitnerStateContext leitnerStateContext)
	{
		_stateContext = leitnerStateContext;
		_context = leitnerStateContext.DbContext;
		if (!GetType().IsSubclassOf(typeof(State)))
			Console.Write(">");

    }
    protected void SetState(State? state)
	{
		_stateContext.State = state;
	}
	protected void SetState<T>() where T : State
	{
		SetState((T?)Activator.CreateInstance(typeof(T), _stateContext));
	}
	public void Handle(string input)
	{
		switch (input)
		{
			case "1":
				SetState<CreateFlashcard>();
				break;
			case "2":
				SetState<ReviewFlashcards>();
				break;
			case "3":
				SetState<ShowAllFlashcards>();
				break;
			case "4":
				Console.Clear();
				break;
			case "0":
				Console.WriteLine("Thank you for using the Leitner Box!");
				Environment.Exit(0);
				break;
			default:
				_stateContext.State?.Command(input);
				break;
		}
	}
	protected void MoveFlashcard(Flashcard flashcard, int delta)
	{
		// Calculate the new box number

		var newBoxNumber = flashcard.BoxNumber + delta;

		// Check if the new box number is valid
		if (newBoxNumber >= 1 && newBoxNumber <= 5)
		{
			// Assign the new box number to the flashcard
			flashcard.BoxNumber = newBoxNumber;
		}
	}
	protected virtual void Command(string input)
	{
        Console.WriteLine("No command found!");
        Console.Write(">");
    }

}
