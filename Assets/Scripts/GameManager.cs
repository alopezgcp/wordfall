using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Canvas canvas;
    public InputField userinput;
    public Text input_text;

    private string input_string;
    private GameObject[] active_words;

    public static bool is_match;

    void Start () {
        userinput.ActivateInputField();
    }

	void Update () {
        FindMatches();
    }

    public void FindMatches()
    {
        input_string = input_text.text;

        active_words = GameObject.FindGameObjectsWithTag("falling-word");

        if (input_string != "")
        {
            foreach (GameObject word in active_words)
            {
                Text text_component = word.GetComponent<Text>();
                string word_string = text_component.text;

                is_match = true; // assume it's a match; prove if it isn't, THEN choose color
                for (int i = 0; i < input_string.Length; i++)
                {
                    if (input_string[i] != word_string[i])
                    {
                        is_match = false;
                        break;
                    }
                }

                // if the input string matches any word so far, highlight that word
                if (is_match)
                {
                    // Color32() takes 0-255 as rbg values; Color() takes 0-1 as rgb
                    text_component.color = new Color32(50, 255, 50, 255);
                }
                else
                {
                    // same as calling Color(1,1,1,1)
                    text_component.color = new Color32(255, 255, 255, 255);
                }

                // if the input completely matches a word, destroy word and reset input text
                if (input_string == word_string)
                {
                    GameObject.Destroy(word);
                    userinput.text = "";
                }

                // if the word gets to the bottom, just destroy it
                if(word.transform.position.y < 100)
                {
                    GameObject.Destroy(word);
                }
            }
        }
        else foreach (GameObject word in active_words)
        {
            word.GetComponent<Text>().color = new Color(1, 1, 1, 1);

            if (word.transform.position.y < 100)
            {
                GameObject.Destroy(word);
            }
        }
    }
}
