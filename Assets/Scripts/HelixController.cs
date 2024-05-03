using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{
    private Vector2 LastTapPosition;
    private Vector3 startPosition;



    void Start()
    {
        startPosition = transform.localEulerAngles;  
    }

    
    void Update()
    {
        if(Input.GetMouseButton(0)) {
            Vector2 currentTapPosition = Input.mousePosition;
           
        if(LastTapPosition==Vector2.zero) {
                LastTapPosition = currentTapPosition;

            }
        float distance = LastTapPosition.x - currentTapPosition.x;
            LastTapPosition = currentTapPosition;


            transform.Rotate(Vector3.up * distance);
        
        }

        if(Input.GetMouseButtonUp(0)) {
        LastTapPosition=Vector2.zero;
        }
    }
}
