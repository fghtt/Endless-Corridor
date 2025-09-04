using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RedScreenEffect : MonoBehaviour
{
    [SerializeField]
    private float _duration;

    private float _opacity;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();    
    }

    public void Show()
    {
        StartCoroutine("ShowScreen");
    }

    private IEnumerator ShowScreen()
    {
        Color color = _image.color;

        while (_opacity < 0.1)
        {
            _opacity += 0.01f;
            color.a = _opacity;
            _image.color = color;

            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine("Hide");
    }

    private IEnumerator Hide()
    {
        Color color = _image.color;
        float elapsedTime = 0f;

        while (elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / _duration);

            float opacity = Mathf.Lerp(1f, 0f, Mathf.Pow(t, 3));
            color.a = opacity;
            _image.color = color;

            yield return null;
        }

        color.a = 0f;
        _image.color = color;
    }
}