using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private bool holding;
    private int distanceToItem = 2;
    public GameObject rightHand;
    public Image choiceCircleOne;

    // Start is called before the first frame update
    void Start()
    {
        choiceCircleOne.enabled = false;
        holding = false;
    }

    // Update is called once per frame
    void Update()
    {
        LookingAround();
        PickUp();
        Swing();
        ChoiceChoice();
    }

    void PickUp()
    {
        //if(Input.GetMouseButtonUp(1))
        if(Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, distanceToItem))
            {
                if(hit.collider.gameObject.tag == "PickUp")
                {
                    if(holding == false)
                    {
                        hit.collider.gameObject.GetComponent<Rigidbody>().useGravity = false;
                        hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                        hit.collider.gameObject.transform.position = rightHand.transform.position;
                        hit.collider.gameObject.transform.localEulerAngles = new Vector3(0,0,0);
                        hit.collider.gameObject.transform.parent = rightHand.transform;
                    }
                }
            }
        }
    }

    void Swing()
    {

    }

    void LookingAround()
    {
       // rightHand.transform.postion.y 
    }

    void ChoiceChoice()
    {
        if(Input.GetMouseButton(2))
        {
            choiceCircleOne.enabled = true;
        }
        else if(Input.GetMouseButtonUp(2))
        {

            choiceCircleOne.enabled = false;
        }
    }
}

