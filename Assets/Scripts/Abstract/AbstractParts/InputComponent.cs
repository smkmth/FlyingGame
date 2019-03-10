using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum AIState
{
    MovingToInitPos,
    InPos

}

public abstract class InputComponent : MonoBehaviour {

    public abstract float GetForward { get; set; }
    public abstract float GetLeft { get; set; }
    public abstract bool GetFire { get; set; }
    public abstract bool GetRoll { get; set; }
    public abstract bool UseSpcPower { get; set; }
    public abstract bool GetFineMov { get; set; }
}
