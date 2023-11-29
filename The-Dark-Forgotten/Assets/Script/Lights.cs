using UnityEngine;
using System.Collections;

public class LightControl : MonoBehaviour
{
    public Light[] lights;

    void Start()
    {
        foreach (Light obj in lights)
            obj.enabled = false;
    }

    public void Update()
    {
        if (Generator.Lights == true)
        {

            foreach (Light obj in lights)
                obj.enabled = true;
        }
    }
}
