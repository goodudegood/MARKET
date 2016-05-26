﻿using UnityEngine;
using System.Collections;

public class DestroyOnNonMobile : MonoBehaviour {

	#if !UNITY_ANDROID && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT
	void Start () {

		Destroy (this.gameObject);

	}
	#endif
}