using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject OpenDoorText;
    public static bool Lights = false;
    public AudioSource GeneratorSound;

    // Start is called before the first frame update
    void Start()
    {
        OpenDoorText.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collider)
    {
        if(collider.gameObject.tag == "Player"&& PlayerMovement.Electricity != 1)
        {
            OpenDoorText.SetActive(true);
            if (Input.GetKey(KeyCode.E) && PlayerMovement.Fuse==1)
            {
                
                PlayerMovement.Electricity = 1;
                Lights = true;
                GeneratorSound.enabled = true;
                OpenDoorText.SetActive(false);
                
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        OpenDoorText.SetActive(false);
    }
}
