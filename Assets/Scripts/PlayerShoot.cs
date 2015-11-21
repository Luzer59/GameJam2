using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public float staminaCost;
    public float staminaRecovery;
    public float recoveryTime;
    public Sprite[] spriteStates;
    public GameObject headSprite;

    private Light muzzleFlame;
    private bool recovering = false;
    private Stamina staminaSystem;
    private ParticleSystem flame;
    private SpriteRenderer spriteRenderer;
    private bool isPlaying = false;

    void Awake()
    {
        muzzleFlame = GetComponentInChildren<Light>();
        staminaSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<Stamina>();
        flame = GetComponentInChildren<ParticleSystem>();
        spriteRenderer = headSprite.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (recovering)
        {
            if (staminaSystem.stamina / staminaSystem.maxStamina >= 0.4f)
            {
                recovering = false;
            }
        }

        if (Input.GetMouseButton(0) && !recovering)
        {
            if (!isPlaying)
            {
                muzzleFlame.enabled = true;
                flame.Play();
                spriteRenderer.sprite = spriteStates[0];
            }
            isPlaying = true;   
        }
        if (Input.GetMouseButtonUp(0) || recovering)
        {
            if (isPlaying)
            {
                muzzleFlame.enabled = false;
                spriteRenderer.sprite = spriteStates[1];
                flame.Stop();
                isPlaying = false;
            }
        }
        if (isPlaying)
        {
            staminaSystem.stamina -= staminaCost * Time.deltaTime;
            if (staminaSystem.stamina <= 0f)
            {
                recovering = true;
            }
        }
        else
        {
            staminaSystem.stamina += staminaRecovery * Time.deltaTime;
        }

        staminaSystem.stamina = Mathf.Clamp(staminaSystem.stamina, 0f, staminaSystem.maxStamina);
    }
}
