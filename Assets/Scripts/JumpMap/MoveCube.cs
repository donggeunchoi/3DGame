using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float moveDuration;
    public float waitDuration;

    public Vector3 target;
    private bool isMoving = false;
    
    // Start is called before the first frame update
    void Start()
    {
        target = pointB.position;
        StartCoroutine(MoveLoop());
    }

    IEnumerator MoveLoop()
    {
        while (true)
        {
            //이동하는 코루틴.
            yield return StartCoroutine(MoveTo(target, moveDuration));
            //멈추고 기다리는 코루틴.
            yield return new WaitForSeconds(waitDuration);   
            
            //해당 위치 도달했으면 반대로 가기위한 반전.
            target = (target == pointA.position) ? pointB.position : pointA.position;
        }
    }

    IEnumerator MoveTo(Vector3 destination, float duration)
    {
        isMoving = true;
        Vector3 start = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            float t = elapsed / duration;
            transform.position = Vector3.Lerp(start, destination, t);
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = destination;
        isMoving = false;
    }

    
}
