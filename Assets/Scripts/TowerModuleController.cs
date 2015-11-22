using UnityEngine;
using System.Collections;

public class TowerModuleController : MonoBehaviour
{
    public Sprite[] states;
    public float dropDistance;
    public int healthMax;
    public int health;
    public int placeIndex;

    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        health = healthMax;
    }

    public void CheckSpriteState()
    {
        if (states.Length == 3)
        {
            float healthPercentage = (float)health / (float)healthMax;

            if (healthPercentage > 0.66f)
            {
                spriteRenderer.sprite = states[0];
            }
            else if (healthPercentage <= 0.66f && healthPercentage > 0.33f)
            {
                spriteRenderer.sprite = states[1];
            }
            else if (healthPercentage <= 0.33f && healthPercentage > 0f)
            {
                spriteRenderer.sprite = states[2];
            }
            else
            {
                //spriteRenderer.sprite = states[3];
            }
        }
    }

    public void ModuleDestroy()
    {
        if (states.Length == 1)
        {
            spriteRenderer.sprite = states[0];
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
