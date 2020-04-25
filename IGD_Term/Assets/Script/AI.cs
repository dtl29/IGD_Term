using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    //public float chaseSpeed = 10f;
    public bool attacked = false;
    //public Transform Player;
    public GameObject GamePlayer;

    //Mesh cube;
    //Rigidbody cube;
    //private Vector3 directionOfPlayer;
    private NavMeshAgent agent;

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
            agent = gameObject.GetComponent<NavMeshAgent>();
            agent.SetDestination(GamePlayer.transform.position);
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
        if (Other.tag == "GamePlayer")
        {
            attacked = true;
        }
    }
}
