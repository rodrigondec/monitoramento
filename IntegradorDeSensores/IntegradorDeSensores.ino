#include <VirtualWire.h>
#include <SPI.h>
#include "nRF24L01.h"
#include "RF24.h"
 
byte message[VW_MAX_MESSAGE_LEN];    // Armazena as mensagens recebidas
byte msgLength = VW_MAX_MESSAGE_LEN; // Armazena o tamanho das mensagens

//Inicializa a placa nos pinos 9 (CE) e 10 (CS) do Arduino
RF24 radio(9,10);

//Define o endereco para comunicacao entre os modulos
const uint64_t pipe = 0xE14BC8F482LL;

void setup()
{
  Serial.begin(9600);
  vw_set_rx_pin(7);           // Define o pino 5 do Arduino como entrada de dados do receptor
  vw_setup(2000);             // Bits por segundo
  vw_rx_start();              // Inicializa o receptor 
  
  radio.begin();
  //Entra em modo de transmissao
  radio.openWritingPipe(pipe);
}

int flag, lm35, mult, value;

void loop()
{   
  flag = 0;
  
  uint8_t message[VW_MAX_MESSAGE_LEN];
  uint8_t msgLength = VW_MAX_MESSAGE_LEN;
  
  if(vw_get_message(message, &msgLength)) // Non-blocking
  {
       value = 0;
       
       for (int i = 0; i < msgLength; i++)
       {
          //Serial.write(message[i]);
          
          mult = 1;
          
          for(int k = 0; k < msgLength-i-1; k++)
          {
            mult *= 10;
          }
          
          if(i != 2)
            value += ((int)((char*)message[i]) - '0') * (mult);
          else
            value += ((int)((char*)message[i]) - '0');          
       }

       value += 1000;
       lm35 = (float(analogRead(A0))*5/(1023))/0.01;
       
       Serial.print("Sensor1: ");
       Serial.println(value);
       radio.write(&value,sizeof(int));
       delay(50);
       
       Serial.print("Sensor2: ");
       Serial.println(lm35);
       radio.write(&lm35,sizeof(int));
       delay(50);
  }
}
