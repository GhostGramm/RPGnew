using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;
using System;

namespace RPG.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        public bool isAttacking = false;
        void Update()
        {
            if (GetTargetToAttack())    return;
            if (MovementInteraction()) return;
        }

        bool MovementInteraction()
        {
            RaycastHit hit;
            bool isValid = Physics.Raycast(GetScreenPointRay(), out hit);

            if (isValid)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMovementAction(hit.point);
                }

                return true;
            }

            return false;
        }


        bool GetTargetToAttack()
        {
            RaycastHit[] hits = Physics.RaycastAll(GetScreenPointRay());
            foreach (RaycastHit hit in hits)
            {
                CombatTarget target = hit.transform.GetComponent<CombatTarget>();
                if (target != null)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        PerformAttack(target);
                    }

                    return true;
                }
            }
            return false;
        }

        void PerformAttack(CombatTarget target)
        {
            isAttacking = true;
            GetComponent<Fighter>().Attack(target);
        }

        public Ray GetScreenPointRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}

