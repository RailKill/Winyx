# Winyx
A window management tool for Windows 7 and above, designed for large screens to group and arrange windows on your screen for efficient multi-tasking.
Winyx is similar to WindowSpace and Actual Window Manager, but more focused on automated arranging and space management.

More information, screenshots, research paper and compiled .exe can be found here: http://mojo10.synology.me/~lemoney/winyx/

### Current Status
Not entirely complete, but it works. Code is messy but luckily this is still a small project. Needs refactoring.

### System Requirements
Operating System must be Windows 7 or higher, and Microsoft .NET Framework 4.5.

### Features
- Rearrange and group all windows automatically into a specific layout.
- Dock windows into 3 columns with automatic switching and resizing existing windows to fit all to screen.
- Move, resize, show, hide, close, kill and swap a single or group of windows with ease.
- Assign or remove windows to and from a group which can be organized and even renamed.
- Rebindable hotkeys for each and every function.
- An overlay control panel to keep track of windows and allow users who are unfamiliar with hotkeys or simply do not want to use them to perform functions manually with buttons.
- Can be set to run on startup.
- Extremely lightweight with no installation, just extract and run.


# How to Use
The following functionality is described with the default hotkeys which are meant for Windows 7. If you're using another OS, please rebind the hotkeys so that they don't clash with any other existing hotkey.
Hotkeys can be rebound in the Settings menu (look for the Gear icon in the overlay control panel after you run Winyx.exe).
Make sure you run as administrator so it can save the changes without any problems.

**1. MOVING WINDOWS**
Hold Shift + Arrow Keys to move current window in the desired direction.

**2. RESIZING WINDOWS**
Hold Ctrl + Shift + Up/Down to grow or shrink current window.

**3. ARRANGING WINDOWS**
Press Win + A to automatically rearrange windows and add them to existing or new categories.
Press Ctrl + Shift + 1-9 to arrange windows by category. There are 9 categories maximum.

**4. CLOSING WINDOWS**
Press Ctrl + Alt + End to close all windows.
Press Ctrl + Alt + 1-9 to close by category.

**5. TERMINATING WINDOW PROCESSES**
Press Ctrl + Alt + Shift + End to kill all windows.
Press Ctrl + Alt + Shift + 1-9 to kill by category.

**6. ADDING WINDOWS TO CATEGORY**
Press Ctrl + 1-9 to add currently active window to category.

**7. AUTODOCK FUNCTION**
Press Ctrl + Shift + Tab to toggle autodock mode.
While in autodock mode, use the arrow keys to dock windows. Up docks the current window to the middle column, upwards. Down docks the current window to the middle column, downwards. Left docks to the left and right docks to the right.
Holding Alt while pressing arrow keys performs an automatic switch upon docking to the back-most window.

**8. SHOW WINDOWS**
Press Win + G to restore and show all windows.
Press Alt + 1-9 to show windows of a category.

**9. HIDE WINDOWS**
Press Win + H to hide all windows.
Press Alt + Shift + 1-9 to hide windows of a category.

**10. MINIMIZE/MAXIMIZE INTERFACE**
Press Win + W to bring up or minimize the interface.

**11. SWAP MAIN WINDOW**
If the current window is in a category, tap Win + S to swap the current window's position with the main window's position of its category.
