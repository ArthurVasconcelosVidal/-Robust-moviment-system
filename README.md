##  Movement System Study based on Mario 64

Estudo de movimento baseado no jogo Super Mario 64

###### Recursos:
    
  - **Character Controller:** A movimentação foi feita utilizando o sistema built-in da Unity o Character Controller
  - **Cinemachine:** Implementado o modulo de camera da unity (Cinemachine) com as devidas configurações de camera para o player (Aproximar, afastar e rotacionar ao redor do personagem)
  - **Movimentação relativa a camera:** As direções do player são relativas a posição da camera na tela
  - **Movimentação progressiva:** A movimentação tem progressão customizavel, é possivel alterar o tempo em que o jogador vai da velocidade minima (0%) até a velocidade máxima (100%) utilizando curvas de animação
  - **Sistema de estados:** A movimentação tem estados diferentes (No chão, Em pulo, caindo e na parede)
  - **Sistema de gravidade:** Cada estado implica em uma aplicação diferente para a gravidade do player
  - **Sistema de pulos:** Cada pulo é definido por uma serie de caracteristicas que determinam a intensidade do pulo e a gravidade de cada pulo, além disso a força da gravidade é alterada caso o jogador solte o botão de pulo cedo demais

###### Resources:
    
  - **Character Controller:** The movement was made using Unity built-in system the Character Controller
  - **Cinemachine:** Implemented the Unity camera module (Cinemachine) with the appropriate camera settings for the player (Zoom in, zoom out and rotate around the character)
  - **Motion relative to camera:** The player directions are relative to the position of the camera on the screen
  - **Progressive movement:** Movement has customizable progression, it is possible to change the time in which the player goes from minimum speed (0%) to maximum speed (100%) using animation curves
  - **State system:** The movement has different states (On the ground, Jumping, falling and on the wall)
  - **Gravity system:** Each state implies a different application for player gravity
  - **Jump system:** Each jump is defined by a series of characteristics that determine the intensity of the jump and the gravity of each jump, in addition the force of gravity is changed if the player releases the jump button too soon

## Youtube Video

[![Non Centralized Gravity System](http://img.youtube.com/vi/yQX44U7CVyM/0.jpg)](https://youtu.be/yQX44U7CVyM "Moviment System Study based on Mario games - Click to Watch!")
- Link: https://youtu.be/yQX44U7CVyM
