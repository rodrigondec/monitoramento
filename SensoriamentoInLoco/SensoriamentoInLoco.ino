#include <VirtualWire.h>
 
void setup()
{
  Serial.begin(9600);
  
  vw_set_tx_pin(8);           //Define o pino 8 do Arduino como pino de dados do transmissor
  vw_set_rx_pin(7);           // Define o pino 7 do Arduino como entrada de dados do receptor
  vw_setup(2000);   // Bits per sec
  pinMode(11, OUTPUT);
}

char ResultadoSensorCharMsg[10];
int leitura, flag, value, mult;

void loop()
{ 
  vw_rx_start();
  
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

      if(value > 10)
      {
        digitalWrite(11, HIGH);
      }
      else
      {
        digitalWrite(11,LOW);
      }

      Serial.print("Recebido: ");
      Serial.println(value);
      Serial.println();
  }

  vw_rx_stop();
  leitura = map(analogRead(A0), 0, 1023, 0, 100);
  itoa(leitura, ResultadoSensorCharMsg,10);
  
  Serial.print("Enviando: ");
  Serial.println(ResultadoSensorCharMsg);

  send(ResultadoSensorCharMsg);
    
  //delay(1500);
} 
 
void send (char *message)
{
  vw_send((uint8_t *)message, strlen(message));
  vw_wait_tx(); // Aguarda o envio de dados
}
