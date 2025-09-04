public class InscriptionLocalizationType : LocalizationType
{
    public override void InitLocalization(Localization localization)
    {
        _localizationData = localization.Inscriptions;
    }
}