using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    [SerializeField] public string main_text;
    [SerializeField] public string rules_text;
    
    [SerializeField] private Text maintextbox;
    
    // Use this for initialization
    void Start () {
        Scene currentscene = SceneManager.GetActiveScene();
        Debug.Log(currentscene.name);
        if(currentscene.name == "EndMenu")
        {
            main_text = "Final Score: " + StaticsMgr.GetScore();
        }
        else if(currentscene.name == "HomeMenu"){
            main_text = "It's typing time, baby.";
        }

        rules_text = "Type the lines as they fall down the screen.\n " +
                         "Complete a line before it reaches the bottom to earn points.\n" +
                         "Points are equal to the number of characters in the line.\n" +
                         "If a word appears twice or more at a time, you only need to type it once.\n\n" +
                         "Have fun!";

        maintextbox.text = main_text;
	}

    public void ToggleRules()
    {
        if (maintextbox.text == rules_text)
        {
            maintextbox.text = main_text;
        }
        else if (maintextbox.text == main_text)
        {
            maintextbox.text = rules_text;
        }
    }
}
