using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpriteSwitch : MonoBehaviour
{
    public Sprite[] sprites;
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SwitchSprite(int index)
    {
        image.sprite = sprites[index];
    }
}
