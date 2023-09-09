#include <SPI.h>
#include <nRF24L01.h>
#include <RF24.h>

// NRF24L01-related constants and variables
#define RF_CE_PIN 36
#define RF_CS_PIN 39
#define CHANNEL 21
RF24 radio(RF_CE_PIN, RF_CS_PIN);

void setup() {
  // Start serial communication for debugging
  Serial.begin(115200);

  // Initialize the NRF24 module
  radio.begin();
  radio.openReadingPipe(1, 0xF0F0F0E1E2LL);
  radio.setPALevel(RF24_PA_HIGH);
  radio.setChannel(CHANNEL);
  radio.startListening();
}

void loop() {
  if (radio.available()) {
    String dataPacket = "";

    // Read the received data packet from NRF24
    radio.read(&dataPacket, sizeof(dataPacket));

    // Parse received data (latitude and longitude)
    float latitude = dataPacket.substring(0, dataPacket.indexOf(',')).toFloat();
    float longitude = dataPacket.substring(dataPacket.indexOf(',') + 1).toFloat();

    // Print received latitude and longitude
    Serial.print("Received Latitude: ");
    Serial.println(latitude, 6);
    Serial.print("Received Longitude: ");
    Serial.println(longitude, 6);

    // You can add your tracking logic here
  }
}
