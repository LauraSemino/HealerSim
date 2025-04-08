using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class HealAT : ActionTask {

		public float healVal;
		public BBParameter<GameObject> target;
       
        Camera cam;
		public float fireRate;
		public BBParameter<float> cooldown;
        //public LayerMask opponent;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
           
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		 
			if(target.value.GetComponent<Health>() != null && cooldown.value <= 0)
			{
                
                target.value.GetComponent<Health>().health += healVal;
				cooldown.value = fireRate;
            }
            if (target.value.GetComponent<HealerHealth>() != null && cooldown.value <= 0)

            {
                target.value.GetComponent<HealerHealth>().health += healVal/2;
                cooldown.value = fireRate;
            }


            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
            
            // Debug.Log("Mouse Pressed");

        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}