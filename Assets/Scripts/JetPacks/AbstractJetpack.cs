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
    [SerializeField] public List<AbstractTail> tails;
    [Header("Movement Settings")]
    [Space]
    [SerializeField] public MovementType movementType;
    [Header("Statistics")]
    [Space]

    [Range(1f, 10f)]
    [SerializeField] public int StatVelocity=1;
    public int ActualVelocity
    {
        get
        {
            return StatVelocity * 300;
        }
    }

    [Range(1f, 10f)]
    [SerializeField] public int StatHealthPoints=1;
    public int ActualHealthPoints
    {
        get
        {
            return StatHealthPoints * 10;
        }
    }

    [Range(1f, 10f)]
    [SerializeField] public int Armor=1;

    [Range(1f, 10f)]
    [SerializeField] public int StatFuelConsumption=1;
    public float ActualFuelConsumption
    {
        get
        {
            return StatFuelConsumption * 0.03f;
        }
    }



    [HideInInspector] public Rigidbody2D myRigid = new Rigidbody2D();
    protected AbstractMovement movement;

    private void Awake()
    {
        GameInfo.ActualJetPack = this;
    }

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
        if (Mathf.Abs(PlayerInput.GetLeftStick().x) > 0.2f || Mathf.Abs(PlayerInput.GetLeftStick().y) > 0.2f)
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
        StartEngine();
    }
    public void OnACancelled()
    {
        StopEngine();
    }


    private void StartEngine()
    {
        movement.SendCommandToMove();
    }
    private void StopEngine()
    {
        movement.StopMoving();
    }


}
