using UnityEngine;
using System.Collections;

public class StaminaBar : MonoBehaviour
{
    public float maxStamina = 100f;
    public float stamina = 0f;

    public GameObject mask;
    private RectTransform maskTransform;
    public GameObject silhouette;
    private RectTransform silhouetteTransform;
    public GameObject flameBar;
    private RectTransform flameBarTransform;

    private float t;
    
    void Awake()
    {
        maskTransform = mask.GetComponent<RectTransform>();
        silhouetteTransform = silhouette.GetComponent<RectTransform>();
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
