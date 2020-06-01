using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelTank : MonoBehaviour , ICollectable
{
    public float FuelAdded;

    public void Collect()
    {
        FuelScript.ActualFuelLevel += FuelAdded;
        Destruct();
    }

    public void Destruct()
    {
        Destroy(gameObject);
    }

    public void OnSpawn()
    {
        return;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collect();
        }
    }
}
