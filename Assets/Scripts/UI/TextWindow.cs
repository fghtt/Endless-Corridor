using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using Zenject;

public class TextWindow : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private List<GameObject> _hidingUI;

    private Language _language;

    private Label _title;
    private Label _content;
    private Button _closeButton;

    [Inject]
    private void Construct(Language language)
    {
        _language = language;
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _title = root.Q<Label>("Title");
        _content = root.Q<Label>("Content");
        _closeButton = root.Q<Button>("CloseButton");
        _closeButton.clicked += () => Close();
        InterfaceLocalizationData buttonText
             = (InterfaceLocalizationData)_language
                 .GetInscription<InterfaceLocalizationType>(1);

         _closeButton.text = buttonText.Content;
    }

    private void HideUI()
    {
        foreach (GameObject ui in _hidingUI)
            ui.SetActive(false);
    }

    private void ShowUI()
    {
        foreach (GameObject ui in _hidingUI)
            ui.SetActive(true);
    }

    public void Show(int id)
    {
        gameObject.SetActive(true);
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;
        HideUI();

        InscriptionLocalizationData inscription =
         (InscriptionLocalizationData)_language
         .GetInscription<InscriptionLocalizationType>(id);
        _title.text = inscription.Title;
        _content.text = inscription.Content;

        _playerController.StopControlling();
    }

    private void Close()
    {
        _playerController.ContinueControlling();
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        ShowUI();
        gameObject.SetActive(false);
    }
}