using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_effect : MonoBehaviour
{
    public AudioSource src;
    public AudioClip _open, _close, _Finish_sound, _teleport;

    public void Close_sound()
    {
        src.clip = _close;
        src.Play();
    }
    public void Finish()
    {
        src.clip = _Finish_sound;
        src.Play();
    }
    public void Open()
    {
        src.clip = _open;
        src.Play();
    }
    public void Teleport()
    {
        src.clip = _teleport;
        src.Play();
    }
}
