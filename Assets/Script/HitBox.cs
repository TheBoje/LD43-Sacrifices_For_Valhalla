using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (!transform.IsChildOf(other.transform) && other.transform.GetComponent<HealthScript>())
        {
            other.GetComponent<HealthScript>().EditLife((int)-transform.parent.parent.GetComponent<HeroScript>().damage);
            other.transform.parent.GetComponent<MonsterScripts>().GetDamage();
            other.transform.parent.GetComponent<Skeletons>().GetDamage();
        }
    }
}
