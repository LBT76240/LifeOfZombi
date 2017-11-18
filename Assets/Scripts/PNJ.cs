using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : Interactible {

    /// <summary>
    ///     PNJ's name
    /// </summary>
    [SerializeField]
    [Tooltip("PNJ's name")]
    string name;

    /// <summary>
    ///     
    /// </summary>

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void OnMouseDownAction() {
        return;
    }

    protected override void OnMouseRightAction() {
        return;
    }

    private void OnMouseOver() {
        return;
    }
}
