using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
	public float moveSpeed = 10f, rotSpeed = 90f;
	private Rigidbody rb;
	//private MeshRenderer myMesh;

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
		print(collision.transform.name);
		if (collision.transform.GetComponent<HealthManager>())
			collision.transform.GetComponent<HealthManager>().ChangeHP(-1);
		SelfDestruct();
	}

	void SelfDestruct()
	{
		Destroy(this.gameObject);
	}

	public void AssignColour(Material input)
	{
		GetComponentInChildren<MeshRenderer>().material = input;
	}
}
