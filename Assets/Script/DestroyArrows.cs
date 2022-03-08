using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyArrows : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sol" || other.tag == "Mur")
        {
            Destroy(gameObject);
        }else if (other.tag == "Player")
        {
            int weakness = other.GetComponent<HeroScript>().weakness;
            other.GetComponent<HealthScript>().EditLife(-1);
            other.GetComponent<HeroScript>().GetDamage();
        }
    }

}
