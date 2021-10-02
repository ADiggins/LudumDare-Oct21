using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
	public float moveSpeed = 7f, sensitivity = 100f;

	private Rigidbody rb;
	private float horizontalInput, verticalInput;
	private Vector3 forwardVector, sideVector, upVector;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	
	void Start()
    {
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
    }

	void Update()
	{
		verticalInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");

		forwardVector = transform.forward * verticalInput * moveSpeed;
		sideVector = transform.right * horizontalInput * moveSpeed;
		upVector = new Vector3(0, rb.velocity.y, 0);

		transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime, 0);
		Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime, 0, 0);
	}

	// Update is called once per frame
	void FixedUpdate()
    {
		rb.velocity = forwardVector + sideVector + upVector;
    }
}
