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

    public virtual void Move()
    {
        return;
    }
    public virtual void StopMoving()
    {
        return;
    }

}
