using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class BonusHealAT : ActionTask {

		public BBParameter<float> activeTime;
        public BBParameter<float> bonusHeal;
		public BBParameter<float> cooldown;
        public float fireRate;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            activeTime.value = 6;
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			activeTime.value -= Time.deltaTime;
			if(activeTime.value >= 0)
			{
                bonusHeal.value = 1.5f;
            }
            else
			{
                cooldown.value = fireRate;
                bonusHeal.value = 1;
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