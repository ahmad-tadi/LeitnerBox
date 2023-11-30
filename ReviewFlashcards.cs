namespace Leitner;

class ReviewFlashcards : State
{
    readonly Flashcard _flashcard;

    public ReviewFlashcards(LeitnerStateContext leitnerStateContext) : base(leitnerStateContext)
    {
        var todayAsNum = DateTime.Now.MapDateToNumber();
        var rand = new Random();
        bool condition(Flashcard x) => todayAsNum - x.LastReviewedDay >= (x.BoxNumber) * 2;
        var count = _context.Flashcards
        .Where(condition)
        .Count(); 
        var target = _context.Flashcards
        .Where(condition)
        .Skip(rand.Next(count)) 
        .Take(1) 
        .FirstOrDefault(); 

        if (target is null)
        {
            Console.WriteLine("There are no flashcards to review.");
            SetState<State>();
            return;
        }
        _flashcard = target;
        Console.WriteLine($"Box Number: {target.BoxNumber}");
        Console.Write("- " + target.Question + ": ");
    }

    protected override void Command(string answer)
    {
        if (_flashcard is null) return;
        if (answer == "del")
        {
            _context.Remove(_flashcard);
            _context.SaveChanges(true);
            Console.WriteLine($"{_flashcard?.Question} ({_flashcard?.Answer}) has been deleted.");
            return;
        }
        else if (answer == _flashcard.Answer)
        {
            Console.WriteLine("Correct!");
            MoveFlashcard(_flashcard, 1);
        }
        else if (answer == "y")
        {
            Console.WriteLine("OK! and the Answer is: " + _flashcard.Answer);
            MoveFlashcard(_flashcard, 1);
        }
        else if (answer == "n")
        {
            Console.WriteLine($"The correct answer is: {_flashcard?.Answer}");
            MoveFlashcard(_flashcard, -_flashcard.BoxNumber + 1);
        }
        else if (answer == "s")
        {
            Console.WriteLine($"The correct answer is: {_flashcard?.Answer}");
            Console.WriteLine("Did you know? For accept type \'y\' otherwise type \'n\'");
        }
        else if (_flashcard.Answer.Contains(answer))
        {
            Console.WriteLine("Kind of Correction! For accept type \'y\' otherwise type \'n\'");
        }
        else if (answer == _flashcard.Question)
        {
            Console.WriteLine("The right word spelling! Now put the answer:");
        }
        else
        {
            Console.WriteLine("Put \"n\" if you don't remember..");
            return;
        }
        _flashcard.LastReviewedDay = DateTime.Now.MapDateToNumber();

        _context.SaveChanges();
        SetState<ReviewFlashcards>();
    }

}
