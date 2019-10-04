using UnityEngine;
using System.Collections;

public class SteeringAlign : MonoBehaviour {

    public float min_distance = 0.1f;
    public float slow_distance = 5.0f;
    public float time_to_accel = 0.1f;
    private float speedFactor = 1.0f;

    private float rotSpeed = 5.0f;

    Move move;

	// Use this for initialization
	void Start () {
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
        // TODO 7: Very similar to arrive, but using angular velocities
        // Find the desired rotation and accelerate to it
        // Use Vector3.SignedAngle() to find the angle between two directions

        Vector3 vel1 = transform.position;
        


        else
        {
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
}
