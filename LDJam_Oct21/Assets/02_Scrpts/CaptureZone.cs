using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureZone : MonoBehaviour
{
	public ElementManager.ElementTypes myType;
	public float timeToCapture = 5;
	
	public bool captured = false;
	public GameObject enemyObj;
	public List<Transform> spawnLocations;
	public float burstDelay = 5, burstCapacity = 3, burstRange = 1, burstSync;

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
		if (other.transform.tag == "Player" && !captured)
		{
			captureSync = Time.time + timeToCapture;
			burstSync = Time.time + burstDelay;
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.transform.tag == "Player" && !captured)
		{
			intensity = (timeToCapture - (captureSync - Time.time)) / timeToCapture;
			if (Time.time > captureSync)
			{
				LevelComplete();
			}
			if (Time.time > burstSync)
			{
				burstSync = Time.time + burstDelay;
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

	public void LevelComplete()
	{
		ps.Play();
		captured = true;
		switch(myType)
		{
			case ElementManager.ElementTypes.Water:
				GameManager.Instance.completedWater = true;
				break;
			case ElementManager.ElementTypes.Nature:
				GameManager.Instance.completedNature = true;
				break;
			case ElementManager.ElementTypes.Fire:
				GameManager.Instance.completedFire = true;
				break;
			case ElementManager.ElementTypes.Earth:
				GameManager.Instance.completedEarth = true;
				break;
			case ElementManager.ElementTypes.Metal:
				GameManager.Instance.completedMetal = true;
				break;
		}
		Invoke("LoadMainScene", 3.0f);
	}

	void LoadMainScene()
	{
		GameManager.Instance.LoadSpecifiedScene(0);
	}
	
	void TriggerDefenders()
	{
		for (int iter = 0; iter < burstCapacity + Random.Range(-burstRange, burstRange); iter++)
		{
			Transform newPosition = spawnLocations[Random.Range(0, spawnLocations.Capacity)];
			Instantiate(enemyObj, newPosition.position, transform.rotation);
		}
	}
}
