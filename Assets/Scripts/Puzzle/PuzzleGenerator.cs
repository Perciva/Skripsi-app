using System.Collections.Generic;
using UnityEngine;

namespace Puzzle
{
    public class PuzzleController
    {
        private List<Puzzle> _puzzles;
        private Filebase fb;

        public PuzzleController()
        {
            fb = Filebase.Instance;
        }
        
        public void LoadPuzzles()
        {
            List<EncryptionPuzzle> enc= fb.LoadEncryptionPuzzles();
            for (int i = 0; i < 4; i++)
            {
                int a = Random.Range(0, enc.Count);
                _puzzles.Add(enc[a]);
                enc.RemoveAt(a);
            }
            
        }
    }
}