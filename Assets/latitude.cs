using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class latitude : MonoBehaviour {

    public float lat;
    public result Lati;

    
    // Use this for initialization
    void Start () {

        lat = Input.location.lastData.latitude;
        print(lat);
        Lati.text = Input.location.lastData.latitude.ToString();

    }
	
	// Update is called once per frame
	void Update () {
        
    }
}
