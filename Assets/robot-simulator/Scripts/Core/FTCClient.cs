using System;
using System.IO;
using System.Net.Sockets;
using UnityEngine;

public class FTCClient : MonoBehaviour
{
    private TcpClient client;
    private StreamWriter writer;
    private StreamReader reader;

    public float gyroData;
    public float distanceData;

    void Start()
    {
        ConnectToFTCServer();
    }

    void ConnectToFTCServer()
    {
        try
        {
            client = new TcpClient("127.0.0.1", 9999);
            writer = new StreamWriter(client.GetStream()) { AutoFlush = true };
            reader = new StreamReader(client.GetStream());

            Debug.Log("Connected to FTC Java Server!");
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to connect: " + e.Message);
        }
    }

    public void SendCommand(string command)
    {
        if (writer != null)
        {
            writer.WriteLine(command);
            Debug.Log("Sent to FTC: " + command);

            // Read response from Java (sensor data)
            string response = reader.ReadLine();
            ParseSensorData(response);
        }
    }

    void ParseSensorData(string data)
    {
        // Example: "Gyro: 180.3, Distance: 45.2"
        string[] parts = data.Split(',');
        if (parts.Length == 2)
        {
            gyroData = float.Parse(parts[0].Split(':')[1]);
            distanceData = float.Parse(parts[1].Split(':')[1]);

            Debug.Log($"Updated Sensors - Gyro: {gyroData}, Distance: {distanceData}");
        }
    }

    void OnApplicationQuit()
    {
        writer?.Close();
        reader?.Close();
        client?.Close();
    }
}
