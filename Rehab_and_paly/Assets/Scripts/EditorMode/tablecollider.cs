using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tablecollider : MonoBehaviour
{
    // Start is called before the first frame update
    EditManager editManager;
    void Start()
    {
        editManager = GameObject.Find("Complete_Shape").GetComponent<EditManager>();
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider collision)
	{
      
		editManager.addNewObject(collision.gameObject);

	}
    private void OnTriggerExit(Collider collision)
	{
		editManager.removeGameObject(collision.gameObject);
	}
    
}
