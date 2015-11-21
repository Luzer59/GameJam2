using UnityEngine;
using System.Collections;
using UnityStandardAssets.ImageEffects;
using UnityEngine.UI;

public class SceneFade : MonoBehaviour
{
    private Blur blur;
    private Image black;
    private bool active;
    private bool fadeIn;
    private float t;
    private int sceneIndex = 0;

    public float fadeSpeed = 1f;

    void Awake()
    {
        blur = Camera.main.GetComponent<Blur>();
        black = GameObject.Find("Black").GetComponent<Image>();
    }

    public void Activate()
    {
        fadeIn = true;
        active = true;
        if (fadeIn)
        {
            black.enabled = true;
            blur.enabled = true;
            t = 1f;
        }
        else
        {
            black.enabled = true;
            blur.enabled = true;
            t = 0f;
        }
    }

    public void Activate(int _sceneIndex)
    {
        sceneIndex = _sceneIndex;
        fadeIn = false;
        active = true;
        if (fadeIn)
        {
            black.enabled = true;
            blur.enabled = true;
            t = 1f;
        }
        else
        {
            black.enabled = true;
            blur.enabled = true;
            t = 0f;
        }
    }

    void Update()
    {
        if (active)
        {
            if (fadeIn)
            {
                t -= fadeSpeed * Time.deltaTime;
                blur.iterations = Mathf.RoundToInt(Mathf.Lerp(1f, 7f, t));
                blur.blurSpread = Mathf.Lerp(0.1f, 0.5f, t);
                black.color = new Color(0f, 0f, 0f, 1f - Mathf.Cos(t * Mathf.PI * 0.5f));

                if (t <= 0f)
                {
                    black.enabled = false;
                    blur.enabled = false;
                    active = false;
                }
            }
            else
            {
                t += fadeSpeed * Time.deltaTime;
                blur.iterations = Mathf.RoundToInt(Mathf.Lerp(1f, 7f, t));
                blur.blurSpread = Mathf.Lerp(0.1f, 0.5f, t);
                black.color = new Color(0f, 0f, 0f, 1f - Mathf.Cos(t * Mathf.PI * 0.5f));

                if (t >= 1f)
                {
                    active = false;
                    if (sceneIndex == -1)
                    {
                        Application.Quit();
                    }
                    else
                    {
                        Application.LoadLevel(sceneIndex);
                    }
                }
            }
        }
    }
}
