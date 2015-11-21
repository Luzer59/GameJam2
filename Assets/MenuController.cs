using UnityEngine;
using System.Collections;

public class MenuController : MonoBehaviour
{
    private SceneFade sceneFade;

    void Awake()
    {
        sceneFade = GetComponent<SceneFade>();
    }
    void Start()
    {
        sceneFade.Activate();
    }
}
