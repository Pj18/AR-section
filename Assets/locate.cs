using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locate : MonoBehaviour {

    public float latitude;
    public float longitude;
   
    IEnumerator Locate()
    {
        if (!Input.location.isEnabledByUser)
            yield break;

        Input.location.Start(1f, .1f);

        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("location Failed!");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
    }

	// Use this for initialization
	void Start () {
        StartCoroutine("Locate");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
