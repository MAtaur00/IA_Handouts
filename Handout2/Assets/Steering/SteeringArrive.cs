using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_accel = 0.1f;
    private float speedFactor = 1.0f;

	Move move;

	// Use this for initialization
	void Start () { 
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
		    Steer(move.target.transform.position);
	}

    public void Steer(Vector3 target)
    {
        if (!move)
            move = GetComponent<Move>();

        // TODO 3: Find the acceleration to achieve the desired velocity
        // If we are close enough to the target just stop moving and do nothing else
        // Calculate the desired acceleration using the velocity we want to achieve and the one we already have
        // Use time_to_target as the time to transition from the current velocity to the desired velocity
        // Clamp the desired acceleration and call move.AccelerateMovement()

        Vector3 vel1 = move.target.transform.position - transform.position;

        if (vel1.magnitude < min_distance)
        {
            move.SetMovementVelocity(Vector3.zero);
        }

        else
        {
            //TODO 4: Add a slow factor to reach the target
            // Start slowing down when we get closer to the target
            // Calculate a slow factor (0 to 1 multiplier to desired velocity)
            // Once inside the slow radius, the further we are from it, the slower we go
            speedFactor = vel1.magnitude / slow_distance;

            vel1.Normalize();
            vel1 *= move.max_mov_speed * speedFactor;


            Vector3 vel2 = move.movement;

            Vector3 accel = (vel1 - vel2) / time_to_accel;

            if (accel.magnitude > move.max_mov_acceleration)
            {
                accel.Normalize();
                accel *= move.max_mov_acceleration;
            }

            move.AccelerateMovement(accel);

            
        }
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}
