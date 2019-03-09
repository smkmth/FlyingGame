using UnityEngine;

public abstract class Engine : MonoBehaviour
{

    public abstract float MaxSpeed { get; set; }

    public abstract float Acceleration { get; set; }

    public abstract void MoveForward(float input );

    public abstract void MoveLeft( float input );

    public abstract float RollForce { get; set; }
	
}
