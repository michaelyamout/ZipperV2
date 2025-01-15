# AggressorScripts: CyberThulhu => ALIAS

Collection of Alias' to Extend the Functionality of CobaltStrike (Currently Version 4.8)

---

## AggressorScript: Alias

---

### Alias: 'b'

##### 'b' is designed to assist an operator with backing out (exiting) a session or preparing to sleep the session. 

#### Example: 'b'
```sh
[beacon] help b

[beacon] b
```

---

### Alias: 'c'

##### 'c' is designed be a quick trigger "clear" command

#### Example: 'c'
```sh
[beacon] help c

[beacon] c
```

---

### Alias: 'exit'

##### 'exit' is a re-implementation of the original exit, but includes note information on the beacon

#### Example: 'exit'
```sh
[beacon] help exit

[beacon] exit
```

---

### Alias: 'hashes'

##### 'hashes' is designed to run mimikatz "!lsadump::lsa" with one of two options (-inject | -patch)

#### Example: 'hashes'
```sh
[beacon] help hashes

[beacon] hashes
```

---

### Alias: 'hibernate'

##### 'hibernate' is a "one-time" sleep 

#### Example: 'hibernate'
```sh
[beacon] help hibernate

[beacon] hibernate
```

---

### Alias: 'info'

##### 'info' is designed to print current information about the beacon and session

#### Example: 'info'
```sh
[beacon] help info

[beacon] info
```

---

### Alias: 'pipes'

##### 'pipes' is designed to enumerate pipe information

#### Example: 'pipes'
```sh
[beacon] help pipes

[beacon] pipes
```

---

### Alias: 'put'

##### 'put' is designed to be a better upload and allows for files to be touchmatched

#### Example: 'put'
```sh
[beacon] help put

[beacon] put
```

---

### Alias: 's'

##### 's' is designed to set SYSTEM level spawntos (x86/x64)

#### Example: 's'
```sh
[beacon] help s

[beacon] s
```

---

### Alias: 'sa'

##### 'sa' is designed to run a set of initial local enumerate on a host

#### Example: 'sa'
```sh
[beacon] help sa

[beacon] sa
```

---

### Alias: 'sp'

##### 'sp' is designed to automatically set PPID and spawntos (x86/x64) depending on Integrity Level and User Context

#### Example: 'sp'
```sh
[beacon] help sp

[beacon] sp
```

---

### Alias: 'start_log'

##### 'start_log' is designed to redirect output of the terminal to the local attack host

#### Example: 'start_log'
```sh
[beacon] help start_log

[beacon] start_log
```

---

### Alias: 'stop_log'

##### 'stop_log' is designed to stop redirection of output to the terminal and send output back to the beacon console

#### Example: 'stop_log'
```sh
[beacon] help stop_log

[beacon] stop_log
```

---

### Alias: 'touch'

##### 'touch' is a re-implementation of "timestomp" but reverses the order in which you supply the source file and destination file

#### Example: 'touch'
```sh
[beacon] help touch

[beacon] touch
```

---

### Alias: 'u'

##### 'u' is designed to set User Level spawnto (x86/x64). Spawntos change depend on Integrity Level of the User Context

#### Example: 'u'
```sh
[beacon] help u

[beacon] u
```

---