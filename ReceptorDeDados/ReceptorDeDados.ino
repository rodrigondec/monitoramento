#include <SPI.h>
#include "nRF24L01.h"
#include "RF24.h"

//Armazena os dados recebidos
int dado, s1, s2, temp;

//Inicializa a placa nos pinos 9 (CE) e 10 (CS) do Arduino
RF24 radio(9,10);

//Define o endereco para comunicacao entre os modulos
const uint64_t pipe = 0xE14BC8F482LL;

void setup()
{
  //Inicializa a serial
  Serial.begin(9600);
  
  //Inicializa a comunicacao
  radio.begin();
  
  //Entra em modo de recepcao
  radio.openReadingPipe(1,pipe);
  radio.startListening();
}

void loop()
{
  dado = 0;
  
  while ( ! radio.available() );
  
  //Verifica se ha sinal de radio
  while(radio.available())
  {
      radio.read(&dado,sizeof(int));
  }

  s1 = dado;

  
  while ( ! radio.available() );
  
  //Verifica se ha sinal de radio
  while(radio.available())
  {
      radio.read(&dado,sizeof(int));
  }
  
  s2 = dado;

  if(s1 > 500)
  {
    s1 -= 1000;
  }
  else if(s2 > 500)
  {
    s2 -= 1000;
    temp = s2;
    s2 = s1;
    s1 = temp;
  }

    
  Serial.print(s1);
  Serial.print(':');
  Serial.print(s2);
  Serial.println(":0");
  
}
