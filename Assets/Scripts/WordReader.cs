using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordReader : MonoBehaviour {

    public Canvas canvas;
    public string latest_string;
    public List<string> potentialmatches;
    
	void Start () {
        latest_string = null;
    }

	void Update () {
        foreach (Transform child in canvas.transform)
        {
            Text tempText = child.GetComponent<Text>();
            Debug.Log(tempText.text);
        }
	}
}
