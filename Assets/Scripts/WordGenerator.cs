using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WordGenerator : MonoBehaviour {

    public List<string> Words;
    private string word; // file is new-line separated already
    //private List<string> Words;

    void Start () {
        using (StreamReader sr = new StreamReader("Assets/Files/words.txt"))
        {
            while (!(sr.EndOfStream))
            {
                word = sr.ReadLine();
                Words.Add(word);
            }
        }

        foreach(string word in Words)
        {
            Debug.Log(word);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
