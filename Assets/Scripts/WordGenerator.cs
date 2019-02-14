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
    
    public float LeftEdge = 100;
    public float RightEdge = Screen.width - 100;
    public float BottomEdge = 30;
    public float TopEdge = Screen.height - 30;

    void Start () {
        string word;
        using (StreamReader sr = new StreamReader("Assets/Files/words.txt"))
        {
            while (!(sr.EndOfStream))
            {
                word = sr.ReadLine();
                Words.Add(word);
            }
        }

        LeftEdge = 100;
        RightEdge = Screen.width - 100;
        BottomEdge = 30;
        TopEdge = Screen.height - 30;

    InvokeRepeating("CreateText", 0.01f, 1.0f);
    }
	
    void CreateText()
    {
        GameObject FallingWord = Instantiate(WordText, maincanvas.transform, true);
        Text wordtext = FallingWord.GetComponent<Text>();

        Vector2 rndPosition = new Vector2(Random.Range(LeftEdge, RightEdge), Random.Range(BottomEdge, TopEdge));
        FallingWord.transform.position = rndPosition;

        int rndIndex = Random.Range(0, Words.Count - 1);
        wordtext.text = Words[rndIndex];
    }

    // Update is called once per frame
    void Update () {
	}
}
