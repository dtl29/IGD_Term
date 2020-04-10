using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCheck : MonoBehaviour
{
    private GameObject Mommy;
    private RoomsController RC;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider other)
    {
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
