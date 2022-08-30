using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundtrigger : MonoBehaviour
{
    public AudioClip triggerSound;
    AudioSource audioSource;
    private bool alreadyplayed = false;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggerSound != null && !alreadyplayed)
        {
            audioSource.PlayOneShot(triggerSound, 0.7f);
            alreadyplayed = true;

        }
    }
}