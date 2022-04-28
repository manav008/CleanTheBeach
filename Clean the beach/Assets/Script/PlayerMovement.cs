using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{

    float LANE_DISTANCE = 5.0f;
   
    int desiredLane = 1;
   
    [SerializeField]
    public float speed=15f;

    float laneShiftingSpeed = 12f;
    [SerializeField]
    float JumpSpeed=10f;
    CharacterController characterController;
    public float gravity = 30f;
    Vector3 targetPos;
    Vector3 moveVector=Vector3.zero;
    

    Animator anim;

    
    private void Awake()
    {
        
        anim = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        moveVector.z = 10.0f;
    }

 
    void Update()
    {
        targetPos = transform.position.z * Vector3.forward;

        if (desiredLane == 0)
        {
            targetPos +=   (Vector3.left * LANE_DISTANCE);
    
        }
        else if (desiredLane == 2)
        {

            targetPos += Vector3.right * LANE_DISTANCE;
        }


        Debug.Log(targetPos.x);
        moveVector.x = (targetPos.x - transform.position.x) * laneShiftingSpeed;

        moveVector.z = speed;

        if (!characterController.isGrounded)
        {
            moveVector.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveVector * Time.deltaTime );
    }

    public void MoveLane(bool goingRight)
    { 
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }
    public void jump()
    {
        if (characterController.isGrounded)
        {
            anim.SetTrigger("jump");
            moveVector.y = JumpSpeed;
           
        }
    }
    
}
