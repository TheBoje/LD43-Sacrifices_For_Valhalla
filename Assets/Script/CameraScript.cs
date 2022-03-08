using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    private GameObject player;
    public Vector3 positionCameraBase;
    private Vector3 positionCameraFinal;
    

	// Use this for initialization  
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }
	
	// Update is called once per frame
	void Update () {
       
        positionCameraFinal = player.transform.position + positionCameraBase;
        transform.position = positionCameraFinal;
    }
}
