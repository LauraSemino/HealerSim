using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;

//using System.Numerics;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	
	public class MoveAT : ActionTask {
        public BBParameter<GameObject> target;
		public NavMeshAgent nma;
		public BBParameter<Vector3> charAccel;
		public BBParameter<Vector3> velocity;
        public BBParameter<float> atkDur;


        public float maxSpeed;
		//public float steerAccel;
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
			

			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if(atkDur.value > 0)
			{
                atkDur.value -= Time.deltaTime;
            }

            velocity.value += charAccel.value;
			float groundSpeed = Mathf.Sqrt(velocity.value.x * velocity.value.x + velocity.value.z * velocity.value.z);
			if(maxSpeed < groundSpeed)
			{
				float cappedX = velocity.value.x / groundSpeed * maxSpeed;
				float cappedZ = velocity.value.z / groundSpeed * maxSpeed;
				velocity.value = new Vector3(cappedX, velocity.value.y, cappedZ);
			}
			agent.transform.position += velocity.value * Time.deltaTime;
			charAccel.value = Vector3.zero;
			EndAction(true);
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}