using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.UI;

namespace NodeCanvas.Tasks.Actions {

	public class CooldownAT : ActionTask {
		public BBParameter<float> basicCooldown;
		public BBParameter<float> ability1Cooldown;
        public BBParameter<float> ability2Cooldown;
		public BBParameter<float> A2Timer;
		public BBParameter<float> ultCharge;

        public TextMeshProUGUI A1cooldownCount;
		public GameObject A1cooldownShade;
        public TextMeshProUGUI A2cooldownCount;
        public GameObject A2cooldownShade;
        public TextMeshProUGUI ultAmount;
        public GameObject inactiveUlt;
		public GameObject activeUlt;

        public TextMeshProUGUI A2activeCount;
        public GameObject A2activeShade;

		public GameObject healAura;
		
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
			if (A2Timer.value > 0)
			{
				healAura.SetActive(true);
                A2activeShade.SetActive(true);
                A2activeCount.gameObject.SetActive(true);
                A2activeCount.text = Mathf.Ceil(A2Timer.value).ToString();
            }
			else
			{
                healAura.SetActive(false);
                A2activeCount.gameObject.SetActive(false);
                A2activeShade.SetActive(false);
            }
            if (ability2Cooldown.value >= 0)
			{
				A2cooldownShade.SetActive(true);
                A2cooldownCount.gameObject.SetActive(true);
                A2cooldownCount.text = Mathf.Floor(ability2Cooldown.value).ToString();
                ability2Cooldown.value -= Time.deltaTime;
            }
			else
			{
                A2cooldownCount.gameObject.SetActive(false);
                A2cooldownShade.SetActive(false);
            }
			if(ultCharge.value >= 99)
			{
				ultCharge = 100;
				ultAmount.gameObject.SetActive(false);
                inactiveUlt.SetActive(false);
				activeUlt.SetActive(true);
            }
			else if(ultCharge.value < 100)
			{
               
                ultCharge.value += Time.deltaTime/2;
                ultAmount.text = Mathf.Ceil(ultCharge.value).ToString();
                ultAmount.gameObject.SetActive(true);
                inactiveUlt.SetActive(true);
                activeUlt.SetActive(false);

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