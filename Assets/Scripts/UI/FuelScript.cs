using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelScript : MonoBehaviour
{
    [SerializeField] private GameObject BarAnchor;
    public static float MaxFuelLevel = 100;
    public static float ActualFuelLevel;

    private void Start()
    {
        ActualFuelLevel = MaxFuelLevel;
    }

    private void Update()
    {
        if (ActualFuelLevel > 100)
        {
            ActualFuelLevel = 100;
        }
        else if (ActualFuelLevel < 0)
        {
            ActualFuelLevel = 0;
        }
        BarAnchor.transform.localScale = new Vector3(1,ActualFuelLevel/MaxFuelLevel,1);
    }

    public static void ConsumeFuel(float value)
    {
        FuelScript.ActualFuelLevel -= value;
    }

    public static bool HasFuelLeft(AbstractJetpack jet)
    {
        if (FuelScript.ActualFuelLevel > jet.ActualFuelConsumption)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public static bool HasFuelLeft()
    {
        if (FuelScript.ActualFuelLevel > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
