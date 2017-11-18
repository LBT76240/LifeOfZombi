using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Clickable {

    [SerializeField]
    int nextLevel;

    GameObject zombi;

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

        Texture2D test = GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().getTexture(Action.Default);
        Cursor.SetCursor(test, hotspot, curMod);

        if(NextLevel==1) {
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().playMusicGraveYard();
        } else {
            GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().playMusicCity();
        }
        SceneManager.LoadScene("Scene"+nextLevel);
       


        StartCoroutine(FinishWalking());
    
    }

    IEnumerator FinishWalking()
    {
        yield return new WaitForSeconds(0.1f);
        bool doneWalking = false;
        while(!doneWalking)
        {
            yield return new WaitForSeconds(0.1f);
            if (!zombi.GetComponent<Character>().IsWalking)
            {
                doneWalking = true;
                
            }
            
        }

        ChangeScene();
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Scene" + nextLevel);

    }
    protected override void OnMouseRightAction()
    {
        return;
    }
}
