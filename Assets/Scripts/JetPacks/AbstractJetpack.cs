using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MovementType
{
    BasicMovement,
    NonExistingMovement
}

public abstract class AbstractJetpack : MonoBehaviour, IControllable, IDamageable
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
    [SerializeField] public int StatVelocity = 1;
    public int ActualVelocity
    {
        get
        {
            return StatVelocity * 300;
        }
    }

    [Range(1f, 10f)]
    [SerializeField] public int StatHealthPoints = 1;
    public int ActualHealthPoints
    {
        get
        {
            return StatHealthPoints * 10;
        }
    }

    [Range(1f, 10f)]
    [SerializeField] public int Armor = 1;

    [Range(1f, 10f)]
    [SerializeField] public int StatFuelConsumption = 1;
    public float ActualFuelConsumption
    {
        get
        {
            return StatFuelConsumption * 0.03f;
        }
    }


    public readonly float MaxFuelLevel = 100;
    public float ActualFuelLevel;
    public readonly float MaxHealthLevel = 100;
    public float ActualHealthLevel;


    [HideInInspector] public Rigidbody2D myRigid = new Rigidbody2D();
    protected AbstractMovement movement;

    //MonoBehav Stuff

    private void Awake()
    {
        GameInfo.ActualJetPack = this;
    }

    protected virtual void Start()
    {
        ActualFuelLevel = MaxFuelLevel;
        ActualHealthLevel = MaxHealthLevel;
        myRigid = GetComponent<Rigidbody2D>();
        PlayerInput.AddToControllables(this);
        UpdateMovement();
    }

    private void Update()
    {
        UpdateRotation();
        FuelCheck();
        HealthCheck();
    }
    //Assigns

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

    //Fuel Stuff

    private void FuelCheck()
    {
        if (ActualFuelLevel > 100)
        {
            ActualFuelLevel = 100;
        }
        else if (ActualFuelLevel < 0)
        {
            ActualFuelLevel = 0;
        }
    }
    public void ConsumeFuel(float value)
    {
        ActualFuelLevel -= value;
    }
    public bool HasFuelLeft()
    {
        if (ActualFuelLevel > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Health Stuff

    private void HealthCheck()
    {
        if (ActualHealthLevel > 100)
        {
            ActualHealthLevel = 100;
        }
        else if (ActualHealthLevel < 0)
        {
            ActualHealthLevel = 0;
            Destroy();
        }
    }
    public void TakeDamage(float value)
    {
        ActualHealthLevel -= value;
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

    //Rotation Stuff

    private void UpdateRotation()
    {
        if (Mathf.Abs(PlayerInput.GetLeftStick().x) > 0.2f || Mathf.Abs(PlayerInput.GetLeftStick().y) > 0.2f)
        {

            float rotationZ = Mathf.Atan2(PlayerInput.GetLeftStick().y, PlayerInput.GetLeftStick().x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ - 90);

        }
        
    }
    
    //Controlls Stuff

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

    //Movement Stuff

    private void StartEngine()
    {
        movement.SendCommandToMove();
    }
    private void StopEngine()
    {
        movement.StopMoving();
    }

}
