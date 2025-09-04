using UnityEngine;
using System.Collections;
using UnityEngine.Experimental.GlobalIllumination;

public class AfterKillingEffect : MonoBehaviour
{
	[SerializeField]
	private ParticleSystem _particleSystem;

	[SerializeField]
	private Light _light;

	[SerializeField]
	private float _lightFading;

	void Start()
	{
		Show();
	}

	public void Show()
	{
		_particleSystem.Play();
		StartCoroutine(ChangeLightIntensity(0, _lightFading));
	}

    private IEnumerator ChangeLightIntensity(float target, float duration)
    {
        float startIntensity = _light.intensity; 
        float elapsedTime = 0f; 

        while (elapsedTime < duration)
        {
            _light.intensity = Mathf.Lerp(startIntensity, target, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _light.intensity = target;
		Destroy(gameObject);
    }
}