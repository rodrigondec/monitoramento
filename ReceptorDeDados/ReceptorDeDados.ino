#include <SPI.h>
#include "nRF24L01.h"
#include "RF24.h"

//Armazena os dados recebidos
int dado, s1, s2,at ,temp, serialData, Leitura;
char Data[9];
bool AtivaEnvio = false;

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
  radio.openWritingPipe(pipe);
  radio.openReadingPipe(1,pipe);
  radio.startListening();  
}

void loop()
{
  dado = 0;
  
    
  if(radio.available())
  {
    if(AtivaEnvio == true)
    {    
      //Verifica se ha sinal de radio
      while(radio.available())
      {
          radio.read(&Data,11);
      }
  
      int i = 0, j;
      char d1[4], d2[4], d3[2];
      
      
      for(j = 0; Data[i] != 'L'; j++)
      {
          d1[j] = Data[i];
          ++i;
      }
  
      i++;
      d1[j] = 0;
      
      for(j = 0; Data[i] != 'M'; j++)
      {
          d2[j] = Data[i];
          ++i;
      }
      
      d2[j] = 0;
  
      d3[0] = Data[++i];
      d3[1] = 0;
      
  
      /*Serial.print("Dado1: ");
      Serial.println(d1);
      Serial.print("Dado2: ");
      Serial.println(d2);
      Serial.print("Dado3: ");
      Serial.println(d3);
      
      Serial.println(Data);*/
      
      //s1 = dado;
  
      /*while ( ! radio.available() );
      
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
    
      if(s1 > 1000 && s1 < 2000)
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
        */
  
      
      Serial.print(d1);
      Serial.print(':');
      Serial.print(d2);
      Serial.print(":0:");
      Serial.println(d3);
    }
  }

  if(Serial.available())
  {
    Leitura = Serial.parseInt();
    /*Serial.write(Leitura);      // Para Debbug
    Serial.println();*/

    switch(Leitura)
    {
      case 0:
      {
        radio.stopListening();
        /*Serial.print("Atuador: ");
        Serial.println(Leitura);*/
        radio.write(&Leitura,sizeof(int));
        radio.startListening();
      }
      break;
      
      case 1:      
      {
        radio.stopListening();
        /*Serial.print("Atuador: ");
        Serial.println(Leitura);*/
        radio.write(&Leitura,sizeof(int));
        radio.startListening();
      }
      break;
      
      case 5:
        AtivaEnvio = true;
      break;
      
      case 6:
        AtivaEnvio = false;
      break;
    }
  
  }
}
