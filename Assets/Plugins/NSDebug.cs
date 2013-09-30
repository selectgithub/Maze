using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class NSDebug : MonoBehaviour {
	
	private static string file;
	private static StreamWriter streamWriter;
	
	private static string time;
	
	private static bool logEnabled = true;

	// Use this for initialization
	void Start () {
		
		time = string.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
		
		if(Application.platform == RuntimePlatform.WindowsPlayer){
			file = Application.dataPath + "\\Maze_"+ time + "_NeuroSky.log";
			streamWriter = File.CreateText(file);
			streamWriter.WriteLine("Log Start!");
			streamWriter.WriteLine("LogEnabled:" + logEnabled);
		}
		if(Application.platform == RuntimePlatform.OSXPlayer){
			file = Application.dataPath + "/Maze_"+ time + "_NeuroSky.log";
			streamWriter = File.CreateText(file);
			streamWriter.WriteLine("Log Start!");
			streamWriter.WriteLine("LogEnabled:" + logEnabled);
		}
		
		
	}
	
	public static void Log(string logString){
		if(!logEnabled){return;}
		
		if(Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer){
			time = string.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
			streamWriter.WriteLine(time + ": " + logString);
		}
	}
	
	void OnApplicationQuit(){
		if(Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.WindowsPlayer){
			time = string.Format("{0:yyyy-MM-dd-HH-mm-ss}",DateTime.Now);
			
			streamWriter.WriteLine(time + ": Log End!");
			streamWriter.Close();
			streamWriter.Dispose();
		}
	}
}
