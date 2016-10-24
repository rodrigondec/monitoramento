//Programa : Teste NRF24L01 - Emissor - Botoes
//Autor : Adilson Thomsen

#include <SPI.h>
#include "nRF24L01.h"
#include "RF24.h"

#define echoPin 7 // Echo Pin
#define trigPin 8 // Trigger Pin

int maximumRange = 200; // Maximum range needed
int minimumRange = 0; // Minimum range needed
long duration, distance; // Duration used to calculate distance

//Armazena os dados enviados
int dado;

//Inicializa a placa nos pinos 9 (CE) e 10 (CS) do Arduino
RF24 radio(9,10);

//Define o endereco para comunicacao entre os modulos
const uint64_t pipe = 0xE14BC8F482LL;

void setup()
{

  //Inicializa a serial
  Serial.begin(57600);
  
  //Inicializa a comunicacao
  radio.begin();
  //Entra em modo de transmissao
  radio.openWritingPipe(pipe);

  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
}

void loop()
{


   digitalWrite(trigPin, LOW); 
   delayMicroseconds(2); 

   digitalWrite(trigPin, HIGH);
   delayMicroseconds(10); 
 
    digitalWrite(trigPin, LOW);
    duration = pulseIn(echoPin, HIGH);
     
    //Calculate the distance (in cm) based on the speed of sound.
    distance = duration/58.2;
     
    //dado = Serial.parseInt();
    Serial.print(distance);
    radio.write(&distance,sizeof(long));
    delay(1000);
}
