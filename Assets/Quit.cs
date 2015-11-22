using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour
{
    public void QuitButton()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFade>().Activate(-1);
    }
}
