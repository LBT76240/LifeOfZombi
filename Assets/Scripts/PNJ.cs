using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PNJ : Interactible {

    /// <summary>
    ///     PNJ's name
    /// </summary>
    [SerializeField]
    [Tooltip("PNJ's name")]
    string namePNJ;
    public PNJ_State state_humain;
    public PNJ_State state_zombie;

    /// <summary>
    ///     
    /// </summary>
    /// 

    protected List<Action> listOfAction;
    protected int index = -1;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public int isAlreadyStated()
    {
        int i;
        for (i = 0; i < GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj.Count; i++)
        {
            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj[i] ==
                state_zombie)
            {
                break;
            }

            if (GameObject.FindGameObjectWithTag("gamemanager").GetComponent<GameManager>().state_pnj[i] ==
                state_humain)
            {
                break;
            }
        }
        return i;
    }

    abstract public void Interact(Action action);

    abstract public void Interact(Item item);
}
