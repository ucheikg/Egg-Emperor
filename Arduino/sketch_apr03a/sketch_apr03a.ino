const int piezoPin = A0;
const int throttle = A1;
const int punchingBag = 7;
const int steeringWheel = A2;
const int turret = 8;
int rightTurn = 341;
int middleValue = 681;
int leftTurn = 1023;
int throttlevalue = 0;
int steeringValue = 0;
int piezoValue = 0;
int threshold = 700;
bool screaming = false;
bool left;
bool right;
char handshake = 'x';

void setup() {
  Serial.begin(9600);
  pinMode(punchingBag, INPUT_PULLUP);
  pinMode(turret, INPUT_PULLUP);

  bool online = false;

  while (!online) {
    while (!Serial.available()) {
    }

    char inp = Serial.read();
    //If we receive the handshake character then we are online allowed to continue
    if (inp == handshake) {
      Serial.println(handshake);
      online = true;
    }
  }
}

void loop() {
  piezoValue = analogRead(piezoPin);
  throttlevalue = analogRead(throttle);
  steeringValue = analogRead(steeringWheel);

  if (piezoValue > threshold) {
    screaming = true;
  } else {
    screaming = false;
  }

  if (steeringValue < rightTurn) {
    right = true;
    left = false;
  }

  if (rightTurn < steeringValue < middleValue) {
    right = false;
    left = false;
  }

  if (middleValue < steeringValue <= leftTurn) {
    left = true;
    right = false;
  }




  if (!Serial.available()) {
    return;
  }
  //otherwise read the serial
  char inp = Serial.read();

  //If we receive 'a' then I know that I want to read the analogue sensor so send back that data
  if (inp == 'a') {
    Serial.println(throttlevalue);
  }

  if (inp == 'b') {
    Serial.println(screaming);
  }

  if (inp == 'q') {
    Serial.println(digitalRead(punchingBag));
  }

  if (inp == 's') {
    Serial.println(right);
  }

  if (inp == 'd') {
    Serial.println(left);
  }
  if (inp = 'm'){
    Serial.println(turret);
  }


}
