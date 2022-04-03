using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;

    [SerializeField] AudioClip clip;

    public void Switch()
    {
        audioManager.ChangeMusic(clip);
    }
}
