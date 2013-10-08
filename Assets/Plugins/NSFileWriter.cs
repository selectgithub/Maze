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
		
		if(Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor){
			file = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MazeData\\" + level;
			Directory.CreateDirectory(file);
			file = Path.Combine(file,time + "_MentalEffort_Familiarity.csv");
			streamWriter = File.CreateText(file);
			streamWriter.WriteLine("Time,CurrentMentalEffort,CurrentTaskFamiliarity");
		}
	}
	
	
	public static void Write(double mentalEffort,double mentalchange,double familiarity,double famiChange){
		
		if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer){
			time = string.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
			streamWriter.WriteLine(time + "," + mentalEffort + "," + mentalchange + "," + familiarity + "," + famiChange);
		}
	}
	
	public static void Write(double mentalEffort,double familiarity){
		
		if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer){
			time = string.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
			streamWriter.WriteLine(time + "," + mentalEffort + "," + familiarity);
		}
	}
	
	public static void CloseFile(){
		if(Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer){
			time = string.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
			
			streamWriter.WriteLine(time + ",END,END");
			streamWriter.Close();
			streamWriter.Dispose();
		}
	}
	
	
	
	
}
