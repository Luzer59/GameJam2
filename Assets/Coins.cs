using UnityEngine;
using System.Collections;

public class Coins : MonoBehaviour
{
    public int coins = 0;

    public void SaveCoins()
    {
        int oldCoins = PlayerPrefs.GetInt("Coins");
        PlayerPrefs.SetInt("Coins", oldCoins + coins);
    }
}
