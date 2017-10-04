﻿using UnityEngine;
using System;

[System.Serializable]
public abstract class AManager<T> : MonoBehaviour where T : Component
{
	[SerializeField] private bool persistent = false;
	
	// use this instance
	private static T _instance;
	protected bool _destroyed = false;
	
	// instance property
	public static T Instance {
		get {
			if (_instance == null) {
				_instance = FindObjectOfType (typeof(T)) as T;
				if (_instance == null) {
					GameObject managerGameObject = new GameObject ();
					managerGameObject.transform.position = Vector3.zero;
					managerGameObject.transform.localRotation = Quaternion.identity;
					managerGameObject.transform.localScale = Vector3.one;
					_instance = managerGameObject.AddComponent<T>() as T;
					// hide gameObject in Hierarchy and don't save it to scene
					managerGameObject.hideFlags = HideFlags.HideAndDontSave;
				}
			}
			return _instance;
		}
	}
	
	protected virtual void Awake ()
	{
		if(persistent)
		{
			GameObject.DontDestroyOnLoad(this.gameObject);
		}
		
		if (_instance == null) {
			_instance = this as T;
		} else 
		{
			if(_instance != this)
			{
				this._destroyed = true;
				Debug.Log (string.Format ("Other instance of {0} detected (will be destroyed)", typeof(T)));
				GameObject.Destroy(this.gameObject);
				return;
			}
		}
	}
}