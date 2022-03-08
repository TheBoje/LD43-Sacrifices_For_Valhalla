using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScripts : MonoBehaviour {

    public float speed = 6.0f;
    public int damage;
    public float gravity;
    public float dist;

    private float invisibleTime;
    private Vector3 playerLastSeen;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;
    private Vector3 offset;
    private Animator anim;


    void Start() {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            playerLastSeen = other.transform.position;
            Vector3 pos = new Vector3( - playerLastSeen.x + transform.position.x, 0, - playerLastSeen.z + transform.position.z);
            transform.rotation = Quaternion.LookRotation(pos.normalized);
            if (knockBackCounter <= 0)
            {
                offset = other.transform.position - transform.position;
                offset = offset.normalized * speed;
                if (Vector3.Distance(transform.position, other.transform.position) < dist)
                {                    
                    anim.SetTrigger("Hit");
                    offset = Vector3.zero;
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime;
            }

        }
    }


    public void GetDamage()
    {
        if (transform.GetChild(0).GetComponent<HealthScript>().isDamagable)
        {
            //AudioSource.PlayClipAtPoint(grunt, transform.position);
            anim.SetTrigger("Damage");
            invisibleTime = Time.time;
            KnockBack(transform.position - playerLastSeen);
            transform.GetChild(0).GetComponent<HealthScript>().isDamagable = false;
        }
    }

    private void Update()
    {

        gameObject.GetComponent<CharacterController>().Move(offset * Time.deltaTime + Vector3.down * gravity);


        if (Time.time >= invisibleTime + 0.75f)
        {
            transform.GetChild(0).GetComponent<HealthScript>().isDamagable = true;
        }
        anim.SetFloat("Speed", offset.magnitude);
    }
    public void KnockBack(Vector3 dir)
    {
        knockBackCounter = knockBackTime;
        offset = dir * knockBackForce;
    }

}
