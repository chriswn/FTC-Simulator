    #!/bin/bash

# Root directory for the robot-simulator project
root_path="robot-simulator"

# Define the directory structure
declare -A directories=(
  ["Assets"]=""
  ["Scripts"]=""
  ["Scenes"]=""
  ["Prefabs"]=""
  ["Editor"]=""
  ["UI"]=""
  ["Documentation"]=""
  ["Builds"]=""
)

# Create the root folder
mkdir -p "$root_path"

# Create all the directories
for dir in "${!directories[@]}"; do
  mkdir -p "$root_path/$dir"
done

# Create the README.md file with initial content
echo -e "# Robot Simulator Project\n\n## Setup Instructions\n\n- Clone the repo\n- Open the project in Unity\n- Play the game" > "$root_path/README.md"

echo "Directory structure for 'robot-simulator' has been created!"
