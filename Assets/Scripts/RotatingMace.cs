using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMace : MonoBehaviour {

    public GameObject axis;
    public float speedOfRotating;

    private bool isRotate;

	// Use this for initialization
	void Start () {

        isRotate = true;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButton(0))
        {
            StartCoroutine(StopRotating());
        }

	}

    void Attack()
    {
        if (isRotate)
        {
            transform.RotateAround(axis.transform.position, Vector3.forward, speedOfRotating * (Time.deltaTime));
        }
    }

    IEnumerator StopRotating()
    {
        Attack();
        yield return new WaitForSeconds(.8f);
        isRotate = false;
    }
}
