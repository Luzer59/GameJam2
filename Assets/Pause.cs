using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public Sprite[] pauseSprites;

    private bool paused = false;
    private Image image;

    void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SwitchPauseDown()
    {
        if (paused)
        {
            image.sprite = pauseSprites[3];
        }
        else
        {
            image.sprite = pauseSprites[1];
        }
    }

    public void SwitchPauseUp()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            image.sprite = pauseSprites[2];
        }
        else
        {
            Time.timeScale = 0f;
            image.sprite = pauseSprites[0];
        }
        paused = !paused;
    }
}
