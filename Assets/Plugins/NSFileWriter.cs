using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class NSFileWriter : MonoBehaviour {
	
	private static string file;
	private static StreamWriter streamWriter;
	
	private static string time;
	
	public static void InitFile(string level) {
		
		time = string.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
		
		if(Application.platform == RuntimePlatform.WindowsPlayer){
			file = Application.dataPath + "-" + level + "-" + time + "_MentalEffort_Familiarity.csv";
			streamWriter = File.CreateText(file);
			streamWriter.WriteLine("Time,CurrentMentalEffort,MentalEffortChange,CurrentTaskFamiliarity,TaskFamiliarityChange");
		}
		if(Application.platform == RuntimePlatform.OSXPlayer){
			file = Application.dataPath + "-" + level + "-" + time + "_MentalEffort_Familiarity.csv";
			streamWriter = File.CreateText(file);
			streamWriter.WriteLine("Time,CurrentMentalEffort,MentalEffortChange,CurrentTaskFamiliarity,TaskFamiliarityChange");
		}
	}
	
	
	public static void Write(double mentalEffort,double mentalchange,double familiarity,double famiChange){
		
		if(Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer){
			time = string.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
			streamWriter.WriteLine(time + "," + mentalEffort + "," + mentalchange + "," + familiarity + "," + famiChange);
		}
	}
	
	public static void CloseFile(){
		if(Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer){
			time = string.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
			
			streamWriter.WriteLine(time + ",END,END,END,END");
			streamWriter.Close();
			streamWriter.Dispose();
		}
	}
	
	
	
	
}
