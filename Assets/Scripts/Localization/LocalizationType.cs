public abstract class LocalizationType
{
    protected LocalizationData[] _localizationData;
    public int LocalizationDataCount => _localizationData.Length;

    public abstract void InitLocalization(Localization localization);

    public LocalizationData GetInscription(int id)
    {
        foreach (LocalizationData data in _localizationData)
        {
            if (data.Id == id)
                return data;
        }

        return null;
    }
}