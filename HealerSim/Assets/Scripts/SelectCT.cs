using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class SelectCT : ConditionTask {

		public BBParameter<GameObject> target;
		Camera cam;
		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){
			// router.onMouseOver += Router_onMouseOver;
			cam = Camera.main;
			return null;
		}

     //   private void Router_onMouseOver(ParadoxNotion.EventData msg)
      //  {
            
     //   }

        //Called whenever the condition gets enabled.
        protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			if(Input.GetMouseButton(1))
			{
				
                return true;
            }
			else
			{
				return true;
			}
		}
		
	}
}