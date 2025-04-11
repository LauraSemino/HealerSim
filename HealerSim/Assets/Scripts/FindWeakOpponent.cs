using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions
{

    public class FindWeakOpponentCT : ConditionTask
    {

        public BBParameter<GameObject> target;

        public float radius;
        public LayerMask opponent;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            return null;
        }

        //Called whenever the condition gets enabled.
        protected override void OnEnable()
        {

        }

        //Called whenever the condition gets disabled.
        protected override void OnDisable()
        {

        }

        //Called once per frame while the condition is active.
        //Return whether the condition is success or failure.
        protected override bool OnCheck()
        {
            Collider[] enemies = Physics.OverlapSphere(agent.transform.position, radius, opponent);
            if (enemies != null)
            {
                //float closest = Mathf.Infinity;
                float squishiest = Mathf.Infinity;
                GameObject bestTarget = null;

                foreach (Collider enemy in enemies)
                {

                    //Debug.Log(i);
                    if (enemy.GetComponent<HealerHealth>() != null )
                    {
                        if(enemy.GetComponent<HealerHealth>().maxHealth < squishiest)
                        {
                            if (enemy.gameObject != agent.gameObject)
                            {
                                squishiest = (agent.transform.position - enemy.transform.position).magnitude;
                                bestTarget = enemy.gameObject;
                            }
                        }
                        
                    }
                    if (enemy.GetComponent<Health>() != null)
                    {
                        if (enemy.GetComponent<Health>().maxHealth < squishiest)
                        {
                            if (enemy.gameObject != agent.gameObject)
                            {
                                squishiest = (agent.transform.position - enemy.transform.position).magnitude;
                                bestTarget = enemy.gameObject;
                            }
                        }
                    }

                }



                if (bestTarget != null)
                {
                    target.value = bestTarget;
                    return true;
                }
            }
            else
            {
                target.value = agent.gameObject;
            }





            return false;


            //Collider[] collision.add);


        }
    }
}