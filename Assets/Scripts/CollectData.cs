using UnityEngine;
using System.Collections;

public class CollectData : MonoBehaviour {
	
	public string level;
	
	ThinkGearDataController dataController;
	
	double mental,mentalChange,famil,familChange;
	bool isNewMental = false;
	bool isNewFamil = false;
	
	void Awake(){
		dataController = GameObject.Find("ThinkGearDataController").GetComponent<ThinkGearDataController>();
		dataController.MentalEffortEvent += OnMentalEffortReceived;
		dataController.MentalEffortChangeEvent += OnMentalEffortChangeReceived;
		dataController.TaskFamiliarityEvent += OnTaskFamiliarityReceived;
		dataController.TaskFamiliarityChangeEvent += OnTaskFamiliarityChangeReceived;
	}

	// Use this for initialization
	void Start () {
		NSFileWriter.InitFile(level);
	}
	
	// Update is called once per frame
	void Update () {
		if(isNewFamil && isNewMental){
			NSFileWriter.Write(mental,mentalChange,famil,familChange);
			isNewFamil = isNewMental = false;
		}
	}
	
	void OnMentalEffortReceived(double value){
		mental = value;
		isNewMental = true;
	}
	void OnMentalEffortChangeReceived(double value){
		mentalChange = value;
	}
	
	void OnTaskFamiliarityReceived(double value){
		famil = value;
		isNewFamil = true;
	}
	void OnTaskFamiliarityChangeReceived(double value){
		familChange = value;
	}
	
	void OnDestroy(){
		dataController.MentalEffortEvent -= OnMentalEffortReceived;
		dataController.MentalEffortChangeEvent -= OnMentalEffortChangeReceived;
		dataController.TaskFamiliarityEvent -= OnTaskFamiliarityReceived;
		dataController.TaskFamiliarityChangeEvent -= OnTaskFamiliarityChangeReceived;
		NSFileWriter.CloseFile();
	}
	
}
