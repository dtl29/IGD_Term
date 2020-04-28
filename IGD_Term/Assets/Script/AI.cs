 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class AI : MonoBehaviour
 {

    public Transform Player;
    public Transform Target;
    public PlayerFPS playerFPS;

    private float chaseSpeed = 5;
    private float fightSpeed = 10;
    private float retreatSpeed = 15;
    private float MaxDistance = 10;
    private Vector3 Direction;
    private float stopDistance = 2f;
    private int eHP = 10;
    private float killTime = 3;
    private bool damage = false;
    private bool attackingP = false;
    private float hit = 1;
    private char type = 'A';
    private bool increase = false;

    void Start()
    {

    }

    void Update()
    {
        transform.LookAt(Player);
        Target = GameObject.FindGameObjectWithTag ("Player").transform;

        if (Vector3.Distance(transform.position, Player.position) > stopDistance)
        {

            transform.position += transform.forward * chaseSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Player.position) <= MaxDistance)
            {
                transform.position += transform.forward * fightSpeed * Time.deltaTime;
                transform.position += transform.up * fightSpeed * Time.deltaTime;
            }

        }
        else if ((Vector3.Distance(Target.position - (Vector3.back * 2.5f), transform.position)) > stopDistance)//Vector3.Distance(transform.position, Player.position) == stopDistance)
        {
            /*transform.position += transform.forward * fightSpeed * Time.deltaTime;
            transform.position += transform.up * chaseSpeed * Time.deltaTime;*/
            Direction = (transform.position - GetComponent<Rigidbody>().position).normalized;
            GetComponent<Rigidbody>().velocity = -Direction * retreatSpeed;
            StartCoroutine(waiting());
        }

        if (damage)
        {
            ++hit;

            if (hit%3 == 0)
            {
                ChangeHealth(1);
            }
        }

        if (attackingP)
        {
            playerFPS.ChangeHealth(1, increase, type);
        }

    }

    IEnumerator waiting()
    {
      yield return new WaitForSeconds(4);
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Hand")
        {
            damage = true;
            Debug.Log("Cut");
        }
        else if (Other.tag == "Player")
        {
            attackingP = true;
            Debug.Log("Charge");
        }
    }

    public void ChangeHealth(int num)
    {
        eHP -= num;
        if(eHP <= 0)
        {
            Debug.Log("Start enemy death sequence");
            Destroy (gameObject, killTime);
        }
    }
}
