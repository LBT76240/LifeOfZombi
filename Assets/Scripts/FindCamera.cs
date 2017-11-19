using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class FindCamera : MonoBehaviour {

    public VideoPlayer videoPlayer; 

	// Use this for initialization
	void Start () {
        videoPlayer.targetCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

    }
	
	// Update is called once per frame
	void Update () {
        if(videoPlayer.frame== (long)videoPlayer.frameCount) {
            Destroy(gameObject);
        }

    }
}
