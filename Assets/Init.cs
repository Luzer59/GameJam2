using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour
{
    public bool resetMoneyOnStart;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Coins") || resetMoneyOnStart)
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
    }
}
