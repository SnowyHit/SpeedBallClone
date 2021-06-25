using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class movementHandler : MonoBehaviour
{
    public bool onRight = true;
    public float movSpeed;
    public float pushForce;
    public float jumpForce;
    private Rigidbody rb;
    private bool isMoving;
    public float currentFloorPos = 0;
    public bool jump;
    private int score;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0,0,movSpeed);
        score = PlayerPrefs.GetInt("score");
    }


    void Update()
    {
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,movSpeed);
        if(!jump)
        {
          if(transform.position.x <= (currentFloorPos -1)|| transform.position.x >= (currentFloorPos + 1))
          {
            rb.velocity = new Vector3(0,rb.velocity.y,movSpeed);
            if(transform.position.x <= (currentFloorPos -1 ))
            {
              transform.position = new Vector3((currentFloorPos - 1.1f) ,transform.position.y ,transform.position.z) ;
            }
            else
            {
              transform.position = new Vector3((currentFloorPos + 1.1f),transform.position.y ,transform.position.z) ;
            }

            isMoving = true ;
          }
          else
          {
            isMoving = false ;
          }
          if(isMoving)
          {
            if (Input.GetMouseButtonDown(0))
              {

                if(EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                score += 5;
                PlayerPrefs.SetInt("score", score);

                if(onRight)
                  {
                    rb.AddForce(new Vector3(-pushForce,0,0) );
                    onRight = false ;
                  }
                else
                  {
                    rb.AddForce(new Vector3(pushForce,0,0) );
                    onRight = true ;
                  }
              }
           }
         }
         else
         {
           rb.AddForce(new Vector3(0,jumpForce,0));
           if(transform.position.x <= (currentFloorPos - 1 ))
           {
             currentFloorPos -= 2 ;
             transform.position = new Vector3((currentFloorPos + 1.1f) ,transform.position.y ,transform.position.z) ;
             onRight = true ;
             jump = false ;
           }
           else
           {
             currentFloorPos += 2 ;
             transform.position = new Vector3((currentFloorPos - 1.1f) ,transform.position.y ,transform.position.z) ;
             onRight = false ;
             jump = false ;
           }
         }
    }
}
