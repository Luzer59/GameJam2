using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour
{
    public void ResetData()
    {
        PlayerPrefs.SetInt("Coins", 0);

        PlayerPrefs.SetInt("SelectedHat", -1);

        int hatCount = PlayerPrefs.GetInt("HatCount");
        for (int i = 0; i < hatCount; i++)
        {
            PlayerPrefs.SetInt("Hat" + i.ToString(), 0);
        }
    }
}
