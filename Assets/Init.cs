using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour
{
    public bool resetMoneyOnStart;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Money") || resetMoneyOnStart)
        {
            PlayerPrefs.SetInt("Money", 0);
        }
    }
}
