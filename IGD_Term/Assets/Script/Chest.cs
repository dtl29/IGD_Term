﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject lid;
    private Animator anim; 
    // Start is called before the first frame update
    void Start()
    {
        anim = lid.transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("Open");
                GameObject.Find("Dagger").GetComponent<Renderer>().enabled = false;
                GameObject.Find("FancySword").GetComponent<Renderer>().enabled = true;
            }
        }
    }
}
