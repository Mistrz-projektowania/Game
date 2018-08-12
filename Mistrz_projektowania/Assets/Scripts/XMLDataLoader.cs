using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Xml;
using System.IO;

public class XMLDataLoader : MonoBehaviour {

	public TextAsset PlanDatabase;
	public TextAsset TripNameDatabase;
	public TextAsset TripNrDatabase;
	public TextAsset CustomerDatabase;
	public TextAsset ParticipantsNrDatabase;
	public int id;
	public string tagName;

	public static string tripData;

	public Text rockText1;
	public Text rockText2;
	public Text rockText3;
	public Text rockText4;
	public Text rockText5;
	public Text rockText6;
	public Text rockText7;
	List<Text> rockTexts = new List<Text>();

	public Text rockTypeText1;
	public Text rockTypeText2;
	public Text rockTypeText3;
	public Text rockTypeText4;
	public Text rockTypeText5;
	public Text rockTypeText6;
	public Text rockTypeText7;
	List<Text> rockTypeTexts = new List<Text>();

	public List<Dictionary<string,string>> Trips = new List<Dictionary<string,string>>();
	Dictionary<string,string> obj;

	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
		
	}

	void addTextToList(){
		rockTexts.Add (rockText1);
		rockTexts.Add (rockText2);
		rockTexts.Add (rockText3);
		rockTexts.Add (rockText4);
		rockTexts.Add (rockText5);
		rockTexts.Add (rockText6);
		rockTexts.Add (rockText7);

		rockTypeTexts.Add (rockTypeText1);
		rockTypeTexts.Add (rockTypeText2);
		rockTypeTexts.Add (rockTypeText3);
		rockTypeTexts.Add (rockTypeText4);
		rockTypeTexts.Add (rockTypeText5);
		rockTypeTexts.Add (rockTypeText6);
		rockTypeTexts.Add (rockTypeText7);
	}
	string getDataString(Text rockText, Text rockTypeText, int order){
		string data = "";
		foreach (KeyValuePair<string, string> kvp in Trips[order])
		{
			if (kvp.Key != "Punkty") {
				if (kvp.Key != "Typ"){
				data += string.Format("{0}: {1}\n", kvp.Key, kvp.Value);
				//data += string.Format("{0}\n", kvp.Value);	
				}
			}
			if (kvp.Key == "Typ") {
				rockTypeText.text = kvp.Value;
			}

		}
		return data;
	}
	string setDataType(Text rockTextType, int order){
		string data = "";
		return data;
	}
	public void setDataSlots(int [] order){
		addTextToList ();
		//string data = "";
		//int i = 0;
		for(int i = 0; i < order.Length; i++){
			rockTexts [order[i]].text = getDataString (rockTexts [order[i]], rockTypeTexts[order[i]], i);
		}

		/*foreach (KeyValuePair<string, string> kvp in Trips[order[i]])
		{
			//data += string.Format("{0}: {1}\n", kvp.Key, kvp.Value);
			data += string.Format("{0}\n", kvp.Value);
		}
		rockText1.text = data;
		i++;
		data = "";
		foreach (KeyValuePair<string, string> kvp in Trips[order[i]])
		{
			//data += string.Format("{0}: {1}\n", kvp.Key, kvp.Value);
			data += string.Format("{0}\n", kvp.Value);
		}
		rockText2.text = data;
		i++;
		data = "";
		foreach (KeyValuePair<string, string> kvp in Trips[order[i]])
		{
			//data += string.Format("{0}: {1}\n", kvp.Key, kvp.Value);
			data += string.Format("{0}\n", kvp.Value);
		}
		rockText3.text = data;
		i++;

		data = "";
		foreach (KeyValuePair<string, string> kvp in Trips[order[i]])
		{
			//data += string.Format("{0}: {1}\n", kvp.Key, kvp.Value);
			data += string.Format("{0}\n", kvp.Value);
		}
		rockText4.text = data;
		i++;

		data = "";
		foreach (KeyValuePair<string, string> kvp in Trips[order[i]])
		{
			//data += string.Format("{0}: {1}\n", kvp.Key, kvp.Value);
			data += string.Format("{0}\n", kvp.Value);
		}
		rockText5.text = data;
		i++;
		data = "";
		foreach (KeyValuePair<string, string> kvp in Trips[order[i]])
		{
			//data += string.Format("{0}: {1}\n", kvp.Key, kvp.Value);
			data += string.Format("{0}\n", kvp.Value);
		}
		rockText6.text = data;
		i++;
		data = "";
		foreach (KeyValuePair<string, string> kvp in Trips[order[i]])
		{
			//data += string.Format("{0}: {1}\n", kvp.Key, kvp.Value);
			data += string.Format("{0}\n", kvp.Value);
		}
		rockText7.text = data;
		*/
	}

	public List<Dictionary<string,string>> getCurrentTripData(){
		
		return Trips;
	}
	public void GetData(int id, string tagName){
		XmlDocument xmlDoc = new XmlDocument(); // xmlDoc is the new xml document.
		xmlDoc.LoadXml(PlanDatabase.text); // load the file.
		//XmlNodeList CustomerList = xmlDoc.GetElementsByTagName(tagName); 

		XmlNode planNode = xmlDoc.SelectSingleNode("//*[@id='"+ id + "']");
		obj = new Dictionary<string,string>();
		//obj.Add("id", id.ToString());
		foreach (XmlNode Node in planNode){ 
			//Debug.Log(Node.Name);

			if(Node.Name == "IdNazwaImprezy")
			{
				int tripNameId = System.Xml.XmlConvert.ToInt32(Node.InnerText);

				XmlDocument DBname = new XmlDocument(); 
				DBname.LoadXml(TripNameDatabase.text); 

				XmlNode nodeName = DBname.SelectSingleNode("//*[@id='"+ tripNameId + "']");
				foreach (XmlNode tNode in nodeName){ 
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					obj.Add(tNode.Name, tNode.InnerText);
				}
				obj.Add("Typ", "Nazwa imprezy");
			}
			if(Node.Name == "IdNrImprezy")
			{
				int tripNrId = System.Xml.XmlConvert.ToInt32(Node.InnerText);

				XmlDocument DBname = new XmlDocument(); 
				DBname.LoadXml(TripNrDatabase.text); 

				XmlNode nodeName = DBname.SelectSingleNode("//*[@id='"+ tripNrId + "']");
				foreach (XmlNode tNode in nodeName){ 
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					obj.Add(tNode.Name, tNode.InnerText);
				}
				obj.Add("Typ", "Nr imprezy");
			}
			if(Node.Name == "IdZleceniodawca")
			{
				int tripCustomerId = System.Xml.XmlConvert.ToInt32(Node.InnerText);

				XmlDocument DBname = new XmlDocument(); 
				DBname.LoadXml(CustomerDatabase.text); 

				XmlNode nodeName = DBname.SelectSingleNode("//*[@id='"+ tripCustomerId + "']");
				foreach (XmlNode tNode in nodeName){ 
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					obj.Add(tNode.Name, tNode.InnerText);
				}
				obj.Add("Typ", "Zleceniodawca");
			}
			if(Node.Name == "IdLiczbaOsob")
			{
				int participantsNrId = System.Xml.XmlConvert.ToInt32(Node.InnerText);

				XmlDocument DBname = new XmlDocument(); 
				DBname.LoadXml(ParticipantsNrDatabase.text); 

				XmlNode nodeName = DBname.SelectSingleNode("//*[@id='"+ participantsNrId + "']");
				foreach (XmlNode tNode in nodeName){ 
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					obj.Add(tNode.Name, tNode.InnerText);
				}
				obj.Add("Typ", "Liczba osób");
			}
			Trips.Add(obj);
			obj = new Dictionary<string,string>();
		}
		/* MASKOWANIE BŁĘDU z SetDataSlots wynikajacego z braku odczytu danych z 3 kolejnych baz */
		Trips.Add(obj);
		Trips.Add(obj);
		Trips.Add(obj);
		//////////////////////////////////

	}
}
