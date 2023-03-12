using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace RPG.Managers
{
    public class ActionScheduler : MonoBehaviour
    {
        public iAction currentAction = null;
        public void StartAction(iAction action)
        {
            if (action == currentAction) return;

            if(currentAction != null)
            {
                Debug.Log("canceling action" + currentAction);
                currentAction.Cancel();
            }
            
            currentAction = action;
        }
    }
}