using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
	[SerializeField] string _nextLevelName;

	Monster[] _monsters;

    [SerializeField] public GameObject loadingScreen;

    private void Start()
    {
        StartCoroutine(wait());
    }

    void OnEnable()
	{
		_monsters = FindObjectsOfType<Monster>();	
	}

	// Update is called once per frame
	void Update()
    {
        if(MonstersAreAllDead())
		{
			StartCoroutine(wait());
			GoToNextLevel();
		}
    }

	void GoToNextLevel()
	{
		Debug.Log("Go to level" + _nextLevelName);
		SceneManager.LoadScene(_nextLevelName);
	}

	void ShowLoadingScreen()
	{
		Debug.Log("loading screen");
		loadingScreen.SetActive(false);
	}

	bool MonstersAreAllDead()
	{
		foreach(var monster in _monsters)
			if(monster.gameObject.activeSelf)
				return false;
		return true;
	}

	IEnumerator wait()
    {
		yield return new WaitForSeconds(2f);
		ShowLoadingScreen();
    }
}
