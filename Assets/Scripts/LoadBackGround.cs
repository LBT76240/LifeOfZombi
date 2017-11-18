using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadBackGround : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("background").GetComponent<ChangeBackGround>().ChangeBack(GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getCurrentScene());

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
