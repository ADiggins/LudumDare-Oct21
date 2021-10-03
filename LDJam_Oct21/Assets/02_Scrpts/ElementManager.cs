using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementManager : MonoBehaviour
{
	public static ElementManager Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public enum ElementTypes { Fire, Earth, Metal, Water, Nature };
	public Material FireMat, EarthMat, MetalMat, WaterMat, NatureMat;

	public Material GetMaterialForType(ElementTypes thisType)
	{
		switch (thisType)
		{
			case ElementTypes.Fire:
				return FireMat;
			case ElementTypes.Earth:
				return EarthMat;
			case ElementTypes.Metal:
				return MetalMat;
			case ElementTypes.Water:
				return WaterMat;
			case ElementTypes.Nature:
				return NatureMat;
		}
		return null;
	}
}
