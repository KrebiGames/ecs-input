using Friflo.Engine.ECS;
using Friflo.Engine.Unity;
using FrifloECS.Unity.EntityVisualize;
using UnityEngine;

namespace ECS.Input {
	[RequireComponent(typeof(ECSStore))]
	public class Input : MonoBehaviour {
		public static EntityStore Store;

		void Awake() => Store = GetComponent<ECSStore>().EntityStore;

#if UNITY_EDITOR
        [SerializeField] bool visualize = true;

        private void Start() {
            EntityVisualizer.Register(name, Store);
        }
#endif
    }
}