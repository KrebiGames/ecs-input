using Friflo.Engine.ECS;
using Friflo.Engine.Unity;
using UnityEngine;

namespace ECS.Input {
	[RequireComponent(typeof(ECSStore))]
	public class Input : MonoBehaviour {
		public static EntityStore Store;

		void Awake() => Store = GetComponent<ECSStore>().EntityStore;
	}
}