using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NicknameValidation : MonoBehaviour
{
    public static string UserName;
    public Text invalidText;
    void Start()
    {
        UserName = "";
    }

    public void Validate(string name)
    {
        if (name == "")
            invalidText.text = "Please, enter a valid username...";
        else
        {
            UserName = name;
            SceneManager.LoadScene("Main menu");
        }
    } 
}
