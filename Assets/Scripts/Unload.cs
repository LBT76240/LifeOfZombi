using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Unload : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (GameObject.FindGameObjectWithTag("uimanager") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("uimanager"));
        }
        if (GameObject.FindGameObjectWithTag("gamemanager") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("gamemanager"));
        }
        SceneManager.LoadScene("Menu");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
