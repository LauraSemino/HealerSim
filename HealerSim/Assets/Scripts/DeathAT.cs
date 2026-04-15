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
            //agent.GetComponent<Collider>().enabled = false;
            if (nma.gameObject.tag == "Tank")
            {
                FMODUnity.RuntimeManager.PlayOneShot("{ 599f3e81 - 1807 - 4225 - 8d63 - 2517f11960c5}", nma.gameObject.transform.position);
            }
            else if (nma.gameObject.tag == "Melee")
            {
                FMODUnity.RuntimeManager.PlayOneShot("{af1625d1-4a56-486c-928f-98f6ed27024f}", nma.gameObject.transform.position);
            }
            else if (nma.gameObject.tag == "Ranger")
            {
                FMODUnity.RuntimeManager.PlayOneShot("{b5440849-3dd6-4946-b026-52143b436c80}", nma.gameObject.transform.position);
            }
            rb.constraints = RigidbodyConstraints.None;
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