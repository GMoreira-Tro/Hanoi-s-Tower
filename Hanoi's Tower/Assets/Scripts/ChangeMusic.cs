using UnityEngine;

public class ChangeMusic : MonoBehaviour
{
    public AudioClip clip;
    void Start()
    {
        InstantiateSounds.DefaultSetMusic(
            GameObject.Find("MusicManager").GetComponent<AudioSource>(),
            clip);
    }

    public void DestroyMusic()
    {
        Destroy(GameObject.Find("MusicManager"));
    }
}
