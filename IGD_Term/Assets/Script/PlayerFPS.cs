﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerFPS : MonoBehaviour
{
    private int health = 100;
    public GameObject rightHand;
    private bool notSwinging = true;
    private int SwingCount = 0;
    private Animator anim;

    public Text healthText;

    // Start is called before the first frame update
    void Start()
    {
        anim = rightHand.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        healthText.text = "Health:" + health;
        Debug.Log("Health: " + health);
        if(Input.GetMouseButtonDown(0))
        {
            Swing();
        }
    }

    //mutator to change the players health
    public void ChangeHealth(int num, bool increase, char type)
    {
        if(increase)
        {
            health += num;
        }
        else
        {
            health -= num;
            if(health <= 0)
            {
                Debug.Log("Start death sequence");
                Application.LoadLevel("Main");
            }
        }
    }

    void Swing()
    {
        Debug.Log("Attacking");
        anim.SetTrigger("Base_Attack");
    }
}
