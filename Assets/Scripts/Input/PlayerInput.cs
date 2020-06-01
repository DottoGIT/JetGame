using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private bool SnapMode;
    private static Vector2 leftVector;
    private static Vector2 rightVector;
    private bool isAPerformed = false;
    private bool isBPerformed = false;
    private Controls controls;
    private static List<IControllable> controllableObjects = new List<IControllable>();

    public static void AddToControllables(IControllable obj)
    {
        controllableObjects.Add(obj);
    }

    private void Awake()
    {
        controls = new Controls();
        controls.Gameplay.LeftStick.performed += ctx => leftVector = ctx.ReadValue<Vector2>();
        controls.Gameplay.RightStick.performed += ctx => rightVector = ctx.ReadValue<Vector2>();
        controls.Gameplay.B.performed += ctx => OnBPressed();
        controls.Gameplay.A.performed += ctx => OnAPressed();
        controls.Gameplay.A.canceled += ctx => OnACancelled();
        controls.Gameplay.B.canceled += ctx => OnBCancelled();
    }

    private void Update()
    {
        if (isAPerformed)
        {
            OnAPerformed();
        }
        if (isBPerformed)
        {
            OnBPerformed();
        }

        if (SnapMode)
        {
            if(Mathf.Abs(GetLeftStick().x) > 0.7f || Mathf.Abs(GetLeftStick().y) > 0.7f)
            {
                OnAPressed();
            }
            else
            {
                OnACancelled();
            }
        }
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    void OnDisable()
    {
        controls.Gameplay.Disable();
    }

    public void OnBPressed()
    {
        isBPerformed = true;  
    }
    public void OnAPressed()
    {
        isAPerformed = true;
    }
    public void OnACancelled()
    {
        isAPerformed = false;

        foreach (var obj in controllableObjects)
        {
            obj.OnACancelled();
        }
    }
    public void OnBCancelled()
    {
        isBPerformed = false;

        foreach (var obj in controllableObjects)
        {
            obj.OnBCancelled();
        }
    }
    public void OnAPerformed()
    {
        foreach (var obj in controllableObjects)
        {
            obj.OnAPerformed();
        }
    }
    public void OnBPerformed()
    {
        foreach (var obj in controllableObjects)
        {
            obj.OnBPerformed();
        }
    }

    public static Vector2 GetLeftStick()
    {
        return leftVector;
    }
    public static Vector2 GetRightStick()
    {
        return rightVector;
    }
}
