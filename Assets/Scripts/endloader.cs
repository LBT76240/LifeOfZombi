using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endloader : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float Morale = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().Moral;
        float maxValue = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().MaxMoral;
        float minValue = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().MinMoral;

        List<PNJ_State> choiceMade = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj;
        if (GameObject.FindGameObjectWithTag("uimanager") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("uimanager"));
        }
        if (GameObject.FindGameObjectWithTag("gamemanager") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("gamemanager"));
        }

        if (choiceMade.Count == 0)
        {
            SceneManager.LoadScene("nothingEnding");
        }
        else
        {
            if (Morale == maxValue)
            {
                SceneManager.LoadScene("humanEnding");
            }
            else if (Morale == minValue)
            {
                SceneManager.LoadScene("zombieEnding");
            }
            else
            {
                SceneManager.LoadScene("mixedEnding");
            }
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
