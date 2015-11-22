using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HatDisplay : MonoBehaviour
{
    public int hatIndex;

    private HatController hatController;
    private Image image;

    void Awake()
    {
        hatController = GameObject.Find("MenuController").GetComponent<HatController>();
        image = GetComponent<Image>();
    }

    void Start()
    {
        if (hatController.ownedHats[hatIndex] == 1)
        {
            image.sprite = hatController.allHatSprites[hatIndex];
        }
        /*else
        {
            sr.sprite = hatController.box;
        }*/
    }

    void Update()
    {
        if (hatController.ownedHats[hatIndex] == 1)
        {
            image.sprite = hatController.allHatSprites[hatIndex];
        }
    }

    public void Click()
    {
        if (hatController.ownedHats[hatIndex] == 1)
        {
            // is available
            hatController.SelectHat(hatIndex);
        }
    }
}
