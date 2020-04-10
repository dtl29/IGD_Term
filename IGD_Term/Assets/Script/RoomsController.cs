using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsController : MonoBehaviour
{
    public GameObject RoomToSpawn;
    public GameObject Door;
    public GameObject SpawnPoint;

    public int SpawnRoatation;
    private Vector3 RotateRoom;

    public bool ShouldSpawn = true;
    private bool alreadySpawned = false;
    public bool CanPass = true;//this can be used so the player has to do something to pass through
    //have to add functionality for this ^^^^^^^^^^^^^^^^^^^^^^

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //OnTriggerEnter is called when another collider enters into this collider
    void OnTriggerEnter(Collider other)
    {
        if(!alreadySpawned && other.tag=="Player" && CanPass && ShouldSpawn)
        {
            //this does not work!!!!!
            if (SpawnRoatation == 2)
            {
                RotateRoom = new Vector3(0f, this.transform.parent.gameObject.transform.localEulerAngles.y - 90f, 0f);
            }
            if (SpawnRoatation == 3)
            {
                RotateRoom = new Vector3(0f, this.transform.parent.gameObject.transform.localEulerAngles.y, 0f);
            }
            if (SpawnRoatation == 1)
            {
                RotateRoom = new Vector3(0f, this.transform.parent.gameObject.transform.localEulerAngles.y + 90f, 0f);
            }

            alreadySpawned = true;
            //add Door Animation then destory it
            Destroy(Door);
            //Instantiate(RoomToSpawn, new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), Quaternion.identity);
            Instantiate(RoomToSpawn, new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), Quaternion.Euler(RotateRoom));
        }
        else if(!alreadySpawned && other.tag == "Player" && CanPass)
        {
            alreadySpawned = true;
            Destroy(Door);
        }
    }
}
