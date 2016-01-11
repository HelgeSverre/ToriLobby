# Toribash Room commands (Networking)

## SPEC


Joins the spectators


## PING 

As far as I understand, this will ask the server to send you the latest "stuff" about the game state and such, also a way for you to not get timed out.


# SAY <whatever>

The command SAY will say anything proceeding the command to everyone in the room.



# whisper <username> <message>

Will wisper to a user in the room


syntax is:

```
whipser username message
```



the server will display this as such: 

```
WHISPER 19226;19227 *gamerbad: hi
```

Not sure what the numbvers are, they are not user ids, night simply be a  packet id" thingy, althought I don't know.







# BOUT Information

```
BOUT 0; 19223 2277 0 4 0 0 KABUYA115 0 1400 877 0 JP 2014-12-05 0
BOUT 1; 19226 10997 0 0 0 0 gamerbad 0 5598 5393 0 NO 2008-03-24 0
BOUT 2; 19200 100 0 0 9 0 DeadKing39 0 33 68 0 0 2016-01-10 0
BOUT 3; 19227 7 0 0 0 0 Willy1804 0 1 6 0 0 2016-01-04 0
BOUT 4; -1 0 0 0 0 END 0
``` 
When connecting to a room, the server will spit some lines at you formated as such:

``` BOUT [SEQUENTIAL_NUMBER]; [NUM] [NUM] [NUM] [NUM] [NUM] [NUM]  [STRING] [NUM]  [NUM]  [NUM]  [NUM]  [STRING] [DATE] [NUM] ```

## Session/User identifier?
The first integer after the semicolon(;), seems to be an identifier of the user in this current room(or possibily globaly), althought the number seems too high to be based on the "you are the X person playing right now", so it might be an autoincremented ID based on acitve clients or plays per X days or since a server reset?

More research is needed.


## Username

The 7th "column" is a string with the username.

Most likely pulled from the "Country Code" field in the forum profile.


## User Country

The  12th column contains a 2 Char long identifier for the user's country, this is used for the little flag next to the username in-game.


## User Join Date

The date in the next-last column seems to me to be the join date for your username as it is displayed in the forum.

Which seems to be correct after checking the users in the room's stats:

- http://forum.toribash.com/tori_stats.php?username=gamerbad
- http://forum.toribash.com/tori_stats.php?username=DeadKing39
- http://forum.toribash.com/tori_stats.php?username=Willy1804


The rest of the columns are not known at this time.