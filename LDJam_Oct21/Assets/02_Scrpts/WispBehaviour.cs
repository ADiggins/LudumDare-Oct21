using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WispBehaviour : MonoBehaviour
{
	public GameObject target;
	public bool attacking = false;
	public float attackRange = 20, passiveRange = 10;
	public float moveSpeed = 1f, passiveTurnSpeed = 2f, attackTurnSpeed = 4f;

	private Vector3 sourcePoint, destination;
	private Vector3 lookVector;
	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Start is called before the first frame update
	void Start()
    {
		sourcePoint = transform.position;
		lookVector = transform.forward;
		PickNewDestination();
    }

    // Update is called once per frame
    void Update()
    {
		attacking = Vector3.Distance(transform.position, target.transform.position) < attackRange;
        if (attacking)
		{
			//Initiate attacking behaviour
			lookVector = Vector3.Lerp(lookVector, target.transform.position - transform.position, attackTurnSpeed * Time.deltaTime);
			transform.rotation = Quaternion.LookRotation(lookVector);
		}
		else
		{
			//Movement vector represents direction I am currently travelling. It is constantly lerping toward the destination
			//If I'm close to the destination, pick a new destination

			//movementVector = (destination - transform.position).normalized;
			lookVector = Vector3.Lerp(lookVector, destination - transform.position, passiveTurnSpeed * Time.deltaTime);
			lookVector.Normalize();
			transform.rotation = Quaternion.LookRotation(lookVector);
			if (Vector3.Distance(transform.position, destination) < 1)
			{
				PickNewDestination();
			}
			
		}
    }

	private void FixedUpdate()
	{
		if (attacking)
		{
			rb.velocity = Vector3.zero;
		}
		else
		{
			rb.velocity = lookVector * moveSpeed;
		}
	}
	void PickNewDestination()
	{
		//Raycast in a random direction. If we hit an obstacle, set the destination to the hit point
		//If no hit, set the destination to the maximum point in space. 
		RaycastHit hit;
		Vector3 randomDirection = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1)).normalized;

		if (Physics.Raycast(sourcePoint, randomDirection, out hit, passiveRange)) {
			destination = hit.point - randomDirection;
		} else
		{
			destination = sourcePoint + randomDirection * passiveRange;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		PickNewDestination();
	}
}