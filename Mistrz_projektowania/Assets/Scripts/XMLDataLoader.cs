using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Xml;
using System.IO;

public class XMLDataLoader : MonoBehaviour {
	public TextAsset PlanDatabase;
	public TextAsset TripNameDatabase;
	public TextAsset TripNrDatabase;
	public TextAsset CustomerDatabase;
	public int id;
	public string tagName;

	public List<Dictionary<string,string>> Trips = new List<Dictionary<string,string>>();
	Dictionary<string,string> obj;

	// Use this for initialization
	void Start () {
		GetData (id, tagName);

		string nazwa = "";
		Trips [0].TryGetValue ("Nazwa", out nazwa);
		Debug.Log (nazwa);
		Debug.Log ((Trips [0]) ["id"]);
		Debug.Log ((Trips [0]) ["Nr"]);
	}
	// Update is called once per frame
	void Update () {
		
	}

	public void GetData(int id, string tagName){
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(PlanDatabase.text); // load the file.
		//XmlNodeList CustomerList = xmlDoc.GetElementsByTagName(tagName); 

		XmlNode planNode = xmlDoc.SelectSingleNode("//*[@id='"+ id + "']");
		obj = new Dictionary<string,string>();
		obj.Add("id", id.ToString());
		foreach (XmlNode Node in planNode){ 
			//Debug.Log(Node.Name);
			obj.Add(Node.Name, Node.InnerText);
			if(Node.Name == "IdNazwaImprezy")
			{
				int tripNameId = System.Xml.XmlConvert.ToInt32(Node.InnerText);

				XmlDocument tripNameDb = new XmlDocument(); 
				tripNameDb.LoadXml(TripNameDatabase.text); 

				XmlNode tripNameNode = tripNameDb.SelectSingleNode("//*[@id='"+ tripNameId + "']");
				foreach (XmlNode tNode in tripNameNode){ 
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					obj.Add(tNode.Name, tNode.InnerText);
				}
			}
			if(Node.Name == "IdNrImprezy")
			{
				int tripNameId = System.Xml.XmlConvert.ToInt32(Node.InnerText);

				XmlDocument tripNameDb = new XmlDocument(); 
				tripNameDb.LoadXml(TripNrDatabase.text); 

				XmlNode tripNameNode = tripNameDb.SelectSingleNode("//*[@id='"+ tripNameId + "']");
				foreach (XmlNode tNode in tripNameNode){ 
					Debug.Log(tNode.Name + ": " + tNode.InnerText);
					obj.Add(tNode.Name, tNode.InnerText);
				}
			}
		}
		Trips.Add(obj);
	}
}
