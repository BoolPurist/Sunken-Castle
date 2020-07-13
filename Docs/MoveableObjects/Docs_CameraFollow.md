# class CameraFollow

Summary: Changes constantly the Transform Position of the camera in order to follow the players movement

## attributes

private Transform playerTransform

Summary: position of the player in the scene

public float verzoegerung

Summary: makes the camera slower than the player in order to look "smooth"

public bool allowtoUpdade

Summary: bool to controll the camera when player is dead => if dead => stop movement of camera

## Methods

private void FixedUpdate()

Summary: is casted every few milliseconds, calculates the new position of the camera dependend on the players position
