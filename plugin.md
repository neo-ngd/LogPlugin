#neo插件简介
通用插件类型：LogPlugin, PersistencePlugin, PolicyPlugin, RpcPlugin
自定义插件类型
##LogPlugin
实现Log方法，在输出共识log时也会调用此方法，得到日志内容
## PersistencePlugin
实现onPersist方法， 并在接收到新区块时调用，得到区块快照
## PolicyPlugin
实现FilterForMemoryPool方法，可以过滤写入memorypool的交易
实现FilterForBlock可以过滤写入区块的交易，这个只会在作为议长有效
## RpcPlugin
实现OnProcess方法，neo收到rpc时会调用此方法
## Akka.Actor
所有插件都可以实现OnMessage方法，来根据得到的消息做出不同的响应
发送消息，使用akka的tell或者ask让neo做出动作，但是不能接收用户的指令做出响应
## 使用neo的命名空间
可以直接使用neo的命名空间，但是同样不能接收用户指令。
## 结论
使用akka框架和neo的命名空间可以使用neo的功能，但是目前唯一的问题是插件不能与用户直接交互。