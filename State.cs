namespace Leitner;
public class LeitnerStateContext
{
	public LeitnerBoxContext DbContext {  get; private set; }
	private State _state;
    public State State { get; set; }
    public LeitnerStateContext(LeitnerBoxContext leitnerBoxContext)
	{
		DbContext = leitnerBoxContext;
		State = new State(this);
	}
}
public class State
{
	private State? _state;
	protected LeitnerStateContext _stateContext;
	protected LeitnerBoxContext _context;
    public State(LeitnerStateContext leitnerStateContext)
	{
		_stateContext = leitnerStateContext;
		_context = leitnerStateContext.DbContext;
		_state = leitnerStateContext.State;
	}
	protected void SetState(State state)
	{
		_state = state;
	}
	protected void SetState<T>() where T :  State
	{
		_state = (T?)Activator.CreateInstance(typeof(T),_stateContext);
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
				_state?.Command(input);
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

    }

}
