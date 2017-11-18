using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InLove : MonoBehaviour {

    [SerializeField]
    GameObject poundingHeart;

    [SerializeField]
    [Tooltip("Heart beating when zombi is in love")]
    AudioClip heartPounding;



    private AudioSource audioSource;

    float heartLifeTime;


    // Use this for initialization
    void Start () {

        heartLifeTime = 2f;
        StartCoroutine(Wait(1f));
        audioSource = GetComponent<AudioSource>();
    
    }

    // Update is called once per frame
    void Update () {

        heartLifeTime -= Time.deltaTime;

        if (heartLifeTime <= 0)
        {
            audioSource.Stop();
        }
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
        audioSource.clip = heartPounding;
        audioSource.loop = false;
        audioSource.Play();

       
    }
}
