using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Xml;
using System.IO;

public class XMLDataLoader : MonoBehaviour {
	public TextAsset Database;

	List<Dictionary<string,string>> Trips = new List<Dictionary<string,string>>();
	Dictionary<string,string> obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetData(){
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(Database.text); // load the file.
		XmlNodeList levelsList = xmlDoc.GetElementsByTagName("Zleceniodawca"); 
	}
}
