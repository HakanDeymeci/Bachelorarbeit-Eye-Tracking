using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private GameObject triggeringNpc;
    private bool triggering;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if (triggering)
        {
            print("Player is triggering with" + triggeringNpc);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "NPC")
        {
            triggering = true;
            triggeringNpc = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC")
        {
            triggering = false;
            triggeringNpc = null;
        }
    }
}
