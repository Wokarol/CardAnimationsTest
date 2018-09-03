using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	public class CardSwapper : MonoBehaviour
	{
		// Variables
		[SerializeField] CardController leftCard;
		[SerializeField] CardController centreCard;
		[SerializeField] CardController rightCard;
		[SerializeField] CardController newCard;
		[Space]
		[SerializeField] CardList list;
		[SerializeField] int index = 2;

		bool canSwap = true;

		Animator animator;
		private void Start ()
		{
			animator = GetComponent<Animator>();
			UpdateCards();
			LocalizationManager.OnLanguageChange += UpdateCards;
		}

		private void Update ()
		{
			if (Input.GetKeyDown(KeyCode.Space)) {
				StartAnimation();
			}
		}

		[ContextMenu("UpdateCards")]
		void UpdateCards ()
		{
			leftCard.SetCard(list.cards[RelativeIndex(-1)]);
			centreCard.SetCard(list.cards[RelativeIndex(0)]);
			rightCard.SetCard(list.cards[RelativeIndex(1)]);
			newCard.SetCard(list.cards[RelativeIndex(2)]);
		}

		public void StartAnimation ()
		{
			canSwap = false;
			animator.SetTrigger("Swap");
		}

		public void AnimationEnded ()
		{
			index++;
			if(index >= list.cards.Length) {
				index = 0;
			}
			UpdateCards();
			canSwap = true;
		}

		int RelativeIndex(int offset)
		{
			int relativeIndex = index;
			relativeIndex += offset;
			if(relativeIndex < 0) {
				relativeIndex = list.cards.Length + relativeIndex;
			} else {
				relativeIndex = relativeIndex % list.cards.Length;
			}

			return relativeIndex;
		}

		private void OnValidate ()
		{
			UpdateCards();
		}
	}
}

