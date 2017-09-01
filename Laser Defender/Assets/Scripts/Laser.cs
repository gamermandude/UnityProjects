using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public int Damage = 100;
    public void Hit()
    {
        Destroy(gameObject);
    }
}
