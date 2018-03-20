using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    private float lat;
    private float longi;

    private bool setOriginalValues = true;

    private Vector3 targetPosition;
    private Vector3 originalPosition;

    private float speed = .1f;
    IEnumerator GetCoordinates()
    {
        while (true)
        {
            if (!Input.location.isEnabledByUser)
                yield break;
        }

        Input.location.Start(1f, .1f);

        int maxWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        // Service didn't initialize in 20 seconds
        if (maxWait < 1)
        {
            print("Timed out");
            yield break;
        }

        // Connection has failed
        if (Input.location.status == LocationServiceStatus.Failed)
        {
            print("Unable to determine device location");
            yield break;
        }
        else
        {
            // Access granted and location value could be retrieved
            print("Location: " + Input.location.lastData.latitude + " " + Input.location.lastData.longitude + " " + Input.location.lastData.altitude + " " + Input.location.lastData.horizontalAccuracy + " " + Input.location.lastData.timestamp);

            //if original value has not yet been set save coordinates of player on app start
            if (setOriginalValues)
            {
                lat = Input.location.lastData.latitude;
                longi = Input.location.lastData.longitude;
                setOriginalValues = false;
            }
            Input.location.Stop();

        }

        print(lat + "  " + longi);
    }
    // Use this for initialization
    void Start () {
            StartCoroutine("GetCoordinates");
            targetPosition = transform.position;
            originalPosition = transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
            //linearly interpolate from current position to target position
            //transform.position = Vector3.Lerp(transform.position, targetPosition, speed);
            //rotate by 1 degree about the y axis every frame
            //transform.eulerAngles += new Vector3(0, 1f, 0);

        }
}
