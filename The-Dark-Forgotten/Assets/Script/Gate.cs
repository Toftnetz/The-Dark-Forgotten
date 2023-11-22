using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public GameObject OpenGateText;

    [SerializeField] private Animator gate = null;

    // Start is called before the first frame update
    void Start()
    {
        OpenGateText.SetActive(false);
    }

    // Update is called once per frame
    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            OpenGateText.SetActive(true);
            if (Input.GetKey(KeyCode.E) && PlayerMovement.keyCount == 3)
            {
                gate.Play("GateOpen", 0, 0.0f);
                OpenGateText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        OpenGateText.SetActive(false);
    }
}
