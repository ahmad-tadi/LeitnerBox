namespace Leitner;

public class Flashcard
{
	public int Id { get; set; } // The primary key
	public string Question { get; set; } // The question or term to be learned
	public string Answer { get; set; } // The answer or definition to be recalled
	public int BoxNumber { get; set; } // The box number that indicates the level of mastery
	
	public int LastReviewedDay { get; set; } 
    }