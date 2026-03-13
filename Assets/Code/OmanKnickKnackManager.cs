using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System;

public class OmanCubeLevel4 : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshPro timeText;
    public TextMeshPro weatherText;

    [Header("Scene Elements")]
    public Light sceneLight;               
    public ParticleSystem rainParticles; 
    public GameObject sunObject;           
    public GameObject cloudObject;        

    [Header("Weather/Location Info")]
    public string city = "Muscat,OM";
    public string apiKey = "397d8818f47c7459c98a92dd02f5240c";

    void Start()
    {
        InvokeRepeating("UpdateClock", 0f, 60f);   
        StartCoroutine(UpdateWeather());          
    }

    // -------------------- Time Handling --------------------
    void UpdateClock()
    {
        DateTime omanTime = DateTime.UtcNow.AddHours(4);
        timeText.text = "Local Time: " + omanTime.ToString("HH:mm");

        // --- Level 4: Change scene lighting based on time ---
        if (sceneLight != null)
        {
            if (omanTime.Hour >= 6 && omanTime.Hour < 18)   // Day
            {
                sceneLight.intensity = 1f;
                if (sunObject != null) sunObject.SetActive(true);
                if (cloudObject != null) cloudObject.SetActive(false);
            }
            else                                             // Night
            {
                sceneLight.intensity = 0.2f;
                if (sunObject != null) sunObject.SetActive(false);
                if (cloudObject != null) cloudObject.SetActive(true);
            }
        }
    }

    // -------------------- Weather Handling --------------------
    IEnumerator UpdateWeather()
    {
        while (true)
        {
            string url = "https://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + apiKey + "&units=metric";

            UnityWebRequest request = UnityWebRequest.Get(url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                WeatherData data = JsonUtility.FromJson<WeatherData>(request.downloadHandler.text);
                weatherText.text = "Weather: " + data.main.temp + "°C";

                // --- Level 4: Change scene based on weather ---
                if (rainParticles != null)
                {
                    if (data.weather.Length > 0 && data.weather[0].main.ToLower().Contains("rain"))
                        rainParticles.Play();
                    else
                        rainParticles.Stop();
                }

                // Example: show clouds for cloudy weather
                if (cloudObject != null)
                {
                    if (data.weather.Length > 0 && data.weather[0].main.ToLower().Contains("cloud"))
                        cloudObject.SetActive(true);
                    else
                        cloudObject.SetActive(false);
                }
            }
            else
            {
                weatherText.text = "Weather: unavailable";
                if (rainParticles != null) rainParticles.Stop();
                if (cloudObject != null) cloudObject.SetActive(false);
            }

            yield return new WaitForSeconds(600f); // Update every 10 minutes
        }
    }

    // -------------------- Helper Classes --------------------
    [Serializable]
    public class Main
    {
        public float temp;
    }

    [Serializable]
    public class WeatherData
    {
        public Weather[] weather;
        public Main main;
    }

    [Serializable]
    public class Weather
    {
        public string main;
    }
}