using Friflo.Engine.ECS;
using Friflo.Engine.ECS.Systems;

namespace ECS.Input {
	public class ButtonSystem : QuerySystem<Action> {
		public ButtonSystem() => Filter.AnyTags(Tags.Get<Button>());

		protected override void OnUpdate() {
			foreach (var entity in Query.Entities)
				entity.GetComponent<Action>().Value.BindButtonAction(entity);
		}
	}
}