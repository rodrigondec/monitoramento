//Programa : Módulo RF Transmissor com Arduino Uno
 
#include <VirtualWire.h>
 
void setup()
{
  Serial.begin(9600);
  //Define o pino 8 do Arduino como 
  //o pino de dados do transmissor
  vw_set_tx_pin(8);
  vw_setup(2000);   // Bits per sec
  Serial.println("Digite o texto e clique em ENVIAR...");
}

char ResultadoSensorCharMsg[10];
float leitura;

void loop()
{
  char data[40];
  
  /*int numero;
  
  numero = Serial.readBytesUntil(13,data,40);
  data[numero] = 0;
    
  Serial.print("Enviado : ");
  Serial.print(data);
  Serial.print(" - Caracteres : ");
  Serial.println(strlen(data));
  
  //Envia a mensagem para a rotina que transmite os dados via RF
  send(data);*/
  
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
    
  delay(2000);
      
} 
 
void send (char *message)
{
  vw_send((uint8_t *)message, strlen(message));
  vw_wait_tx(); // Aguarda o envio de dados
}
