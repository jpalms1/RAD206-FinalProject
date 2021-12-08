# RAD206-FinalProject

# Software:
- This project was created using Unity 2020.3.19f1 and Arduino version 1.8.10

# Hardware:
- This project used a HoloLens 2 developed by Microsoft Corporation found at: 
	https://www.microsoft.com/en-us/hololens/hardware
- The microcontorller used for servo control is the Arduino Mega 2560 Rev3 found at: 
	https://store-usa.arduino.cc/products/arduino-mega-2560-rev3?selectedStore=us
- The servos used for development were the Hextrinik HXT500 6.2g 0.6kg .08sec Micro Servo found at: 
	https://www.amazon.com/gp/product/B00WFHMXHY/ref=ppx_yo_dt_b_search_asin_title?ie=UTF8&psc=1
- The rack and pinion mechanism used to provide normal forces to the user's wrist were 3D printed using the
	https://formlabs.com/3d-printers/form-3/
- The housings around the wrist-worn device were 3D printed using the
	https://www.makerbot.com/3d-printers/replicator/

#Setup:	
Unity Hub:
	- In Unity Hub, open the Unity project folder named FinalProject in the path: 
			[your download location]\RAD206-FinalProject\Final Project

Unity Editor:
	- Once the Hololens 2 Holographic Remoting and Arduino serial communication is setup, 
	press the Play button in the Unity Editor to start the simulation

Hololens 2 Setup:
	- This project is run using the Hololens' Holographic Remoting in the Unity Editor so that the serial 
	communication between the Arduino microcontroller and Unity can allow the wrist-worn device to provide haptic feedback 
	- Please follow the instructions to setup Holographic Remoting in the Unity Editor (Unity 2020 + OpenXR): 
		https://docs.microsoft.com/en-us/windows/mixed-reality/develop/unity/unity-play-mode?tabs=openxr

- Arduino Setup:
	- Plug in the Arduino connected to your servo-driven wearable device to a USB port on your computer
		- Find the folder with path [your download location]\RAD206-FinalProject\Final Project\UnityArduinoComms 
			and open the file UnityArduinoComms.ino
		- Download the program to the Arduino and make note of the COM port being used
		- In the Unity Editor, find the script SerialComms.cs in the file path Assets\Scripts
		- One line 13 of SerialComms.cs, change the String variable to "COM[#]" where "[#]" is the number (e.g. "COM3")
			of the COM port used to upload the UnityArduinoComms.ino program to the Arduino
		- Recompile the project in Unity Editor and ensure the change was made by checking the "Port Name" public variable
			attached to the GameObject "Needle"

