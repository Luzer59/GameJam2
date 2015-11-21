using UnityEngine;
using System.Collections;

public class GroundFireEffect : MonoBehaviour
{
    public bool alignWithTerrain = false;

    public void Activate(Vector3 position, Vector3 direction)
    {
        transform.position = position;

        Quaternion newRotation = Quaternion.LookRotation(Vector3.forward, direction);
        newRotation *= Quaternion.Euler(0f, 0f, -90f);
        if (alignWithTerrain)
        {
            transform.rotation = newRotation;
        }
        StartCoroutine(RemoveAfterTime());
    }

    IEnumerator RemoveAfterTime()
    {
        yield return new WaitForSeconds(1f);
        ReturnToPool();
    }

    void ReturnToPool()
    {
        gameObject.SetActive(false);
    }
}
