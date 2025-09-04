[System.Serializable]
public class Localization
{
    public InterfaceLocalizationData[] Interface;
    public InscriptionLocalizationData[] Inscriptions;
    public ReplicasLocalizationData[] Replicas;
    public InteractableObjectsLocalizationData[] InteractableObjects;
}

[System.Serializable]
public class LanguageData
{  
    public Localization RU;
    public Localization EN;
}