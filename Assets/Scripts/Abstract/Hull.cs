using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InputComponent))]
public abstract class Hull : MonoBehaviour {

    public abstract Engine MainEngine { get; set; }
    public abstract List<Gun> GunList { get; set; }

}
