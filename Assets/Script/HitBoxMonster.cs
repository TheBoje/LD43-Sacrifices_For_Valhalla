using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoxMonster : MonoBehaviour {

    private GlobalValue GlobalVal;

     void Start()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        GlobalVal = GameObject.Find("GlobalValue").GetComponent<GlobalValue>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            int weakness = other.GetComponent<HeroScript>().weakness;
            other.GetComponent<HealthScript>().EditLife(-1 * (int)GlobalVal.weakness);
            other.GetComponent<HeroScript>().GetDamage();
        }
    }
}
