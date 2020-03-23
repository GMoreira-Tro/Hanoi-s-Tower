using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopSounds : MonoBehaviour
{
    public static bool MuteMusic;
    public void ToggleStopContinue()
    {
        MuteMusic = GameObject.Find("MusicManager").GetComponent<AudioSource>().mute = !GameObject.Find("MusicManager").GetComponent<AudioSource>().mute;
    }
}
