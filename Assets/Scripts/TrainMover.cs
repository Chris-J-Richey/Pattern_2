using UnityEngine;
using System.Collections;

public class TrainMover : MonoBehaviour {

	public float power = 1f;
	public float control;
	public Rigidbody rb;

	public movement move = new forward();

	void Start() 
	{
		rb = GetComponent<Rigidbody>();
	}

	void FixedUpdate() 
	{
		move.move (ref control);
		rb.AddForce(transform.forward * control * power);
	}
}

public abstract class movement
{
	public abstract void move(ref float x);
}

public class backward : movement
{
	public override void move(ref float x)
	{
		x = -1f;
	}
}

public class forward : movement 
{
	public override void move(ref float x)
	{
		x = 1f;
	}
}

public class stop : movement
{
	public override void move(ref float x)
	{
		x = 0f;
	}
}
