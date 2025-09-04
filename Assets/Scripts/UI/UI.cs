using UnityEngine;
using System.Collections.Generic;

public class UI : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _uiElements;

	public void ShowUI()
	{
		foreach(GameObject uiElement in _uiElements)
		{
			uiElement.SetActive(true);
		}
	}

    public void HideUI()
    {
        foreach (GameObject uiElement in _uiElements)
        {
            uiElement.SetActive(false);
        }
    }
}