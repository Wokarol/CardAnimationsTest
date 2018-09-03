using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class LanguageSetter : MonoBehaviour
	{
		// Variables
		private const string prefsKey = "User_language_code";

		[SerializeField] private string languageCode;
		// Functions
		public void SetLanguage ()
		{
			LocalizationManager.Instance.ChangeLanguage(languageCode);
		}
	}
}

