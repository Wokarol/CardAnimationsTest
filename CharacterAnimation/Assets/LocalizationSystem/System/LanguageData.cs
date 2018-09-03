using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol
{
	[System.Serializable]
	public class LocalizationData
	{
		public List<LocalizationEntity> localizationEntities;
	}

	[System.Serializable]
	public class LocalizationEntity
	{
		public string key;
		public string value;
	}
}

