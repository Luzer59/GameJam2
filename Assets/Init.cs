using UnityEngine;
using System.Collections;

public class Init : MonoBehaviour
{

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
        if (!PlayerPrefs.HasKey("SelectedHat"))
        {
            PlayerPrefs.SetInt("SelectedHat", -1);
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
