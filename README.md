# Info-Meciuri

## Overview
This is a C# application that manages basketball matches, teams, and player statistics. It allows users to retrieve match details, display team rosters, and view active players in specific matches.

## Features
- **Match Management:** Retrieve matches within a given date range.
- **Score Display:** Show scores for specific matches.
- **Team Roster:** Display players for a selected team.
- **Active Players in a Match:** List active players and their statistics for a particular match.
- **File-Based Persistence:** Data is stored and retrieved from files using repositories.

## Technologies & Architecture
- **Programming Language:** C#
- **IDE:** JetBrains Rider
- **DataBase:** File-based storage for entities like players and active players
- **Architecture:** Layered architecture with the following layers:
  - **Domain Layer:** Defines core entities such as matches, teams, and players.
  - **Repository Layer:** Manages data persistence by reading and writing data from files.
  - **Service Layer:**  Implements business logic to manage player and match data.
  - **UI Layer:** Displays data.

## Installation & Setup
1. Download and install JetBrains Rider.
2. Clone the repository or open the project file directly in Rider.
3.Ensure that the necessary files (e.g., data files) are present in the project directory.
4.Run the application via the main class.
