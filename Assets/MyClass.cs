using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class MyClass{

	public int integer;
	public string theName;
	public double doubleNumber;

	public MyClass(int i, string name){
		this.integer = i;
		this.theName = name; 
	}

	public MyClass(int i, string name, double num){
		this.integer = i;
		this.theName = name;
		this.doubleNumber = num;
	}
}
