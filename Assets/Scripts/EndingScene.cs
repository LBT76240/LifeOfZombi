using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EndingScene : MonoBehaviour {

    public float speed;
    Text textDisplayer;

    [SerializeField]
    public string textToDisplay;

    float textSize;

    // Use this for initialization
    void Start () {
        textDisplayer = GetComponent<Text>();
        textSize = textToDisplay.Length;
        StartCoroutine(DisplayText());
	}

    IEnumerator DisplayText() {
        foreach(char c in textToDisplay)
        {
            textDisplayer.text += c;
            yield return new WaitForSeconds(speed);
            Debug.Log(textDisplayer.text);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
