// setting the Pins to be read
const int piezoPin = A0;
const int throttle = A1;
const int punchingBag = 7;
const int steeringWheel = A2;
const int turret = 8;

// steering wheel values
int rightTurn = 341;
int middleValue = 681;
int leftTurn = 1023;
int steeringValue = 0;
bool left;
bool right;

// throttle values
int throttlevalue = 0;
int Stop = 0;
int slow = 341;
int medium = 682;
int fast = 1023;
bool point1 = false;
bool point2 = false;
bool point3 = false;
bool breaks;

// voice module value with threshold
int piezoValue = 0;
int threshold = 700;
bool screaming = false;

char handshake = 'x';

void setup() {
  Serial.begin(9600);
  pinMode(punchingBag, INPUT_PULLUP);
  pinMode(turret, INPUT_PULLUP);

  bool online = false;
// checks if a connection is possible using handhsake x
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
  // set values to each of their respective categories;
  piezoValue = analogRead(piezoPin);
  throttlevalue = analogRead(throttle);
  steeringValue = analogRead(steeringWheel);

  // checks if player screams loud enough for the value to pass the thresshold
  // if yes then it will make screaming true
  if (piezoValue > threshold) {
    screaming = true;
  } else {
    screaming = false;
  }

  // gives a bull output for unity to read

  // bool outputs depend on on the direction the potentiometer has been turned 1023 being its max turn and 0 being it minimun turn 
  //checks if it is turned to the right
  if (steeringValue < rightTurn) {
    right = true;
    left = false;
  }
// checks if it is in the middle
  if (rightTurn < steeringValue && steeringValue < middleValue) {
    right = false;
    left = false;
  }
// checks if its turned to the left
  if (middleValue < steeringValue && steeringValue <= leftTurn) {
    left = true;
    right = false;
  }
// checks if its been turned all the way back
  if (throttlevalue == Stop) {
    point1 = false;
    point2 = false;
    point3 = false;
    breaks = true;
  }
// checks if it has been turned slightly foward
  if (Stop < throttlevalue && throttlevalue < slow) {
    point1 = true;
    point2 = false;
    point3 = false;
  }
  // checks if it is in the middle
  if (slow < throttlevalue && throttlevalue < medium) {
    point1 = false;
    point2 = true;
    point3 = false;
// checks if it is fully pushed foward
  }
  if (medium < throttlevalue && throttlevalue  <= fast) {
    point1 = false;
    point2 = false;
    point3 = true;

  }
// sneds a charcter to unity so it knows which data to read from;
  if (!Serial.available()) {
    return;
  }
  //otherwise read the serial
  char inp = Serial.read();

  //If we receive the specific character mentioned then send the data attached
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
  if (inp == 'm') {
    Serial.println(digitalRead(turret));
  }
  
  if (inp == 'h') {
  Serial.println(point1);
  }
  if (inp == 'n') {
  Serial.println(point2);
  }
  
  if (inp == 'f') {
  Serial.println(point3);
  }

  if (inp == 'o'){
    Serial.println(breaks);
  }

}
