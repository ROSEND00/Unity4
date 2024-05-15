using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public float ImpulseForce = 3f;
    private bool IgnoreNextColision;

    private Vector3 StartPosition;
    [HideInInspector]
    public int perfectPass;

    public float superSpeed = 8;
    private bool isSuperSpeedActive;
    private int perfectPassCount = 3;




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

        if (isSuperSpeedActive && !collision.transform.GetComponent<GoalController>() )
        {
            Destroy(collision.transform.parent.gameObject,0.2f);
        
        }
        else { 
        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if (deathPart) {
        
        GameManager.singleton.RestartLevel();
        
        }
        }

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up*ImpulseForce,ForceMode.Impulse);
    IgnoreNextColision = true;

        Invoke("Allownextcolision", 0.2f);

        perfectPass = 0;
        isSuperSpeedActive = false;
    }

    private void Update()
    {
    if(perfectPass>=perfectPassCount && !isSuperSpeedActive) {

            isSuperSpeedActive = true;


            rb.AddForce(Vector3.down*superSpeed,ForceMode.Impulse);
        }        
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
