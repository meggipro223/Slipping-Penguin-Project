using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningBombs : MonoBehaviour {

    public GameObject bombs;
    private int randomNumber;

	
	// Update is called once per frame
	void Update () {

        randomNumber = Random.Range(-70, -55000);

        for(int i = 0; i < 2; i++)
        {
            Instantiate(bombs, new Vector3(randomNumber, -3.9f, 0), Quaternion.identity);
        }

	}
}
