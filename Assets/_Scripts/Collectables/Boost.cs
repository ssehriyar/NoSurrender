using System;
using UnityEngine;

namespace NoSurrender
{
	public class Boost : MonoBehaviour, ICollectable
	{
		[SerializeField] private float _speed;
		[SerializeField] private float _duration;

		public void Collect(IPlay player)
		{
			player.AddSpeed(_speed, _duration);
			CollactableManager.Instance.DestroyCollectable(transform.parent.gameObject);
		}
	}
}
