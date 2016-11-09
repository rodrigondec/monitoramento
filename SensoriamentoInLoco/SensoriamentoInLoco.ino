#include <VirtualWire.h>
 
void setup()
{
  Serial.begin(9600);
  
  vw_set_tx_pin(8);           //Define o pino 8 do Arduino como pino de dados do transmissor
  vw_setup(2000);   // Bits per sec
}

char ResultadoSensorCharMsg[10];
int leitura;

void loop()
{ 
  leitura = map(analogRead(A0), 0, 1023, 0, 100);
  itoa(leitura, ResultadoSensorCharMsg,10);
  
  int i;
  for(i = 0; ResultadoSensorCharMsg[i] != 0; i++);
  
  ResultadoSensorCharMsg[i] = 'L';
  ResultadoSensorCharMsg[i+1] = 'D';
  ResultadoSensorCharMsg[i+2] = 0;

  Serial.print("Enviando: ");
  Serial.println(ResultadoSensorCharMsg);
  
  send(ResultadoSensorCharMsg);
    
  delay(1000);
} 
 
void send (char *message)
{
  vw_send((uint8_t *)message, strlen(message));
  vw_wait_tx(); // Aguarda o envio de dados
}
