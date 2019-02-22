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

    public float left_x = Screen.width * 0.25f,
                 center_x = Screen.width * 0.4f,
                 right_x = Screen.width * 0.65f;

    void Start () {
        string word;
        using (StreamReader sr = new StreamReader("Assets/Files/practice-code.cpp"))
        {
            while (!(sr.EndOfStream))
            {
                word = sr.ReadLine();
                Words.Add(word);
            }
        }

        LeftEdge = 100;
        RightEdge = Screen.width - 100;
        BottomEdge = 100;
        TopEdge = Screen.height - 30;

        InvokeRepeating("SpawnWord", 0.01f, 2f);
    }

    void SpawnWord()
    {
        GameObject FallingWord = Instantiate(WordText, maincanvas.transform, true);
        Text wordtext = FallingWord.GetComponent<Text>();

        int rndIndex = Random.Range(0, Words.Count - 1);
        wordtext.text = Words[rndIndex];

        float x_pos = 0f;
        if (Words[rndIndex].Length > 12)
            x_pos = center_x;
        else
        {
            float randvalue = Random.value;
            if (randvalue <= 0.5f) x_pos = left_x;
            else if (randvalue <= 1f) x_pos = right_x;
        }

        Vector2 rndPosition = new Vector2(x_pos, Screen.height + 10);
        FallingWord.transform.position = rndPosition;
    }
}
