using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class WordGenerator : MonoBehaviour {

    public List<string> Words;
    public Canvas maincanvas;
    public GameObject WordText;

    void Start () {
        StaticsMgr.SetWordCount(0);

        // read each line in from the code file as a "word"
        string word;
        using (StreamReader sr = new StreamReader("Assets/Files/practice-code.cpp"))
        {
            while (!(sr.EndOfStream))
            {
                word = sr.ReadLine();
                Words.Add(word);
            }
        }

        // SpawnWord() recursively calls itself at random intervals
        Invoke("SpawnWord", 0.5f);
    }

    void SpawnWord()
    {
        // instantiate the falling word and fill with word data
        GameObject FallingWord = Instantiate(WordText, maincanvas.transform, true);
        Text wordtext = FallingWord.GetComponent<Text>();
        int rndIndex = Random.Range(0, Words.Count - 1);
        wordtext.text = Words[rndIndex];

        // spawn points
        float x1, x2, x3;
        x1 = Screen.width * 0.3f;
        x2 = Screen.width * 0.5f;
        x3 = Screen.width * 0.7f;

        Vector2 rndposition;
        // spawn most of the short words at x1 and x3
        if (Words[rndIndex].Length < 15)
        {
            float rndvalue = Random.value;
            if (rndvalue <= 0.45f)
                rndposition = new Vector2(x1, Screen.height + 10);
            else if (rndvalue <= 0.55f)
                rndposition = new Vector2(x2, Screen.height + 10);
            else
                rndposition = new Vector2(x3, Screen.height + 10);
        }
        else
            rndposition = new Vector2(x2, Screen.height + 10);

        FallingWord.transform.position = rndposition;

        StaticsMgr.UpdateWordCount(1);
        Invoke("SpawnWord", Random.value + 0.5f);
    }
}
