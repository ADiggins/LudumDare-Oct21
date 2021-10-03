using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance { get; private set;}

	public bool completedWater, completedNature, completedFire, completedEarth, completedMetal;

	private void Awake()
	{ 
		DontDestroyOnLoad(this);
		if (Instance == null)
			Instance = this;
		else
			Destroy(this.gameObject);
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	public void RestartCurrentScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void LoadSpecifiedScene(int index)
	{
		SceneManager.LoadScene(index);
	}
}
