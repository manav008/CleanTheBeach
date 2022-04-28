using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private float minimumDistance = 0.2f; 
    [SerializeField]
    private float maxTime = 1f;
     [SerializeField,Range(0f,1f)]
    private float directionThreshold = .9f;

    public UnityEvent swipeLeftEvent;
    public UnityEvent swipeRightEvent;
    public UnityEvent swipeUpEvent;
   
    

    private inputManager _inputManager;
    private Vector2 startPos;
    private float startTime;

    private Vector2 endPos;
    private float endTime;

    private void Awake()
    {
        _inputManager = inputManager.Instance;
    }
    private void OnEnable()
    {
        _inputManager.onStartTouch += swipeStart;
        _inputManager.onEndTouch += swipeEnd;
    }
    private void OnDisable()
    {
        _inputManager.onStartTouch -= swipeStart;
        _inputManager.onEndTouch -= swipeEnd;
    }
    private void swipeStart(Vector2 pos,float time)
    {
        startPos = pos;
        startTime = time;
    }
    private void swipeEnd(Vector2 pos,float time)
    {
        endPos = pos;
        endTime = time;
        detectSwipe(); 
    }
    private void detectSwipe()
    {
        if(Vector3.Distance(startPos,endPos)>=minimumDistance&& (endTime-startTime) <= maxTime)
        {
        //    Debug.Log("swipe detected");
        
            Vector3 direction = endPos - startPos;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            SwipeDirection(direction2D);
        }
    }
    private void SwipeDirection(Vector2 direction)
    {
        if(Vector2.Dot(Vector2.up,direction) > directionThreshold)
        {
            swipeUpEvent.Invoke();
          //  Debug.Log("swipe Up");
        }
        else if(Vector2.Dot(Vector2.down,direction) > directionThreshold)
        {
      //      Debug.Log("swipe down");
        }
        else if (Vector2.Dot(Vector2.left,direction) > directionThreshold)
        {
            swipeLeftEvent.Invoke();
        //    Debug.Log("swipe left");
        }
        else if (Vector2.Dot(Vector2.right,direction) > directionThreshold)
        {
            swipeRightEvent.Invoke();
        //    Debug.Log("swipe right");
        }
    }
}
