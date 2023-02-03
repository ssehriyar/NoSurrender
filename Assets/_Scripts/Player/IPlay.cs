using System.Collections;
using UnityEngine;

namespace NoSurrender
{
    public interface IPlay
    {
        void AddScore(int scoreAmount);
        void AddForce(Vector3 dir, ForceType forceType);
        void AddSpeed(float speedAmount, float duration);
    }
}
