using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.Managers
{
    public class ActionScheduler : MonoBehaviour
    {
        public MonoBehaviour currentAction = null;
        public void StartAction(MonoBehaviour action)
        {
            if (action == currentAction) return;

            if(action != null)
            {
                Debug.Log("Starting action" + action);
            }
            
            currentAction = action;
        }
    }
}