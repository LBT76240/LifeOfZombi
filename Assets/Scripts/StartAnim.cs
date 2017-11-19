using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnim : MonoBehaviour {

    public GameObject zombi;
    public Animator animator;

	// Use this for initialization
	void Start () {
		if(GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getLastScene() != 0) {
            Destroy(gameObject);
        } else {
            zombi.SetActive(false);
            StartCoroutine(Wait(1.8f));
        }
	}
    IEnumerator Wait(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        zombi.SetActive(true);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update () {
        
    }
}
