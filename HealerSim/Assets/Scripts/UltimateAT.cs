using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using static UnityEngine.GraphicsBuffer;

namespace NodeCanvas.Tasks.Actions {

	public class UltimateAT : ActionTask {
        public BBParameter<float> ultCharge;
		public float ultActiveTimer;
		public GameObject ultAura;
		public float healVal;
		public Collider[] friends;
        public LayerMask fren;


        public Light light;
        public Color defaultLight;
        public Color bluLight;
        public Color pinkLight;
        public Material mat1;
		public Material mat2;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            if (ultCharge.value >= 99)
            {
                ultAura.gameObject.SetActive(true);
            }
            defaultLight = light.color;
            ultActiveTimer = 10;
            //EndAction(true);
        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

			if(ultCharge.value >= 99)
			{
                if (ultActiveTimer > 0)
                {
                    ultActiveTimer -= Time.deltaTime;
                    friends = Physics.OverlapSphere(agent.transform.position, 150, fren);
                    foreach (Collider friend in friends)
                    {
                        if (friend.gameObject.GetComponent<Health>() != null)
                        {
                            friend.gameObject.GetComponent<Health>().health += healVal * Time.deltaTime;
                        }
                        if (friend.gameObject.GetComponent<HealerHealth>() != null)
                        {
                            friend.gameObject.GetComponent<HealerHealth>().health += healVal * Time.deltaTime;
                        }



                    }
                    if (Mathf.RoundToInt(ultActiveTimer % 2) == 0)
                    {
                        light.color = bluLight;
                        
                        ultAura.gameObject.GetComponent<MeshRenderer>().material = mat1;
                    }
                    else if (Mathf.RoundToInt(ultActiveTimer) % 2 == 1)
                    {
                        light.color = pinkLight;
                        ultAura.gameObject.GetComponent<MeshRenderer>().material = mat2;
                    }


                }
                else
                {
                    light.color = defaultLight;
                    ultAura.gameObject.SetActive(false);
                    ultCharge.value = 0;
                    EndAction(true);
                }
            }
			else
            {
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