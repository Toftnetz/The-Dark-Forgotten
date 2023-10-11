using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject OpenDoorText;

    // Start is called before the first frame update
    void Start()
    {
        OpenDoorText.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            OpenDoorText.SetActive(true);
            if (Input.GetKey(KeyCode.E)&& PlayerMovement.keyCount==2)
            {
                Destroy(gameObject);
                OpenDoorText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        OpenDoorText.SetActive(false);
    }
}
