using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sound : MonoBehaviour {


    public AudioClip audioClip;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
