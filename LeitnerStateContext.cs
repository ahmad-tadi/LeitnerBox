namespace Leitner
{
	public class LeitnerStateContext
	{
		public LeitnerBoxContext DbContext { get; private set; }
		public State? State { get; set; }
		public LeitnerStateContext(LeitnerBoxContext leitnerBoxContext)
		{
			DbContext = leitnerBoxContext;
			State = new State(this);
		}
	}
}
