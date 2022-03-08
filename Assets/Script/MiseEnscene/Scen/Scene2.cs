using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 : MonoBehaviour {

    public int state = 1;
    public GameObject Hero;
    public TestBoxHolder TextHolder;
    public float speed;
    public GameObject button;
    private GlobalValue GlobalVal;

    private void Start()
    {
        GlobalVal = GameObject.Find("GlobalValue").GetComponent<GlobalValue>();
    }

    void Update () {
        /*étape
         *1 Déplacer le personnage jusqu'à 0.0.0
         * */

        if (state == 1){
            if (Hero.transform.position.z >= 0)
            {
                Hero.transform.GetChild(0).GetComponent<Animator>().SetBool("Walk", false);
                Hero.GetComponent<Rigidbody>().velocity = Vector3.zero;
                state = 2;
            }
            else
            {
                Hero.transform.Translate(Vector3.forward * speed * Time.deltaTime);
                Hero.transform.GetChild(0).GetComponent<Animator>().SetBool("Walk", true);
            }
        } else if(state == 2)
        {
            if (Camera.main.transform.position.z <= -5)
            {
                Camera.main.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
            }
            else
            {
                Camera.main.GetComponent<Rigidbody>().velocity = Vector3.zero;
                if (Camera.main.GetComponent<Camera>().orthographicSize <= 8)
                {
                    Camera.main.GetComponent<Camera>().orthographicSize += 0.1f;
                }
                else
                {
                    state = 3;
                }
            }
        } else if(state == 3)
        {
            TextHolder.ChangeText("So you succeed?\n" +
                "Quite impressive..." +
                "[z] next");
            if (Input.GetKeyDown(KeyCode.Z))
            {
                state = 4;
            }
        }else if(state == 4)
        {
            TextHolder.ChangeActive(false);
            TextHolder.ChangeText("What do you choose to give up?:\n");
            button.SetActive(true);
        }else if(state == 5)
        {
            TextHolder.ChangeText("You do not choose randomly, don't you?\n");
            button.SetActive(false);
            Application.LoadLevel(6);
        }
    }

    public void Chose(string choix)
    {
        if(choix == "s")
        {
            GlobalVal.weakness = 4;
        }
        else
        {
            GlobalVal.life = 5;
        }

        state = 5;
    }
}
