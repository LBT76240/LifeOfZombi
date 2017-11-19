using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void menuQuit() {
        Application.Quit();
    }

    public void menuStart() {
        SceneManager.LoadScene("_preload");
    }

}
