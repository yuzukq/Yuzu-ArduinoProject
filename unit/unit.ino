// キャリブレーション用の変数
int baseX = 0;
int baseY = 0;
int baseZ = 0;
bool isCalibrated = false;

const int BUTTON_PIN = 2;  // タクトスイッチのピン番号

void setup() {
  Serial.begin(9600);
  pinMode(BUTTON_PIN, INPUT_PULLUP);  
}

void loop() {
  int x = analogRead(0);
  int y = analogRead(1);
  int z = analogRead(2);
  
  // スイッチの状態を常時モニタリング
  int buttonState = digitalRead(BUTTON_PIN);
  Serial.print("Switch state: ");
  Serial.println(buttonState);  // HIGH（1）なら押下、LOW（0）なら未押下
  
  // キャリブレーション
  if (buttonState == HIGH) {
    baseX = x;
    baseY = y;
    baseZ = z;
    isCalibrated = true;
    Serial.println("Calibration executed");
    Serial.print("Base: X=");
    Serial.print(baseX);
    Serial.print(", Y=");
    Serial.print(baseY);
    Serial.print(", Z=");
    Serial.println(baseZ);
    delay(500); // チャタ防止
  }
  
  // キャリブレーション後の値計算
  if (isCalibrated) {
    x = x - baseX;
    y = y - baseY;
    z = z - baseZ;
  }
  
  String dataString = String(x) + "," + String(y) + "," + String(z);
  Serial.println(dataString);
  
  delay(100);  // デバッグ出力用: 100ms,実装時:20ms
}
