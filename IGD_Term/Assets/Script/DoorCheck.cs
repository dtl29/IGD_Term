using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    /*
        var spawnPoint:Vector3 = spawn[randomPick].position;
        var hitColliders = Physics.OverlapSphere(spawnPoint, 2);//2 is purely chosen arbitrarly
        if(hitColliders.Length > 0) //You have someone with a collider here 
    */
    private GameObject Mommy;
    private RoomsController RC;
    private Vector3 spawnPoint1;
    private Collider[] hitCollider1;
    // Start is called before the first frame update
    void Start()
    {
        //spawnPoint = this.transform.localEulerAngles;
        spawnPoint1 = this.transform.position;
        hitCollider1 = Physics.OverlapSphere(spawnPoint1, .5f);
        if(hitCollider1.Length > 0)
        {
            for (int i = 0; i < hitCollider1.Length; i++)
            {
                Debug.Log("We hit something");
                if (hitCollider1[i].gameObject.tag == "Door")
                {
                    Debug.Log("we hit a door");
                    //GetComponent<script name>.name of variable <-- to access variables from other scripts attached to something 
                    Mommy = this.transform.parent.gameObject;
                    Mommy.GetComponent<RoomsController>().ShouldSpawn = false;
                    Destroy(hitCollider1[i].gameObject);
                    Destroy(this); //check the paretns first 
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("We Colliding");
        if(other.tag == "Door")
        {
            //GetComponent<script name>.name of variable <-- to access variables from other scripts attached to something 
            Mommy = this.transform.parent.gameObject;
            Mommy.GetComponent<RoomsController>().ShouldSpawn = false;
            Destroy(other);
            Destroy(this);
        }
    }
}
