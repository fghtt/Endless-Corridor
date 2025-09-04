public class ReplicasLocalizationType : LocalizationType
{
    public override void InitLocalization(Localization localization)
    {
        _localizationData = localization.Replicas;
    }
}