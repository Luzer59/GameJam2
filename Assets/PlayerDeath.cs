using UnityEngine;
using System.Collections;

public class PlayerDeath : MonoBehaviour
{
    private Coins coinHolder;
    private GameObject head;
    private ParticleSystem blood;
    private SceneFade sceneFade;
    private bool readyForExit = false;

    void Awake()
    {
        coinHolder = GameObject.FindGameObjectWithTag("GameController").GetComponent<Coins>();
        head = GameObject.Find("Head");
        blood = GameObject.Find("Body").GetComponentInChildren<ParticleSystem>();
        sceneFade = GameObject.FindGameObjectWithTag("GameController").GetComponent<SceneFade>();
    }

    void Update()
    {
        if (readyForExit)
        {
            if (Input.anyKeyDown)
            {
                PlayerPrefs.SetInt("Coins", coinHolder.coins);
                sceneFade.Activate(0);
            }
        }
    }

    public IEnumerator DeathEffect()
    {
        head.SetActive(false);
        blood.Play();
        yield return new WaitForSeconds(3f);
        sceneFade.GetComponent<Coins>().SaveCoins();
        readyForExit = true;
    }
}
