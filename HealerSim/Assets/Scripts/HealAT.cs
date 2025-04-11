using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class HealAT : ActionTask {

		public BBParameter<float> totalultCharge;
		//public float ultPerHeal;

		public float healVal;
		public BBParameter<GameObject> target;
		public BBParameter<float> bonusHeal;
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
				if(target.value.GetComponent<Health>().health < target.value.GetComponent<Health>().maxHealth)
				{

                    target.value.GetComponent<Health>().health += healVal * bonusHeal.value;
                    cooldown.value = fireRate;
                    totalultCharge.value += healVal * bonusHeal.value * 1.05f;
                }
                
               
            }
            if (target.value.GetComponent<HealerHealth>() != null && cooldown.value <= 0)

            {
				if (target.value.GetComponent<HealerHealth>().health < target.value.GetComponent<HealerHealth>().maxHealth)
				{
					target.value.GetComponent<HealerHealth>().health += healVal / 2 * bonusHeal.value;
					cooldown.value = fireRate;
				}

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