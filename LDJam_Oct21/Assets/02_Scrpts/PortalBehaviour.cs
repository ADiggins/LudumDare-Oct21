using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalBehaviour : MonoBehaviour
{
	public ElementManager.ElementTypes myType;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.transform.tag == "Player")
		{
			switch (myType)
			{
				case ElementManager.ElementTypes.Fire:
					if (!GameManager.Instance.completedFire)
						GameManager.Instance.LoadSpecifiedScene(1);
					break;
				case ElementManager.ElementTypes.Earth:
					break;
				case ElementManager.ElementTypes.Metal:
					break;
				case ElementManager.ElementTypes.Water:
					if (!GameManager.Instance.completedWater)
						GameManager.Instance.LoadSpecifiedScene(2);
					break;
				case ElementManager.ElementTypes.Nature:
					if (!GameManager.Instance.completedNature)
						GameManager.Instance.LoadSpecifiedScene(3);
					break;
			}
		}
	}
}
