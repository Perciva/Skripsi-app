namespace Puzzle
{
    public class WebPuzzle:Puzzle
    {
        private string webKey;

        public WebPuzzle(string title, string question, string type, string keya, string webKey) : base(title, question, type, keya)
        {
            this.webKey = webKey;
        }
    }
}