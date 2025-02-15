import java.io.*;
import java.net.*;

public class FTCServer {
    private static final int PORT = 9999;

    public static void main(String[] args) {
        try (ServerSocket serverSocket = new ServerSocket(PORT)) {
            System.out.println("FTC Server started. Waiting for Unity...");

            while (true) {
                try (Socket clientSocket = serverSocket.accept();
                     BufferedReader in = new BufferedReader(new InputStreamReader(clientSocket.getInputStream()));
                     PrintWriter out = new PrintWriter(clientSocket.getOutputStream(), true)) {

                    System.out.println("Connected to Unity!");

                    String inputLine;
                    while ((inputLine = in.readLine()) != null) {
                        System.out.println("Received from Unity: " + inputLine);

                        // Simulate sensor data
                        String sensorData = "Gyro: " + (Math.random() * 360) + ", Distance: " + (Math.random() * 100);
                        out.println(sensorData);  // Send sensor data back to Unity
                    }
                }
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
