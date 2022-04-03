using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitch : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;

    [SerializeField] AudioClip clip;

    public void Switch()
    {
        Debug.Log("Switch!");
        Debug.Log("audioManager is null!" + audioManager == null);
        Debug.Log("clip is null !" + clip == null);
        audioManager.ChangeMusic(clip);
    }
}
