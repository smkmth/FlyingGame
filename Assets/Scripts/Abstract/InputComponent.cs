﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InputComponent : MonoBehaviour {

    public abstract float GetForward { get; set; }
    public abstract float GetLeft { get; set; }
    public abstract bool GetFire { get; set; }
}