# LogBackendPlugin
a plugin for neo to integrate with a log backend.
## prepation
set up a backend server based on http protocol, follow this [log-backend](https://github.com/KickSeason/log-backend)
so you can get a url: http://backendsrv:port

### build
1. clone this repository
2. build using dotnet or visual studio
3. you can got LogBackends.dll and LogBackends/config.json
### download
you can download release version directly at [releases](https://github.com/KickSeason/neo-plugins/releases)
## configuration
```
{
  "PluginConfiguration": {
    "CacheCount": 256,
    "Backend": "http://47.98.227.225:8080"
    }
}
```
> __CacheCount__:this is how many logs can store in the queue. when more than CacheCount logs are not sent, oldest logs will be abandoned.
> __Backend__: the log-backend you establish to receive logs using http.
## usage
4. copy LogBackend.dll and LogBackends/config.json into *Plugins* under *neo-cli*
5. start *neo-cli*
now  you can get the consensus logs at your backend server.

## todo
1. add a buffer in Backend, so wont connection every log.
2. long term: consider long connection tcp or http.
