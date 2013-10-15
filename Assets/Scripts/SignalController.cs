using UnityEngine;
using System.Collections;

public class SignalController : MonoBehaviour {
	
	public GameObject connectedIcon;
	public GameObject disconnectedIcon;
	public GameObject fittingIcon;
	
	ThinkGearDataController dataController;
	int signal = 200;
	
	void Awake(){
		dataController = GameObject.Find("ThinkGearDataController").GetComponent<ThinkGearDataController>();
		dataController.PoorSignalEvent += OnPoorSignal;
		fittingIcon.SetActive(false);
		connectedIcon.SetActive(false);
		disconnectedIcon.SetActive(true);
	}
	
	void OnPoorSignal(int value){
		signal = value;                    
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(signal == 0){
			disconnectedIcon.SetActive(false);
			fittingIcon.SetActive(false);
			connectedIcon.SetActive(true);
		}else if(signal == 29 || signal == 54 || signal == 55 || signal == 56 || signal == 80 || signal == 81 || signal == 82 || signal == 107 || signal == 200){
			fittingIcon.SetActive(false);
			connectedIcon.SetActive(false);
			disconnectedIcon.SetActive(true);
		}else{
			disconnectedIcon.SetActive(false);
			connectedIcon.SetActive(false);
			fittingIcon.SetActive(true);
		}
	}
}
