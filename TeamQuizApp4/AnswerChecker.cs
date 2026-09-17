namespace TeamQuizApp4
{
    public class AnswerChecker
    {
        public bool CheckAnswer(Question q, int selectedIndex)
        {
            return q.CorrectIndex == selectedIndex;
        }
    }
}