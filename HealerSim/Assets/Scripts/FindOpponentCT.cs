using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class FindOpponentCT : ConditionTask {

		public BBParameter<GameObject> target;
		
		public float radius;
		public LayerMask opponent;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck()
		{
			Collider[] enemies = Physics.OverlapSphere(agent.transform.position, radius, opponent);
			float closest = Mathf.Infinity;
			GameObject bestTarget = null;
			
                foreach (Collider enemy in enemies)
                {
					//Debug.Log(i);
                    if ((agent.transform.position - enemy.transform.position).magnitude < closest)
                    {
                        
						if (enemy.gameObject != agent.gameObject)
						{
							closest = (agent.transform.position - enemy.transform.position).magnitude;
							bestTarget = enemy.gameObject;
						}
                        
                        //return true;

                    }

                }
			if (bestTarget != null )
			{
                target.value = bestTarget;
                return true;
            }
				

            
			
			return false;
			

			//Collider[] collision.add);

			
		}
	}
}