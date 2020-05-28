using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantTail : AbstractTail
{
    public override void StopEngine()
    {
        foreach (var systems in myWorkingSystems)
        {
            systems.Emit(0);
        }
    }

    public override void WorkingEngine()
    {
        foreach (var systems in myWorkingSystems)
        {
            systems.Emit(1);
        }
    }
}
