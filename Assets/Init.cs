using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour
{
    public bool reset;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Coins") || reset)
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
        if (!PlayerPrefs.HasKey("SelectedHat") || reset)
        {
            PlayerPrefs.SetInt("SelectedHat", 0);
        }

        if (PlayerPrefs.HasKey("HatCount"))
        {
            int hatCount = PlayerPrefs.GetInt("HatCount");
            for (int i = 0; i < hatCount; i++)
            {
                PlayerPrefs.SetInt("Hat" + i.ToString(), 0);
            }
        }
    }
}
