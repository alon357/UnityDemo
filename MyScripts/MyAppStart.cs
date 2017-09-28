using UnityEngine;
using System.Collections;

public class MyAppStart : MonoBehaviour
{
	public static string uniqueUserId = "demoUserUnity";
	public static string appKey = "38760d6d" ;

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("MyAppStart Start called");

		//IronSource tracking sdk
		IronSource.Agent.reportAppStarted ();

		//Dynamic config example
		IronSourceConfig.Instance.setClientSideCallbacks (true);

		string id = IronSource.Agent.getAdvertiserId ();
		Debug.Log ("IronSource.Agent.getAdvertiserId : " + id);
		
		Debug.Log ("IronSource.Agent.validateIntegration");
		IronSource.Agent.validateIntegration ();

		Debug.Log ("unity version" + IronSource.unityVersion ());

		// Add Banner Events
		//IronSourceEvents.onBannerAdLoadedEvent += BannerAdLoadedEvent;
		//IronSourceEvents.onBannerAdLoadFailedEvent += BannerAdLoadFailedEvent;		
		//IronSourceEvents.onBannerAdClickedEvent += BannerAdClickedEvent; 
		//IronSourceEvents.onBannerAdScreenPresentedEvent += BannerAdScreenPresentedEvent; 
		//IronSourceEvents.onBannerAdScreenDismissedEvent += BannerAdScreenDismissedEvent;
		//IronSourceEvents.onBannerAdLeftApplicationEvent += BannerAdLeftApplicationEvent;

		//SDK init
		Debug.Log ("IronSource.Agent.init");
		IronSource.Agent.setUserId ("uniqueUserId");
		IronSource.Agent.init (appKey);
		//IronSource.Agent.init (appKey, IronSourceAdUnits.REWARDED_VIDEO, IronSourceAdUnits.INTERSTITIAL, IronSourceAdUnits.OFFERWALL, IronSourceAdUnits.BANNER);

		//Load Banner example
		//IronSource.Agent.loadBanner (IronSourceBannerSize.BANNER, IronSourceBannerPosition.BOTTOM);
	}
	
	// Update is called once per frame
	void Update ()
	{

	}

	void OnApplicationPause (bool isPaused)
	{
		Debug.Log ("OnApplicationPause = " + isPaused);
		IronSource.Agent.onApplicationPause (isPaused);
	}

	//Banner Events
	//void BannerAdLoadedEvent ()
	//{
	//	Debug.Log ("I got BannerAdLoadedEvent");
	//}
	
	//void BannerAdLoadFailedEvent (IronSourceError error)
	//{
	//	Debug.Log ("I got BannerAdLoadFailedEvent, code: " + error.getCode () + ", description : " + error.getDescription ());
	//}
	
	//void BannerAdClickedEvent ()
	//{
	//	Debug.Log ("I got BannerAdClickedEvent");
	//}
	
	//void BannerAdScreenPresentedEvent ()
	//{
	//	Debug.Log ("I got BannerAdScreenPresentedEvent");
	//}
	
	//void BannerAdScreenDismissedEvent ()
	//{
	//	Debug.Log ("I got BannerAdScreenDismissedEvent");
	//}
	
	//void BannerAdLeftApplicationEvent ()
	//{
	//	Debug.Log ("I got BannerAdLeftApplicationEvent");
	//}
}
