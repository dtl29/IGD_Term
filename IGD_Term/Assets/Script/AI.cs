 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class AI : MonoBehaviour
 {

    public Transform Player;
    public Transform Target;
    float chaseSpeed = 5;
    float fightSpeed = 6;
    float retreatSpeed = 15;
    float MaxDistance = 10;
    private Vector3 Direction;
    float stopDistance = 2.5f;

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
    }

    IEnumerator waiting()
    {
      yield return new WaitForSeconds(4);
    }
}
