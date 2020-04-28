using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyHealth : MonoBehaviour
{
    //public Transform Enemy;
    public Text health;
    public bool hit = false;

    private int hp = 10;

    void Start()
    {
        health.text = "Enemy Health: 10";
    }

    // Update is called once per frame
    void Update()
    {
        //var wantedPos = Camera.main.WorldToViewportPoint (this.transform. position);
        //this.transform.position = wantedPos;

        if (hit)
        {
            --hp;
            health.text = "Enemy Health: " + hp.ToString();
        }
    }


    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            hit = true;
        }
    }
}
