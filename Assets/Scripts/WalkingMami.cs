using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingMami : MonoBehaviour {

    Animator Animator;


    // Use this for initialization
    void Start () {
        Animator = GetComponent<Animator>();
        
        Animator.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
