# README: Cloning and Running the Hotel Booking System

## Introduction

This guide will help you clone a public GitHub repository containing the C# console application to your local computer, compile the project, and run it.

## Prerequisites

- Git installed on your local computer. [Download Git](https://git-scm.com/downloads)
- .NET SDK installed on your local computer. [Download .NET SDK](https://dotnet.microsoft.com/download)

### 1. Clone the Repository

1. Open your terminal or command prompt.
2. Navigate to the directory where you want to clone the repository.
3. Use the following command to clone the repository:

   ```sh
   git clone https://github.com/suhailsheikh/HotelBookingSystem.git
   
4. Navigate into the cloned repository directory:

   ```sh
   cd HotelBookingSystem

## Compiling the Application

1. Ensure you are in the root directory of the cloned repository.
2. Open the project in Visual Studio. Right-click the solution and click on **"Build Solution"**. Alternatively, run the following command to restore the dependencies and compile the application:

   ```sh
   dotnet build

## Running the Application

1. Once the build is successful, enter the following command: `cd HotelBookingSystem` **(The file path should read: C:\HotelBookingSystem\HotelBookingSystem)**
2. Run the application using the following command:

   ```sh
   dotnet run

Alternatively, run **HotelBookingSystem.exe** from `bin/Debug/net8.0`

When you run the application, you will be presented with this screen **(see below)**. Please enter the input command like so:

![image](https://github.com/user-attachments/assets/06bf0837-93c3-46a1-841c-caab43908d47)

## Input Commands

**Here are the input commands you can use:**

- Availability(H1, 20240901, SGL)
- Availability(H1, 20240901-20240903, DBL)
- Search(H1, 365, SGL)
