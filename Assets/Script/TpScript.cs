using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpScript : MonoBehaviour {

    public int nextScene;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (Application.loadedLevel == 1)
                GameObject.Find("GlobalValue").GetComponent<GlobalValue>().passtuto = true;
            Application.LoadLevel(nextScene);
        }
    }
}
