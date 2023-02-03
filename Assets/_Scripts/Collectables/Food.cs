using UnityEngine;

namespace NoSurrender
{
	public class Food : MonoBehaviour, ICollectable
	{
		[SerializeField] private int _score;

		public void Collect(IPlay play)
		{
			play.AddScore(_score);
			CollactableManager.Instance.DestroyCollectable(transform.parent.gameObject);
		}
	}
}
