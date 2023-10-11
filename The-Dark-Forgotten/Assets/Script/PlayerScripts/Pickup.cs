using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject PickUpText;
    
    void Start()
    {
        PickUpText.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                PlayerMovement.keyCount += 1;
                Destroy(gameObject);
                PickUpText.SetActive(false);
            }
        }
        
    }
    private void OnTriggerExit(Collider collider)
    {
        PickUpText.SetActive(false);
    }
}
