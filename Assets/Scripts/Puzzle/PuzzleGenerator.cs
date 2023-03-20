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
            int a = 0;
            List<EncryptionPuzzle> enc= new List<EncryptionPuzzle>(fb.LoadEncryptionPuzzles());
            for (int i = 0; i < 4; i++)
            {
                a = Random.Range(0, enc.Count);
                _puzzles.Add(enc[a]);
                _combinedKey = _combinedKey + enc[a].Key;
                enc.RemoveAt(a);
            }
            List<WebPuzzle> web= new List<WebPuzzle>(fb.LoadWebPuzzles());
            a = Random.Range(0, web.Count);
            Debug.Log("Web Key: "+web[a].WebKey );
            _puzzles.Add(web[a]);
            Debug.Log("Web Key: "+(_puzzles[4]as WebPuzzle).WebKey );
            _combinedKey = _combinedKey + web[a].Key;

            stegPuzzle sp = new stegPuzzle("Steganography","please open the steganography tool and find the key","steganography","1483");
            _puzzles.Add(sp);

            _combinedKey = _combinedKey + "1483";
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
            for (int i = 0; i < _puzzles.Count; i++)
            {
                Debug.Log(_puzzles[i] is WebPuzzle);
                if(_puzzles[i] is WebPuzzle) Debug.Log((_puzzles[i] as WebPuzzle).WebKey);
            }
            Debug.Log(_combinedKey);
            Debug.Log(_puzzles[index]);
            return _puzzles[index];
        }
    }
}