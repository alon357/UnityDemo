using UnityEngine;
using System.Collections;

public class ShowRewardedVideoScript : MonoBehaviour
{
	GameObject InitText;
	GameObject ShowButton;
	GameObject ShowText;
	GameObject AmountText;
	int userTotalCredits = 0;
	
	// Use this for initialization
	void Start ()
	{	
		Debug.Log ("ShowRewardedVideoScript Start called");

		ShowButton = GameObject.Find ("ShowRewardedVideo");
		ShowText = GameObject.Find ("ShowRewardedVideoText"); 
		ShowText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.red;

		AmountText = GameObject.Find ("RVAmount");
		
		//Add Rewarded Video Events
		IronSourceEvents.onRewardedVideoAdOpenedEvent += RewardedVideoAdOpenedEvent;
		IronSourceEvents.onRewardedVideoAdClosedEvent += RewardedVideoAdClosedEvent; 
		IronSourceEvents.onRewardedVideoAvailabilityChangedEvent += RewardedVideoAvailabilityChangedEvent;
		IronSourceEvents.onRewardedVideoAdStartedEvent += RewardedVideoAdStartedEvent;
		IronSourceEvents.onRewardedVideoAdEndedEvent += RewardedVideoAdEndedEvent;
		IronSourceEvents.onRewardedVideoAdRewardedEvent += RewardedVideoAdRewardedEvent; 
		IronSourceEvents.onRewardedVideoAdShowFailedEvent += RewardedVideoAdShowFailedEvent; 
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void ShowRewardedVideoButtonClicked ()
	{
		Debug.Log ("ShowRewardedVideoButtonClicked");
		if (IronSource.Agent.isRewardedVideoAvailable ()) {
			IronSource.Agent.showRewardedVideo ();
		} else {
			Debug.Log ("IronSource.Agent.isRewardedVideoAvailable - False");
		}
	}

	void RewardedVideoAvailabilityChangedEvent (bool canShowAd)
	{
		Debug.Log ("I got RewardedVideoAvailabilityChangedEvent, value = " + canShowAd);
		if (canShowAd) {
			ShowText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.blue;
		} else {
			ShowText.GetComponent<UnityEngine.UI.Text> ().color = UnityEngine.Color.red;
		}
	}

	void RewardedVideoAdOpenedEvent ()
	{
		Debug.Log ("I got RewardedVideoAdOpenedEvent");
	}

	void RewardedVideoAdRewardedEvent (IronSourcePlacement ssp)
	{
		Debug.Log ("I got RewardedVideoAdRewardedEvent, amount = " + ssp.getRewardAmount () + " name = " + ssp.getRewardName ());
		userTotalCredits = userTotalCredits + ssp.getRewardAmount ();
		AmountText.GetComponent<UnityEngine.UI.Text> ().text = "" + userTotalCredits;

	}
	
	void RewardedVideoAdClosedEvent ()
	{
		Debug.Log ("I got RewardedVideoAdClosedEvent");
	}

	void RewardedVideoAdStartedEvent ()
	{
		Debug.Log ("I got RewardedVideoAdStartedEvent");
	}

	void RewardedVideoAdEndedEvent ()
	{
		Debug.Log ("I got RewardedVideoAdEndedEvent");
	}
	
	void RewardedVideoAdShowFailedEvent (IronSourceError error)
	{
		Debug.Log ("I got RewardedVideoAdShowFailedEvent, code :  " + error.getCode () + ", description : " + error.getDescription ());
	}

}
