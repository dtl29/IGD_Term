 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.UI;

 public class AI : MonoBehaviour
 {

    private Transform Player;
    public Transform Target;
    public PlayerFPS playerFPS;
    public GameObject gamePlayer;

    private float chaseSpeed = 5;
    private float fightSpeed = 5;
    private float retreatSpeed = 15;
    private float MaxDistance = 10;
    private Vector3 Direction;
    private float stopDistance = 2.3f;
    private int eHP = 5;
    private float killTime = 3;

    private GameObject player;

    void Start()
    {
        gamePlayer = GameObject.Find("Player");
        Player = Player.gameObject.transform;
    }

    void Update()
    {
        Debug.Log("EnemyHealth:" + eHP);
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
        else if ((Vector3.Distance(Target.position - (Vector3.back * 2.5f), transform.position)) > stopDistance)
        {
            Direction = (transform.position - GetComponent<Rigidbody>().position).normalized;
            GetComponent<Rigidbody>().velocity = -Direction * retreatSpeed;
            StartCoroutine(waiting());
        }
    }

    IEnumerator waiting()
    {
        yield return new WaitForSeconds(5);
    }

    void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            Player.GetComponent<PlayerFPS>().ChangeHealth(5, false, 'p');
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
