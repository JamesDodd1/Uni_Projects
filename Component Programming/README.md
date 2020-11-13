# Component Programming Coursework

A desktop and web application to book holidays for a virtual company's employees.


## Table of Contents
1. [General Info](#1-general-info)
2. [Technologies](#2-technologies)
3. [Setup](#3-Setup)
4. [Features](#4-features)
5. [Status](#5-status)


## 1. General Info
This program contains both a desktop and a web application.  The desktop system has to allow an admin to be able to login, while both allow standard employees to login.  A standard employee is able to request dates to book a holiday, which are validated by checking the booking constraints.  An admin has the ability to accept or reject any booking.


## 2. Technologies
- C# in .NET Framework (ver 16.7.7)
- LINQ


## 3. Setup
1. Download HolidayBooking folder
2. Open the `HolidaySystem.sln` file with the folder
3. To run the system:
    - __Desktop App:__ Select either "Admin System" or "Staff System" from the menu bar then compile
    - __Website:__ Expand the web app project in the Solution Explorer, select a web page, right click and select "View in Browser"

__NOTE:__ The application may not fully work as the database is not longer active


## 4. Features
- Web app using ASP.NET
- Web Service (SOAP)
- Components used to store contraints and sorting algorithms 
- Data stored within database and retrieved using LINQ commands


## 5. Status
This project is complete
