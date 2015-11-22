using UnityEngine;
using System.Collections;

public class CoinToPouch : MonoBehaviour
{
    private float timer = 0f;
    private bool letItLerp = false;
    private Vector3 startPos;
    private GameObject pouch;
    private Coins coins;

    public float speed;

    void Awake()
    {
        coins = GameObject.FindGameObjectWithTag("GameController").GetComponent<Coins>();
        pouch = GameObject.Find("Pouch");
    }

    public void Activate(Vector3 position)
    {
        timer = 0f;
        letItLerp = true;
        startPos = position;
    }

    void Update()
    {
        if (letItLerp)
        {
            timer += speed * Time.deltaTime;
            transform.position = Vector3.Lerp(startPos, pouch.transform.position, (1f - Mathf.Cos(timer * Mathf.PI * 0.5f)));

            if (timer >= 1f)
            {
                letItLerp = false;
                coins.coins++;
                ReturnToPool();
            }
        }
    }

    void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
