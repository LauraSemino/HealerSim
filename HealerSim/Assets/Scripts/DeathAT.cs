using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

namespace NodeCanvas.Tasks.Actions {

	public class DeathAT : ActionTask {
        public NavMeshAgent nma;
		public Rigidbody rb;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
		protected override void OnExecute() {
			nma.isStopped = true;
			nma.enabled = false;
			rb.AddForce(new Vector3(Random.Range(-10,10), Random.Range(-10, 10), Random.Range(-10, 10)), ForceMode.Impulse);
			//agent.gameObject.transform.rotation = Quaternion.Euler(90, 0, 0);
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}