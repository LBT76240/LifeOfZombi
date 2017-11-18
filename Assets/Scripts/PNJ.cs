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

    /// <summary>
    ///     
    /// </summary>

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    abstract public void Interact(Action action);

    abstract public void Interact(Item item);
}
