# Connecting to a lobby

When you want to connect to a specific lobby 


The first string that is sent to the server is 

```
mlogin gamerbad 5f4dcc3b5aa765d61d8327deb882cf99 0 4a7074688ea4a32cd257f7c672d56365
STAT_GRF 0;TB4.95,Intel(R) HD Graphics 4600,WIN32,REF1,FLD1,SFT1,NORAYTRACER,SUCCESS
TUTORIAL 0;gamerbad 0
VERSION 0;2 4.95
```


the important line here is the "mlogin" line.

it is structured like this:


mlogin [username] [md5 password] 0 [MD5 of Mac Address]


The mac address is lower cased and colon delimited (aa:bb:cc:33:44:55)