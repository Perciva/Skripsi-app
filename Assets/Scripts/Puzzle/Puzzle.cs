using UnityEngine;

namespace Puzzle
{
    public abstract class Puzzle
    {
        protected string title;
        protected string question;
        protected string type;
        protected string keya;

        
        public bool CheckKey(string key)
        {

            return Equals(key,keya);
        }

        private bool Equals(string a, string b)
        {
            char[] aca = a.ToCharArray();
            char[] bca = b.ToCharArray();
            Debug.Log("a : b" + a.Trim().Length+ " :"+b.Trim().Length);
            Debug.Log("a : b" + aca[a.Length-1]+ ":"+b);
            if (a.Length-1 != b.Length) return false;
            for (int i = 0; i < b.Length; i++)
            {
                Debug.Log(aca[i] + "!=" + bca[i]);
                if (aca[i] != bca[i]) return false;
            }
            return true;
        }

        protected Puzzle(string title, string question, string type, string keya)
        {
            this.title = title;
            this.question = question;
            this.type = type;
            this.keya = keya;
        }

        public string Title
        {
            get => title;
            private set => title = value;
        }

        public string Question
        {
            get => question;
            private set => question = value;
        }

        public string Type
        {
            get => type;
            private set => type = value;
        }

        public string Key
        {
            get => keya;
            private  set => keya = value;
        }

    }
}