#include <Wire.h>
#include <TinyGPS++.h>
#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>

// Define the hardware serial port for GPS communication (Serial2)
#define GPS_SERIAL Serial2

// Create a TinyGPS++ object
TinyGPSPlus gps;

// NRF24L01-related constants and variables
#define RF_CE_PIN 36
#define RF_CS_PIN 39
#define CHANNEL 21
RF24 radio(RF_CE_PIN, RF_CS_PIN);

void setup() {
  // Start serial communication for debugging
  Serial.begin(115200);

  // Initialize the GPS module (Serial2)
  GPS_SERIAL.begin(9600);

  // NRF24L01 initialization
  radio.begin();
  radio.openWritingPipe(0xF0F0F0E1E2LL);
  radio.setPALevel(RF24_PA_HIGH);
  radio.setChannel(CHANNEL);
}

void loop() {
  // Check if data is available from the GPS module (Serial2)
  while (GPS_SERIAL.available() > 0) {
    char c = GPS_SERIAL.read();

    // Feed the GPS data to the TinyGPS++ library
    gps.encode(c);

    // Check if a full GPS fix is available
    if (gps.location.isUpdated()) {
      // Get latitude and longitude from the TinyGPS++ object
      float latitude = gps.location.lat();
      float longitude = gps.location.lng();

      // Print latitude and longitude for debugging
      // Serial.print("Latitude: ");
      // Serial.println(latitude, 6);
      // Serial.print("Longitude: ");
      // Serial.println(longitude, 6);

      // NRF24L01 Data Transmission
      String dataPacket = String(latitude, 6) + "," + String(longitude, 6);
      radio.stopListening();
      radio.write(&dataPacket, sizeof(dataPacket));
      radio.startListening();
    }
  }
}
