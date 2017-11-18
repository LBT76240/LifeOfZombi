using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLove : MonoBehaviour {

    [SerializeField]
    GameObject poundingHeart;

    float heartLifeTime;


    // Use this for initialization
    void Start () {
        if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getCurrentScene() == 2) {
            heartLifeTime = 2f;
            StartCoroutine(Wait(1f));
        }
    
    }

    // Update is called once per frame
    void Update () {

    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        StartPounding();
       
    }

    void StartPounding()
    {
        heartLifeTime = 2f;
        Destroy(Instantiate(poundingHeart, new Vector2(transform.position.x - 0.1f, transform.position.y + 2.2f), Quaternion.identity),heartLifeTime);
      
    }
}
