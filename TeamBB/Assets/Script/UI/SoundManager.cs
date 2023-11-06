using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource MusicSource;

    public void SetMusicVolume(float Volume)
    {
        MusicSource.volume = Volume;
    }
}
