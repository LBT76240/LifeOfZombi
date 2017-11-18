﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Clickable {

    [SerializeField]
    int nextLevel;

    GameObject zombi;
    Vector3 target;

    public int NextLevel
    {
        get
        {
            return this.nextLevel;
        }
        set
        {
            this.nextLevel = value;
        }
    }


    // Use this for initialization
    void Start ()
    {
        zombi = GameObject.Find("zombi");
    }
	
	// Update is called once per frame
	void Update () {
		
        //if(zombi.transform. )
	}

    protected override void OnMouseDownAction()
    {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Texture2D test = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default);
        Cursor.SetCursor(test, hotspot, curMod);
            
        StartCoroutine(FinishWalking());
    }

    IEnumerator FinishWalking()
    {
        yield return new WaitForSeconds(0.1f);
        Vector3 target = zombi.GetComponent<Character>().getTarget();
        bool doneWalking = false;
        while(!doneWalking)
        {
            yield return new WaitForSeconds(0.1f);
            if (!zombi.GetComponent<Character>().IsWalking)
            {
                doneWalking = true;              
            }
            
        }

        if(Mathf.Abs(target.x - zombi.transform.position.x) <= 0.2)
        {
            ChangeScene();
        }
    }
    void ChangeScene()
    {
        GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().changeCurrentScene(NextLevel);
        if (NextLevel == 1) {
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().playMusicGraveYard();
        } else {
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().playMusicCity();
        }
        SceneManager.LoadScene("Scene" + nextLevel);

    }
    protected override void OnMouseRightAction()
    {
        return;
    }
}
