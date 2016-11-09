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

#define atuador 4

int vatuador;

char Envio[15];

void setup()
{
  pinMode(atuador, OUTPUT);
  Serial.begin(9600);
  vw_set_rx_pin(8);           // Define o pino 7 do Arduino como entrada de dados do receptor
  //vw_set_tx_pin(7);          
  vw_setup(2000);             // Bits por segundo
  pinMode(12, INPUT);
  
  radio.begin();
  
  //Entra em modo de recepcao
  radio.openWritingPipe(pipe);
  radio.openReadingPipe(1,pipe);
  radio.startListening();
  
  // Inicia Receptor RF433
  vw_rx_start();
}

int lm35, mult, value;
int dado;

void loop()
{     
  dado = 0;
  
  uint8_t message[VW_MAX_MESSAGE_LEN];
  uint8_t msgLength = VW_MAX_MESSAGE_LEN;
  
  if(vw_get_message(message, &msgLength)) // Non-blocking
  {
    value = 0;
       
    for (int i = 0; i < msgLength-2; i++)
    {
       //Serial.write(message[i]);
          
       mult = 1;
          
       for(int k = 0; k < msgLength-i-3; k++)
       {
         mult *= 10;
       }
         
       if(i != 2)
         value += ((int)((char*)message[i]) - '0') * (mult);
       else
         value += ((int)((char*)message[i]) - '0');          
    }

    lm35 = (float(analogRead(A0))*5/(1023))/0.01;
    
    //value += 1000;
    
    radio.stopListening();
    /*
    Serial.print("Sensor1: ");
    Serial.println(value);
    radio.write(&value,sizeof(int));
    //delay(10);
      
    Serial.print("Sensor2: ");
    Serial.println(lm35);
    radio.write(&lm35,sizeof(int));
    //delay(10);
    
    Serial.print("Atuador: ");*/
    
    if(digitalRead(4))
    {
      //Serial.println("Ligado");
      vatuador = 1;
      //radio.write(&vatuador,sizeof(int));
    }
    else
    {
      //Serial.println("Desligado");
      vatuador = 0;
      //radio.write(&vatuador,sizeof(int));
    }

    String teste = (String)value + "L" + (String)lm35 + "M" + (String)vatuador;
    const char * envio = teste.c_str();
 
    Serial.println(envio);
    radio.write(envio,11);
    delay(50);
    
    radio.startListening();
  }  

  if(radio.available())
  {
    //Verifica se ha sinal de radio
    
    Serial.print("Dado Recebido: ");
    
    while(radio.available())
    {
        radio.read(&dado,sizeof(int));
        Serial.print("Dado Recebido: ");
        Serial.println(dado);
    }
    
    /*radio.stopListening();
    Serial.print("Enviando de volta: ");
    Serial.println(dado);
    radio.write(&dado,sizeof(int));
    delay(30);
    radio.startListening();*/

    if(dado == 1)
    {
      digitalWrite(atuador, HIGH);
    }
    else
    {
      digitalWrite(atuador, LOW);
    }
  }
  
}
