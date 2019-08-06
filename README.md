# Monitoring System For Consensus Nodes  

## System Architecture
![system](https://github.com/neo-ngd/LogPlugin/blob/master/log-monitor.png)

This monitoring system is composed with 3 parts:  
[LogPlugin](https://github.com/neo-ngd/LogPlugin.git) is for sending neo-cli's log to LogServer.  
[LogServer](https://github.com/neo-ngd/LogServer) is for persisting logs into files.  

## Prepation
set up a backend server based on http protocol, follow [LogServer](https://github.com/neo-ngd/LogServer) , so you can get a url: http://LogServer:port/log. 

### Build
1. clone this repository
2. build using dotnet or visual studio
3. you can got LogPlugin.dll and LogPlugin/config.json
### Download
  download from [Releases](https://github.com/neo-ngd/LogPlugin/releases)
## Configuration
For example
```
{
  "PluginConfiguration": {
    "Name": "ngd@neo.org",
    "Backend": "http://LogServer:port/log"
    }
}
```
> __Name__:this is the name of your node.  
> __Backend__: the LogServer you establish to receive logs using http.
## Usage
4. copy LogPlugin.dll and LogPlugin/config.json into `Plugins` under `neo-cli`
5. start `neo-cli`
now  you can get the consensus logs at your log server.
## Trouble Shooting
1. if you cannt start because of exception: **Unable to load DLL 'System.Net.Http.Native': The specified module or one of its dependencies could not be found**.
please check [dotnet core 2.x requisite](https://docs.microsoft.com/en-us/dotnet/core/linux-prerequisites?tabs=netcore2x), specially libcurl3 for ubuntu and libcurl for centos.
