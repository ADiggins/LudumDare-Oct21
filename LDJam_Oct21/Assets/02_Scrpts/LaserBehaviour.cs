using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
	public float moveSpeed = 10f, rotSpeed = 90f;
	private Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}
	// Start is called before the first frame update
	void Start()
    {
		rb.velocity = transform.forward * moveSpeed;
		Invoke("SelfDestruct", 3.0f);
	}

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0,0,rotSpeed * Time.deltaTime);
    }

	private void OnCollisionEnter(Collision collision)
	{
		SelfDestruct();
	}

	void SelfDestruct()
	{
		Destroy(this.gameObject);
	}
}
