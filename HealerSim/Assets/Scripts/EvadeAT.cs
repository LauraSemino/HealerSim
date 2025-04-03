using NodeCanvas.Framework;
using ParadoxNotion.Design;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.TextCore.Text;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class EvadeAT : ActionTask {
        public BBParameter<GameObject> target;
        public float steerAccel;
        public BBParameter<Vector3> charAccel;
        public float atkRange;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
		protected override void OnExecute() {
            float distanceToTarget = Vector3.Distance(agent.transform.position, target.value.gameObject.transform.position);
            if (distanceToTarget < atkRange)
            {
                EndAction(true);
                return;
            }
            Vector3 direction = target.value.transform.position - agent.transform.position;
            direction = new Vector3(direction.x, 0, direction.z);        
            charAccel.value += direction.normalized * steerAccel * Time.deltaTime;

            //nma.SetDestination(target.value.transform.position);

            //EndAction(true);
            EndAction(true);
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