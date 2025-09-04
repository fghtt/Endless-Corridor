using UnityEngine;
using TMPro;

public class InteractableObjectTitleUi : MonoBehaviour
{
    TextMeshProUGUI _textMesh;

    private bool _isActive;
    private float _passedTime;
    private float _showingTime = 0.1f;

    private void Awake()
    {
        _textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (_isActive)
        {
            _passedTime += Time.deltaTime;

            if (_passedTime > _showingTime)
                Hide();
        }
    }

    public void Show(string title)
    {
        _passedTime = 0;
        _isActive = true;
        gameObject.SetActive(true);
        _textMesh.text = title;
    }

    private void Hide()
    {
        _passedTime = 0;
        _textMesh.text = "";
        _isActive = false;
        gameObject.SetActive(false);
    }
}