# Snow Surfer

A technical prototype developed in Unity to demonstrate 2D physics interactions, state-based logic, and input handling. The project focuses on a skiing mechanic where the player navigates down snowy mountains, collects power-ups, and avoids obstacles using a boolean state machine logic.

## 🎮 Key Features & Technical Details

### 1. State-Based Interaction Logic
Instead of simple collisions, the gameplay relies on a logic flow managed by the `PlayerController` script.
* **Boolean State Machine:** The player uses state flags to manage different gameplay modes ("Skiing", "Boosting", "Damaged", "GameOver").
* **Logic Safety:** Ensures the player cannot perform conflicting actions simultaneously and maintains consistent game state.
* **Power-up System:** Tracks active power-ups with a state-driven approach for buff management and duration handling.

### 2. Physics & Movement (PlayerController.cs)
* **Input System Integration:** Utilizes Unity's `UnityEngine.InputSystem` namespace for handling real-time keyboard inputs (`Keyboard.current`).
* **Vector Mathematics:** Movement is calculated using `transform.Translate` and `transform.Rotate` combined with `Time.deltaTime` to ensure frame-rate independent gameplay.
* **Dynamic Speed Handling:** Implemented a boost mechanic that alters the player's velocity state upon triggering specific zones (`OnTriggerEnter2D` vs `OnCollisionEnter2D`).
* **Gravity & Momentum:** Realistic skiing physics with gravity-based acceleration and friction calculations for natural downhill movement.

### 3. Feedback Systems
* **Visual Feedback:** Integrated Particle Systems that trigger programmatically upon power-up collection, obstacle collisions, and boost activation.
* **UI Updates:** Real-time UI text updates using `TMPro` (TextMeshPro) to indicate score, power-up status, and health.
* **Audio Integration:** Dynamic sound effects that respond to gameplay events.

## 🕹️ Controls

* **Left / Right Arrows:** Steer Left / Steer Right
* **Up Arrow:** Accelerate / Boost
* **Objective:** Navigate down the mountain, collect power-ups, avoid obstacles, and achieve the highest score possible.

## 🛠️ Installation & How to Run

1. Clone this repository:
   ```bash
   git clone https://github.com/delioglu22/Unity-2D-Finite-Snow-Surfer-Prototype.git
   ```
2. Open **Unity Hub**.
3. Click **Add** and select the cloned folder.
4. Open the project (Recommended Version: Unity 2021.3 LTS or later).
5. Open the main scene from `Assets/Scenes/` and press **Play**.

---
*This project was developed as a technical study for game development and prototype implementation.*
