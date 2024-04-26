using UnityEngine;
using System.Collections;

public class EnemyAnimation : MonoBehaviour {

	public float deadZone = 5f;					// The number of degrees for which the rotation isn't controlled by Mecanim.
	
	public float speedDampTime = 0.1f;				// Damping time for the Speed parameter.
	public float angularSpeedDampTime = 0.7f;		// Damping time for the AngularSpeed parameter
	public float angleResponseTime = 0.6f;			// Response time for turning an angle into angularSpeed.

	private UnityEngine.AI.NavMeshAgent nav;					// Reference to the nav mesh agent.
	private Animator anim;						// Reference to the Animator.

	public Transform target;					// Destination of the agent.

	void Awake ()
	{
		// Setting up the references.
		nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
		anim = GetComponent<Animator>();
		
		// Making sure the rotation is controlled by Mecanim.
		nav.updateRotation = false;
		
		// Set the weights for the shooting and gun layers to 1.
		anim.SetLayerWeight(1, 1f);
		anim.SetLayerWeight(2, 1f);
		
		// We need to convert the angle for the deadzone from degrees to radians.
		deadZone *= Mathf.Deg2Rad;
	}
	
	
	void Update () 
	{
		if(target != null)
		{
			//TODO: Set the destination of the NavMesh agent to the position of the target.


			// Create the parameters to pass to the helper function.
			float speed = 0;
			float angularSpeed = 0;
			DetermineAnimParameters (out speed, out angularSpeed);

			//Set the values of the parameters to the animator.
			anim.SetFloat("Speed", speed, speedDampTime, Time.deltaTime);
			anim.SetFloat("AngularSpeed", angularSpeed, angularSpeedDampTime, Time.deltaTime);
		}
	}
	
	
	void OnAnimatorMove()
	{
		// Set the NavMeshAgent's velocity to the change in position since the last frame, by the time it took for the last frame.
		nav.velocity = anim.deltaPosition / Time.deltaTime;
		
		// The gameobject's rotation is driven by the animation's rotation.
		transform.rotation = anim.rootRotation;
	}
	
	
	void DetermineAnimParameters (out float speed, out float angularSpeed)
	{
		// TODO: Set the speed to the magnitude of the projection of nav.desiredVelocity on to the forward vector...
		speed = Vector3.Project(nav.desiredVelocity, transform.forward).magnitude;


		// Set the angle to the angle between forward and the desired velocity.
		float angle = FindAngle(transform.forward, nav.desiredVelocity, transform.up);
		
		// If the angle is within the deadZone...
		if(Mathf.Abs(angle) < deadZone)
		{
			// TODO: set the direction to be along the desired direction and set the angle to be zero.
			transform.LookAt(transform.position + nav.desiredVelocity);
			angle = 0f;
		}
		
		angularSpeed = angle / angleResponseTime;
	}
	
	
	float FindAngle (Vector3 fromVector, Vector3 toVector, Vector3 upVector)
	{
		
		// Create a float to store the angle between the facing of the enemy and the direction it's travelling.
		float angle = 0;

		// If the vector the angle is being calculated to is 0...
		if(toVector == Vector3.zero)
			// ... the angle between them is 0.
			return 0f;

		//TODO: Return the angle, in radians, between fromVector and toVector;
		// NOTE that Vector3.Angle returns the ACUTE angle between the two vectors 
		//   (this is: the smaller of the two possible angles between them and never greater than 180 degrees)
		angle = Vector3.Angle(fromVector, toVector) * Mathf.Deg2Rad;

		return angle;
	}
	
	public void setTarget(Transform target, float speed = 2.0f)
	{
		this.target = target;
		nav.speed = speed;
	}
	
	public void Stop()
	{
		nav.speed = 0f;
	}
}
