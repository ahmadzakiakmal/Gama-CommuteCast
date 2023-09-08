#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>
#include "XOR.h"

// NRF24L01-related constants and variables
#define RF_CE_PIN 9
#define RF_CS_PIN 10
#define CHANNEL 21  // Set the same channel as on the transmitter
RF24 radio(RF_CE_PIN, RF_CS_PIN);

void setup() {
  // Start serial communication for debugging
  Serial.begin(115200);

  // Initialize the NRF24 module
  radio.begin();
  radio.openReadingPipe(1, 0xF0F0F0E1E2LL);
  radio.setPALevel(RF24_PA_HIGH);
  radio.setChannel(CHANNEL);  // Set the same communication channel as on the transmitter
  radio.startListening();  // Start listening for incoming data
}

void loop() {
  if (radio.available()) {
    String dataPacket = "";

    // Read the received data packet from NRF24
    radio.read(&dataPacket, sizeof(dataPacket));

    // Parse received data (latitude and longitude)
    float latitude = dataPacket.substring(0, dataPacket.indexOf(',')).toFloat();
    float longitude = dataPacket.substring(dataPacket.indexOf(',') + 1).toFloat();

    // Process and use the latitude and longitude data as needed
    Serial.print("Latitude: ");
    Serial.println(latitude, 6);
    Serial.print("Longitude: ");
    Serial.println(longitude, 6);

    // You can add your tracking logic here
  }
}
