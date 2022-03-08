using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour {

    public GameObject Text;

    private float cd = 0;

    private void Start()
    {
        cd = Time.time;
    }

    void Update () {
        if (Time.time >= cd + 5f)
        {
            Text.GetComponent<TextMesh>().characterSize = 0.25f;
            Text.GetComponent<TextMesh>().text = "Made by Feugeas Simon, Leenart Louis & Commin Vincent.\n" +
                "Made in 48h for the LD43" +
                "Thanks for playing :)" +
                "\nYou can quit!";
        }
	}
}
