using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsController : MonoBehaviour
{
    public GameObject RoomToSpawn;
    public GameObject Door;
    public GameObject SpawnPoint;

    public int SpawnRoatation;
    private float RotateRoom;

    private bool alreadySpawned = false;
    public bool CanPass = true;//this can be used so the player has to do something to pass through
    //have to add functionality for this ^^^^^^^^^^^^^^^^^^^^^^

    // Start is called before the first frame update
    void Start()
    {
        //this does not work!!!!!
        if(SpawnRoatation == 2)
        {
            RotateRoom = -90f;
        }
        if (SpawnRoatation == 3)
        {
            RotateRoom = 0f;
        }
        if (SpawnRoatation == 1)
        {
            RotateRoom = 90f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //OnTriggerEnter is called when another collider enters into this collider
    void OnTriggerEnter(Collider other)
    {
        if(!alreadySpawned && other.tag=="Player" && CanPass)
        {
            alreadySpawned = true;
            //add Door Animation then destory it
            Destroy(Door);
            Instantiate(RoomToSpawn, new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), Quaternion.identity);
            //Instantiate(RoomToSpawn, new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), Quaternion.Euler.forward);
        }
    }
}
