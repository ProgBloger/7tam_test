using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource music;
    public void ChangeMusic(AudioClip clip)
    {
        music.Stop();
        music.clip = clip;
        music.volume = 0.5f;
        music.Play();
    }
}
