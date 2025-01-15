# AggressorScripts: CyberThulhu

Collection of Modular Scripts to be paired with CobaltStrike (Currently Version 4.8)

## AggressorScript: Main

###### "Main" is what an Operator would load into the Scripts Manager on CobaltStrike. This will then load all the other CNAs in this Suite.

#### Example: 'main'
```sh
aggressor> load /opt/cobaltstrike/aggressorscripts_cyberthulhu/aggressorscripts_cyberthulhu_main.cna
```

---

## AggressorScript: Alias

Collection of Alias' to Extend basic Functionalities in CobaltStrike

| ALIAS 		| DESCRIPTION 																	|
|:--------------|:------------------------------------------------------------------------------|
| 'b'			| Alias for "Backing Out" of a session (Sleeping or Exiting)					|
| 'c'			| Quick trigger for "Clearing" beacon queue										|
| 'exit'		| Modified "Built-In" for Beacon Exit											|
| 'hashes'		| Quick Trigger implementation of Mimikatz's "!lsadump:lsa" command				|
| 'hibernate'	| One-time sleep, used when operator is done sending commands, but not exiting	|
| 'info'		| Prints information on current beacon session									|
| 'pipes'		| Enumerates pipes on current beacon session									|
| 'put'			| Better/Quicker implementation of Upload and timestomps uploaded IOC			|
| 's'			| Quick trigger for setting SYSTEM or High Integrity spawntos'					|
| 'sa'			| Runs basic initial enumeration on local target								|
| 'sp'			| Quick trigger for setting PPID and Spawntos'									|
| 'start_log'	| Redirects output from Beacon Console to a Log File (*See 'stop_log')			|
| 'stop_log'	| Redirects output from Log File to Beacon Console (*See 'start_log')			|
| 'touch'		| Re-implementation of "timestomp" except source/destination files are swapped	|
| 'u'			| Quick trigger for setting USER or High Integrity USER spawntos'				|

---

## AggressorScript: Arsenal

Collection of Scripts to be used with Arsenal Kit (Introduced in CobaltStrike v4.5)

| ARSENAL 	| DESCRIPTION 	|
|:----------|:--------------|
|			|				|

---

## AggressorScript: Assemblies

Collection of Assemblies to extend functionality in CobaltStrike.
Assemblies are coded in **C#** (csharp) and will use spawntos' to execute

| ASSEMBLIES 		| DESCRIPTION 	|
|:------------------|:--------------|
| 'arp'				|				|
| 'auditpol'		|				|
| 'checksig'		|				|
| 'chrometab'		|				|
| 'create_process'	|				|
| 'dcom_exec'		|				|
| 'dnsdump'			|				|
| 'dnsfarm'			|				|
| 'dsquery'			|				|
| 'env'				|				|
| 'eventlog'		|				|
| 'hotfixes'		|				|
| 'icacles'			|				|
| 'ipconfig'		|				|
| 'listdrivers'		|				|
| 'lld'				|				|
| 'netstat'			|				|
| 'pagegrab'		|				|
| 'readfile'		|				|
| 'resources'		|				|
| 'taskkill'		|				|
| 'tasklist_svc'	|				|
| 'tasklist_wmi'	|				|
| 'testcreds'		|				|
| 'windowlist'		|				|
| 'wmi_query'		|				|

---

## AggressorScript: BOFs

Collection of Beacon Object Files (BOFs) to extend functionality of CobaltStrike
BOFs are written in **C** and will be executed inside of the Beacon Process. 
**WARNING:** BOFs, if written incorrectly, can kill a Beacon Session.

| BOFS 	| DESCRIPTION 	|
|:------|:--------------|
|		|				|

---

## AggressorScript: FancySuit

Collection of Scripts to _alter_ CobaltStrike's appearance _(Like wearing a suit)_

| FANCYSUIT 	| DESCRIPTION 	|
|:--------------|:--------------|
|				|				|

---

## AggressorScript: Monocle

Collection of Scripts to monitor the CobaltStrike TeamServer, and perform automatic actions when an operator is not logged in or otherwise busy _(The seeing eye)_

| MONOCLE 	 | DESCRIPTION 																										|
|:-----------|:-----------------------------------------------------------------------------------------------------------------|
| Client	 |																													|
| TeamServer |																													|
| TokenWatch | Watches "enabled" sessions for new user logged in at a specified heartbeat, and "token-store steals" their token	|

---

## AggressorScript: Operation Security

Collection of Scripts to protect the Operaterator from executing "Easy to Signature" or "Dangerous" commands _(Protection from yourself)_

| OPSEC 	| DESCRIPTION 	|
|:----------|:--------------|
|			|				|

---

## AggressorScript: PowerShell

Collection of Scripts to extend CobaltStrike's powershell functionality

| POWERSHELL 	| DESCRIPTION 	|
|:--------------|:--------------|
|				|				|

---

## AggressorScript: Tophat

Collection of Scripts to perform other actions behind the scenes when an Operator is actively operating _(It's a cover)_

| TOPHAT		| DESCRIPTION 	|
|:--------------|:--------------|
| Client	 	|				|
| TeamServer	|				|

---

## AggressorScript: WalkingCane

Collection of Scripts to be used for Automation in CobaltStrike _(It's a crutch)_

| WALKINGCANE 	| DESCRIPTION 	|
|:--------------|:--------------|
|				|				|
