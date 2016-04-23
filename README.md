World2D - 2D toolkit for making games with Unity3d

Demo here - http://tinyurl.com/World2D


inheritance model
=======

PlayerCode2D  -> ex: Big-T  
MonsterCode2D -> ex: Goomba  
WeaponCode2D  -> ex: Machete  

Script execution order
=======
-500 WorldCode2D.cs  
-100 PlayerCode2D.cs  
-90  WeaponCode2D.cs  
-80  MonsterCode2D.cs  