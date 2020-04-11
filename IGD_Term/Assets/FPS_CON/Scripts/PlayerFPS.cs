using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFPS : MonoBehaviour
{
    private int health = 100;
    public GameObject rightHand;
    private bool notSwinging = true;
    private int SwingCount = 0;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (notSwinging)
        {
            if(Input.GetMouseButtonDown(0))
            {
                notSwinging = false;
            }
        }
        else
        { 
            Swing();
        }
    }

    //mutator to change the players health 
    void ChangeHealth(int num, bool increase)
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
                Debug.Log("Start death sequnce");
            }
        }
    }

    void Swing()
    {
        if (SwingCount < 50)
        {
            Debug.Log("Attacking");
            anim.Play("Swing");
            SwingCount++;
        }
        else
        {
            notSwinging = true;
            SwingCount = 0;
        }
    }
}
