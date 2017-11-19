using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoaScript : MonoBehaviour {

    bool alreadyInterract = false;

    public GameObject whoaprefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDown() {
        if(!alreadyInterract) {
            print("whoa");
            Instantiate(whoaprefab, new Vector3(0, 0, 0), Quaternion.identity);
            alreadyInterract = true;
        }
    }
}
