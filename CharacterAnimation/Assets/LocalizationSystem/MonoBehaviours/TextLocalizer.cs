using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Wokarol
{
	[RequireComponent(typeof(TMP_Text))]
	public class TextLocalizer : MonoBehaviour
	{
		[SerializeField] private string key;
		private LocalizationManager manager;

		private void Start ()
		{
			manager = LocalizationManager.Instance;
			LocalizationManager.OnLanguageChange += Set;
			Set();
		}

		void Set ()
		{
			GetComponent<TMP_Text>().text = manager.GetText(key);
		}
	}
}

