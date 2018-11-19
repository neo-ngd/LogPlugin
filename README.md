# Monitoring System For Consensus Nodes  

## System Architecture
![system](https://github.com/neo-ngd/LogPlugin/blob/master/log-monitor.png)

This monitoring system is composed with 3 parts:  
[LogPlugin](https://github.com/neo-ngd/LogPlugin.git) is for sending neo-cli's log to LogServer.  
[LogServer](https://github.com/neo-ngd/LogServer) is for persisting logs into files and sending to partners.  
[LogMonitor](https://github.com/neo-ngd/LogMonitor) is the website to view realtime logs.  

## Prepation
set up a backend server based on http protocol, follow [LogServer](https://github.com/neo-ngd/LogServer) and [LogMonitor](https://github.com/neo-ngd/LogMonitor), so you can get a url: http://LogServer:port. (LogMonitor can be in the same server as LogServer)

### Build
1. clone this repository
2. build using dotnet or visual studio
3. you can got LogBackends.dll and LogBackends/config.json

## Configuration
For example
```
{
  "PluginConfiguration": {
    "CacheCount": 256,
    "Backend": "http://LogServer:port"
    }
}
```
> __CacheCount__:this is how many logs can store in the queue. when more than CacheCount logs are not sent, oldest logs will be abandoned.  
> __Backend__: the log-server you establish to receive logs using http.
## Usage
4. copy LogBackend.dll and LogBackends/config.json into *Plugins* under *neo-cli*
5. start *neo-cli*
now  you can get the consensus logs at your log server.
## Trouble Shooting
1. if you cannt start because of exception: **Unable to load DLL 'System.Net.Http.Native': The specified module or one of its dependencies could not be found**.
please check [dotnet core 2.x requisite](https://docs.microsoft.com/en-us/dotnet/core/linux-prerequisites?tabs=netcore2x), specially libcurl3 for ubuntu and libcurl for centos.
## Todo
1. add a buffer in Backend, so wont connection every log.
2. long term: consider long connection tcp or http.
