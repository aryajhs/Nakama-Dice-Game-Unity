<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Multiplayer Dice Game Setup Guide</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            max-width: 800px;
            margin: 0 auto;
            padding: 20px;
            background-color: #f5f5f5;
        }
        h1 {
            color: #333;
            border-bottom: 2px solid #333;
            padding-bottom: 10px;
        }
        h2 {
            color: #666;
            border-bottom: 1px solid #ccc;
            padding-bottom: 5px;
        }
        p {
            color: #444;
        }
        code {
            font-family: Consolas, monospace;
            background-color: #f0f0f0;
            padding: 2px 4px;
            border-radius: 3px;
        }
        pre {
            background-color: #f0f0f0;
            padding: 10px;
            border-radius: 5px;
            overflow-x: auto;
        }
        .command {
            background-color: #e0e0e0;
            padding: 5px 10px;
            margin-bottom: 10px;
            border-radius: 5px;
        }
        .note {
            background-color: #ffffcc;
            padding: 10px;
            border-left: 4px solid #ffeb3b;
            margin-bottom: 20px;
        }
        .highlight {
            background-color: #ffffcc;
            padding: 10px;
            border-left: 4px solid #ffc107;
            margin-bottom: 20px;
        }
    </style>
</head>
<body>
    <h1>Multiplayer Dice Game Setup Guide</h1>
    <p>Welcome to the setup guide for the multiplayer dice game using Nakama server with Docker and Unity. Follow the instructions below to set up the environment and run the game on your local system.</p>

    <h2>Prerequisites</h2>
    <ul>
        <li>Unity: Version X.X.X or higher. Download from <a href="https://unity.com" target="_blank">Unity's official website</a>.</li>
        <li>Docker Desktop: Install Docker Desktop for your operating system from <a href="https://www.docker.com/products/docker-desktop" target="_blank">Docker's official website</a>.</li>
    </ul>

    <h2>Setting Up Nakama Server with Docker</h2>
    <ol>
        <li><strong>Clone the Repository:</strong></li>
        <pre><code>git clone https://github.com/yourusername/your-repository.git</code></pre>

        <li><strong>Navigate to Docker Compose File:</strong></li>
        <pre><code>cd your-repository</code></pre>

        <li><strong>Start Docker Containers:</strong></li>
        <div class="command"><code>docker-compose up</code></div>

        <li><strong>Verify Nakama Server:</strong></li>
        <p>Open your web browser and go to <code>http://localhost:7350/dashboard</code> to verify that Nakama server is running correctly.</p>
    </ol>

    <h2>Setting Up Unity Project</h2>
    <ol>
        <li><strong>Open Unity Project:</strong></li>
        <p>Open Unity Hub and add the cloned project folder.</p>

        <li><strong>Configure Nakama Connection:</strong></li>
        <p>Open the <code>NakamaManager.cs</code> script located in <code>Assets/Scripts/NakamaManager.cs</code> and update the following variables based on your Nakama server configuration:</p>
        <pre><code>// Update Nakama server connection details
const string scheme = "http";
const string host = "localhost";
const int port = 7350;
const string serverKey = "defaultkey";
</code></pre>

        <li><strong>Build and Run the Unity Project:</strong></li>
        <ul>
            <li>Click on <strong>File > Build Settings</strong> in Unity.</li>
            <li>Select your target platform and click <strong>Build and Run</strong>.</li>
            <li>Alternatively, you can test in the Unity Editor by clicking <strong>Play</strong>.</li>
        </ul>
    </ol>

    <h2>Gameplay Instructions</h2>
    <ul>
        <li><strong>Hosting a Game:</strong>
            <ul>
                <li>Launch the Unity build or Editor.</li>
                <li>Click on the "Host Game" button in the game UI to create a new match.</li>
                <li>Wait for another player to join the created match.</li>
            </ul>
        </li>
        <li><strong>Joining a Game:</strong>
            <ul>
                <li>Launch another instance of the Unity build or Editor.</li>
                <li>Click on the "Join Game" button and enter the match ID provided by the host.</li>
                <li>Start playing the multiplayer dice game!</li>
            </ul>
        </li>
    </ul>

    <h2>Additional Notes</h2>
    <ul>
        <li><strong>Security:</strong> Replace <code>defaultkey</code> in <code>NakamaManager.cs</code> with your actual server key for production deployments.</li>
        <li><strong>Scaling:</strong> For scaling Nakama and CockroachDB in production, consult Nakama's official documentation.</li>
    </ul>
</body>
</html>
