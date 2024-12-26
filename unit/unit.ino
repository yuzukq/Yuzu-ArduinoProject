void setup() {
  Serial.begin(9600);
}

void loop() {
  int x = analogRead(0);
  int y = analogRead(1);
  int z = analogRead(2);
  
  
  String dataString = String(x) + "," + String(y) + "," + String(z);
  Serial.println(dataString);
  
  delay(20);
}