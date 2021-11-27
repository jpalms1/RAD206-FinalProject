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

#Setup:
If you are using the exact hardware and software setup the developer used with the app already instaled to the HoloLens2:
	- Go to [your download location]\RAD206-FinalProject\Final Project\Builds
	- Open "FinalProject.sln"
	- Select ARM64 architecture and Release
	- Press play button

Else:
	- In Unity Hub, open the Unity project folder named FinalProject in the path: 
		[your download location]\RAD206-FinalProject\Final Project
	- Plug in the Arduino connected to your servo-driven wearable device to a USB port on your computer
	- Find the folder with path [your download location]\RAD206-FinalProject\Final Project\UnityArduinoComms 
		and open the file UnityArduinoComms.ino
	- Download the program to the Arduino and make note of the COM port being used
	- In the Unity Editor, find the script SerialComms.cs in the file path Assets\Scripts
	- One line 13 of SerialComms.cs, change the String variable to "COM[#]" where "[#]" is the number (e.g. "COM3")
		of the COM port used to upload the UnityArduinoComms.ino program to the Arduino
	- Recompile the project in Unity Editor and ensure the change was made by checking the "Port Name" public variable
		attached to the GameObject "Needle" in the path: MixedRealityPlayspace/Main Camera/Needle
	- Go to File > Build Settings: 
		- Set Target Device to Hololens
		- Set Architecture to ARM64
		- Select Build
		- Create a folder to store the build files
		- In that build folder, open "FinalProject.sln"
		- Select ARM64 architecture and Release
		- Press play button