using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ConnectivityChecker : MonoBehaviour
{
	public static event System.Action onInternetConnect;
	public static event System.Action onInternetDisconnect;


	public static ConnectivityChecker instance;

	public float frequency = 1;
	public static bool isOnline = true;
	public bool isAwake = true;

    public static event System.Action<NetworkReachability> onInternetConnection;

    public static NetworkReachability reachability;

	void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Destroy(gameObject)
		
		DontDestroyOnLoad(gameObject);
		
	}
	void Start()
	{
		Init();
	}
	public void Sleep()
	{
		isAwake = false;
        CancelInvoke("CheckInternet");
	}
	void Restart()
	{
		Sleep();
		Init();

	}
	public void Init()
	{
		isAwake = true;
        reachability = NetworkReachability.NotReachable;
		InvokeRepeating("CheckInternet", frequency, frequency);
	}
    string Log(NetworkReachability reach)
    {
        switch (reach)
        {
            case NetworkReachability.NotReachable: return "Offline";
            case NetworkReachability.ReachableViaCarrierDataNetwork: return "Datos";
            case NetworkReachability.ReachableViaLocalAreaNetwork: return "Wifi";
        }
        return "none";
    }

    public void CheckInternet()
    {
        if (reachability != Application.internetReachability)
        {
            reachability = Application.internetReachability;            
			onInternetConnection?.Invoke(reachability);
			
			if(reachability == NetworkReachability.NotReachable)
			{
				onInternetDisconnect?.Invoke();
				isOnline = false;
			}
			else
			{
				isOnline = true;
				onInternetConnect?.Invoke();
			}
				
        }
    }
}




