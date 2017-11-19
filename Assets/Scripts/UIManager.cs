using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    Slider slider;

    [SerializeField]
    Slider sliderTime;

    GameObject gameManager;
    public Sprite sprite_default;
    public Texture2D texture_default;
	// Use this for initialization
	void Start () {
       gameManager = GameObject.FindGameObjectWithTag("gamemanager");
        slider.minValue = gameManager.GetComponent<GameManager>().MinMoral;
        slider.maxValue = gameManager.GetComponent<GameManager>().MaxMoral;
        sliderTime.maxValue = gameManager.GetComponent<GameManager>().Time;
    }
	
	// Update is called once per frame
	void Update () {
        slider.value = gameManager.GetComponent<GameManager>().Moral;
        sliderTime.value = gameManager.GetComponent<GameManager>().currentTime;
        if (slider.value < (slider.minValue + slider.maxValue)/2)
        { 
            GameObject.Find("SliderBack").GetComponent<Image>().color= new Color(99f/255f, 124f/255f, 99f/255f);
            GameObject.Find("SliderFill").GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else if(slider.value > (slider.minValue + slider.maxValue) / 2)
        {
            GameObject.Find("SliderFill").GetComponent<Image>().color = new Color(1, 205f / 255f, 93f/255f);
            GameObject.Find("SliderBack").GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else
        {
            GameObject.Find("SliderBack").GetComponent<Image>().color = new Color(1, 1, 1);
            GameObject.Find("SliderFill").GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

}
