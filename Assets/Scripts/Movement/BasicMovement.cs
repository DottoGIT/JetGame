using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : AbstractMovement
{

    public BasicMovement(AbstractJetpack _jet) : base(_jet) { }

    public override void Move()
    {
        myJet.myRigid.AddForce(PlayerInput.GetLeftStick().normalized * myJet.Velocity);
    }



}
