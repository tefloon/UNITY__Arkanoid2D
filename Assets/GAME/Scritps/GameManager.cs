using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private RectTransform menuPanel;
	[SerializeField] private RectTransform optionsPanel;

	private bool czyJestPauza = false;

	public void NewGame()
	{
		menuPanel.gameObject.SetActive(false);
		SceneManager.LoadScene("__MAIN__", LoadSceneMode.Additive);
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;

		#else
		Application.Quit();
		
		#endif
	}

	public void PokazOpcje()
	{
		menuPanel.gameObject.SetActive(false);
		optionsPanel.gameObject.SetActive(true);
	}

	public void UkryjOpcje()
	{
		menuPanel.gameObject.SetActive(true);
		optionsPanel.gameObject.SetActive(false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (czyJestPauza)
			{
				czyJestPauza = false;
				menuPanel.gameObject.SetActive(false);
				Time.timeScale = 0;
			}

			else
			{
				czyJestPauza = true;
				menuPanel.gameObject.SetActive(true);
				Time.timeScale = 1;
			}
		}
	}
}
