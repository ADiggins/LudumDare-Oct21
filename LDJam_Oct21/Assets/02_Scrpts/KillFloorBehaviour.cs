using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillFloorBehaviour : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Player")
			GameManager.Instance.RestartCurrentScene();
	}
}
