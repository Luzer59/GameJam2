using UnityEngine;
using System.Collections;

public class UpdateVisuals : MonoBehaviour
{
    public void UpdateElements()
    {
        print("here1");
        BroadcastMessage("UpdateHatDisplay");
    }
}
