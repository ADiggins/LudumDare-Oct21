using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureZone : MonoBehaviour
{
	public float timeToCapture = 5;
	
	public bool captured = false;

	private ParticleSystem ps;
	private Material highlighter;
	private Color currentColor;
	private float intensity;
	private float captureSync;

	private void Awake()
	{
		highlighter = GetComponentInChildren<MeshRenderer>().materials[1];
		ps = GetComponent<ParticleSystem>();
	}
	// Start is called before the first frame update
	void Start()
    {
		currentColor = highlighter.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
		highlighter.SetColor("_EmissionColor", (currentColor * intensity)/5);
	}

	private void OnTriggerEnter(Collider other)
	{
		print("Something entered");
		if (other.transform.tag == "Player" && !captured)
		{
			captureSync = Time.time + timeToCapture;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.transform.tag == "Player" && !captured)
		{
			intensity = (timeToCapture - (captureSync - Time.time)) / timeToCapture;
			if (Time.time > captureSync)
			{
				ps.Play();
				captured = true;
			}
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.transform.tag == "Player" && !captured)
		{
			intensity = 0;
		}
	}
}
