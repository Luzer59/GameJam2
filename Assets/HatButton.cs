using UnityEngine;
using System.Collections;

public class HatButton : MonoBehaviour
{
    private HatController hatController;
    private SpriteRenderer sr;

    void Awake()
    {
        hatController = GameObject.Find("MenuController").GetComponent<HatController>();
        sr = GetComponent<SpriteRenderer>();
    }

    /*public void Click()
    {

            hatController.UnboxHat();

    }*/
}
