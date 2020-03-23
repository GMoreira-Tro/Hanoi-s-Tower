using UnityEngine.UI;
using UnityEngine;

public class Points : MonoBehaviour
{
    public Text points;

    void Start()
    {
        GameObject.Find("MovesPlayed").GetComponent<Points>().points.text = "You have finished with " + RenderObjects.moves + " moves!";
    }
}
