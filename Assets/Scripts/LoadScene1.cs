﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().playMusicGraveYard();
        SceneManager.LoadScene("Scene" + 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
