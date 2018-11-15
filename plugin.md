# neo插件简介
通用插件类型：LogPlugin, PersistencePlugin, PolicyPlugin, RpcPlugin
自定义插件类型
## 通用plugin
### LogPlugin
实现Log方法，在输出共识log时也会调用此方法，得到日志内容
### PersistencePlugin
实现onPersist方法， 并在接收到新区块时调用，得到区块快照
### PolicyPlugin
实现FilterForMemoryPool方法，可以过滤写入memorypool的交易
实现FilterForBlock可以过滤写入区块的交易，这个只会在作为议长有效
### RpcPlugin
实现OnProcess方法，neo收到rpc时会调用此方法
## 自定义插件
### Akka.Actor
使用akka的tell或者ask调用neo内部的功能， 或者继承Actor并注册到neo内部模块中，需要neo内部修改和支持
### 使用neo的命名空间
可以直接使用neo的命名空间
## 结论
使用akka框架和neo的命名空间可以使用neo的功能，但是目前唯一的问题是插件不能与用户直接交互。
