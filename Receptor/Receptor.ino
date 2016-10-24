//Programa : Teste NRF24L01 - Receptor - Led
//Autor : Adilson Thomsen

#include <SPI.h>
#include "nRF24L01.h"
#include "RF24.h"

//Armazena os dados recebidos
int recebidos;
float sensor;

//Inicializa a placa nos pinos 9 (CE) e 10 (CS) do Arduino
RF24 radio(9,10);

//Define o endereco para comunicacao entre os modulos
const uint64_t pipe = 0xE14BC8F482LL;

//Define o pino do leds
int LED1 = 12;

void setup()
{
  //Define o pino do led como saida
  pinMode(LED1, OUTPUT);

  //Inicializa a serial
  Serial.begin(57600);
  
  //Inicializa a comunicacao
  radio.begin();
  //Entra em modo de recepcao
  radio.openReadingPipe(1,pipe);
  radio.startListening();
}

int recebeu = 0;

void loop()
{

  while ( ! radio.available() );
  
  //Verifica se ha sinal de radio
  while(radio.available())
  {
      radio.read(&sensor,sizeof(float));
  }

  //analogWrite(LED1, recebidos);
  
  Serial.print("Dados recebidos : ");    
  Serial.println(sensor);
  delay(200);
  
}
