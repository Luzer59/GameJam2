using UnityEngine;
using System.Collections.Generic;

public class HatController : MonoBehaviour
{
    public int coins;
    public int unboxPrice;
    public Sprite[] allHatSprites;
    public int[] ownedHats;

    private UpdateVisuals hatContainer;
    private int ownedHatCount;
    private int selectedHat;

    void Awake()
    {
        hatContainer = GameObject.Find("HatContainer").GetComponent<UpdateVisuals>();

        PlayerPrefs.SetInt("HatCount", allHatSprites.Length);
        selectedHat = PlayerPrefs.GetInt("SelectedHat");

        if (allHatSprites.Length > 0)
        {
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
    }

    /*void Start()
    {
        
    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            print(selectedHat);
        }
    }

    public void UnboxHat()
    {
        print("here1");
        if (ownedHats.Length > ownedHatCount)// && coins >= unboxPrice)
        {
            print("here2");
            coins -= unboxPrice;
            int random;
            while (true)
            {
                print("here3");
                random = Random.Range(0, allHatSprites.Length);
                if (ownedHats[random] == 0)
                {
                    print("here4");
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
