using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float ImpulseForce = 3f;
    private bool IgnoreNextColision;

    private Vector3 StartPosition;
    
    private void Start()
    {
        StartPosition = transform.position;
    }
    private void OnCollisionEnter(Collision collision)
    {
      

        if (IgnoreNextColision)
        {
            return;
        }
        
        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if (deathPart) {
        
        GameManager.singleton.RestartLevel();
        
        }


        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*ImpulseForce,ForceMode.Impulse);
    IgnoreNextColision = true;

        Invoke("Allownextcolision", 0.2f);
    }
    private void Allownextcolision()
    {
        IgnoreNextColision=false;
    }

    public void ResetBall()
    {
        transform.position = StartPosition;
    }


}
