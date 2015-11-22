using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class HatController : MonoBehaviour
{
    public int coins;
    public int unboxPrice;
    public Sprite[] allHatSprites;
    public int[] ownedHats;
    public GameObject text;

    private UpdateVisuals hatContainer;
    private int ownedHatCount;
    private int selectedHat;
    private Text coinText;

    void Awake()
    {
        coinText = text.GetComponent<Text>();
        hatContainer = GameObject.Find("HatContainer").GetComponent<UpdateVisuals>();

        PlayerPrefs.SetInt("HatCount", allHatSprites.Length);
        selectedHat = PlayerPrefs.GetInt("SelectedHat");

        if (allHatSprites.Length > 0)
        {
            print(allHatSprites.Length);
            ownedHats = new int[allHatSprites.Length];

            for (int i = 0; i < allHatSprites.Length; i++)
            {
                if (PlayerPrefs.HasKey("Hat" + i.ToString()))
                {
                    ownedHats[i] = PlayerPrefs.GetInt("Hat" + i.ToString());
                }
                else
                {
                    PlayerPrefs.SetInt("Hat" + i.ToString(), 0);
                    ownedHats[i] = 0;
                }
            }
            for (int i = 0; i < ownedHats.Length; i++)
            {
                if (ownedHats[i] == 1)
                {
                    ownedHatCount++;
                }
            }
        }

        coins = PlayerPrefs.GetInt("Coins");
        coinText.text = coins.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(selectedHat);
        }
    }

    public void UnboxHat()
    {
        if (ownedHats.Length > ownedHatCount)// && coins >= unboxPrice)
        {
            coins -= unboxPrice;
            coinText.text = coins.ToString();
            int random;
            while (true)
            {
                random = Random.Range(0, allHatSprites.Length);
                if (ownedHats[random] == 0)
                {
                    ownedHats[random] = 1;
                    ownedHatCount++;
                    PlayerPrefs.SetInt("Hat" + random.ToString(), 1);
                    return;
                }
            }
        }
    }

    public void SelectHat(int hatIndex)
    {
        selectedHat = hatIndex;
    }

    public void ExitShop()
    {
        PlayerPrefs.SetInt("Coins", coins);
        PlayerPrefs.SetInt("SelectedHat", selectedHat);
        GetComponent<SceneFade>().Activate(0);
    }
}
