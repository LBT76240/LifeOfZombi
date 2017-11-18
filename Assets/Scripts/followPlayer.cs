using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

    GameObject zombi;

	// Use this for initialization
	void Start () {

        zombi = GameObject.Find("zombi");
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(zombi.transform.position.x - 0.1f, zombi.transform.position.y + 2.2f);
	}
}
