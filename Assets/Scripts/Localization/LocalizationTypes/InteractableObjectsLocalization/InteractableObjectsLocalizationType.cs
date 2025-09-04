public class InteractableObjectsLocalizationType : LocalizationType
{
    public override void InitLocalization(Localization localization)
    {
        _localizationData = localization.InteractableObjects;
    }
}