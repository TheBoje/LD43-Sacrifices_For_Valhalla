using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidenRoofScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        this.GetComponent<MeshRenderer>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Quand le joueur rentre dans la maison, le toit s'enlève
    void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        if(other.tag == "Player")
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            //Debug.Log("RENTRE");
        }
    }

    // Quand le joueur sort de la maison, le toit reviens
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            //Debug.Log("SORT");
        }
    }
}
