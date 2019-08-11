using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class JSONRetriever : MonoBehaviour {

	private string path;
	private string filename = "MyList.JSON";

	public Text idText, nameText, doubleText;

	public Dropdown dropdown;

	private MyClassList myClassList;

	// Use this for initialization
	void Start () {
		path = Application.persistentDataPath + "/" +filename;
		CheckForFile ();
		SetupDropdown ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void CheckForFile (){
		if (File.Exists (path)) {
			string contents = File.ReadAllText (path);
			myClassList = JsonUtility.FromJson<MyClassList> (contents);
		} else {
			myClassList = new MyClassList ();
		}
	}

	private void SetupDropdown(){
		for (int i = 0; i < myClassList.classList.Count; i++) {
			dropdown.AddOptions(new List<Dropdown.OptionData>(i.ToString()));
		}
	}

}
