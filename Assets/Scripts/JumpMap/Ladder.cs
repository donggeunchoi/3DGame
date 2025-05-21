using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public float liftHeight;

    public float liftDuration;

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(UpLadder(collision.transform));;
        }
    }

    IEnumerator UpLadder(Transform player)
    {
        Vector3 start = player.position;
        Vector3 end = start + Vector3.up * liftHeight;
        float elapsed = 0f;

        while (elapsed < liftDuration)
        {
            float t = elapsed / liftDuration;
            player.position = Vector3.Lerp(start, end, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        player.position = end;
    }
    
}
