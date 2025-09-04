using UnityEngine;

public abstract class AdvertisementService
{
	public abstract void ShowMidgameAdvert(AudioSource _audioSource);
	public abstract void ShowAdvertWhileCreatingLevel(CreatingLevelWindow
		creatingLevelWindow);
}