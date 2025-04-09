using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.UI;


namespace NodeCanvas.Tasks.Actions {

	public class SelectAT : ActionTask {

		public BBParameter<GameObject> selectSig;
        public BBParameter<GameObject> target;
        Camera cam;
		
        public LayerMask ally;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            cam = Camera.main;
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

			Vector3 mousePos = Input.mousePosition;
			mousePos.z = 100f;
			mousePos = cam.ScreenToWorldPoint(mousePos);

			Debug.DrawRay(cam.transform.position, mousePos - cam.transform.position, Color.red);

			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, 100))
			{
				if (hit.transform.gameObject.IsInLayerMask(ally))
				{
					target.value = hit.transform.gameObject;
					
					//selectSig.transform.position = new Vector3 (target.value.transform.position.x, target.value.transform.position.y + 25, target.value.transform.position.z) ;
					//Debug.Log(hit.transform.name);
				}


			}

			
			bool hasTarget;
            if (target.value != null)
            {
                selectSig.value.SetActive(true);
                hasTarget = true;
            }
			else
			{
				hasTarget = false;
				selectSig.value.SetActive(false);
			}
			if(hasTarget)
			{
                selectSig.value.transform.position = cam.WorldToScreenPoint(new Vector3(target.value.transform.position.x, target.value.transform.position.y + 5, target.value.transform.position.z));
            }
            if(Input.GetMouseButton(0) && target.value != null)
			{
				if(target.value.GetComponent<Health>() != null)
				{
                    if (target.value.gameObject.GetComponent<Health>().health < target.value.gameObject.GetComponent<Health>().maxHealth)
                    {
                        selectSig.value.GetComponent<RawImage>().color = Color.green;
                    }
					else
					{
                        selectSig.value.GetComponent<RawImage>().color = Color.white;
                    }
                }
				if (target.value.GetComponent<HealerHealth>() != null)
				{
                    if (target.value.gameObject.GetComponent<HealerHealth>().health < target.value.gameObject.GetComponent<HealerHealth>().maxHealth)
                    {
                        selectSig.value.GetComponent<RawImage>().color = Color.green;
                    }
					else
					{
                        selectSig.value.GetComponent<RawImage>().color = Color.white;
                    }
                }
                

            }
			if(Input.GetMouseButtonUp(0))
			{
                selectSig.value.GetComponent<RawImage>().color = Color.white;
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