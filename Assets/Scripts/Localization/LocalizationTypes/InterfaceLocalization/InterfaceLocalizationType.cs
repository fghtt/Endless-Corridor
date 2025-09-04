public class InterfaceLocalizationType : LocalizationType
{
    public override void InitLocalization(Localization localization)
    {
        _localizationData = localization.Interface;
    }
}