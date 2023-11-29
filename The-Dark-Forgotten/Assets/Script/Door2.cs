using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHeli : MonoBehaviour
{
    public GameObject OpenDoor1Text;

    [SerializeField] private Animator Door1 = null;
    bool DoorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        OpenDoor1Text.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            OpenDoor1Text.SetActive(true);
            if (Input.GetKey(KeyCode.E) && PlayerMovement.keyCount == 2 && DoorOpen!=true)
            {
                Door1.Play("Door1", 0, 0.0f);
                DoorOpen = true;
                OpenDoor1Text.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if(DoorOpen==true)
            Door1.Play("DoorClose1", 0, 0.0f);
            DoorOpen = false;
        OpenDoor1Text.SetActive(false);
    }
}
