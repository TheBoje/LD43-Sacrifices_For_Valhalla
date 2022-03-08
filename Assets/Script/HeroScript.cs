using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroScript : MonoBehaviour {

    public float speed;
    public Transform hitBox;
    public int damage;
    public int weakness;
    public float gravity;
    public Texture2D hpBar;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    private float velocity;
    private float invisibleTime;
    private Vector3 direction;
    private Vector3 move;
    private Animator anim;
    private Rigidbody rb;
    private CharacterController cc;
    private GlobalValue GlobalVal;

    private float hitReman;

    void Start () {
        anim = transform.GetChild(0).GetComponent<Animator>();
        rb = transform.GetChild(0).GetComponent<Rigidbody>();
        cc = GetComponent<CharacterController>();
        GlobalVal = GameObject.Find("GlobalValue").GetComponent<GlobalValue>();
        speed = (int)GlobalVal.speed;
        damage = (int)GlobalVal.damage;
        weakness = (int)GlobalVal.weakness;
        GetComponent<HealthScript>().life = (int)GlobalVal.life;
	}
	
	void Update () {
        direction = transform.GetChild(0).TransformDirection(Vector3.forward);

        if (knockBackCounter <= 0)
        {
            move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * speed * Time.deltaTime;

        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }

        cc.Move(move + Vector3.down * gravity);
       

        if (Input.GetMouseButtonDown(0) )
        {
            anim.SetTrigger("Hit");
            hitBox.gameObject.SetActive(true);
            hitReman = Time.time;
        }

        if(Time.time >= hitReman + 0.5f)
        {
            hitBox.gameObject.SetActive(false);
        }
        if (Time.time >= invisibleTime + 0.75f)
        {
            transform.GetComponent<HealthScript>().isDamagable = true;
        }



        if (velocity == 0)
        {
            TurnToMouse();
        }
        else
        {
            transform.GetChild(0).rotation = Quaternion.LookRotation(move);
        }

        velocity = move.magnitude;

        //Animation:
        anim.SetFloat("Speed", velocity);

    }
    private void TurnToMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos = new Vector3(mousePos.x, 0,mousePos.y-6.6f) - new Vector3(transform.position.x,0,transform.position.y);

        transform.GetChild(0).rotation = Quaternion.LookRotation(mousePos.normalized);
    }

    public void GetDamage()
    {
        if (transform.GetComponent<HealthScript>().isDamagable == true)
        {
            invisibleTime = Time.time;
            KnockBack(-move.normalized);
            transform.GetComponent<HealthScript>().isDamagable = false;
        }
    }

    public void KnockBack(Vector3 dir)
    {
        knockBackCounter = knockBackTime;
        Debug.Log("AYAYAYA");
        move = dir * knockBackForce;
    }

    private void OnGUI()
    {
        if (GetComponent<HealthScript>().life >= 0)
        {
            float barLenght = (GetComponent<HealthScript>().life/ GlobalVal.life) * 250;
            GUI.DrawTexture(new Rect(Screen.width / 2 - barLenght/2, Screen.height - 15,barLenght,10),hpBar);
        }
    }
}
