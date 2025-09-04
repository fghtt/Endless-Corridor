using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayButton : MonoBehaviour
{
	[SerializeField] private int _gameSceneNumber;

	public void LoadGameScene()
	{
		SceneManager.LoadScene(_gameSceneNumber);
	}
}