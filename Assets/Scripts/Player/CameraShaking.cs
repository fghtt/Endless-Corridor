using UnityEngine;
using System.Collections;

public class CameraShaking : MonoBehaviour
{
    private float _x;
    private float _y;

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            _x += Random.Range(-0.5f, 0.5f) * magnitude;
            _y += Random.Range(-0.5f, 0.5f) * magnitude;

            float y = originalPosition.y + _y;

            transform.localPosition = new Vector3(_x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        _x = 0;
        _y = 0;
        transform.localPosition = originalPosition;
    }

    public void TriggerShake(float duration, float magnitude)
    {
        StartCoroutine(Shake(duration, magnitude));
    }
}