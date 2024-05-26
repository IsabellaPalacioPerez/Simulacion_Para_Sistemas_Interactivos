# Documentación de la evidencia evaluativa de la unidad

## Enlace al video en YouTube


## Explicación de la solución
The problem in this unit is to enhance the project to make it more appealing by adding features such as eyes on creatures (using Raycasts), creating disorder in the simulation, wind physics, and various types of joints in objects. The README.md should be in English to reach a global audience.

To solve it, I implemented Raycasting on the camera, so that when it's aimed at the fish and clicked, it hits them. The fish have an animation that changes their color to red for a while and slightly scales up to indicate the impact.

To create disorder, I placed a button below the camera, which, when pressed, makes everything go wild and move all around. Additionally, when the button is hit, it sinks to the ocean floor thanks to a Fixed Joint.

Also, at the bottom, you can see some particles affected by the wind, or in my case, the sea's tide.

Another implementation includes some hanging plants, which use Spring Joints. The giant plant has a Hinge Joint, making it look like a massive chain.
