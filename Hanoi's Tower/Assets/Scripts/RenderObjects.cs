using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class RenderObjects : MonoBehaviour
{
    public Text ShowLevel;
    public GameObject GO;
    public Hook bases;
    public static List<Hook> hooks;
    public static int moves;
    public Text min_movesText;
    public Text movesText;
    public AudioClip musicaGameOver;
    public AudioClip clickButtonClip;

    void Start()
    {
        DragObjects.musicaGameOver = musicaGameOver;
        DragObjects.clickButtonClip = clickButtonClip;
        moves = 0;
        min_movesText.text = "Minimum amount of moves: " + ((int)System.Math.Pow(2, LevelSelect.level) - 1).ToString();
        movesText.text = "Moves played: " + moves.ToString();
        hooks = new List<Hook>();
        ShowLevel.text = LevelSelect.level + " pieces level";

        for (int i = 0; i < 3; i++)
        {
            bases.name = "Base " + (i + 1);
            hooks.Add(Instantiate(bases, new Vector3(-7.5f + i * 7.5f, -3.5f, 0), Quaternion.identity));
            hooks[i].GetComponent<MeshRenderer>().material.color = new Color(0.127f, 0, 0.127f);
            hooks[i].transform.GetChild(0).GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.127f, 0, 0.127f));
        }

        for (short i = 0; i < LevelSelect.level; i++)
        {
            GO.name = "Rect " + (LevelSelect.level - i);
            GO.transform.localScale = new Vector3(0.5f + (LevelSelect.level - i -1)/ 2f, 1, 1);

            hooks[0].cubes.Push(Instantiate(GO, new Vector3(-7.5f, -3 + i, -0.1f), Quaternion.identity));
            hooks[0].cubes.Peek().GetComponent<DragObjects>().ID = LevelSelect.level - i;
            hooks[0].cubes.Peek().GetComponent<DragObjects>().hookID = 0;
            Corzinha.pintarCubos(hooks[0].cubes.Peek().GetComponent<DragObjects>().ID, hooks[0].cubes.Peek().GetComponent<DragObjects>().gameObject);

        }
        /*movesText.name = "Moves played"; 
        movesText.fontSize = 24;
        movesText.fontStyle = FontStyle.Bold;
        Instantiate(movesText, new Vector3(-200, 135, 0), Quaternion.identity);*/
    }
}
