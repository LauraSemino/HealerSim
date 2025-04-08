using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions {

	public class CooldownAT : ActionTask {
		public BBParameter<float> basicCooldown;
		public BBParameter<float> ability1Cooldown;
		public TextMeshProUGUI A1cooldownCount;
		public GameObject A1cooldownShade;
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
			if(basicCooldown.value >= 0)
			{
                basicCooldown.value -= Time.deltaTime;
            }
            if (ability1Cooldown.value >= 0)
            {
                A1cooldownCount.gameObject.SetActive(true);
                A1cooldownCount.text = Mathf.Ceil(ability1Cooldown.value).ToString();
				A1cooldownShade.SetActive(true);
                ability1Cooldown.value -= Time.deltaTime;
            }
			else
			{
				A1cooldownCount.gameObject.SetActive(false);
                A1cooldownShade.SetActive(false);
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