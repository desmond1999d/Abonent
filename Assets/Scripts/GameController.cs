using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static GameController Instance = null;

	[SerializeField] private Canvas mainCanvas;
	public Canvas MainCanvas
	{
		get { return mainCanvas; }
	}

	[SerializeField] private Camera mainCamera;
	public Camera MainCamera
	{
		get { return mainCamera; }
	}

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}

}
