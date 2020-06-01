using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : AbstractMovement
{
    Vector2 oldPos = Vector2.up;

    public BasicMovement(AbstractJetpack _jet) : base(_jet) { }

    protected override void Move()
    {
        base.Move();

        if (Mathf.Abs(PlayerInput.GetLeftStick().x) > 0.2f || Mathf.Abs(PlayerInput.GetLeftStick().y) > 0.2f)
        {
            myJet.myRigid.AddForce(PlayerInput.GetLeftStick().normalized * myJet.ActualVelocity * Time.deltaTime);
            oldPos = PlayerInput.GetLeftStick().normalized;
            FuelScript.ConsumeFuel(myJet.ActualFuelConsumption);
        }
        else
        {
            myJet.myRigid.AddForce(oldPos * myJet.ActualVelocity * Time.deltaTime);
            FuelScript.ConsumeFuel(myJet.ActualFuelConsumption);

        }


    }



}
