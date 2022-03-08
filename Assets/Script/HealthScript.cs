using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public int life;
    public AudioClip hurt;
    public int deadScene;

    public bool isDamagable = true;
    private Animator anim;
    private GlobalValue GlobalVal;

    void Start() {
        GlobalVal = GameObject.Find("GlobalValue").GetComponent<GlobalValue>();
        anim = GetComponent<Animator>();
        if(anim == null && !transform.parent)
        {
            anim = transform.GetChild(0).GetComponent<Animator>();
        }else if(anim == null)
        {
            anim = transform.parent.GetComponent<Animator>();
        }
    }

    void Update()
    {        
        if (life <= 0 && transform.parent)
        {
            if (transform.tag != "Player")
            {
                if (transform.tag == "Monster")
                {
                    GlobalVal.score += 100;
                }
                if (transform.tag == "Skelette")
                {
                    GlobalVal.score += 200;
                }
                Debug.Log(GlobalVal.score);
            }
            Destroy(this.transform.parent.gameObject);
        }else if(life <= 0)
        {
            if (transform.tag != "Player")
            {
                if(transform.tag == "Monster")
                {
                    GlobalVal.score += 100;
                }
                if (transform.tag == "Skelette")
                {
                    GlobalVal.score += 200;
                }
                Debug.Log(GlobalVal.score);
            }
            else
            {
                Application.LoadLevel(deadScene);
                GlobalVal.ResetVal();
            }
            Destroy(this.gameObject);
        }

    }

    public void EditLife(int e)
    {
        if (!isDamagable)
            return;
        AudioSource.PlayClipAtPoint(hurt, transform.position);
        life += e;
        anim.SetTrigger("Damage");
    }
}
