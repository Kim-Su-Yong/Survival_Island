using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public Light inLight;
    public AudioSource source;
    public AudioClip OnSound;
    public AudioClip OffSound;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inLight.enabled = true;
            source.PlayOneShot(OnSound, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            inLight.enabled = false;
            source.PlayOneShot(OffSound, 1.0f);
        }
    }
}
