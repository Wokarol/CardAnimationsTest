using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Wokarol
{
	public class LocalizationManager
	{
		#region Singleton
		public static LocalizationManager Instance {
			get {
				if (instance != null) {
					return instance;
				} else {
					return instance = new LocalizationManager();
				}
			}
		}
		private static LocalizationManager instance;
		#endregion

		private const string prefsKey = "User_language_code";
		private const string preFileName = "Language_";
		private const string postFileName = ".txt";

		Dictionary<string, string> languageEntities;
		public static System.Action OnLanguageChange;
		string currentLanguageCode;

		public LocalizationManager ()
		{
			if (!PlayerPrefs.HasKey(prefsKey)) {
				PlayerPrefs.SetString(prefsKey, System.Globalization.CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
			}
			currentLanguageCode = PlayerPrefs.GetString(prefsKey);
			UpdateLanguageData();
		}

		public void ChangeLanguage (string TwoLettersISOCOde)
		{
			Debug.Log($"Changed language to {TwoLettersISOCOde}");
			PlayerPrefs.SetString(prefsKey, TwoLettersISOCOde);
			currentLanguageCode = TwoLettersISOCOde;
			UpdateLanguageData();
			OnLanguageChange?.Invoke();
		}

		public string GetText (string key)
		{
			string value = "Error: invalid value"; // Default incorect text
			if (languageEntities != null && languageEntities.ContainsKey(key)) {
				value = languageEntities[key];
			}
			return value;
		}


		void UpdateLanguageData ()
		{
			languageEntities = GetDataFromFile(GetPath());
		}

		string GetPath ()
		{
			string path = Path.Combine(Application.streamingAssetsPath, $"{preFileName}{currentLanguageCode}{postFileName}");
			if (!File.Exists(path)) {
				Debug.LogWarning($"Can't find desired language file, trying to find default english file [Tryied <b>{path}</b>]");
				path = Path.Combine(Application.streamingAssetsPath, $"{preFileName}en{postFileName}");
				if (!File.Exists(path)) {
					throw new System.Exception($"Can't find language file [Tryied <b>{path}</b>]");
				}
			}

			return path;
		}

		//Dictionary<string, string> GetDataFromFile (string path)
		//{
		//	LocalizationData localizationData = JsonUtility.FromJson<LocalizationData>(File.ReadAllText(path));
		//	var dictionary = new Dictionary<string, string>();

		//	Debug.Log($"File {path} has {localizationData.localizationEntities.Count} entities");
		//	for (int i = 0; i < localizationData.localizationEntities.Count; i++) {
		//		dictionary.Add(localizationData.localizationEntities[i].key, localizationData.localizationEntities[i].value);
		//	}

		//	return dictionary;
		//}

		Dictionary<string, string> GetDataFromFile (string path)
		{
			var dictionary = new Dictionary<string, string>();

			string[] lines = File.ReadAllLines(path);
			for (int i = 0; i < lines.Length; i++) {
				var line = lines[i];
				int indexOfTwoDots = line.IndexOf(':');

				if (indexOfTwoDots != -1) {
					string key = line.Substring(0, indexOfTwoDots).Trim();
					string value = line.Substring(indexOfTwoDots + 1).Trim();
					dictionary.Add(key, value);
				}
			}

			return dictionary;
		}
	}
}

