using UnityEngine;

namespace NoSurrender
{
    public class WeakPoint : MonoBehaviour
    {
        [SerializeField] private PlayerBase _player;

        public void AddForce(Vector3 dir, ForceType forceType)
		{
            _player.AddForce(dir, forceType);
		}
    }
}
