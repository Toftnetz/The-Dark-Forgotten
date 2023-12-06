using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject Endinggame;


    // Start is called before the first frame update
    void Start()
    {
        Endinggame.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Endinggame.SetActive(true);
            if (Input.GetKey(KeyCode.E) && PlayerMovement.keyCount == 2)
            {
                
                Endinggame.SetActive(false);
            }
        }
    }
    
}
