using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {

	public GameObject volumeSlider;
	public GameObject showFPS;
	public Text volume;

	// Use this for initialization
	void Start () {
		showFPS.GetComponent<Toggle> ().isOn = GameplayModel.gameFPSOn;
		volumeSlider.GetComponent<Slider> ().value = GameplayModel.gameVolume;
		volume.text = getPercentValue();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void handleShowFPS(){
		GameplayModel.gameFPSOn = showFPS.GetComponent<Toggle> ().isOn;
	}

	public void handlevolumeSlider(){
		float sliderValue = volumeSlider.GetComponent<Slider> ().value;
		GameplayModel.gameVolume = sliderValue;
		volume.text = getPercentValue();
	}

	private string getPercentValue(){
		return ((int)(volumeSlider.GetComponent<Slider> ().value * 100)).ToString() + "%";
	}
}
