using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue : MonoBehaviour {

    public float score = 0;

    public float damage = 5;

    public float speed = 15;

    public float life = 20;

    public float weakness = 1;

    public bool vision = false;

    public bool passtuto = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ResetVal()
    {
        score = 0;
        damage = 5;
        speed = 15;
        life = 20;
        weakness = 1;
        vision = false;
}

}
