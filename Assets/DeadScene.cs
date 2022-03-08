using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadScene : MonoBehaviour {

    private GlobalValue GV;

    private void Start()
    {
        GV =GameObject.Find("GlobalValue").GetComponent<GlobalValue>();
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (GV.passtuto)
            {
                Application.LoadLevel(1);
            }
            else
            {
                Application.LoadLevel(0);
            }
        }
	}
}
