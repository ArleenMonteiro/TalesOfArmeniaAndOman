using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System;

public class ARCubeInfo : MonoBehaviour
{
    public TextMeshPro timeText;
    public TextMeshPro weatherText;

    public string city = "Vagharshapat,AM";
    public string apiKey = "397d8818f47c7459c98a92dd02f5240c";

    void Start()
    {
        InvokeRepeating("UpdateClock", 0f, 60f);
        StartCoroutine(UpdateWeather());
    }

    void UpdateClock()
    {
        DateTime armeniaTime = DateTime.UtcNow.AddHours(4);
        timeText.text = "Local Time: " + armeniaTime.ToString("HH:mm");
    }

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
            }
            else
            {
                weatherText.text = "Weather: unavailable";
            }

            yield return new WaitForSeconds(600f);
        }
    }

    [Serializable]
    public class Main
    {
        public float temp;
    }

    [Serializable]
    public class WeatherData
    {
        public Main main;
    }
}