using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupFlashLight : MonoBehaviour
{
    public GameObject PickUpText;  
    public GameObject FlashLightOnPlayer;

    void Start()
    {
        PickUpText.SetActive(false);
        FlashLightOnPlayer.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PickUpText.SetActive(true);

            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);   

                FlashLightOnPlayer.SetActive(true);

                PickUpText.SetActive(false);
            }
        }
        
    }
    private void OnTriggerExit(Collider collider)
    {
        PickUpText.SetActive(false);
    }
}
