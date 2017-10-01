using UnityEngine;
using System.Collections;

public class ShowInterstitialScript : MonoBehaviour
{
	GameObject InitText;
	GameObject LoadButton;
	GameObject LoadText;
	GameObject ShowButton;
	GameObject ShowText;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("ShowInterstitialScript Start called");

		LoadButton = GameObject.Find ("LoadInterstitial");
		LoadText = GameObject.Find ("LoadInterstitialText");
		LoadText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.blue;
		
		ShowButton = GameObject.Find ("ShowInterstitial");
		ShowText = GameObject.Find ("ShowInterstitialText");
		ShowText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.red;

		// Add Interstitial Events
		IronSourceEvents.onInterstitialAdReadyEvent += InterstitialAdReadyEvent;
		IronSourceEvents.onInterstitialAdLoadFailedEvent += InterstitialAdLoadFailedEvent;		
		IronSourceEvents.onInterstitialAdShowSucceededEvent += InterstitialAdShowSucceededEvent; 
		IronSourceEvents.onInterstitialAdShowFailedEvent += InterstitialAdShowFailEvent; 
		IronSourceEvents.onInterstitialAdClickedEvent += InterstitialAdClickedEvent;
		IronSourceEvents.onInterstitialAdOpenedEvent += InterstitialAdOpenedEvent;
		IronSourceEvents.onInterstitialAdClosedEvent += InterstitialAdClosedEvent;
		// Add Rewarded Interstitial Events
		IronSourceEvents.onInterstitialAdRewardedEvent += InterstitialAdRewardedEvent;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void LoadInterstitialButtonClicked ()
	{
		Debug.Log ("LoadInterstitialButtonClicked");
		IronSource.Agent.loadInterstitial ();
	}
	
	public void ShowInterstitialButtonClicked ()
	{
		Debug.Log ("ShowInterstitialButtonClicked");
		if (IronSource.Agent.isInterstitialReady ()) {
			IronSource.Agent.showInterstitial ();
		} else {
			Debug.Log ("IronSource.Agent.isInterstitialReady - False");
		}
	}
	
	void InterstitialAdReadyEvent ()
	{
		Debug.Log ("I got InterstitialAdReadyEvent");
		ShowText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.blue;
	}
	
	void InterstitialAdLoadFailedEvent (IronSourceError error)
	{
		Debug.Log ("I got InterstitialAdLoadFailedEvent, code: " + error.getCode () + ", description : " + error.getDescription ());
	}
	
	void InterstitialAdShowSucceededEvent ()
	{
		Debug.Log ("I got InterstitialAdShowSucceededEvent");
		ShowText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.red;
	}
	
	void InterstitialAdShowFailEvent (IronSourceError error)
	{
		Debug.Log ("I got InterstitialAdShowFailEvent, code :  " + error.getCode () + ", description : " + error.getDescription ());
		ShowText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.red;
	}
	
	void InterstitialAdClickedEvent ()
	{
		Debug.Log ("I got InterstitialAdClickedEvent");
	}
	
	void InterstitialAdOpenedEvent ()
	{
		Debug.Log ("I got InterstitialAdOpenedEvent");
	}

	void InterstitialAdClosedEvent ()
	{
		Debug.Log ("I got InterstitialAdClosedEvent");
	}

	void InterstitialAdRewardedEvent ()
	{
		Debug.Log ("I got InterstitialAdRewardedEvent");
	}
}

