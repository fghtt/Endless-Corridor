using CrazyGames;
using UnityEngine;

public class CrazyGamesAdvertisement : AdvertisementService
{
    public override void ShowAdvertWhileCreatingLevel
        (CreatingLevelWindow creatingLevelWindow)
    {
        CrazySDK.Ad.RequestAd(CrazyAdType.Midgame, () =>
        {
           
        },
        (error) =>
        {
            creatingLevelWindow.Hide();
        },
        () =>
        {
            creatingLevelWindow.Hide();
        });
    }

    public override void ShowMidgameAdvert(AudioSource audioSource)
    {
        CrazySDK.Ad.RequestAd(CrazyAdType.Midgame, () =>
        {
            audioSource.enabled = false;
        },
        (error) =>
        {
            audioSource.enabled = true;
        },
        () =>
        {
            audioSource.enabled = true;
        });
    }
}