using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject OpenDoorText;

    void Start()
    {
        OpenDoorText.SetActive(false);
    }

    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            OpenDoorText.SetActive(true);
            
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        OpenDoorText.SetActive(false);
    }
}
