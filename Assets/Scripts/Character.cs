using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Interactible {

    Vector3 target;

    [SerializeField]
    [Tooltip("Sets the movement speed of the zombie")]
    float speed = 1.5f;

    /// <summary>
    ///     The character rotates to look at the mouse
    /// </summary>
    void FaceClickedPoint() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );
        transform.eulerAngles = new Vector3(transform.rotation.x, direction.x > 0 ? 0 : -180, transform.rotation.z);
    }

    /// <summary>
    ///     Updates the coordinates of the coordinates toward where the zoombie must walk to on click
    /// </summary>
    /// 
    void UpdateTarget() {
        target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        target.y = transform.position.y;    //  Horizontal movement only
        target.z = transform.position.z;
    }

    // Use this for initialization
    void Start () {
        target = transform.position;
        action = Action.Prendre;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            UpdateTarget();
            FaceClickedPoint();
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }


    override protected void OnMouseDownAction() {
        //AudioSource audio = GetComponent<AudioSource>();
        //audio.Play();
        //audio.Play(44100);
    }

    protected override void OnMouseRightAction() {
        return;
    }
}
