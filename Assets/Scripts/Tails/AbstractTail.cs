using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractTail : MonoBehaviour
{

    [SerializeField] protected List<ParticleSystem> myWorkingSystems;
    [SerializeField] protected List<ParticleSystem> myStartSystems;

    [HideInInspector] public bool isEngineOn = false;
    [HideInInspector] public bool wasEngineStarted = false;
    [HideInInspector] public bool wasEngineStopped = false;

    protected void Update()
    {
        if(isEngineOn == true)
        {
            if(wasEngineStarted == false)
            {
                StartEngine();
            }

            WorkingEngine();
        }
        if(isEngineOn==false)
        {
            if(wasEngineStopped == false)
            {
                StopEngine();
            }
        }
    }

    public virtual void StartEngine()
    {
        wasEngineStarted = true;
    }
    public virtual void WorkingEngine()
    {
    }
    public virtual void StopEngine()
    {
        wasEngineStopped = true;
    }
}
