using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[CreateAssetMenu()]
	public class CardData : ScriptableObject
	{
		[Header("Localization")]
		[SerializeField] private string titleKey;
		[SerializeField] private string descriptionKey;

		[Header("Debug")]
		[SerializeField] private string title;
		public string Title {
			get {
				return title;
			}

			private set {
				title = value;
			}
		}

		[SerializeField] private string description;
		public string Description {
			get {
				return description;
			}

			private set {
				description = value;
			}
		}

		[Header("Card Settings")]
		[SerializeField] private Sprite sprite;
		public Sprite Sprite {
			get {
				return sprite;
			}

			private set {
				sprite = value;
			}
		}

		public void LocalizeText ()
		{
			var manager = LocalizationManager.Instance;
			title = manager.GetText(titleKey);
			description = manager.GetText(descriptionKey);
		}
	}
}

