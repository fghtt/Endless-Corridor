using UnityEngine;

public class Language
{
    private Localization _localization;

    public Language()
    {
        ChangeLanguage("en");
    }

    public void ChangeLanguage(string language)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Localization");

        if (jsonFile != null)
        {
            string json = jsonFile.text;

            LanguageData languageData
                = JsonUtility.FromJson<LanguageData>(json);
          
            switch (language)
            {
                case "ru":
                    _localization
                    = languageData.RU;
                    break;
                case "en":
                    _localization
                        = languageData.EN;
                    break;
            }
        }
    }

    public LocalizationData GetInscription<T>(int id) where T
        : LocalizationType, new ()
    {
        T localizationType = new T();
        localizationType.InitLocalization(_localization);
        return localizationType.GetInscription(id);
    }

    public int GetInscriptionsCount<T>() where T
        : LocalizationType, new()
    {
        T localizationType = new T();
        localizationType.InitLocalization(_localization);
        return localizationType.LocalizationDataCount;
    }

    /*  public static void SetCurrentLanguage(string language)
      {
          _currentLanguage = language;

          TextAsset jsonFile = Resources.Load<TextAsset>("Inscriptions");

          if (jsonFile != null)
          {
              string json = jsonFile.text;

              LanguageData languageData
                  = JsonUtility.FromJson<LanguageData>(json);
              InscriptionData[] inscriptionData;

              switch (language)
              {
                  case "ru":
                      _inscriptionsData
                      = languageData.RU;
                      break;
                  case "en":
                      _inscriptionsData
                          = languageData.EN;
                      break;
              }
          }
          else
          {
              Debug.LogError("Файл не найден в Resources: " + "Inscriptions.json");
          }
      } */

        // public string GetInscription(int id)
        // {
        /*   foreach (InterfaceLocalizationData inscriptionData in _inscriptionsData)
           {
               if (inscriptionData.Id == id)
                   return inscriptionData.Content;
           }

           return null;*/
        // }
}