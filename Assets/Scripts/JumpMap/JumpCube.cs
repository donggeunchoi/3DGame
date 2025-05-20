using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCube : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            if (player != null)
            {
                player.AddForce();
            }
            else
            {
                Debug.LogWarning("JumpCube: Player 오브젝트에 PlayerController가 없습니다.");
            }
        }
       

    }
}
