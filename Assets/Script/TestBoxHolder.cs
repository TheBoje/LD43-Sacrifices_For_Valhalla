using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestBoxHolder : MonoBehaviour {

    public Text textUI;
    public GameObject panel;

    public string text;

    public bool active;

    private int id;

    public void ChangeText(string t)
    {
        id = 0;
        textUI.text = t;
        text = t;
        ChangeActive(true);
    }
    public void ChangeActive(bool state)
    {
        active = state;
    }

    private void Update()
    {
        panel.SetActive(active);
        if (active)
        {
            textUI.text = text;
            Debug.Log("sqdsqddq");
        }
    }
   
    public IEnumerable wait()
    {
        yield return new WaitForSeconds(0.5f);
    }

}
