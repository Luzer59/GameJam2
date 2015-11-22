using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour
{
    public void RestartButton()
    {
        GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFade>().Activate(Application.loadedLevel);
    }
}
