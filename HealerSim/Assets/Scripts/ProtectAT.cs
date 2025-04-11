using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ProtectAT : ActionTask {
        public BBParameter<GameObject> target;
		public BBParameter<GameObject> ally;
        public float steerAccel;
        public BBParameter<Vector3> charAccel;
        public float atkRange;
        public float protectRange;
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
            float distanceToAlly;
            if (ally != null)
            {
                distanceToAlly = Vector3.Distance(agent.transform.position, ally.value.gameObject.transform.position);
            }
            else
            {
                distanceToAlly = Vector3.Distance(agent.transform.position, agent.transform.position);
            }

            if (ally.value.tag == "Healer" && target.value.tag == "Ranger")
            {
                protectRange = 50f;
            }
           

            //Debug.Log(distanceToAlly);
            // Debug.Log(distanceToTarget);
            Vector3 direction;
            if (distanceToTarget < atkRange)
              {
                  EndAction(true);
                  return;
              }
            if (distanceToAlly > protectRange)
            {
                direction = (ally.value.transform.position - agent.transform.position);
            }
            else
            {
                direction = (target.value.transform.position - agent.transform.position);

            }
            direction = new Vector3(direction.x, 0, direction.z);
            charAccel.value += direction.normalized * steerAccel * Time.deltaTime;
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