#include <SPI.h>
#include "nRF24L01.h"
#include "RF24.h"

//Armazena os dados recebidos
int dado, s1, s2,at ,temp, serialData;

//Inicializa a placa nos pinos 9 (CE) e 10 (CS) do Arduino
RF24 radio(9,10);

//Define o endereco para comunicacao entre os modulos
const uint64_t pipe  = 0xE14BC8F482LL;

void setup()
{
  //Inicializa a serial
  Serial.begin(9600);
  
  //Inicializa a comunicacao
  radio.begin();
  
  //Entra em modo de recepcao
  radio.openReadingPipe(1,pipe);
  radio.openWritingPipe(pipe);
  radio.startListening();  
}

void loop()
{
  dado = 0;

  if(radio.available())
  {
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

    while ( ! radio.available() );
    
    //Verifica se ha sinal de radio
    while(radio.available())
    {
        radio.read(&dado,sizeof(int));
    }
    
    at = dado;
  
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
  
    if(s1 < 0)
    {
      s1 = 0;
    }
  
    if(s2 < 0)
    {
      s2 = 0;
    }
      
    Serial.print(s1);
    Serial.print(':');
    Serial.print(s2);
    Serial.print(":0:");
    Serial.println(at);
  }

  if(Serial.available())
  {
    serialData = Serial.parseInt();
    
    radio.stopListening();
    
    /*Serial.print("Atuador: ");
    Serial.println(serialData);*/
    radio.write(&serialData,sizeof(int));
    delay(100);

    radio.startListening();
  }
  
}
