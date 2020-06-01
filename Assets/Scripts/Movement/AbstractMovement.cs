using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMovement
{
   

    protected AbstractJetpack myJet;

    public AbstractMovement(AbstractJetpack _jet)
    {
        myJet = _jet;
    }

    public virtual void SendCommandToMove()
    {
        if(FuelScript.HasFuelLeft(myJet) == true)
        {
            Move();
        }
        else
        {
            StopMoving();
        }
    }



    protected virtual void Move()
    {
        StartTails();
    }
    public virtual void StopMoving()
    {
        StopTails();
    }

    private void StartTails()
    {
        foreach (var tail in myJet.tails)
        {
            tail.isEngineOn = true;
        }
    }
    private void StopTails()
    {
        foreach (var tail in myJet.tails)
        {
            tail.isEngineOn = false;
        }
    }


}
