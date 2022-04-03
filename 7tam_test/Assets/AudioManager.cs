using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    public void ChangeMusic(AudioClip clip)
    {
        Debug.Log("ChangeMusic");
        music.Stop();
        music.clip = clip;
        music.Play();
    }
}
