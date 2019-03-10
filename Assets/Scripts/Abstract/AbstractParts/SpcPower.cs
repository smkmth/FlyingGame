using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpcPower : MonoBehaviour
{
    public abstract float PowerRechargeRate { get; set; }

    public abstract float MaxPowerMeter { get; set; }

    public abstract void UsePower();
}
