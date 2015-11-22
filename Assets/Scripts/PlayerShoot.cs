using UnityEngine;
using System.Collections;

[System.Serializable]
public class HSprites
{
    public Sprite[] states;
}


public class PlayerShoot : MonoBehaviour
{
    public float staminaCost;
    public float staminaRecovery;
    public float recoveryTime;

    public HSprites[] headSprites;
    public Sprite[] bodySpriteStates;
    public GameObject headSprite;
    public GameObject bodySprite;

    private Light muzzleFlame;
    private bool recovering = false;
    private Stamina staminaSystem;
    private ParticleSystem flame;
    private SpriteRenderer headSR;
    private SpriteRenderer bodySR;
    private bool isPlaying = false;
    private PlayerState playerState;
    private int selectedHat;

    void Awake()
    {
        playerState = GetComponent<PlayerState>();
        muzzleFlame = GetComponentInChildren<Light>();
        staminaSystem = GameObject.FindGameObjectWithTag("GameController").GetComponent<Stamina>();
        flame = GameObject.Find("Head").GetComponentInChildren<ParticleSystem>();
        headSR = headSprite.GetComponent<SpriteRenderer>();
        bodySR = bodySprite.GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        selectedHat = PlayerPrefs.GetInt("SelectedHat");
        selectedHat = 0; // DEBUG
    }

    void Update()
    {
        if (!playerState.GameOver)
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
                    headSR.sprite = headSprites[selectedHat].states[0];
                    bodySR.sprite = bodySpriteStates[0];
                }
                isPlaying = true;
            }
            if (Input.GetMouseButtonUp(0) || recovering)
            {
                if (isPlaying)
                {
                    muzzleFlame.enabled = false;
                    headSR.sprite = headSprites[selectedHat].states[1];
                    bodySR.sprite = bodySpriteStates[1];
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
}
