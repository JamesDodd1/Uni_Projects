# Final Year Project

A mobile app which extends street map's route pathing functionality to allow paths to be plotted to indoor areas.


## Table of Contents
1. [General Info](#1-general-info)
2. [Technologies](#2-technologies)
3. [Setup](#3-Setup)
4. [Features](#4-features)
5. [Status](#5-status)


## 1. General Info
The iPhone mobile app inports paths and rooms for part of the University of Greenwich.  When the user selects a indoor destinations the program plots the best route to the building's entrance and then from the entrance to the indoor location.


## 2. Technologies
- Swift
- [HERE SDK for iOS](https://developer.here.com/documentation/ios-premium/3.16/dev_guide/topics/overview.html) (ver 3.16)


## 3. Setup
1. Download the IndoorMaps folder
2. Open the `IndoorMaps.xcwordspace` file __NOT__ `IndoorMaps.xcodeproj`


## 4. Features
- Inports indoor map room and path data
- Draws path from current location to destination
- Selects alternative route if shortest path has a major delay (e.g. many simulated people)


## 5. Status
This project is complete
