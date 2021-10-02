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

	public enum EnemyTypes { Fire, Earth, Metal, Water, Nature };
	public Material FireMat, EarthMat, MetalMat, WaterMat, NatureMat;

	public Material GetMaterialForType(EnemyTypes thisType)
	{
		switch (thisType)
		{
			case EnemyTypes.Fire:
				return FireMat;
			case EnemyTypes.Earth:
				return EarthMat;
			case EnemyTypes.Metal:
				return MetalMat;
			case EnemyTypes.Water:
				return WaterMat;
			case EnemyTypes.Nature:
				return NatureMat;
		}
		return null;
	}
}
