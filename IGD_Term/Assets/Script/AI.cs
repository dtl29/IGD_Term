using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public float chaseSpeed = 10f;
    public bool attacked = false;
    //public Transform Player;
    public GameObject Player;

    //Mesh cube;
    //Rigidbody cube;
    //private Vector3 directionOfPlayer;
    //private NavMeshAgent agent;

    void Start()
    {
        //cube = this.GetComponent<Rigidbody>();//= this.GetComponent<MeshFilter>().mesh;
        //this.GetComponent<NavMeshAgent>();//.SetDestination(GamePlayer.transform.position);
        //agent = gameObject.GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else
        {
            //agent = gameObject.GetComponent<NavMeshAgent>();
            //agent.SetDestination(GamePlayer.transform.position);
            //this.transform.position = this.transform.position - Player.transform.position;
            //this.transform.Translate(Player.transform.position,chaseSpeed,0,0);
            this.transform.position = Vector3.forward - Player.transform.position;
            if (attacked)
            {
                //this.transform.position = Vector3.forward - directionOfPlayer.position;
            }
            /*else
            {
              this.transform.position += Vector3.right * Time.deltaTime;
            }*/
        }
    }

    void OnTriggerEnter (Collider Other)
    {
        if (Other.tag == "Player")
        {
            attacked = true;
        }
    }
}
