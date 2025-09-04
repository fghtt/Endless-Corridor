using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Zenject;

public class SettingsWindow : MonoBehaviour
{
    [SerializeField] private List<GameObject> _showingUi;
    [SerializeField] private GameObject _settingsWindow;

    private Button _closeWindowButton;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _closeWindowButton = root.Q<Button>("close-window-button");
        _closeWindowButton.clicked += () => Close();
    }

    private void Close()
    {
        foreach (GameObject ui in _showingUi)
            ui.SetActive(true);

        gameObject.SetActive(false);
    }
}