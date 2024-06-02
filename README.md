# Unity Day-Night Cycle

This Unity script creates a realistic day-night cycle by rotating a directional light to simulate the sun's movement. It includes customizable public variables and events for different times of the day.

## Features

- **Sun Rotation:** Simulates the sun's movement across the sky.
- **Customizable Day Length:** Set the duration of a full day in real-time seconds.
- **Time of Day Events:** Trigger events at sunrise, noon, sunset, and midnight.
- **Debug Time Control:** Adjust the time of day directly in the editor for easy testing.

## Getting Started

### Prerequisites

- Unity 2019.4 or later

### Usage

1. **Attach the Script to a GameObject:**
   - Create an empty GameObject in your scene and attach the `DayNightCycle` script to it.

2. **Assign the Sun:**
   - In the Inspector, assign the directional light (which represents the sun) to the `Sun` field of the script.

3. **Set Events:**
   - Assign any functions you want to trigger at sunrise, noon, sunset, and midnight to the respective events in the Inspector.

4. **Adjust Settings:**
   - Adjust the `Day Length` to set how long a full day should last in real seconds.
   - Set the initial rotation of the sun if needed.

## Script Breakdown

### Public Variables

- `Light sun`: Reference to the directional light representing the sun.
- `float dayLength`: Length of a full day in real seconds.
- `Vector3 sunInitialRotation`: Sun's initial rotation.

### Events

- `UnityEvent onSunrise`: Event triggered at sunrise.
- `UnityEvent onNoon`: Event triggered at noon.
- `UnityEvent onSunset`: Event triggered at sunset.
- `UnityEvent onMidnight`: Event triggered at midnight.

### Debug

- `float timeOfDay`: Debug time (0-24) for testing in the editor.

## Example

Here's a basic example of how to use the script in your Unity project:

1. Create a new empty GameObject and attach the `DayNightCycle` script to it.
2. Assign your directional light (sun) to the script.
3. Customize the day length, sun initial rotation, and events as needed.

This script will rotate the sun to simulate a day-night cycle and invoke events at specific times of the day. Feel free to expand and customize the script as needed.

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.
