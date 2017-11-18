using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Clickable {

    [SerializeField]
    int nextLevel;


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
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnMouseDownAction()
    {
        
            SceneManager.LoadScene("Scene"+nextLevel);
       

    }

    protected override void OnMouseRightAction()
    {
        return;
    }
}
