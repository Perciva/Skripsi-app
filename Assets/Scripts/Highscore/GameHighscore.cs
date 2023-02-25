
    public class GameHighscore
    {
        private string _username;
        private int _score;

        public GameHighscore(string username, int score)
        {
            _username = username;
            _score = score;
        }

        public string Username
        {
            get => _username;
            set => _username = value;
        }

        public int Score
        {
            get => _score;
            set => _score = value;
        }
    }
