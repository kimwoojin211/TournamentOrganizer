# Tournament Organizer

<div align="center">
<img src="https://github.com/glenbuck503.png" width="25%" height="auto" >
<img src="https://github.com/kimwoojin211.png" width="25%" height="auto" >
<img src="https://github.com/OlgaHi.png" width="25%" height="auto" >
<img src="https://github.com/BrianSturgis.png" width="25%" height="auto" >


</div>
<br>
<br>
<br>

#### 

#### By Glen Buck, Woo Jin Kim, Olha Hizhytska, Brian Sturgis


## Description
Welcome to the Tournament Organizer App! Users will be able to look up tournaments, see outcomes and stats and users that register with the app will have even more access to the tournaments. 



## Setup/Installation Requirements

Repository: https://github.com/kimwoojin211/TournamentOrganizer.Solution
1. In your terminal of choice or [GitHub's Desktop Application](https://desktop.github.com/) , clone the above repository from Github. For further explanation on how to clone this repository, please visit [GitHub's Documentation](https://docs.github.com/en/github/using-git/which-remote-url-should-i-use).
2. Ensure you are running .NET Core SDK by using the command dotnet --version in your terminal. If a version number is not presented, please visit [this download page for .NET 5 and install the applicable software for your OS](https://dotnet.microsoft.com/download/dotnet/5.0). 
3. Once you verify you are running a .NET 5, navigate in your terminal to TournamentOrganizer directory within the TournamentOrganizer.Solution directory you just cloned. Once there, run "dotnet build" in your terminal to build application within directory. 
4. In your terminal, while still in TournamentOrganizer directory, run "dotnet restore."
5. You will require a text or code editor to complete the following steps. [VS Code is recommended](https://code.visualstudio.com/)
6. Make sure to do a dotnet restore.


### _Installation: Database Recreation_

1. Ensure you are running MySQL Server 8 and MySQL WorkBench 8. If you are running windows, use the [Windows Installer ](https://dev.mysql.com/downloads/installer/) for MySQL and follow the instructions provided by the installer. For Macs, visit [MySQL Commuinity Downloads](https://dev.mysql.com/downloads/mysql/) and select macOS from the Operation Systems. This will be a manual installation. If you need additional assistance on this, please visit Epicodus's [Learn How to Program Article](https://www.learnhowtoprogram.com/c-and-net/getting-started-with-c/installing-and-configuring-mysql).
2. Once you verify you have SQL installed, create a file called "appsettings.json" in the root directory TournamentOrganizer.Solution. Paste the following into this file.
```
{
  "AppSettings": {
    "Secret":"[ENTER LONG (15+ CHARS) STRING HERE]"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Warning",
      "System": "Information", 
      "Microsoft": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port={PORT OF SERVER};database=[NAME YOUR DB];uid=root;pwd={PASSWORD OF SERVER};"
  }
}
```
3. In the same folder, create another file called "appsettings.Development.json" Paste the following into this file.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```
4. In your terminal, run "dotnet ef database update"
### _Installation: General Use_

1. Back in your terminal in the  production directory, type "dotnet run." The terminal will present local host routes for you to navigate to in your browser. An example would be "http://localhost:5000." Enter this into a web browser of choice to use this application. Keep the terminal running as it is being used to control the local server.
2. Navigate to the top level directory of the project (TournamentOrganizer.Solution), and then into the TournamentOrganizerClient folder.
3. Like before, create a file called "appsettings.json" and paste the following into this file.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning", 
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```
4. In the same folder, create another file called "appsettings.Development.json" Paste the following into this file.
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  }
}
```
5. Type in "dotnet run" into your terminal.
6. When finished, exit the terminal or use the command "CTRL C"(Windows) or "CMD C"(Mac) to shut down the local server.


##  API Documentation

<details>
<summary>Click here to see full API Documentation</summary>

# Version: 1.0
### <ul><li> **Base URL** </ul></li> 
```
http://localhost/5000 
or 
https://localhost/5001
```
### <ul><li> **HTTP Requests:** </ul></li>
<details>
<summary>Tournaments</summary>

```
GET /api/tournaments
POST /api/tournaments
GET /api/tournaments/{id}
PUT /api/tournaments/{id}
DELETE /api/tournaments/{id}
POST /api/tournaments/{id}/AddUser/{userId}
DELETE /api/tournaments/{id}/DeleteUser/{joinId}

```

### <ul><li>  **URL Parameters** </ul></li>

| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| userId | int | none | false | Return tournaments that user w/ userId# has registered for.| 


### Example Query
```
https://localhost:5000/api/Tournaments/?userId=135
```

### <ul><li> **Sample Response** </ul></li>

```
{
  {
    "tournamentId": 1,
    "name": "Battle of West Coast",
    "organizedBy": "Epi Codus",
    "location": "West Coast",
    "time": "2021-04-20T19:00:00",
    "category": "Game",
    "matches": [
        {
            "matchId": 1,
            "format": "First to 5",
            "category": "Game",
            "score": "1-1",
            "tournamentId": 1,
            "matchUsers": [user1, user2]
        }
    ],
    "tournamentUsers": [
      {
          "tournamentUserId": 1,
          "userId": 1,
          "tournamentId": 1
      },
      {
          "tournamentUserId": 2,
          "userId": 2,
          "tournamentId": 1
      }
    ]
  }
}
```
</details>

<details>
<summary>Matches</summary>

```
GET /api/matches
POST /api/matches
GET /api/matches/{id}
PUT /api/matches/{id}
DELETE /api/matches/{id}
POST /api/matches/{id}/AddUser/{userId}
DELETE /api/matches/{id}/DeleteUser/{joinId}

```
  
### <ul><li>  **URL Parameters** </ul></li>

| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| userId | int | none | false | Return matches that user w/ userId# has registered for.| 


### Example Query
```
https://localhost:5000/api/matches/?userId=135
```

### <ul><li> **Sample Response** </ul></li>

```
{
  "matchId": 235,
  "format": "First to 5",
  "category": "Game",
  "score": "1-1",
  "tournamentId": 1,
  "matchUsers": [
      {
          "matchUserId": 2,
          "userId": 1,
          "matchId": 2
      }
  ]
}
```
</details>

<details>
<summary>Users</summary>

```
GET /api/users
POST /api/users
POST /api/users/authenticate
GET /api/users/{id}
PUT /api/users/{id}
DELETE /api/users/{id}
POST /api/users/{id}/AddUser/{userId}
DELETE /api/users/{id}/DeleteUser/{joinId}

```


### Example Query
```
https://localhost:5000/api/users/2
```

### <ul><li> **Sample Response** </ul></li>

```
{
  "userId": 33,
  "Name": "First Last",
  "Username": "LasttoFirst",
  "Email": "fl@gmail.com",
  "Region": "West NA",
  "Password": "imthebest" 
  "Token": null
}
```
</details>

</details>

## Bugs as of 4/11/2021

- Bracket logic not included
- Font size is not legible on some pages.
- JWT remains active, even if a different user logs on.
- Styling incomplete or broken on some pages.
- Not all pages are routed yet.


## Support and contact details

For contact support, please email  <a href =>Send Email</a>

## Technologies Used

- C# 9
- .NET 5.0.102
- SDK 8.0.19
- Razor
- Bootstrap 4.5
- HTML 5 (CS version)/CSS3
- My SQL 8.0.19/WorkBench 8.0.19
- Entity Framework
- HTML Helper
- Entity Design
- JWT Authentication


### License

333.23.21

Copyright (c) 2021 Tournament Organizer.
```
Woo Jin Kim (kimwoojin211@gmail.com)
Olha Hizhytska (olgainfotech@gmail.com)
Brian Sturgis (sturujisu@gmail.com)
Glen Buck (glenbuck503@gmail.com)
```