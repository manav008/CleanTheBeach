
using UnityEngine;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-1)]
public class inputManager : Singleton<inputManager>
{
    // Start is called before the first frame update
    #region events
    public delegate void StartTouch(Vector2 pos, float time);
    public event StartTouch onStartTouch;
    public delegate void endTouch(Vector2 pos, float time);
    public event endTouch onEndTouch;

    #endregion



    public PlayerControls playerControls;
    private Camera mainCamera;

    private void Awake()
    {
        playerControls = new PlayerControls();
        mainCamera = Camera.main;
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
  
    void Start()
    {
        playerControls.Touch.Primarycontact.started += ctx=> StartTouchPrimary(ctx);
        playerControls.Touch.Primarycontact.canceled += ctx=> EndTouchPrimary(ctx);
    }

    private void StartTouchPrimary(InputAction.CallbackContext context)
    {
        if (onStartTouch != null) 
            onStartTouch(playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(),(float)context.startTime);
    }
    private void EndTouchPrimary(InputAction.CallbackContext context)
    {
      if (onEndTouch != null)
            onEndTouch(playerControls.Touch.PrimaryPosition.ReadValue<Vector2>(), (float)context.time);

    }
    public Vector2 PrimaryPosition()
    {
        return (playerControls.Touch.PrimaryPosition.ReadValue<Vector2>());
    }

}
