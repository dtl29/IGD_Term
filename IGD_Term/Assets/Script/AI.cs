 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class AI : MonoBehaviour
 {

    public Transform Player;
    public Transform Target;
    private float chaseSpeed = 5;
    private float fightSpeed = 6;
    private float retreatSpeed = 15;
    private float MaxDistance = 10;
    private Vector3 Direction;
    private float stopDistance = 2.5f;
    private int eHP = 10;
    private float killTime = 3;
    private bool hit = false;

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

        if (hit)
        {
            ChangeHealth(1);
        }

    }

    IEnumerator waiting()
    {
      yield return new WaitForSeconds(4);
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            hit = true;
            Debug.Log("Hit");
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
