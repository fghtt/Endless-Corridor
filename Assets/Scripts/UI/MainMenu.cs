using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Zenject;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private int _gameScene;
    [SerializeField] private List<GameObject> _hidingUI;
    [SerializeField] private GameObject _settingsWindow;

    private Button _startGameButton;
    private Button _settingsButton;

    private Language _language;

    [Inject]
    private void Construct(Language language)
    {
        _language = language;
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _startGameButton = root.Q<Button>("StartGameButton");
        _settingsButton = root.Q<Button>("SettingsButton");

        _startGameButton.clicked += () => StartGame();
        _settingsButton.clicked += () => OpenSettings();
        InterfaceLocalizationData startButtonText
             = (InterfaceLocalizationData)_language
                 .GetInscription<InterfaceLocalizationType>(5);
        InterfaceLocalizationData settingsButtonText
             = (InterfaceLocalizationData)_language
                 .GetInscription<InterfaceLocalizationType>(6);

        _startGameButton.text = startButtonText.Content;
        _settingsButton.text = settingsButtonText.Content;
    }

    private void StartGame()
    {
        Debug.Log("Click");
        SceneManager.LoadScene(_gameScene);
    }

    private void OpenSettings()
    {
        foreach (GameObject ui in _hidingUI)
            ui.SetActive(false);

        _settingsWindow.SetActive(true);
    }
}