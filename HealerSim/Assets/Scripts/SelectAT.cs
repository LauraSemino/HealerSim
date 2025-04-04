using NodeCanvas.Framework;
using ParadoxNotion;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class SelectAT : ActionTask {

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
			if(Physics.Raycast(ray, out hit, 100))
			{
				if (hit.transform.gameObject.IsInLayerMask(ally))
				{
					target.value = hit.transform.gameObject;
                    //Debug.Log(hit.transform.name);
                }
				
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