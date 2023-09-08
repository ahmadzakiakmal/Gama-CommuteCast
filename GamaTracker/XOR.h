// XOR encryption function to encrypt exchanged data with a key
#ifndef XOR_H
#define XOR_H
#include <Arduino.h>

// XOR encryption function
void xorEncrypt(String& data, const char* key) {
  int keyLength = strlen(key);
  int dataLength = data.length();
  
  // Loop through each character in the data
  for (int i = 0; i < dataLength; i++) {
    // XOR the current character with the corresponding key character
    data[i] = data[i] ^ key[i % keyLength];
  }
}

#endif

// Example usage:
// String dataToEncrypt = "Hello, World!";
// xorEncrypt(dataToEncrypt, "zakong");
// Serial.println(dataToEncrypt);
