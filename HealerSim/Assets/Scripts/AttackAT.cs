using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;


namespace NodeCanvas.Tasks.Actions {

	public class AttackAT : ActionTask {
		public float damage;
		public BBParameter<float> atkDur;
        public float totalAtkTime;
        public NavMeshAgent nma;
        public BBParameter<GameObject> target;
        public BBParameter<Vector3> velocity;
        public bool stopToAtk;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            atkDur.value = totalAtkTime;
            return null;
		}

        //This is called once each time the task is enabled.
        //Call EndAction() to mark the action as finished, either in success or failure.
        //EndAction can be called from anywhere.
		protected override void OnExecute() {

            //nma.SetDestination(agent.transform.position);

            if (stopToAtk == true)
            {
                velocity.value = Vector3.zero;
            }
            //EndAction(true);
            
        }

		
        //Called once per frame while the action is active.
        protected override void OnUpdate() {
 
            atkDur.value -= Time.deltaTime;
            if (atkDur.value <= 0)
            {
                if (nma.gameObject.tag == "Melee")
                {

                }
                else if(nma.gameObject.tag == "Tank")
                {
                    int n = Random.Range(0, 2);
                    switch (n)
                    {
                        case 0:
                            FMODUnity.RuntimeManager.PlayOneShot("{ee8817b1-3eb7-4906-95a6-8bbbe77e02be}", nma.gameObject.transform.position);
                            break;
                        case 1:
                            FMODUnity.RuntimeManager.PlayOneShot("{5642b734-e6c3-40fb-b8a0-4d5d7f80b873}", nma.gameObject.transform.position);
                            break;
                    }        
                    
                }
                else if(nma.gameObject.tag == "Ranger")
                {

                }
                if (target.value.GetComponent<Health>() != null)
                {
                    int n = Random.Range(0, 3);
                    switch (n)
                    {
                        case 0:
                            FMODUnity.RuntimeManager.PlayOneShot("{daeca49a-9af2-4401-addf-b310ec0d1747}", target.value.transform.position);
                            break;
                        case 1:
                            FMODUnity.RuntimeManager.PlayOneShot("{ec0b3df7-043a-4296-aeff-b4edd315750e}", target.value.transform.position);
                            break;
                        case 2:
                            FMODUnity.RuntimeManager.PlayOneShot("{a682ce77-7868-42b8-a2cc-5fc57224d4b9}", target.value.transform.position);
                            break;
                    }
                    target.value.GetComponent<Health>().health -= damage;
                }
                else if (target.value.GetComponent<HealerHealth>() != null)
                {
                    int n = Random.Range(0, 3);
                    switch (n)
                    {
                        case 0:
                            FMODUnity.RuntimeManager.PlayOneShot("{daeca49a-9af2-4401-addf-b310ec0d1747}", target.value.transform.position);
                            break;
                        case 1:
                            FMODUnity.RuntimeManager.PlayOneShot("{ec0b3df7-043a-4296-aeff-b4edd315750e}", target.value.transform.position);
                            break;
                        case 2:
                            FMODUnity.RuntimeManager.PlayOneShot("{a682ce77-7868-42b8-a2cc-5fc57224d4b9}", target.value.transform.position);
                            break;
                    }
                    FMODUnity.RuntimeManager.PlayOneShot("{d49c0aa9-1f23-4fa1-b231-dc6a4a6d3bde}");
                    target.value.GetComponent<HealerHealth>().health -= damage;
                }             
                atkDur.value = totalAtkTime;
                //EndAction(true);
            }
            

            EndAction(true);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}