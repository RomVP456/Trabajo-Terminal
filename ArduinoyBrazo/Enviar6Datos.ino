int Potenciometros[] = {0,0,0,0,0,0};
int valor = 0;
void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
}

void loop() {
  // put your main code here, to run repeatedly:
  valor = analogRead(0);
  Serial.print(valor);
  for (int i=1;i<5;i++){
    Serial.print(",");
    valor = analogRead(i);
    Serial.print(valor);
  }
  Serial.print(",");
  valor = analogRead(5);
  Serial.println(valor);
  delay(20);
}
