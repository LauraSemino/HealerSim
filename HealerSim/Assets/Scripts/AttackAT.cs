using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


namespace NodeCanvas.Tasks.Actions {

	public class AttackAT : ActionTask {
		public float damage;
		float atkDur;
        public float totalAtkTime;
        public NavMeshAgent nma;
        public BBParameter<GameObject> target;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
		protected override void OnExecute() {

            nma.SetDestination(agent.transform.position);
            atkDur = totalAtkTime;
            
            //EndAction(true);
        }

		
        //Called once per frame while the action is active.
        protected override void OnUpdate() {

            atkDur -= Time.deltaTime;
            if (atkDur <= 0)
            {
                target.value.GetComponent<Health>().health -= damage;
                atkDur = totalAtkTime;
                EndAction(true);
            }
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}