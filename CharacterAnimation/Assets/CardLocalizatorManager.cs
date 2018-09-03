using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class CardLocalizatorManager : MonoBehaviour
	{
		[SerializeField] CardList list;

		private void Awake ()
		{
			LocalizeAll();
			LocalizationManager.OnLanguageChange += LocalizeAll;
		}

		[ContextMenu("Localize for current setting")]
		public void LocalizeAll ()
		{
			foreach (var card in list.cards) {
				card.LocalizeText();
			}
		}
	}
}

