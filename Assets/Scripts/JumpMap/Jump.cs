using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rigidbody;

    private float jumpPower = 5.0f;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void AddForce()
    {
        rigidbody.AddForce(transform.up * jumpPower);
        rigidbody.AddForce(transform.up * jumpPower, ForceMode.Impulse);
    }


    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("충돌했데이 여기에다 에드폴스 넣으면 되겠제?");
    }
}
