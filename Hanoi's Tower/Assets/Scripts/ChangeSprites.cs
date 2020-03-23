using UnityEngine;
using UnityEngine.UI;

public class ChangeSprites : MonoBehaviour
{
    public Sprite[] sprites;
    public static int numSprite;
    public void ChangeSprite()
    {
        numSprite = (numSprite + 1) % sprites.Length;
        gameObject.GetComponent<Image>().sprite = sprites[numSprite];   
    }

    public void Start()
    {
        gameObject.GetComponent<Image>().sprite = sprites[numSprite];
    }
}
