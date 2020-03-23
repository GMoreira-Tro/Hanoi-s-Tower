using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public static void LoadSceneWithMusic(string name, AudioClip musica)
    {
        InstantiateSounds.DefaultSetMusic(GameObject.Find("MusicManager").GetComponent<AudioSource>(),
            GameObject.Find("MusicManager").GetComponent<AudioSource>().clip);
       SceneManager.LoadScene(name);
    }

    public void instaWin()
    {
        RenderObjects.moves = System.DateTime.Now.Millisecond % 100;
        SceneManager.LoadScene("GameOver");
    }

    public void DestroyMusic()
    {
        Destroy(GameObject.Find("MusicManager"));
    }
}
