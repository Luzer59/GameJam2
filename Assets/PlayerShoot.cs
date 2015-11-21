using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public float staminaCost;
    public float staminaRecovery;
    public float recoveryTime;

    private bool recovering = false;
    private Stamina staminaSystem;
    private ParticleSystem flame;
    private bool isPlaying = false;

    void Awake()
    {
        staminaSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<Stamina>();
        flame = GetComponentInChildren<ParticleSystem>();
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
                flame.Play();
            }
            isPlaying = true;   
        }
        if (Input.GetMouseButtonUp(0) || recovering)
        {
            flame.Stop();
            isPlaying = false;
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
