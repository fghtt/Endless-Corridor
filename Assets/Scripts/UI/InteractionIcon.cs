using UnityEngine;

public class InteractionIcon : MonoBehaviour
{
    private bool _isActive;
    private float _passedTime;
    private float _showingTime = 0.1f;

    private void Update()
    {
        if (_isActive)
        {
            _passedTime += Time.deltaTime;

            if (_passedTime > _showingTime)
                Hide();
        }
    }

    public void Show()
    {
        _passedTime = 0;
        gameObject.SetActive(true);
        _isActive = true;
    }

    private void Hide()
    {
        _passedTime = 0;
        gameObject.SetActive(false);
        _isActive = false;
    }
}