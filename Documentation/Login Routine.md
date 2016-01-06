# Reverse Engineering The Toribash Multiplayer Protocol

## Login Routine

When starting the game, the client presents a login screen with a username and password, which when filled out and the login button pressed sends a regular HTTP request to this address:


URL: www.toribash.com/cp/login.php

GET Params:

- username: Plain text username
- md5password: MD5 Encoded Password Hash


## Server Response

When you send the GET request defined above to the server, you get this response:

### Correct Password

```
PASS
```

The server will also send back the following cookies:

```
Set-Cookie: tb5sessionhash=05e11b44983a51c5809d74f3e8c7821b; path=/; HttpOnly
Set-Cookie: tb5lastvisit=1451757338; expires=Sun, 01-Jan-2017 17:55:38 GMT; path=/
Set-Cookie: tb5lastactivity=0; expires=Sun, 01-Jan-2017 17:55:38 GMT; path=/
```

The cookie names are sort of interesting, the "prefix" tb5 I would assume actually stands for **T**ori**B**ash**5**, however, the "official" version number for the Toribash client as of this writing is only 4.95, but owell.

An additional fact is that the login server is behind CloudFlare, which means you get some additional HTTP Headers that you can safely ignore if you were to write a private server.


#### Example request

Request
```
GET /cp/login.php?username=example&md5password=5f4dcc3b5aa765d61d8327deb882cf99 HTTP/1.1
Host: www.toribash.com
Accept: */*
```

Response
```
HTTP/1.1 200 OK
Date: Sat, 02 Jan 2016 17:55:39 GMT
Content-Type: text/html; charset=ISO-8859-5
Transfer-Encoding: chunked
Connection: keep-alive
X-Powered-By: PHP/5.3.3
Set-Cookie: tb5sessionhash=05e11b44983a51c5809d74f3e8c7821b; path=/; HttpOnly
Set-Cookie: tb5lastvisit=1451757338; expires=Sun, 01-Jan-2017 17:55:38 GMT; path=/
Set-Cookie: tb5lastactivity=0; expires=Sun, 01-Jan-2017 17:55:38 GMT; path=/
Cache-Control: private
Pragma: private
X-UA-Compatible: IE=7

PASS
```
(I stripped out CloudFlare Specific headers in the response)


Another interesting thing is that the server seems to be using a quite outdated version of PHP, namely version 5.3.3(as seen in the ```X-Powered-By``` header).

Not that it usually matters very much except in some edge cases and scenarios, PHP 5.3.3 is a very outdated version of PHP with lot's of [vulnerabilities](https://www.cvedetails.com/version/97802/PHP-PHP-5.3.3.html).


### Incorrect Password

It seems that no "length" validation is done on the password, althought it might be done internally, but the same error message will be returned regardless of if the password is wrong or of an invalid length.

Regardless the response from the server will be:

```
Username or password is incorrect
```

This text will also be displayed in the game client.


#### Example request

Request
```
GET /cp/login.php?username=example&md5password=5f4dcc3b5aa765d61d8327deb882cf99 HTTP/1.1
Host: www.toribash.com
Accept: */*
```

Response 
```
HTTP/1.1 200 OK
Date: Sat, 02 Jan 2016 18:38:57 GMT
Content-Type: text/html; charset=ISO-8859-5
Transfer-Encoding: chunked
Connection: keep-alive
X-Powered-By: PHP/5.3.3
Set-Cookie: tb5sessionhash=338a1291fc021ff223cc5227f95204d3; path=/; HttpOnly
Set-Cookie: tb5lastvisit=1451759937; expires=Sun, 01-Jan-2017 18:38:57 GMT; path=/
Set-Cookie: tb5lastactivity=0; expires=Sun, 01-Jan-2017 18:38:57 GMT; path=/
Cache-Control: private
Pragma: private
X-UA-Compatible: IE=7

Username or password is incorrect
```


## Storing Credentials

Once the user has been logged in, and if you clicked the "Remember me" checkbox (which is checked by default if IIRC), the ToriBash game client will do something rather silly, it will store the username and password in a plain text .dat file in the root of the game folder (```C:\Games\Toribash-x.xx\tb_login.dat```).

The format of the file is as follows:

```
user example
pass password
```

I don't think I need to explain how the data is structured...

If someone were to grab this file from your computer they would have all the information they need to steal your account.

I'd like to see this file go away or get encrypted somehow in future releases of ToriBash.

Either way, if the file exists it will not prompt you to login.



## Post-Login


### Textures
After the client is logged in, it will imidiatly go out and fetch the player textures.

Request
```
GET /cp/textures.php?username=gamerbad HTTP/1.1
Host: content.toribash.com
Accept: */*
Pragma: no-cache
Cache-Control: no-cache
```

Response
```
HTTP/1.1 200 OK
Date: Sat, 02 Jan 2016 18:47:30 GMT
Content-Type: text/html
Transfer-Encoding: chunked
Connection: keep-alive
X-Powered-By: PHP/5.3.3

http://cache.toribash.com/textures/20/543764.tga.zlib?md5=7da5d8ae5ca530193fd121b79ba29d6c custom/gamerbad/l_triceps.tga 7da5d8ae5ca530193fd121b79ba29d6c
http://cache.toribash.com/textures/21/543765.tga.zlib?md5=cb8fb16d8ea008e57813ab2f3275a647 custom/gamerbad/r_triceps.tga cb8fb16d8ea008e57813ab2f3275a647
http://cache.toribash.com/textures/22/543766.tga.zlib?md5=4cf5a1d41fdae16b7e7724430478cc0e custom/gamerbad/r_hand.tga 4cf5a1d41fdae16b7e7724430478cc0e
http://cache.toribash.com/textures/23/543767.tga.zlib?md5=62bcbba9fab9edb024ed3bd702648192 custom/gamerbad/dq.tga 62bcbba9fab9edb024ed3bd702648192
http://cache.toribash.com/textures/24/543768.tga.zlib?md5=5a444ed6341928189452ce981a140aed custom/gamerbad/head.tga 5a444ed6341928189452ce981a140aed
http://cache.toribash.com/textures/25/543769.tga.zlib?md5=8804357d11eb1d74398d378e4f01badb custom/gamerbad/l_hand.tga 8804357d11eb1d74398d378e4f01badb
http://cache.toribash.com/textures/26/543770.tga.zlib?md5=128d6e7bd760ecf3311fb2ccf96f26c6 custom/gamerbad/r_foot.tga 128d6e7bd760ecf3311fb2ccf96f26c6
http://cache.toribash.com/textures/27/543771.tga.zlib?md5=7c1329b3e0fa003d0a5a7aca0e03d7a5 custom/gamerbad/l_foot.tga 7c1329b3e0fa003d0a5a7aca0e03d7a5
http://cache.toribash.com/textures/28/543772.tga.zlib?md5=a10851975e343af22f227a32048abbb9 custom/gamerbad/l_biceps.tga a10851975e343af22f227a32048abbb9
http://cache.toribash.com/textures/29/543773.tga.zlib?md5=c675bebafaf9bf966f78379fa3806832 custom/gamerbad/stomach.tga c675bebafaf9bf966f78379fa3806832
http://cache.toribash.com/textures/30/543774.tga.zlib?md5=3df588d3ef0d62091a03dcb4242a6dcf custom/gamerbad/r_leg.tga 3df588d3ef0d62091a03dcb4242a6dcf
http://cache.toribash.com/textures/31/543775.tga.zlib?md5=f3877c9ec7f90ef3720b866da40e01c4 custom/gamerbad/r_biceps.tga f3877c9ec7f90ef3720b866da40e01c4
http://cache.toribash.com/textures/32/543776.tga.zlib?md5=15029538a0d5b8b1c11d9038188a326e custom/gamerbad/l_leg.tga 15029538a0d5b8b1c11d9038188a326e
http://cache.toribash.com/textures/33/543777.tga.zlib?md5=63607c6057e9bf7f6887cf6d39cd3651 custom/gamerbad/chest.tga 63607c6057e9bf7f6887cf6d39cd3651
http://cache.toribash.com/textures/34/543778.tga.zlib?md5=fef2d92e675767ab4ba984c26d07bb11 custom/gamerbad/l_pecs.tga fef2d92e675767ab4ba984c26d07bb11
http://cache.toribash.com/textures/35/543779.tga.zlib?md5=739b884c9c1f9548ce6fe096b9fa40ed custom/gamerbad/r_pecs.tga 739b884c9c1f9548ce6fe096b9fa40ed
http://cache.toribash.com/textures/36/543780.tga.zlib?md5=afff24e02b018ec7433712311922538f custom/gamerbad/breast.tga afff24e02b018ec7433712311922538f
http://cache.toribash.com/textures/37/543781.tga.zlib?md5=84c2595c7e53b8468bfdfb5b01c26116 custom/gamerbad/l_thigh.tga 84c2595c7e53b8468bfdfb5b01c26116
http://cache.toribash.com/textures/38/543782.tga.zlib?md5=60af9d1ff6c544b32cf372348719b9ad custom/gamerbad/groin.tga 60af9d1ff6c544b32cf372348719b9ad
http://cache.toribash.com/textures/39/543783.tga.zlib?md5=4ad8de915418743cfa75361f86e0e7b1 custom/gamerbad/r_thigh.tga 4ad8de915418743cfa75361f86e0e7b1
http://cache.toribash.com/textures/40/543784.tga.zlib?md5=6e1e6047e8bd55988d0b8ebb33fe2db1 custom/gamerbad/trail_l_arm.tga 6e1e6047e8bd55988d0b8ebb33fe2db1
http://cache.toribash.com/textures/41/543785.tga.zlib?md5=6e1e6047e8bd55988d0b8ebb33fe2db1 custom/gamerbad/trail_r_arm.tga 6e1e6047e8bd55988d0b8ebb33fe2db1
http://cache.toribash.com/textures/42/543786.tga.zlib?md5=343791e4e466019674eb525e1f165504 custom/gamerbad/ground.tga 343791e4e466019674eb525e1f165504
http://cache.toribash.com/textures/262/575750.tga.zlib?md5=a1ad107de7226b4503b6477faa69842a custom/gamerbad/background.tga a1ad107de7226b4503b6477faa69842a
http://cache.toribash.com/textures/441/580025.tga.zlib?md5=232cbd6e7a1732ee492fa5154fc145fb custom/gamerbad/header.tga 232cbd6e7a1732ee492fa5154fc145fb
http://cache.toribash.com/textures/442/580026.tga.zlib?md5=3361f4532e462aa12117b8905048066d custom/gamerbad/logo.tga 3361f4532e462aa12117b8905048066d
http://cache.toribash.com/textures/443/580027.tga.zlib?md5=c0b307e552f9e3cf33875aa9ce19378e custom/gamerbad/splatt1.tga c0b307e552f9e3cf33875aa9ce19378e
# err : 
# err : 
# err : 
```

The links you get in the response are the compressed TGA image files (commonly used for textures in games), followed by a space then the local path where the files should be placed.


This would be the path:
```C:\Games\Toribash-x.xx\custom\[username]\[bodypart].tga```


the 3 last lines containing ```# err :``` I am going to assume are missing, corrupted or nonexisting texture files that I might not have bought or might not have uploaded, I am not entierly sure.




### Items

Request
```
GET /cp/items.php?steam=0&username=gamerbad&me=1 HTTP/1.1
Host: content.toribash.com
Accept: */*
Pragma: no-cache
Cache-Control: no-cache
```

Response
```
HTTP/1.1 200 OK
Date: Sat, 02 Jan 2016 18:47:30 GMT
Content-Type: text/html
Transfer-Encoding: chunked
Connection: keep-alive
X-Powered-By: PHP/5.3.3

#gamerbad 59538
TEXT 0;0 0 0 0 0 0 
ITEM 0;32 50 32 50 0 87 1 32 0 0 0 32 0 32 32 0 0 0 0 0 0
BODCOL 0;0 0 1 0 2 0 3 0 4 0 5 0 6 0 7 0 8 0 9 0 10 0 11 0 12 0 13 0 14 0 15 0 16 0 17 0 18 0 19 0 20 0
GRADCOL1 0;0 0 1 0 2 0 3 0 4 0 5 0 6 0 7 0 8 0 9 0 10 0 11 0 12 0 13 0 14 0 15 0 16 0 17 0 18 0 19 0 20 0
GRADCOL2 0;0 0 1 0 2 0 3 0 4 0 5 0 6 0 7 0 8 0 9 0 10 0 11 0 12 0 13 0 14 0 15 0 16 0 17 0 18 0 19 0 20 0
FORCOL 0;0 50 1 50 2 50 3 50 4 50 5 50 6 50 7 50 8 50 9 50 10 50 11 50 12 50 13 50 14 50 15 50 16 50 17 50 18 50 19 50 20 0
RELCOL 0;0 32 1 32 2 32 3 32 4 32 5 32 6 32 7 32 8 32 9 32 10 32 11 32 12 32 13 32 14 32 15 32 16 32 17 32 18 32 19 32 20 0
REPCOL 0;0 50 1 50 2 50 3 50 4 50 5 50 6 50 7 50 8 50 9 50 10 50 11 50 12 50 13 50 14 50 15 50 16 50 17 50 18 50 19 50 20 0
BELTNAME 0;
TRAILCOL 0;0 0 1 0 2 0 3 0
TEXBODY 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 1 1 0 0 0 0 0 0
BMAPBODY 0; 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
TEXJOINT 0; 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
BMAPJOINT 0; 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
TEXTRAIL 0; 0 0 1 1
TEXGROUND 0; 0
FLAME0 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
FLAME1 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
FLAME2 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
FLAME3 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
FLAME4 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR0 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR1 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR2 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR3 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR4 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR5 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR6 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR7 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR8 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR9 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR10 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR11 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR12 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR13 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR14 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
HAIR15 0; 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0
OBJ0 0; 0 0 0 0 0 0 0
OBJ1 0; 0 0 0 0 0 0 0
OBJ2 0; 0 0 0 0 0 0 0
OBJ3 0; 0 0 0 0 0 0 0
OBJ4 0; 0 0 0 0 0 0 0
OBJ5 0; 0 0 0 0 0 0 0
OBJ6 0; 0 0 0 0 0 0 0
OBJ7 0; 0 0 0 0 0 0 0
OBJ8 0; 0 0 0 0 0 0 0
OBJ9 0; 0 0 0 0 0 0 0
OBJ10 0; 0 0 0 0 0 0 0
OBJ11 0; 0 0 0 0 0 0 0
OBJ12 0; 0 0 0 0 0 0 0
OBJ13 0; 0 0 0 0 0 0 0
OBJ14 0; 0 0 0 0 0 0 0
OBJ15 0; 0 0 0 0 0 0 0
OBJ16 0; 0 0 0 0 0 0 0
OBJ17 0; 0 0 0 0 0 0 0
OBJ18 0; 0 0 0 0 0 0 0
OBJ19 0; 0 0 0 0 0 0 0
OBJ20 0; 0 0 0 0 0 0 0
BELT 0;10997
GENDER 0;0
TC 0;2704 0
```

The first line is the the username prefixed with a hash, then proceeded with a space and the userid, which can be confirmed by visiting my ToriBash forum profile page: http://forum.toribash.com/member.php?u=59538