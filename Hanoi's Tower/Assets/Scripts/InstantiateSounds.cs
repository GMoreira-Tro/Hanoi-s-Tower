using UnityEngine;

public class InstantiateSounds : MonoBehaviour
{
    public AudioClip clip;
    void Start()
    {
        try
        {
            GameObject.Find("MusicManager").GetComponent<AudioSource>().playOnAwake = false;
        }
        catch(System.Exception)
        {
            AudioSource source = gameObject.AddComponent<AudioSource>();
            DefaultSetMusic(source, clip);
            DontDestroyOnLoad(source);
        }
    }

    public static void DefaultSetMusic(AudioSource source, AudioClip clip)
    {
        source.clip = clip;
        source.playOnAwake = false;
        source.Play();
        source.loop = true;
        source.mute = StopSounds.MuteMusic;
    }

    public void ButtonSounds()
    {
        gameObject.GetComponent<AudioSource>().clip = clip;
        gameObject.GetComponent<AudioSource>().Play();
    } 
}
