using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeletons : MonoBehaviour {

    public float speed = 5.0f;
    public double distShoot = 5.0;
    public float arrowSpeed = 20.0f;
    public float realodingTime = 9.0f;
    public float animTime = 1.0f;

    private float invisibleTime;

    private float timer;
    private Vector3 playerLastSeen;
    public Rigidbody arrow;
    private Vector3 offset;
    private Animator anim;

    public float gravity = 2;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    // Use this for initialization
    void Start () {
        anim = transform.GetChild(0).GetComponent<Animator>();
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
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            playerLastSeen = other.transform.position;
            if (knockBackCounter <= 0)
            {
                
                if (Vector3.Distance(transform.position, other.transform.position) >= distShoot)
                {
                    offset = other.transform.position - transform.position;
                    offset = offset.normalized * speed;
                    gameObject.GetComponent<CharacterController>().Move(offset * Time.deltaTime);
                }
                else
                {
                    offset = Vector3.zero;
                }
            }
            else
            {
                knockBackCounter -= Time.deltaTime;
            }
            anim.SetFloat("Speed", offset.magnitude);
            Vector3 pos = new Vector3(other.transform.position.x, 0, other.transform.position.z) - new Vector3(transform.position.x, 0, transform.position.z);
            transform.rotation = Quaternion.LookRotation(pos.normalized);
            timer += Time.deltaTime;
            if (timer > realodingTime)
            {
                Shoot();
                anim.SetTrigger("Hit");
                timer = 0;
            }
        }

    }

    void Shoot()
    {

        Rigidbody projectile = Instantiate(arrow, transform.position + new Vector3(0.0f, 1.0f, 0.0f), Quaternion.identity);
        projectile.transform.rotation = Quaternion.LookRotation(offset.normalized);
        projectile.transform.rotation = Quaternion.Euler(90, 0, 0);
        projectile.velocity = transform.forward * arrowSpeed;

    }
    public void GetDamage()
    {
        anim.SetTrigger("Damage");
        invisibleTime = Time.time;
        KnockBack(transform.position - playerLastSeen);
        transform.GetChild(1).GetComponent<HealthScript>().isDamagable = false;
    }
    public void KnockBack(Vector3 dir)
    {
        knockBackCounter = knockBackTime;
        offset = dir * knockBackForce;
    }
}
