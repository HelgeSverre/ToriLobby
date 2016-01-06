# ToriLobby
## A Toribash Server Explorer and Bot Manager

### About

**ToriLobby** is a C# application that communicates with the Toribash multiplayer servers to display information about the game rooms and players within them.

### Features

As of right now, these are the features in ToriLobby:

- Display and sort all Toribash game rooms in a grid view
- Display all players inside each room
- Display the total amount of players on the server
- Display the total amount of lobbies



### Planned Features 

In the future ToriLobby will be extended to allow these features:

- Room creation and basic "enter and spectate" capabilities.
- Mass-mute/kick functions for rooms created with ToriLobby or when Op'd
- Parsing of Color codes in room description
- Display game room information (game mode, game rules etc)
- Chat client functionality
- Logging statistics about game results
- Allow for custom behaviour through LUA scripting.
 

### Motivation and Purpose

The purpose and motivation behind creating this software is to get some real world programming experience with C# and reverse engineering network protocols so I can implement my own clients/bots and programs.

I chose the game Toribash as the game to do this with since I have spent a great deal of time playing it (since 2008), another reason for chosing Toribash for this project is that all of the data being sent back and fourth to the server is actually in plain text, so I don't have to bother with encryption.


### Protocol Documentation

If you want to learn about the Toribash multiplayer protocol and how the game works on a lower level, check out the ```Documentation/``` folder in this repo, it contains various documents explaining various aspects of the protocol.

I don't guarantee these documents to be 100% correct as some educated guesses has been put into it, if you spot a mistake, feel free to create a PR with a fix.



### Contribute

I am not looking for anyone to help me write the code for this application, it's purpose is for me to learn the C# language and the .NET framework.

However, if you have any comments on ways I am doing things feel free to comment & critizise (just don't be a dick about it).

Feature requests and bug reports are always welcome, if create an issue and give as much detail as possible and I will get to it.

