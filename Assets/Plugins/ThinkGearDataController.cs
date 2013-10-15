using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

using System.IO;
using System.IO.Ports;

using NeuroSky.ThinkGear;
using NeuroSky.ThinkGear.Algorithms;

public class ThinkGearDataController : MonoBehaviour {
	public static double FAMIL_BASELINE;
	public static double EFF_BASELINE;
	
	public delegate void DataChangeDelegate(double value);
	public delegate void IntDataChangeDelegate(int value);
	
	public event DataChangeDelegate MentalEffortEvent;
	public event DataChangeDelegate MentalEffortChangeEvent;
	
	public event DataChangeDelegate TaskFamiliarityEvent;
	public event DataChangeDelegate TaskFamiliarityChangeEvent;

	public event IntDataChangeDelegate PoorSignalEvent;
	
	Connector connector;
	Device.DataEventArgs de;
	//TGParser tgParser;
	
    double task_famil_baseline, task_famil_cur, task_famil_change;
    bool task_famil_first;
    double mental_eff_baseline, mental_eff_cur, mental_eff_change;
    bool mental_eff_first;
	
    byte rcv_poorSignal;
	
	void Awake(){
		connector = new NeuroSky.ThinkGear.Connector();
	}
	public void Connect(){
		connector.ConnectScan("COM3");
		NSDebug.Log("ConnectScan COM3");
	}
	// Use this for initialization
	void Start () {
			if(connector == null){
				return;
			}
            connector.DeviceConnected += new EventHandler(OnDeviceConnected);
            connector.DeviceConnectFail += new EventHandler(OnDeviceFail);
            connector.DeviceValidating += new EventHandler(OnDeviceValidating);

            // Scan for devices
            // add this one to scan 1st
            //connector.ConnectScan("COM3");
			//NSDebug.Log("ConnectScan COM3");

            //start the mental effort and task familiarity calculations

                connector.enableTaskDifficulty(); //depricated
                connector.enableTaskFamiliarity(); //depricated

                connector.setMentalEffortRunContinuous(true);
                connector.setMentalEffortEnable(true);
                connector.setTaskFamiliarityRunContinuous(true);
                connector.setTaskFamiliarityEnable(true);

                connector.setBlinkDetectionEnabled(false);
            
            task_famil_baseline = task_famil_cur = task_famil_change = 0.0;
            task_famil_first = true;
            mental_eff_baseline = mental_eff_cur = mental_eff_change = 0.0;
            mental_eff_first = true;
         
	}
	
	
	void OnDeviceConnected(object sender, EventArgs e){
		Connector.DeviceEventArgs de = (Connector.DeviceEventArgs)e;

		NSDebug.Log("OnDeviceConnected");
		
        de.Device.DataReceived += new EventHandler(OnDataReceived);
	}
	
   	void OnDeviceFail(object sender, EventArgs e) {
		NSDebug.Log("OnDeviceFail");
        }
 
    void OnDeviceValidating(object sender, EventArgs e) {
		NSDebug.Log("OnDeviceValidating");
        }
	
	void OnDataReceived(object sender, EventArgs e) {
            de = (Device.DataEventArgs)e;
		
			//tgParser = new TGParser(); //encounter ERROR when create TGParser,because of NLog.
            //tgParser.Read(de.DataRowArray);
		
       foreach(DataRow row in de.DataRowArray){
			Code type = row.Type;
			switch(type){
			case Code.PoorSignal:
					//Debug.Log("PQ:"+row.Data[0]);
					if(PoorSignalEvent != null){
						PoorSignalEvent(row.Data[0]);
					}
				break;
			case Code.Raw:
					//Debug.Log("Raw");
				break;
				
			case Code.MentalEffort:
					mental_eff_cur = BitConverter.ToDouble(row.Data,0);
					
                        if (mental_eff_first) {
                            mental_eff_first = false;
							EFF_BASELINE = mental_eff_baseline = mental_eff_cur;
							Debug.Log("MentalBaseLine:"+mental_eff_baseline);
                        }
				
				    if(MentalEffortEvent != null){
						MentalEffortEvent(mental_eff_cur);
					}
				break;
			case Code.TaskFamiliarity:
					
				task_famil_cur = BitConverter.ToDouble(row.Data,0);
                        if (task_famil_first) {
                            task_famil_first = false;
							FAMIL_BASELINE = task_famil_baseline = task_famil_cur;
							Debug.Log("FamilBaseLine:"+task_famil_baseline);
                        }
                        
				if(TaskFamiliarityEvent != null){
					TaskFamiliarityEvent(task_famil_cur);
				}
				break;
			}
		}

        }
	
	double calcPercentChange(double baseline, double current)
        {
            double change;

            if (baseline == 0.0) baseline = 1.0; //don't allow divide by zero
            /*
             * calculate the percentage change
             */
            change = current - baseline;
            change = (change / baseline) * 1000.0 + 0.5;
            change = Math.Floor(change) / 10.0;
            return (change);
        }
	
	void OnApplicationQuit(){
		connector.Close();
	}

}
