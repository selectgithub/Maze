using UnityEngine;
using System.Collections;

public class CollectData : MonoBehaviour {
	
	public string level;
	
	ThinkGearDataController dataController;
	
	EndDestroyPlayer destroyPlayer;
	
	double mental,mentalChange,famil,familChange;
	bool isNewMental = false;
	bool isNewFamil = false;
	
	void Awake(){
		dataController = GameObject.Find("ThinkGearDataController").GetComponent<ThinkGearDataController>();
		dataController.MentalEffortEvent += OnMentalEffortReceived;
		//dataController.MentalEffortChangeEvent += OnMentalEffortChangeReceived;
		dataController.TaskFamiliarityEvent += OnTaskFamiliarityReceived;
		//dataController.TaskFamiliarityChangeEvent += OnTaskFamiliarityChangeReceived;
		
		destroyPlayer = GameObject.FindGameObjectWithTag("destroyer").GetComponent<EndDestroyPlayer>();
		destroyPlayer.FinishLevelEvent += OnDestroyPlayer;
	}

	// Use this for initialization
	void Start () {
		StatusKeeper.LEVEL = level;
		NSFileWriter.InitFile(level);
		NSFileWriter.Write(ThinkGearDataController.EFF_BASELINE,ThinkGearDataController.FAMIL_BASELINE);
	}
	
	// Update is called once per frame
	void Update () {
		if(isNewFamil && isNewMental){
			isNewFamil = isNewMental = false;
			//NSFileWriter.Write(mental,mentalChange,famil,familChange);
			NSFileWriter.Write(mental,famil);
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
	
	void OnDestroyPlayer(){
		dataController.MentalEffortEvent -= OnMentalEffortReceived;
		//dataController.MentalEffortChangeEvent -= OnMentalEffortChangeReceived;
		dataController.TaskFamiliarityEvent -= OnTaskFamiliarityReceived;
		//dataController.TaskFamiliarityChangeEvent -= OnTaskFamiliarityChangeReceived;
		NSFileWriter.CloseFile();
	}
	
	void OnDestroy(){
		
	}
	
}
