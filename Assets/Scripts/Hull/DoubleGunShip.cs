using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleGunShip : Hull
{
    [SerializeField]
    private Engine mainEngine;
    public override Engine MainEngine { get; set; }

    [SerializeField]
    private List<Gun> gunArray;
    public override List<Gun> GunList { get; set ; }

    private void Start()
    {
        GunList = gunArray;
        MainEngine = mainEngine;
        
    }

}
