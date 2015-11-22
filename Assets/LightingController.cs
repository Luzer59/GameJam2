using UnityEngine;
using System.Collections;

public class LightingController : MonoBehaviour
{
    private float[] timer = new float[2] {0f, 0.8f};
    public float speed = 1f;
    public float minIntensity;
    public float maxIntensity;
    public float minRange;
    public float maxRange;
    Light[] lights;

    void Awake()
    {
        lights = GetComponentsInChildren<Light>();
    }

    void Update()
    {
        for (int i = 0; i < timer.Length; i++)
        {
            timer[i] += speed * Time.deltaTime;
            lights[i].range = Mathf.Lerp(minRange, maxRange, (Mathf.Sin(timer[i]) + 1) / 2);
            lights[i].intensity = Mathf.Lerp(minIntensity, maxIntensity, (Mathf.Sin(timer[i]) + 1) / 2);
        }
    }
}
