# Advanced Programming Coursework

An application for a dashboard for a train on a simulated journey.


## Table of Contents
1. [General Info](#1-general-info)
2. [Technologies](#2-technologies)
3. [Setup](#3-Setup)
4. [Features](#4-features)
5. [Status](#5-status)


## 1. General Info
The dashboard within this program contains four different types of display indicators.  The values of the indicators can be manually set or automatically adjust when the simulation is run.

__Indicators Types:__
- Vertical bar
- Digital display
- Traffic light
- Dial


## 2. Technologies
- Java (ver 15.0.1)


## 3. Setup
1. Download TrainDashboard folder 
2. Open folder with a Java IDE
3. Run the main method located in `TrainDashboard/src/Main/TrainDashboard.java`


## 4. Features
- Each type of indicator is stored as a JavaBean components
- Multiple design patterns used
- JUnit testing for the indicators
- Threads to seemlessly transition the indicators from their current position to a new position

__Dashboard__
<p float="left">
    <img src="./Images/Dashboard_Startup.png" alt="Dashboard with fuel at 100%, speed at 0, temperature at 30 and door state closed" height=300 width=auto />
</p>
Dashboard display at startup

<br />
<br />

<p float="left">
    <img src="./Images/Dashboard_Custom.png" alt="Dashboard with fuel at 50%, speed at 100, temperature at 45 and door state open" height=300 width=auto />
</p>
Dashboard with custom inputs


## 5. Status
This project is complete
