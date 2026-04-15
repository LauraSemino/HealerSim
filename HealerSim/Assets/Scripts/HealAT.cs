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
					if(target.value.GetComponent<Health>().health > 0)
					{
                        target.value.GetComponent<Health>().health += healVal * bonusHeal.value;
                        cooldown.value = fireRate;
						if(healVal == 0.35f)
						{
                            FMODUnity.RuntimeManager.PlayOneShot("{70867d9a-9b9c-464f-bc1c-3215cf5443e0}");
                        }
						else if (healVal == 3f)
                        {
                            FMODUnity.RuntimeManager.PlayOneShot("{88071625-6d05-4a24-a072-21ed547770b0}");
                        }
                        totalultCharge.value += healVal * bonusHeal.value * 1.05f;
                    }
                    
                }
                
               
            }
            if (target.value.GetComponent<HealerHealth>() != null && cooldown.value <= 0)

            {
				if (target.value.GetComponent<HealerHealth>().health < target.value.GetComponent<HealerHealth>().maxHealth)
				{
                    if (healVal == 0.35f)
                    {
                        FMODUnity.RuntimeManager.PlayOneShot("{70867d9a-9b9c-464f-bc1c-3215cf5443e0}");
                    }
                    else if (healVal == 3f)
                    {
                        FMODUnity.RuntimeManager.PlayOneShot("{88071625-6d05-4a24-a072-21ed547770b0}");
                    }                  
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