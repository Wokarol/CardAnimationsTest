using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Wokarol
{
	public class CardController : MonoBehaviour
	{
		// Variables
		[SerializeField] TMP_Text desc;
		[SerializeField] TMP_Text title;
		[SerializeField] SpriteRenderer sprite;

		// Functions
		public void SetCard (CardData data)
		{
			desc.text = data.Description;
			title.text = data.Title;
			sprite.sprite = data.Sprite;
		}
	}
}

