using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    BasicMovement,
    NonExistingMovement
}

public abstract class AbstractJetpack : MonoBehaviour, IControllable
{
    [Header("Basic Configuration")]
    [Space]
    [SerializeField] protected List<AbstractTail> tails;
    [Header("Movement Settings")]
    [Space]
    [SerializeField] public MovementType movementType;
    [SerializeField] public float Velocity;

    [HideInInspector] public Rigidbody2D myRigid = new Rigidbody2D();
    protected AbstractMovement movement;

    protected virtual void Start()
    {
        myRigid = GetComponent<Rigidbody2D>();
        PlayerInput.AddToControllables(this);
        UpdateMovement();
    }

    protected virtual void FixedUpdate()
    {
        UpdateRotation();
    }

    public void AssignMovement(AbstractMovement _movement)
    {
        movement = _movement;
    }
    public void AssignTail(List<AbstractTail> _tails)
    {
        tails = _tails;
    }

    public void UpdateMovement(MovementType _movementType)
    {
        movementType = _movementType;

        UpdateMovement();
    }
    public void UpdateMovement()
    {
        switch (movementType)
        {
            case MovementType.BasicMovement:
                movement = new BasicMovement(this);
                break;
        }
    }



    private void UpdateRotation()
    {
        if (PlayerInput.GetLeftStick() != Vector2.zero && Mathf.Abs(PlayerInput.GetLeftStick().x) > 0.2f || Mathf.Abs(PlayerInput.GetLeftStick().y) > 0.2f)
        {

            float rotationZ = Mathf.Atan2(PlayerInput.GetLeftStick().y, PlayerInput.GetLeftStick().x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);

        }
    }
    
    public void OnBPerformed()
    {
        return;
    }
    public void OnBCancelled()
    {
        return;
    }

    public void OnAPerformed()
    {
        StartTails();
        StartEngine();
    }
    public void OnACancelled()
    {
        StopTails();
        StopEngine();
    }


    private void StartEngine()
    {
        movement.Move();
    }
    private void StopEngine()
    {
        return;
    }

    private void StartTails()
    {
        foreach(var tail in tails)
        {
            tail.isEngineOn = true;
        }
    }
    private void StopTails()
    {
        foreach (var tail in tails)
        {
            tail.isEngineOn = false;
        }
    }
}
