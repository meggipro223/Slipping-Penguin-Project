using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour {

    public static ScrollingBG instance;
    public bool isScrolling;
    public float speedOfScrolling;

	// Use this for initialization
	void Start () {

        MakeInstance();

    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
	
	// Update is called once per frame
	void Update () {

        Scroll();

    }

    void Scroll()
    {
        if (isScrolling)
        {
            Vector2 offset = new Vector2(Time.time * speedOfScrolling, 0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
    }
}
