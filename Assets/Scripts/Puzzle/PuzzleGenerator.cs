using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class PuzzleGenerator
    {
        private static PuzzleGenerator _mInstance;
        private List<Puzzle> _puzzles;
        private Filebase fb;
        private string _combinedKey;
        public static PuzzleGenerator Instance
        {
            get
            {
                if (_mInstance == null) _mInstance = new PuzzleGenerator();
                return _mInstance;
            }
        }
        private PuzzleGenerator()
        {
            fb = Filebase.Instance;
            _puzzles = new List<Puzzle>(10);
            LoadPuzzles();
        }
        
        public void LoadPuzzles()
        {
            List<EncryptionPuzzle> enc= new List<EncryptionPuzzle>(fb.LoadEncryptionPuzzles());
            for (int i = 0; i < 4; i++)
            {
                int a = Random.Range(0, enc.Count);
                _puzzles.Add(enc[a]);
                _combinedKey = _combinedKey + enc[a].Key;
                enc.RemoveAt(a);
            }
        }

        public bool CheckCombinedKey(string key)
        {
            Debug.Log(key + " " + _combinedKey);
            Debug.Log(_combinedKey.Length+" " + key.Length);
            return key.Equals(_combinedKey);
        }

        public Puzzle GetPuzzle(int index)
        {
            index--;
            Debug.Log(_combinedKey);
            return _puzzles[index];
        }
    }
}