#include <Wire.h>
#include <Adafruit_GPS.h>
#include <Adafruit_Sensor.h>
#include <Adafruit_LIS3DH.h>
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>
#include "XOR.h"

// GPS-related constants and variables
#define GPS_SERIAL Serial1
#define GPS_BAUD 9600
Adafruit_GPS GPS(&GPS_SERIAL);

// NRF24L01-related constants and variables
#define RF_CE_PIN 9
#define RF_CS_PIN 10
#define CHANNEL 21  // Set the desired channel for communication
RF24 radio(RF_CE_PIN, RF_CS_PIN);

void setup() {
  // Start serial communication for debugging
  Serial.begin(115200);

  // Initialize the GPS module
  GPS.begin(GPS_BAUD);
  GPS.sendCommand(PMTK_SET_NMEA_OUTPUT_RMCGGA);
  GPS.sendCommand(PMTK_SET_NMEA_UPDATE_1HZ);
  delay(1000);

  // Initialize the NRF24 module
  radio.begin();
  radio.openWritingPipe(0xF0F0F0E1E2LL);
  radio.setPALevel(RF24_PA_HIGH);
  radio.setChannel(CHANNEL);  // Set the communication channel
}

void loop() {
  char c = GPS.read();
  
  // Check if a new NMEA sentence is received from the GPS
  if (GPS.newNMEAreceived()) {
    if (!GPS.parse(GPS.lastNMEA())) {
      return;  // Parsing failed, skip this sentence
    }

    // Extract latitude and longitude from GPS data
    float latitude = GPS.latitudeDegrees;
    float longitude = GPS.longitudeDegrees;

    // Create a data packet with latitude and longitude
    String dataPacket = String(latitude, 6) + "," + String(longitude, 6);

    // Send the data packet via NRF24
    radio.stopListening();   // Stop listening to receive mode
    radio.write(&dataPacket, sizeof(dataPacket));  // Send the data
    radio.startListening();  // Resume listening mode

    // Print the sent data for debugging
    Serial.println("Data Sent: " + dataPacket);
  }
}
