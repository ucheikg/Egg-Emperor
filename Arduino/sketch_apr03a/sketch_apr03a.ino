const int piezoPin = A0;
const int throttle = A1;
const int punchingBag = 7;
const int steeringWheel = A2;
const int turret = 8;

int rightTurn = 341;
int middleValue = 681;
int leftTurn = 1023;
int steeringValue = 0;
bool left;
bool right;

int throttlevalue = 0;
int Stop = 0;
int slow = 341;
int medium = 682;
int fast = 1023;
bool point1;
bool point2;
bool point3;
bool Break;

int piezoValue = 0;
int threshold = 700;
bool screaming = false;

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

  if (throttlevalue = Stop) {
    point1 = false;
    point2 = false;
    point3 = false;
  }

  if (Stop < throttlevalue <= slow) {
    point1 = true;
    point2 = false;
    point3 = false;
    Break = false;
  }
  if (slow < throttlevalue <= medium) {
    point1 = false;
    point2 = true;
    point3 = false;

  }
  if (medium < throttlevalue <= fast) {
    point1 = false;
    point2 = false;
    point3 = true;

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
  if (inp = 'm') {
    Serial.println(turret);
  }
  
  if (inp = 'h') {
  Serial.println(point1);
  }
  if (inp = 'n') {
  Serial.println(point2);
  }
  
  if (inp = 'f') {
  Serial.println(point3);
  }

}
