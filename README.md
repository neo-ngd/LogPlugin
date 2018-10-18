# LogBackendPlugin
a plugin for neo to integrate with a log backend.
## prepation
set up a backend server based on http protocol.
so you can get a url: http://yourserver:port
## installation
1. clone this repository
2. build using dotnet or visual studio
3. you can got LogBackends.dll and LogBackends/config.json
4. copy LogBackend.dll and LogBackends/config.json into Plugins under neo-cli
5. start neo-cli
now  you can get the consensus logs at your backend server.

## todo
1. add a buffer in Backend, so wont connection every log.
2. long term: consider long connection tcp or http.