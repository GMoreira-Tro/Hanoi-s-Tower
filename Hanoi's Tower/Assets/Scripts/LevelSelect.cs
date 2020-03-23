using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public static int level = 4;
    public Dropdown dropdown;

    public void Start()
    {
        //Debug.Log(level);
        GameObject.Find("LevelSelectGO").GetComponent<LevelSelect>().dropdown.value = level - 4;
    }

    /*
    public void Update()
    {
        Debug.Log("AAAA" + level);
    }

    public void SelectLevel()
    {
        dropdown.onValueChanged.AddListener((value) => setlevel(value));
    }*/

    public void SelectLevel(int l)
    {
        level = l + 4;
    }

}
