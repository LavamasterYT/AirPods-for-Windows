So you want to create a template for AppleBluetoothUI? Well here are the instructions.

# Tutorial
## Create .JSON file
First, we need to create a .JSON file to store our settings in. Create a .JSON file and add the following values to it:
```json
{
    "templatename": "ok",
    "usingimage": 0,
    "iconlocation": "Templates/Assets/ag1.mp4",
    "statictext": 0,
    "staticname": "AirPods",
    "buttontext": "text"
}
```
Now to test the template, save it and put the template anywhere you want. Next go into the configurator (BluetoothUI.exe) and select the other radio button. Find the file and open it. All the changes are automatically applied. Now click on the "Test UI" button. You should see the button text change. Congrats, you created your first template! Now we will go over and see what each setting does.
##  templatename
This is the template name. Nothing much.

### usingimage
If the value is set to 0, it uses MediaElement. If it is set to 1, then it uses Image. Basically, if you are using a image for your animation thingy, set it to 1. If you are using a video loop or anything like that, then set it to 0.

### iconlocation
This is where the animation/image is stored. Now this is where it gets weird. Store the animation/image inside the folder where BluetoothUI.exe and the other files are stored. It can be in a folder or whatever but it has to be inside of there. Example, if my animation/image is stored inside my documents folder, putting in C:\Users\test\Documents\animation.mp4 as the value ain't going to work. If my animation/image is stored inside a folder called "animations" or inside the "Templates\Assets" folder in the directory where BluetoothUI.exe and the other files are stored and I put the value as "Templates\Assets\anim.mp4" or "animations\anim.mp4" or whatever the folder is called, then it will work. If you are still confused, please PM me on Reddit (u/LavamasterYT).

### statictext
If you want the device name to always be the same, set this value to 1, else set it to 0. (This will not change the device name)

### staticname
If statictext is set to 1, then this is going to be the name it will default to.

### buttontext
Just changes the done button text.

## Notes
If this doesn't make sense, PM me on reddit (u/LavamasterYT).

You have to have all the values listed. Even if you are not using static text, include a static name.
