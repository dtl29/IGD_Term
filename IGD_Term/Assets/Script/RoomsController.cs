using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomsController : MonoBehaviour
{
    private GameObject RoomToSpawn;
    public GameObject Door;
    public GameObject SpawnPoint;

    public int SpawnRoatation;
    private Vector3 RotateRoom;

    public bool ShouldSpawn = true;
    private bool alreadySpawned = false;
    public bool CanPass = true;//this can be used so the player has to do something to pass through

    private string roomName;
    private int rNFR; 
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
            else if (SpawnRoatation == 3)
            {
                RotateRoom = new Vector3(0f, this.transform.parent.gameObject.transform.localEulerAngles.y, 0f);
            }
            else if (SpawnRoatation == 1)
            {
                RotateRoom = new Vector3(0f, this.transform.parent.gameObject.transform.localEulerAngles.y + 90f, 0f);
            }
            else if(SpawnRoatation == 4)
            {
                RotateRoom = new Vector3(0f, this.transform.parent.gameObject.transform.localEulerAngles.y + 180, 0f);
            }

            alreadySpawned = true;
            //add Door Animation then destory it
            Destroy(Door);

            //rNFR = Random.Range(1, 5);
            rNFR = 4;
            roomName = "Room" + rNFR;
            Debug.Log(roomName);
            Instantiate((Resources.Load(roomName, typeof(GameObject))), new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), Quaternion.Euler(RotateRoom));
        }
        else if(!alreadySpawned && other.tag == "Player" && CanPass)
        {
            alreadySpawned = true;
            Destroy(Door);
        }
    }
}
