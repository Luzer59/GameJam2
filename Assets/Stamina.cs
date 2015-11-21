using UnityEngine;
using System.Collections;

public class Stamina : MonoBehaviour
{
    public float maxStamina = 100f;
    public float stamina = 0f;

    public GameObject flameBar;
    private RectTransform flameBarTransform;

    private float t;
    
    void Awake()
    {
        flameBarTransform = flameBar.GetComponent<RectTransform>();
    }

    void Start()
    {
        stamina = maxStamina;
    }

    void Update()
    {
        t = stamina / maxStamina;
        flameBarTransform.localPosition = new Vector3(flameBarTransform.localPosition.x, Mathf.Lerp(-75f, 0f, t), flameBarTransform.localPosition.z);
    }
}
