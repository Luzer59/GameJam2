using UnityEngine;
using System.Collections;

public class Pulser : MonoBehaviour
{
    public float timer = 0f;
    public float speed = 1f;
    public float min;
    public float max;

    void Update()
    {
        timer += speed * Time.deltaTime;
        float lerpedValue = Mathf.Lerp(min, max, (Mathf.Sin(timer) + 1) / 2);
        transform.localScale = new Vector3(lerpedValue, lerpedValue, 1f);
    }
}
