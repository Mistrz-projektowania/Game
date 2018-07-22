using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Xml;
using System.IO;

public class XMLDataLoader : MonoBehaviour {
	public TextAsset Database;
	public int id;
	public string tagName;

	List<Dictionary<string,string>> Trips = new List<Dictionary<string,string>>();
	Dictionary<string,string> obj;

	// Use this for initialization
	void Start () {
		GetData (id, tagName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void GetData(int id, string tagName){
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(Database.text); // load the file.
		XmlNodeList CustomerList = xmlDoc.GetElementsByTagName(tagName); 

		XmlNode customerNode = xmlDoc.SelectSingleNode("//*[@id='"+ id + "']");
		foreach (XmlNode Node in customerNode){ // levels itens nodes.
			
			/*
			 * if(Node.Name == "Nazwa"){
				Debug.Log ("Nazwa: " + Node.InnerText);
			}
			*/
			Debug.Log (Node.Name + ": " + Node.InnerText);

		}
		/*
		foreach (XmlNode Customer in CustomerList) {
			XmlNodeList CustomerData = Customer.ChildNodes;
			foreach (XmlNode Node in CustomerData) { // levels itens nodes.
				
				if(Node.Name == "Nazwa"){
					Debug.Log ("Nazwa: " + Node.InnerText);
				}
			}
		}
		*/
	}
}
