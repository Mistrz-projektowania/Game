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
	public TextAsset notPayingParticipantsNrDatabase;
	public TextAsset CustomerContactDatabase;
	public TextAsset tripPlanDatabase;
	public TextAsset tripLengthDatabase;
	public TextAsset hotelDatabase;
	public TextAsset restaurantDatabase;
	public TextAsset servicesDatabase;
	public TextAsset vehicleDatabase;
	public TextAsset participantsTypeDatabase;
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
		foreach (KeyValuePair<string, string> kvp in Trips[order+1])
		{
			//Debug.Log (order);
			if (kvp.Key != "Punkty") {
				if (kvp.Key != "Typ"){
					//Debug.Log (kvp.Key + " " + kvp.Value);
				//data += string.Format("{0}: {1}\n", kvp.Key, kvp.Value);
					data += string.Format("{0}\n", kvp.Value);	
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
		//Debug.Log(order.Length);
		for(int i = 0; i < order.Length; i++){
			rockTexts [order[i]].text = getDataString (rockTexts [order[i]], rockTypeTexts[order[i]], i);
			// Debug.Log ("i: " + i + ", order[i]: " + order [i] + ", text: " + rockTexts [order [i]].text);
		}
			
	}

	public List<Dictionary<string,string>> getCurrentTripData(){
		
		return Trips;
	}

	public List<string> getQuestionsData(string dropdownName){
		XmlDocument xmlDoc = new XmlDocument();
		List<string> questionsData = new List<string>();
		switch(dropdownName){
			case "participantsNr":
				xmlDoc.LoadXml (ParticipantsNrDatabase.text); // load the file.
				XmlNode nodes = xmlDoc.SelectSingleNode("LiczbaUczestnikowPlacacych");
				foreach (XmlNode tNode in nodes) { 
				questionsData.Add(tNode.SelectSingleNode("LiczbaOsob").InnerText + " (" + tNode.SelectSingleNode("Punkty").InnerText + " pkt)");
				}
				break;
		case "notPayingParticipantsNr":
			xmlDoc.LoadXml (notPayingParticipantsNrDatabase.text); // load the file.
			XmlNode participantsNodes = xmlDoc.SelectSingleNode("LiczbaUczestnikowNieplacacych");
			foreach (XmlNode tNode in participantsNodes) { 
				questionsData.Add(tNode.SelectSingleNode("LiczbaOsob").InnerText + " (" + tNode.SelectSingleNode("Punkty").InnerText + " pkt)");
			}
			break;
		case "tripName":
			xmlDoc.LoadXml (TripNameDatabase.text);
			XmlNode tripNodes = xmlDoc.SelectSingleNode ("NazwyImprez");
			foreach (XmlNode tNode in tripNodes) { 
				questionsData.Add(tNode.SelectSingleNode("Nazwa").InnerText + " (" + tNode.SelectSingleNode("Punkty").InnerText + " pkt)");
			}
			break;
		case "participantsType":
			xmlDoc.LoadXml (participantsTypeDatabase.text);
			XmlNode participantsTypeNodes = xmlDoc.SelectSingleNode ("Uczestnicy");
			foreach (XmlNode tNode in participantsTypeNodes) { 
				questionsData.Add(tNode.SelectSingleNode("Nazwa").InnerText + " (" + tNode.SelectSingleNode("Punkty").InnerText + " pkt)");
			}
			break;
		case "vehicle":
			xmlDoc.LoadXml (vehicleDatabase.text);
			XmlNode vehicleNodes = xmlDoc.SelectSingleNode ("Transport");
			foreach (XmlNode tNode in vehicleNodes) { 
				questionsData.Add(tNode.SelectSingleNode("Nazwa").InnerText + " (" + tNode.SelectSingleNode("Punkty").InnerText + " pkt)");
			}
			break;
		case "tripLength":
			xmlDoc.LoadXml (tripLengthDatabase.text);
			XmlNode tripLengthNodes = xmlDoc.SelectSingleNode ("CzasyTrwania");
			foreach (XmlNode tNode in tripLengthNodes) { 
				questionsData.Add(tNode.SelectSingleNode("Czas").InnerText + " (" + tNode.SelectSingleNode("Punkty").InnerText + " pkt)");
			}
			break;
		default:
			break;
		}
		return questionsData;
	}

	public string getGameData(string database, int id){
		XmlDocument xmlDoc = new XmlDocument();
		string itemData = "";
		switch (database){
		case "participantsNr":
			xmlDoc.LoadXml (ParticipantsNrDatabase.text); 
			XmlNode nodes = xmlDoc.SelectSingleNode ("LiczbaUczestnikowPlacacych");
			itemData = xmlDoc.SelectSingleNode ("//*[@id='" + id + "']").SelectSingleNode ("LiczbaOsob").InnerText;
			break;
		case "notPayingParticipantsNr":
			xmlDoc.LoadXml (notPayingParticipantsNrDatabase.text);
			XmlNode participantsNodes = xmlDoc.SelectSingleNode("LiczbaUczestnikowNieplacacych");
			itemData = xmlDoc.SelectSingleNode ("//*[@id='" + id + "']").SelectSingleNode("LiczbaOsob").InnerText;
			break;
		case "tripName":
			xmlDoc.LoadXml (TripNameDatabase.text);
			XmlNode tripNodes = xmlDoc.SelectSingleNode ("NazwyImprez");
			itemData = xmlDoc.SelectSingleNode ("//*[@id='" + id + "']").SelectSingleNode("Nazwa").InnerText;
			break;
		case "participantsType":
			xmlDoc.LoadXml (participantsTypeDatabase.text);
			XmlNode participantsTypeNodes = xmlDoc.SelectSingleNode ("Uczestnicy");
			itemData = xmlDoc.SelectSingleNode ("//*[@id='" + id + "']").SelectSingleNode("Nazwa").InnerText;
			break;
		case "vehicle":
			xmlDoc.LoadXml (vehicleDatabase.text);
			XmlNode vehicleNodes = xmlDoc.SelectSingleNode ("Transport");
			itemData = xmlDoc.SelectSingleNode ("//*[@id='" + id + "']").SelectSingleNode("Nazwa").InnerText;
			break;
		case "tripLength":
			xmlDoc.LoadXml (tripLengthDatabase.text);
			XmlNode tripLengthNodes = xmlDoc.SelectSingleNode ("CzasyTrwania");
			itemData = xmlDoc.SelectSingleNode ("//*[@id='" + id + "']").SelectSingleNode("Dni").InnerText;
			break;
		default:
			break;
		}
		return itemData;
	}


	public int checkPoints(string database, int itemIndex){
		int points = 0;
		XmlDocument xmlDoc = getDatabaseData (database);
		points = System.Xml.XmlConvert.ToInt32 (xmlDoc.SelectSingleNode ("//*[@id='" + itemIndex + "']").SelectSingleNode ("Punkty").InnerText);
		return points;
	}


	XmlDocument getDatabaseData(string database){
		XmlDocument xmlDoc = new XmlDocument();
		switch (database) {
		case "participantsNr":
			xmlDoc.LoadXml (ParticipantsNrDatabase.text); // load the file.
			break;
		case "notPayingParticipantsNr":
			xmlDoc.LoadXml (notPayingParticipantsNrDatabase.text); // load the file.
			break;
		case "tripName":
			xmlDoc.LoadXml (TripNameDatabase.text);	
			break;
		case "participantsType":
			xmlDoc.LoadXml (participantsTypeDatabase.text);
			break;
		case "vehicle":
			xmlDoc.LoadXml (vehicleDatabase.text);
			break;
		case "tripLength":
			xmlDoc.LoadXml (tripLengthDatabase.text);
			break;
		default:
			break;
		}
		return xmlDoc;
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
					if (tNode.Name == "Nazwa") {
						GameObject tripName = GameObject.Find("TripTitle");
						tripName.GetComponent<Text> ().text = tNode.InnerText;
					}
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
			if(Node.Name == "IdZleceniodawcy")
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

			if(Node.Name == "IdPrzedstawicielaZleceniodawcy")
			{
				int customerContactId = System.Xml.XmlConvert.ToInt32(Node.InnerText);

				XmlDocument DBname = new XmlDocument(); 
				DBname.LoadXml(CustomerContactDatabase.text); 

				XmlNode nodeName = DBname.SelectSingleNode("//*[@id='"+ customerContactId + "']");
				foreach (XmlNode tNode in nodeName){ 
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					obj.Add(tNode.Name, tNode.InnerText);
				}
				obj.Add("Typ", "Kontakt zleceniodawcy");
			}
			if(Node.Name == "IdTrasyImprezy")
			{
				int tripPlanId = System.Xml.XmlConvert.ToInt32(Node.InnerText);

				XmlDocument DBname = new XmlDocument(); 
				DBname.LoadXml(tripPlanDatabase.text); 

				XmlNode nodeName = DBname.SelectSingleNode("//*[@id='"+ tripPlanId + "']");
				foreach (XmlNode tNode in nodeName){ 
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					obj.Add(tNode.Name, tNode.InnerText);
				}
				obj.Add("Typ", "Trasa");
			}
			if(Node.Name == "IdMiejscaNoclegowego")
			{
				int hotelId = System.Xml.XmlConvert.ToInt32(Node.InnerText);

				XmlDocument DBname = new XmlDocument(); 
				DBname.LoadXml(hotelDatabase.text); 

				XmlNode nodeName = DBname.SelectSingleNode("//*[@id='"+ hotelId + "']");
				foreach (XmlNode tNode in nodeName){ 
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					obj.Add(tNode.Name, tNode.InnerText);
				}
				obj.Add("Typ", "Hotel");
			}

			if(Node.Name == "IdWyzywienia")
			{
				XmlDocument DBname = new XmlDocument(); 
				DBname.LoadXml(restaurantDatabase.text); 
				foreach (XmlNode tNode in Node) {
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					List<Dictionary<string,string>> restaurant = new List<Dictionary<string,string>> ();
					int restaurantId = System.Xml.XmlConvert.ToInt32(tNode.InnerText);
					XmlNode nodeName = DBname.SelectSingleNode("//*[@id='"+ restaurantId + "']");
					string restaurantData = "";
					foreach (XmlNode ttNode in nodeName){ 
						//Debug.Log(ttNode.Name + ": " + ttNode.InnerText);
						restaurantData += ttNode.InnerText + " ";
				
					}
					//restaurant.Add (restaurantData);
					obj.Add("Lokal" + tNode.InnerText, restaurantData);
					//Debug.Log("Lokal" + tNode.InnerText + ": " + restaurantData);
				}



				//obj.Add(tNode.Name, tNode.InnerText);
				obj.Add("Typ", "Wyżywienie");
			}
			if(Node.Name == "IdUslug")
			{
				XmlDocument DBname = new XmlDocument(); 
				DBname.LoadXml(servicesDatabase.text); 
				foreach (XmlNode tNode in Node) {
					//Debug.Log(tNode.Name + ": " + tNode.InnerText);
					List<Dictionary<string,string>> restaurant = new List<Dictionary<string,string>> ();
					int serviceId = System.Xml.XmlConvert.ToInt32(tNode.InnerText);
					XmlNode nodeName = DBname.SelectSingleNode("//*[@id='"+ serviceId + "']");
					string serviceData = "";
					foreach (XmlNode ttNode in nodeName){ 
						//Debug.Log(ttNode.Name + ": " + ttNode.InnerText);
						serviceData += ttNode.InnerText + " ";

					}
					//restaurant.Add (restaurantData);
					obj.Add("Usługa" + tNode.InnerText, serviceData);
					//Debug.Log("Usługa" + tNode.InnerText + ": " + serviceData);
				}



				//obj.Add(tNode.Name, tNode.InnerText);
				obj.Add("Typ", "Usługi");
			}
			Trips.Add(obj);

			obj = new Dictionary<string,string>();
		}

	}
}
