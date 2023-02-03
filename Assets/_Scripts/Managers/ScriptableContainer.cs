
namespace NoSurrender
{
    public class ScriptableContainer : Singleton<ScriptableContainer>
    {
        public CollectableSC collectableSC;
        public EnemySC enemySC;

		private void Awake()
		{
			Init();
		}
	}
}
