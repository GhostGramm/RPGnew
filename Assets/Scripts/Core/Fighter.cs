using System.Collections;
using UnityEngine;

namespace RPG.Core
{
    public class Fighter : MonoBehaviour
    {
        public void Attack(CombatTarget target)
        {
            Debug.Log($"Attacking the target {target}");
        }
    }
}