# Nakama-Dice-Game-Unity
Multiplayer Dice Game Setup Guide
Welcome to the setup guide for the multiplayer dice game using Nakama server with Docker and Unity. Follow the instructions below to set up the environment and run the game on your local system.

Prerequisites
Before you begin, ensure you have the following installed:

Unity: Version 2022.3.21f1 or higher. Download from Unity's official website.
Docker Desktop: Install Docker Desktop for your operating system from Docker's official website.
Setting Up Nakama Server with Docker
Clone the Repository:

Clone the project repository from GitHub:

bash
Copy code
git clone https://github.com/yourusername/your-repository.git
Navigate to Docker Compose File:

Open a terminal or command prompt and navigate to the root directory of the cloned repository.

Start Docker Containers:

Run the following command to start the Docker containers (Nakama server, CockroachDB, and Prometheus):

bash
Copy code
docker-compose up
This command will pull the necessary Docker images and start the services defined in docker-compose.yml.

Verify Nakama Server:

Open your web browser and go to http://localhost:7350/dashboard to verify that Nakama server is running correctly.

Setting Up Unity Project
Open Unity Project:

Open Unity Hub and add the cloned project folder.

Configure Nakama Connection:

Open the NakamaManager.cs script located in Assets/Scripts/NakamaManager.cs and update the following variables based on your Nakama server configuration:

scheme: Set to "http" (or "https" for SSL/TLS).
host: Set to "localhost" or your Docker host IP/domain name.
port: Set to 7350 or the port configured in your Nakama Docker setup.
serverKey: Set to your Nakama server key (replace "defaultkey").
Build and Run the Unity Project:

Click on File > Build Settings in Unity.
Select your target platform and click Build and Run.
Alternatively, you can test in the Unity Editor by clicking Play.
Gameplay Instructions
Hosting a Game:

Launch the Unity build or Editor.
Click on the "Host Game" button in the game UI to create a new match.
Wait for another player to join the created match.
Joining a Game:

Launch another instance of the Unity build or Editor.
Click on the "Join Game" button and enter the match ID provided by the host.
Start playing the multiplayer dice game!
Additional Notes
Security: Replace defaultkey in NakamaManager.cs with your actual server key for production deployments.
Scaling: For scaling Nakama and CockroachDB in production, consult Nakama's official documentation.
