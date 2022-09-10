using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    private Transform penguin;

	// Use this for initialization
	void Start () {

        penguin = GameObject.Find("Penguin").transform;
		
	}
	
	// Update is called once per frame
	void Update () {

        FollowThePenguin();

    }

    void FollowThePenguin()
    {
        if(penguin != null)
        {
            Vector3 temp = transform.position;
            temp.x = penguin.position.x - 5f;
            transform.position = temp;
        }
    }
}
